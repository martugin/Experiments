grammar Condition;

/* Parser */

//��� ��������� ����������
tablGen : IDENT props EOF              #TablGenProps
            | IDENT '.' PARENT  EOF    #TablGenParent			                                   
            ;

//��� ��������� �������������
subTablGen : CHILDREN props EOF;

props : ('.' prop)*;

prop : CHILDREN                    #PropChildren  
		| COND '(' expr ')'          #PropCond
		//������
		| COND ('(' ')')?                     #PropCondError
		| COND LPAREN expr             #PropCondParenLost
		| COND '(' expr ')' RPAREN   #PropCondParenExtra
		;

//��������� �� ���������
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
		//������		
		| IDENT LPAREN pars              #ExprFunParenLost		
		| IDENT '(' pars ')' RPAREN    #ExprFunParenExtra		
		;

pars : expr (';' expr)*    #ParamsList
       |                             #ParamsEmpty              
	    ;

//���������
cons : INT                      #ConsInt
       | REAL                    #ConsReal 
	   | TIME                    #ConsTime
	   | STRING                #ConsString
	   ;

/* Lexer */

//������� � �����������
WS  : [' '\n\r\t] -> skip;
COMMENT : '/*' .*? '*/' -> skip;
LINECOMMENT : '//' .*? '\r'? '\n' -> skip;

//�������� �����
COND : [Cc][Oo][Nn][Dd][Ii][Tt][Ii][Oo][Nn] | [��][��][��][��][��][��][��];
PARENT : ([Uu][Pp][Tt][Aa][Bb][Ll] | [��][��][��][��][��][��][��]) ('(' ')')?;
CHILDREN : ([Ss][Uu][Bb][Tt][Aa][Bb][Ll] | [��][��][��][��][��][��][��]) ('(' ')')?;

//��������
fragment OR : [Oo][Rr] | [��][��][��];
fragment AND: [Aa][Nn][Dd] | [��];
fragment XOR : [Xx][Oo][Rr] | [��][��][��][��][��][��][��];
fragment LIKE : [Ll][Ii][Kk][Ee] | [��][��][��][��][��][��][��];
fragment MOD : [Mm][Oo][Dd];
fragment DIV : [Dd][Ii][Vv];

NOT : [Nn][Oo][Tt] | [��][��];
MINUS : '-';

OPER5 : '^';
OPER4 : ('*' | '/' | DIV | MOD);
OPER3 : ('+' | '-' );
OPER2 : ('==' | '<>' | '<' | '>' | '<=' | '>=' | LIKE);
OPER1 : (AND | OR | XOR);

//�������
LPAREN : '(';
RPAREN : ')';

//���������  �  ��������������
fragment DIGIT : [0-9];
fragment LETTER : [_a-zA-Z�-��-�];
fragment IDSYMB : (DIGIT | LETTER);

INT : DIGIT+;
REAL : INT ('.' | ',') INT
         | INT (('.' | ',') INT) ? 'e' '-' ? INT
	     ;
TIME : '#' INT '.' INT '.' INT ' '+ INT ':' INT ':' INT '#';

IDENT : IDSYMB* LETTER IDSYMB*;
STRING : '\'' ('\'\'' | ~[\'])*? '\'';