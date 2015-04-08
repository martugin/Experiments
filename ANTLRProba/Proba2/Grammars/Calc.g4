grammar Calc;

/*
 * Parser Rules
 */
 
prog: expr+ ;
 
expr : expr Op = ( MUL | DIV ) expr   # MulDiv
     | expr Op = ('+'|'-') expr   # AddSub
	 | Op = SIGN '(' expr ')'  # Sign
     | INT                  # int
     | '(' expr ')'         # parens
     ;
 
/*
 * Lexer Rules
 */

SIGN : 'sign';
INT : [0-9]+;
MUL : '*';
DIV : '/';
ADD : '+';
SUB : '-';
WS
    :   (' ' | '\t' | '\r' | '\n') -> channel(HIDDEN)
	    ;