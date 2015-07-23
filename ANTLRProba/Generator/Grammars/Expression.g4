grammar Expression;

/* Parser Rules */
expr: element*                 #CombinedText;

element : tag                    #ElementTag
			| STRING           #ElementString
			| SIGNAL           #ElementSignal
			| COMMENT       #ElementComment
			| TEXT                #ElementText;

tag : BTAG PARENT BTAG expr ETAG ETAG                             #TagParent
	 | BTAG CHILDREN BTAG expr ETAG ETAG                         #TagChildren
	 | BTAG CHILDRENCOND BTAG cond ETAG BTAG expr ETAG ETAG    #TagChildrenCond
	 | BTAG IDENT ETAG	                                                         #TagIdent;
	 	  
cond: IDENT OPER IDENT              #CondSimple
	   | '(' cond ')'                              #CondParents           	
	   | cond OR cond                          #CondOr
	   | cond AND cond                       #CondAnd
	   | NOT cond                               #CondNot;		

/* Lexer Rules */

fragment LETTER : [_a-zA-Z�-��-�];
fragment DIGIT : [0-9];
fragment WS :  (' ' | '\t' | '\r' | '\n');
fragment SYMB: ( LETTER | DIGIT | WS | [+-()<>=;:,.] | '[' | ']' | '^') ;

STRING : '\'' .*? '\'';
SIGNAL: '{' .*? '}';
COMMENT: '/*' .*? '*/';
TEXT: ('*' | '/' | SYMB+); 		 

BTAG: '@' '<';
ETAG: '>' '@';

PARENT : ([Pp][Aa][Rr][Ee][Nn][Tt] | [��][��][��][��][��][��][��][��]);
CHILDREN : ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn] | [��][��][��][��]);
CHILDRENCOND: ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn][Cc][Oo][Nn][Dd] | [��][��][��][��][��][��][��][��][��][��][��]);

OPER: '=' | '<>' | '<' | '>' | '<=' | '>=';
OR : [Oo][Rr] | [��][��][��];
AND: [Aa][Nn][Dd] | [��];
NOT: [Nn][Oo][Tt] | [��][��];

IDENT: (LETTER | DIGIT)+;