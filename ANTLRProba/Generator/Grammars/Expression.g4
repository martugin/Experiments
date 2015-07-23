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

fragment LETTER : [_a-zA-Z‡-ˇ¿-ﬂ];
fragment DIGIT : [0-9];
fragment WS :  (' ' | '\t' | '\r' | '\n');
fragment SYMB: ( LETTER | DIGIT | WS | [+-()<>=;:,.] | '[' | ']' | '^') ;

STRING : '\'' .*? '\'';
SIGNAL: '{' .*? '}';
COMMENT: '/*' .*? '*/';
TEXT: ('*' | '/' | SYMB+); 		 

BTAG: '@' '<';
ETAG: '>' '@';

PARENT : ([Pp][Aa][Rr][Ee][Nn][Tt] | [–][ŒÓ][ƒ‰][»Ë][“Ú][≈Â][ÀÎ][‹¸]);
CHILDREN : ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn] | [ƒ‰][≈Â][“Ú][»Ë]);
CHILDRENCOND: ([Cc][Hh][Ii][Ll][Dd][Rr][Ee][Nn][Cc][Oo][Nn][Dd] | [ƒ‰][≈Â][“Ú][»Ë][”Û][—Ò][ÀÎ][ŒÓ][¬‚][»Ë][≈Â]);

OPER: '=' | '<>' | '<' | '>' | '<=' | '>=';
OR : [Oo][Rr] | [»Ë][ÀÎ][»Ë];
AND: [Aa][Nn][Dd] | [»Ë];
NOT: [Nn][Oo][Tt] | [ÕÌ][≈Â];

IDENT: (LETTER | DIGIT)+;