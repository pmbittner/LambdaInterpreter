parser grammar LambdaParser;

options { tokenVocab=LambdaLexer; }

program: aliases+=aliasDefinition* main aliases+=aliasDefinition*;

main: term END_EXPRESSION;
aliasDefinition: name=IDENTIFIER DEFINE_ALIAS body=term END_EXPRESSION;

term: (variable | function | brackets)*;
function: LAMBDA parameters+=variable+ DOT term;
variable: IDENTIFIER;
brackets: BRACKET_L term BRACKET_R;

