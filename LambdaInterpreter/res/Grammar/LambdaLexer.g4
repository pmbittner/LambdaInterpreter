lexer grammar LambdaLexer;

WS: [ \r\n\t]+ -> skip;

LAMBDA: '\\';
IDENTIFIER: [a-zA-Z_] [a-zA-Z_0-9]*;
BRACKET_L: '(';
BRACKET_R: ')';
DOT: '.';
