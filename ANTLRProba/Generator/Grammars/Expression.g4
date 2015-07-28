grammar Expression;

/* Parser Rules */
expr: element* EOF                #CombinedText;

element : tag                    #ElementTag
			| STRING           #ElementString
			| SIGNAL           #ElementSignal
			| COMMENT       #ElementComment			 
 			| text                  #ElementText;

text: keyword                                       #TextKeyword
        | (IDENT | TEXT | WS)              #TextText;

keyword: (PARENT | CHILDREN | CHILDRENCOND | OR | AND | NOT | OPER | LPAREN | RPAREN)   #GetKeyword;

tag : BTAG PARENT BATG expr ETAG ETAG                      #TagParent
     | BTAG CHILDREN BATG expr ETAG ETAG                  #TagChildren
	 | BTAG CHILDRENCOND BTAG cond ETAG BATG expr ETAG ETAG           #TagChildrenCond
	 | BTAG IDENT ETAG                                                   #TagIdent;
	 	  
cond: IDENT OPER IDENT             #CondSimple
	   | LPAREN cond RPAREN          #CondParents           	
	   | cond OR cond                        #CondOr
	   | cond AND cond                     #CondAnd
	   | NOT cond                             #CondNot;		

/* Lexer Rules */

fragment LETTER : [_a-zA-Z�-��-�];
fragment DIGIT : [0-9];
fragment SPACE :  (' ' | '\t' | '\r' | '\n');
fragment SYMB: ( LETTER | DIGIT | [+-;:,.] | '[' | ']' | '^') ;

STRING : '\'' .*? '\'';
SIGNAL: '{' .*? '}';
COMMENT: '/*' .*? '*/';
BTAG: '@<';
ETAG: '>@';
WS: SPACE+;

PARENT : ([Pp][Aa][Rr][Ee][Nn][Tt] | [��][��][��][��][��][��][��][��]);
CHILDREN : ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn] | [��][��][��][��]);
CHILDRENCOND: ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn][Cc][Oo][Nn][Dd] | [��][��][��][��][��][��][��][��][��][��][��]);

LPAREN : '(';
RPAREN : ')';
OPER: '=' | '<>' | '<' | '>' | '<=' | '>=';
OR : [Oo][Rr] | [��][��][��];
AND: [Aa][Nn][Dd] | [��];
NOT: [Nn][Oo][Tt] | [��][��];

IDENT: (LETTER | DIGIT)+;	 
TEXT: '*' | '/' | SYMB+; 	