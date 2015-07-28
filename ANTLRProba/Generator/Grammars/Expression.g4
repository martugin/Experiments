grammar Expression;

/* Parser Rules */
expr: element* EOF                #CombinedText;

element : tag                    #ElementTag
			| STRING           #ElementString
			| SIGNAL           #ElementSignal
			| COMMENT       #ElementComment			 
 			| text                  #ElementText;

text: keyword                                       #TextKeyword
        | (IDENT | TEXT | SPACE)              #TextText;

keyword: (PARENT | CHILDREN | CHILDRENCOND | OR | AND | NOT | OPER | LPAREN | RPAREN)   #GetKeyword;

tag : BTAG PARENT WS* BTAG expr ETAG WS* ETAG                            #TagParent
     | BTAG SPACE PARENT WS* BTAG expr ETAG WS* ETAG                 #TagParent
     | BTAG CHILDREN WS* BTAG expr ETAG WS* ETAG                        #TagChildren
	 | BTAG SPACE CHILDREN WS* BTAG expr ETAG WS* ETAG             #TagChildren
	 | BTAG CHILDRENCOND WS* BTAG WS* cond WS* ETAG WS* BTAG expr ETAG WS* ETAG               #TagChildrenCond
	 | BTAG SPACE CHILDRENCOND WS* BTAG WS* cond WS* ETAG WS* BTAG expr ETAG WS* ETAG    #TagChildrenCond
	 | BTAG IDENT WS* ETAG                                                                  #TagIdent
	 | BTAG SPACE IDENT WS* ETAG                                                       #TagIdent;

cond: IDENT OPER WS* IDENT                    #CondSimple
       | IDENT SPACE OPER WS* IDENT        #CondSimple
	   | LPAREN WS* cond WS* RPAREN         #CondParents           	      	
	   | NOT WS* cond                                    #CondNot	
	   | cond WS* OR WS* cond                       #CondOr	   
	   | cond WS* AND WS* cond                    #CondAnd;	   
	   	

/* Lexer Rules */

fragment LETTER : [_a-zA-Z�-��-�];
fragment DIGIT : [0-9];
fragment WS :  (' ' | '\t' | '\r' | '\n');
fragment SYMB: ( LETTER | DIGIT | [+-;:,.] | '[' | ']' | '^') ;

STRING : '\'' .*? '\'';
SIGNAL: '{' .*? '}';
COMMENT: '/*' .*? '*/';
BTAG: '@<';
ETAG: '>@';
SPACE: WS+;

PARENT : ([Pp][Aa][Rr][Ee][Nn][Tt] | [��][��][��][��][��][��][��][��]);
CHILDREN : ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn] | [��][��][��][��]);
CHILDRENCOND: ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn][Cc][Oo][Nn][Dd] | [��][��][��][��][��][��][��][��][��][��][��]);

LPAREN : '(';
RPAREN : ')';
OPER: '==' | '<>' | '<' | '>' | '<=' | '>=';
OR : [Oo][Rr] | [��][��][��];
AND: [Aa][Nn][Dd] | [��];
NOT: [Nn][Oo][Tt] | [��][��];

IDENT: (LETTER | DIGIT)+;	 
TEXT: '*' | '/' | SYMB+; 	