lexer grammar LambdaLexer;

WS: [ \t]+ -> skip;
LINEBREAK: [\n\r] -> skip;

IDENTIFIER: [a-zA-Z_] [a-zA-Z_0-9]*;

LAMBDA: '\\';
BRACKET_L: '(';
BRACKET_R: ')';
DOT: '.';
END_EXPRESSION: ';';

DEFINE_ALIAS: ':=';