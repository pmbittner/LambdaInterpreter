parser grammar LambdaParser;

options { tokenVocab=LambdaLexer; }

program: aliases+=alias* main aliases+=alias*;

main: term END_EXPRESSION;
alias: name=IDENTIFIER DEFINE_ALIAS body=term END_EXPRESSION;

term: (variable | function | brackets)*;
function: LAMBDA parameters+=variable+ DOT term;
variable: IDENTIFIER;
brackets: BRACKET_L term BRACKET_R;

