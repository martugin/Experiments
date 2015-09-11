grammar Condition;

/* Parser */

//ƒл€ генерации параметров
tablGen : IDENT props EOF              #TablGenProps
            | IDENT '.' PARENT  EOF    #TablGenParent			                                   
            ;

//ƒл€ генерации подпараметров
subTablGen : CHILDREN props EOF;

props : ('.' prop)*;

prop : CHILDREN                    #PropChildren  
		| COND '(' expr ')'          #PropCond
		//ќшибки
		| COND ('(' ')')?                     #PropCondError
		| COND LPAREN expr             #PropCondParenLost
		| COND '(' expr ')' RPAREN   #PropCondParenExtra
		;

//¬ыражени€ со значением
expr : cons                                #ExprCons		
		| '(' expr ')'                     #ExprParen		
		| IDENT                          #ExprIdent		
		| IDENT '(' pars ')'         #ExprFun		
		| MINUS expr                 #ExprUnary 
		| NOT expr                      #ExprUnary
		| expr OPER5 expr           #ExprOper		
		| expr OPER4 expr           #ExprOper		
		| expr OPER3 expr           #ExprOper		
		| expr OPER2 expr           #ExprOper		
		| expr OPER1 expr            #ExprOper		
		//ќшибки		
		| IDENT LPAREN pars              #ExprFunParenLost		
		| IDENT '(' pars ')' RPAREN    #ExprFunParenExtra		
		;

pars : expr (';' expr)*    #ParamsList
       |                             #ParamsEmpty              
	    ;

// онстанты
cons : INT                      #ConsInt
       | REAL                    #ConsReal 
	   | TIME                    #ConsTime
	   | STRING                #ConsString
	   ;

/* Lexer */

//ѕробелы и комментарии
WS  : [' '\n\r\t] -> skip;
COMMENT : '/*' .*? '*/' -> skip;
LINECOMMENT : '//' .*? '\r'? '\n' -> skip;

// лючевые слова
COND : [Cc][Oo][Nn][Dd][Ii][Tt][Ii][Oo][Nn] | [”у][—с][Ћл][ќо][¬в][»и][≈е];
PARENT : ([Uu][Pp][Tt][Aa][Bb][Ll] | [Ќн][ја][ƒд][“т][ја][Ѕб][Ћл]) ('(' ')')?;
CHILDREN : ([Ss][Uu][Bb][Tt][Aa][Bb][Ll] | [ѕп][ќо][ƒд][“т][ја][Ѕб][Ћл]) ('(' ')')?;

//ќперации
fragment OR : [Oo][Rr] | [»и][Ћл][»и];
fragment AND: [Aa][Nn][Dd] | [»и];
fragment XOR : [Xx][Oo][Rr] | [»и][—с][ к][Ћл][»и][Ћл][»и];
fragment LIKE : [Ll][Ii][Kk][Ee] | [ѕп][ќо][ƒд][ќо][Ѕб][Ќн][ќо];
fragment MOD : [Mm][Oo][Dd];
fragment DIV : [Dd][Ii][Vv];

NOT : [Nn][Oo][Tt] | [Ќн][≈е];
MINUS : '-';

OPER5 : '^';
OPER4 : ('*' | '/' | DIV | MOD);
OPER3 : ('+' | '-' );
OPER2 : ('==' | '<>' | '<' | '>' | '<=' | '>=' | LIKE);
OPER1 : (AND | OR | XOR);

//—имволы
LPAREN : '(';
RPAREN : ')';

// онстанты  и  идентификаторы
fragment DIGIT : [0-9];
fragment LETTER : [_a-zA-Zа-€ј-я];
fragment IDSYMB : (DIGIT | LETTER);

INT : DIGIT+;
REAL : INT ('.' | ',') INT
         | INT (('.' | ',') INT) ? 'e' '-' ? INT
	     ;
TIME : '#' INT '.' INT '.' INT ' '+ INT ':' INT ':' INT '#';

IDENT : IDSYMB* LETTER IDSYMB*;
STRING : '\'' ('\'\'' | ~[\'])*? '\'';