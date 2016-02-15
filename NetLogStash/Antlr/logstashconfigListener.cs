//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Logstashconfig.g4 by ANTLR 4.5.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="LogstashconfigParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.2")]
[System.CLSCompliant(false)]
public interface ILogstashconfigListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.config"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConfig([NotNull] LogstashconfigParser.ConfigContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.config"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConfig([NotNull] LogstashconfigParser.ConfigContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.stage_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStage_declaration([NotNull] LogstashconfigParser.Stage_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.stage_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStage_declaration([NotNull] LogstashconfigParser.Stage_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.stage_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStage_definition([NotNull] LogstashconfigParser.Stage_definitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.stage_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStage_definition([NotNull] LogstashconfigParser.Stage_definitionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.plugin_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPlugin_declaration([NotNull] LogstashconfigParser.Plugin_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.plugin_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPlugin_declaration([NotNull] LogstashconfigParser.Plugin_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.plugin_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPlugin_definition([NotNull] LogstashconfigParser.Plugin_definitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.plugin_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPlugin_definition([NotNull] LogstashconfigParser.Plugin_definitionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.plugin_attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPlugin_attribute([NotNull] LogstashconfigParser.Plugin_attributeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.plugin_attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPlugin_attribute([NotNull] LogstashconfigParser.Plugin_attributeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.plugin_attribute_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPlugin_attribute_value([NotNull] LogstashconfigParser.Plugin_attribute_valueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.plugin_attribute_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPlugin_attribute_value([NotNull] LogstashconfigParser.Plugin_attribute_valueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.stage_condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStage_condition([NotNull] LogstashconfigParser.Stage_conditionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.stage_condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStage_condition([NotNull] LogstashconfigParser.Stage_conditionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.logical_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogical_expression([NotNull] LogstashconfigParser.Logical_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.logical_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogical_expression([NotNull] LogstashconfigParser.Logical_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.negative_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNegative_expression([NotNull] LogstashconfigParser.Negative_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.negative_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNegative_expression([NotNull] LogstashconfigParser.Negative_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.compare_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompare_expression([NotNull] LogstashconfigParser.Compare_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.compare_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompare_expression([NotNull] LogstashconfigParser.Compare_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.in_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIn_expression([NotNull] LogstashconfigParser.In_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.in_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIn_expression([NotNull] LogstashconfigParser.In_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.match_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMatch_expression([NotNull] LogstashconfigParser.Match_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.match_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMatch_expression([NotNull] LogstashconfigParser.Match_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.rvalue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRvalue([NotNull] LogstashconfigParser.RvalueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.rvalue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRvalue([NotNull] LogstashconfigParser.RvalueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.fieldref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldref([NotNull] LogstashconfigParser.FieldrefContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.fieldref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldref([NotNull] LogstashconfigParser.FieldrefContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.fieldref_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldref_element([NotNull] LogstashconfigParser.Fieldref_elementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.fieldref_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldref_element([NotNull] LogstashconfigParser.Fieldref_elementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArray([NotNull] LogstashconfigParser.ArrayContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArray([NotNull] LogstashconfigParser.ArrayContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.array_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArray_element([NotNull] LogstashconfigParser.Array_elementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.array_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArray_element([NotNull] LogstashconfigParser.Array_elementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.hash"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHash([NotNull] LogstashconfigParser.HashContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.hash"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHash([NotNull] LogstashconfigParser.HashContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LogstashconfigParser.hash_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHash_element([NotNull] LogstashconfigParser.Hash_elementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LogstashconfigParser.hash_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHash_element([NotNull] LogstashconfigParser.Hash_elementContext context);
}
