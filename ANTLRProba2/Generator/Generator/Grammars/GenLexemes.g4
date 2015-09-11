lexer grammar GenLexemes;

//����� �� ��������� (DEFAULT_MODE)

TLSQUARE : '['  -> pushMode(EXPRESSION) ;
TRSQUARE : ']'  -> popMode;

//�����
SPECIAL :'\\{' | '\\}' | '\\\'' |'\\/*' | '\\*/' | '\\\\'; 
TSTRING : '\'' .*? '\'';
TSIGNAL: '{' .*? '}';

TCOMMENT : '/*' .*? '*/' -> skip;

TEXT: ~('[' | ']')+?;

//����� ���������
mode EXPRESSION;
LSQUARE : '['  -> pushMode(DEFAULT_MODE) ;
RSQUARE : ']'  -> popMode;

//������� � �����������
WS  : [' '\n\r\t] -> skip;
COMMENT : '/*' .*? '*/' -> skip;
LINECOMMENT : '//' .*? '\r'? '\n' -> skip;

//�������� �����
PARENT : ([Uu][Pp][Tt][Aa][Bb][Ll] | [��][��][��][��][��][��][��]) ('(' ')')?;
CHILDREN : ([Ss][Uu][Bb][Tt][Aa][Bb][Ll] | [��][��][��][��][��][��][��]) ('(' ')')?;

IF : [Ii][Ff] | [��][��][��][��];
WHILE : [Ww][Hh][Ii][Ll][Ee] | [��][��][��][��];
VOID : [Vv][Oo][Ii][Dd] | [��][��][��][��][��][��];

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
SET : '=';
LPAREN : '(';
RPAREN : ')';
COLON : ';';
DOT : '.';
SEP : ':';

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


