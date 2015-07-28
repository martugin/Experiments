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

fragment LETTER : [_a-zA-Z‡-ˇ¿-ﬂ];
fragment DIGIT : [0-9];
fragment SPACE :  (' ' | '\t' | '\r' | '\n');
fragment SYMB: ( LETTER | DIGIT | [+-;:,.] | '[' | ']' | '^') ;

STRING : '\'' .*? '\'';
SIGNAL: '{' .*? '}';
COMMENT: '/*' .*? '*/';
BTAG: '@<';
ETAG: '>@';
WS: SPACE+;

PARENT : ([Pp][Aa][Rr][Ee][Nn][Tt] | [–][ŒÓ][ƒ‰][»Ë][“Ú][≈Â][ÀÎ][‹¸]);
CHILDREN : ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn] | [ƒ‰][≈Â][“Ú][»Ë]);
CHILDRENCOND: ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn][Cc][Oo][Nn][Dd] | [ƒ‰][≈Â][“Ú][»Ë][”Û][—Ò][ÀÎ][ŒÓ][¬‚][»Ë][≈Â]);

LPAREN : '(';
RPAREN : ')';
OPER: '=' | '<>' | '<' | '>' | '<=' | '>=';
OR : [Oo][Rr] | [»Ë][ÀÎ][»Ë];
AND: [Aa][Nn][Dd] | [»Ë];
NOT: [Nn][Oo][Tt] | [ÕÌ][≈Â];

IDENT: (LETTER | DIGIT)+;	 
TEXT: '*' | '/' | SYMB+; 	