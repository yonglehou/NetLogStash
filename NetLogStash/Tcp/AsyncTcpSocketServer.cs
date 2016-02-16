﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetLogStash.Util
{
    public class AsyncTcpSocketServer
    {
        #region Fields

       
        private IBufferManager _bufferManager;
        private TcpListener _listener;
        private readonly ConcurrentDictionary<string, AsyncTcpSocketSession> _sessions = new ConcurrentDictionary<string, AsyncTcpSocketSession>();
        private readonly IAsyncTcpSocketServerMessageDispatcher _dispatcher;
        private readonly AsyncTcpSocketServerConfiguration _configuration;

        private int _state;
        private const int _none = 0;
        private const int _listening = 1;
        private const int _disposed = 5;

        #endregion

        #region Constructors

        public AsyncTcpSocketServer(int listenedPort, IAsyncTcpSocketServerMessageDispatcher dispatcher, AsyncTcpSocketServerConfiguration configuration = null)
            : this(IPAddress.Any, listenedPort, dispatcher, configuration)
        {
        }

        public AsyncTcpSocketServer(IPAddress listenedAddress, int listenedPort, IAsyncTcpSocketServerMessageDispatcher dispatcher, AsyncTcpSocketServerConfiguration configuration = null)
            : this(new IPEndPoint(listenedAddress, listenedPort), dispatcher, configuration)
        {
        }

        public AsyncTcpSocketServer(IPEndPoint listenedEndPoint, IAsyncTcpSocketServerMessageDispatcher dispatcher, AsyncTcpSocketServerConfiguration configuration = null)
        {
            if (listenedEndPoint == null)
                throw new ArgumentNullException("listenedEndPoint");
            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");

            this.ListenedEndPoint = listenedEndPoint;
            _dispatcher = dispatcher;
            _configuration = configuration ?? new AsyncTcpSocketServerConfiguration();

            if (_configuration.FrameBuilder == null)
                throw new InvalidProgramException("The frame handler in configuration cannot be null.");

            Initialize();
        }

        public AsyncTcpSocketServer(
            int listenedPort,
            Func<AsyncTcpSocketSession, byte[], int, int, Task> onSessionDataReceived = null,
            Func<AsyncTcpSocketSession, Task> onSessionStarted = null,
            Func<AsyncTcpSocketSession, Task> onSessionClosed = null,
            AsyncTcpSocketServerConfiguration configuration = null)
            : this(IPAddress.Any, listenedPort, onSessionDataReceived, onSessionStarted, onSessionClosed, configuration)
        {
        }

        public AsyncTcpSocketServer(
            IPAddress listenedAddress, int listenedPort,
            Func<AsyncTcpSocketSession, byte[], int, int, Task> onSessionDataReceived = null,
            Func<AsyncTcpSocketSession, Task> onSessionStarted = null,
            Func<AsyncTcpSocketSession, Task> onSessionClosed = null,
            AsyncTcpSocketServerConfiguration configuration = null)
            : this(new IPEndPoint(listenedAddress, listenedPort), onSessionDataReceived, onSessionStarted, onSessionClosed, configuration)
        {
        }

        public AsyncTcpSocketServer(
            IPEndPoint listenedEndPoint,
            Func<AsyncTcpSocketSession, byte[], int, int, Task> onSessionDataReceived = null,
            Func<AsyncTcpSocketSession, Task> onSessionStarted = null,
            Func<AsyncTcpSocketSession, Task> onSessionClosed = null,
            AsyncTcpSocketServerConfiguration configuration = null)
            : this(listenedEndPoint,
                  new InternalAsyncTcpSocketServerMessageDispatcherImplementation(onSessionDataReceived, onSessionStarted, onSessionClosed),
                  configuration)
        {
        }

        private void Initialize()
        {
            _bufferManager = new GrowingByteBufferManager(_configuration.InitialBufferAllocationCount, _configuration.ReceiveBufferSize);
        }

        #endregion

        #region Properties

        public IPEndPoint ListenedEndPoint { get; private set; }
        public bool IsListening { get { return _state == _listening; } }
        public int SessionCount { get { return _sessions.Count; } }

        #endregion

        #region Server

        public void Listen()
        {
            int origin = Interlocked.CompareExchange(ref _state, _listening, _none);
            if (origin == _disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
            else if (origin != _none)
            {
                throw new InvalidOperationException("This tcp server has already started.");
            }

            try
            {
                _listener = new TcpListener(this.ListenedEndPoint);
                ConfigureListener();

                _listener.Start(_configuration.PendingConnectionBacklog);

                Task.Run(async () =>
                {
                    await Accept();
                })
                .Forget();
            }
            catch (Exception ex) when (!ShouldThrow(ex)) { }
        }

        public void Shutdown()
        {
            if (Interlocked.Exchange(ref _state, _disposed) == _disposed)
            {
                return;
            }

            try
            {
                _listener.Stop();
                _listener = null;

                Task.Run(async () =>
                {
                    try
                    {
                        foreach (var session in _sessions.Values)
                        {
                            await session.Close();
                        }
                    }
                    catch (Exception ex) when (!ShouldThrow(ex)) { }
                })
                .Wait();
            }
            catch (Exception ex) when (!ShouldThrow(ex)) { }
        }

        private void ConfigureListener()
        {
            _listener.AllowNatTraversal(_configuration.AllowNatTraversal);
        }

        public bool Pending()
        {
            if (!IsListening)
                throw new InvalidOperationException("The tcp server is not active.");

            // determine if there are pending connection requests.
            return _listener.Pending();
        }

        private async Task Accept()
        {
            try
            {
                while (IsListening)
                {
                    var tcpClient = await _listener.AcceptTcpClientAsync();
                    Task.Run(async () =>
                    {
                        await Process(tcpClient);
                    })
                    .Forget();
                }
            }
            catch (Exception ex) when (!ShouldThrow(ex)) { }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task Process(TcpClient acceptedTcpClient)
        {
            var session = new AsyncTcpSocketSession(acceptedTcpClient, _configuration, _bufferManager, _dispatcher, this);

            if (_sessions.TryAdd(session.SessionKey, session))
            {
               
                try
                {
                    await session.Start();
                }
                catch (TimeoutException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    AsyncTcpSocketSession throwAway;
                    if (_sessions.TryRemove(session.SessionKey, out throwAway))
                    {
                        //_log.DebugFormat("Close session [{0}].", throwAway);
                    }
                }
            }
        }

        private bool ShouldThrow(Exception ex)
        {
            if (ex is ObjectDisposedException
                || ex is InvalidOperationException
                || ex is SocketException
                || ex is IOException)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Send

        public async Task SendToAsync(string sessionKey, byte[] data)
        {
            await SendToAsync(sessionKey, data, 0, data.Length);
        }

        public async Task SendToAsync(string sessionKey, byte[] data, int offset, int count)
        {
            AsyncTcpSocketSession sessionFound;
            if (_sessions.TryGetValue(sessionKey, out sessionFound))
            {
                await sessionFound.SendAsync(data, offset, count);
            }
            else
            {
                //_log.WarnFormat("Cannot find session [{0}].", sessionKey);
            }
        }

        public async Task SendToAsync(AsyncTcpSocketSession session, byte[] data)
        {
            await SendToAsync(session, data, 0, data.Length);
        }

        public async Task SendToAsync(AsyncTcpSocketSession session, byte[] data, int offset, int count)
        {
            AsyncTcpSocketSession sessionFound;
            if (_sessions.TryGetValue(session.SessionKey, out sessionFound))
            {
                await sessionFound.SendAsync(data, offset, count);
            }
            else
            {
                //_log.WarnFormat("Cannot find session [{0}].", session);
            }
        }

        public async Task BroadcastAsync(byte[] data)
        {
            await BroadcastAsync(data, 0, data.Length);
        }

        public async Task BroadcastAsync(byte[] data, int offset, int count)
        {
            foreach (var session in _sessions.Values)
            {
                await session.SendAsync(data, offset, count);
            }
        }

        #endregion
    }
}
