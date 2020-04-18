parser grammar LambdaParser;

options { tokenVocab=LambdaLexer; }

term: (variable | function | brackets)*;

function: LAMBDA parameters+=variable+ DOT term;
variable: IDENTIFIER;
brackets: BRACKET_L term BRACKET_R;

