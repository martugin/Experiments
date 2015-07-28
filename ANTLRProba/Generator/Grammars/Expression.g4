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

fragment LETTER : [_a-zA-Z‡-ˇ¿-ﬂ];
fragment DIGIT : [0-9];
fragment WS :  (' ' | '\t' | '\r' | '\n');
fragment SYMB: ( LETTER | DIGIT | [+-;:,.] | '[' | ']' | '^') ;

STRING : '\'' .*? '\'';
SIGNAL: '{' .*? '}';
COMMENT: '/*' .*? '*/';
BTAG: '@<';
ETAG: '>@';
SPACE: WS+;

PARENT : ([Pp][Aa][Rr][Ee][Nn][Tt] | [–][ŒÓ][ƒ‰][»Ë][“Ú][≈Â][ÀÎ][‹¸]);
CHILDREN : ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn] | [ƒ‰][≈Â][“Ú][»Ë]);
CHILDRENCOND: ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn][Cc][Oo][Nn][Dd] | [ƒ‰][≈Â][“Ú][»Ë][”Û][—Ò][ÀÎ][ŒÓ][¬‚][»Ë][≈Â]);

LPAREN : '(';
RPAREN : ')';
OPER: '==' | '<>' | '<' | '>' | '<=' | '>=';
OR : [Oo][Rr] | [»Ë][ÀÎ][»Ë];
AND: [Aa][Nn][Dd] | [»Ë];
NOT: [Nn][Oo][Tt] | [ÕÌ][≈Â];

IDENT: (LETTER | DIGIT)+;	 
TEXT: '*' | '/' | SYMB+; 	