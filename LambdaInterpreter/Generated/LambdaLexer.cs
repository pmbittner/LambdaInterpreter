//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from res/Grammar/LambdaLexer.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Antlr {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class LambdaLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		WS=1, LAMBDA=2, IDENTIFIER=3, BRACKET_L=4, BRACKET_R=5, DOT=6;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"WS", "LAMBDA", "IDENTIFIER", "BRACKET_L", "BRACKET_R", "DOT"
	};


	public LambdaLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public LambdaLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, "'\\'", null, "'('", "')'", "'.'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "WS", "LAMBDA", "IDENTIFIER", "BRACKET_L", "BRACKET_R", "DOT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "LambdaLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static LambdaLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\b', '%', '\b', '\x1', '\x4', '\x2', '\t', '\x2', '\x4', 
		'\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', 
		'\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\x6', 
		'\x2', '\x11', '\n', '\x2', '\r', '\x2', '\xE', '\x2', '\x12', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', 
		'\x4', '\a', '\x4', '\x1B', '\n', '\x4', '\f', '\x4', '\xE', '\x4', '\x1E', 
		'\v', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\a', '\x3', '\a', '\x2', '\x2', '\b', '\x3', '\x3', '\x5', '\x4', '\a', 
		'\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\x3', '\x2', '\x5', '\x5', 
		'\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', '\x5', '\x2', '\x43', '\\', 
		'\x61', '\x61', '\x63', '|', '\x6', '\x2', '\x32', ';', '\x43', '\\', 
		'\x61', '\x61', '\x63', '|', '\x2', '&', '\x2', '\x3', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x3', '\x10', 
		'\x3', '\x2', '\x2', '\x2', '\x5', '\x16', '\x3', '\x2', '\x2', '\x2', 
		'\a', '\x18', '\x3', '\x2', '\x2', '\x2', '\t', '\x1F', '\x3', '\x2', 
		'\x2', '\x2', '\v', '!', '\x3', '\x2', '\x2', '\x2', '\r', '#', '\x3', 
		'\x2', '\x2', '\x2', '\xF', '\x11', '\t', '\x2', '\x2', '\x2', '\x10', 
		'\xF', '\x3', '\x2', '\x2', '\x2', '\x11', '\x12', '\x3', '\x2', '\x2', 
		'\x2', '\x12', '\x10', '\x3', '\x2', '\x2', '\x2', '\x12', '\x13', '\x3', 
		'\x2', '\x2', '\x2', '\x13', '\x14', '\x3', '\x2', '\x2', '\x2', '\x14', 
		'\x15', '\b', '\x2', '\x2', '\x2', '\x15', '\x4', '\x3', '\x2', '\x2', 
		'\x2', '\x16', '\x17', '\a', '^', '\x2', '\x2', '\x17', '\x6', '\x3', 
		'\x2', '\x2', '\x2', '\x18', '\x1C', '\t', '\x3', '\x2', '\x2', '\x19', 
		'\x1B', '\t', '\x4', '\x2', '\x2', '\x1A', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x1B', '\x1E', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x1A', '\x3', 
		'\x2', '\x2', '\x2', '\x1C', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'\b', '\x3', '\x2', '\x2', '\x2', '\x1E', '\x1C', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', ' ', '\a', '*', '\x2', '\x2', ' ', '\n', '\x3', '\x2', 
		'\x2', '\x2', '!', '\"', '\a', '+', '\x2', '\x2', '\"', '\f', '\x3', '\x2', 
		'\x2', '\x2', '#', '$', '\a', '\x30', '\x2', '\x2', '$', '\xE', '\x3', 
		'\x2', '\x2', '\x2', '\x5', '\x2', '\x12', '\x1C', '\x3', '\b', '\x2', 
		'\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Antlr