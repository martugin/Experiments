grammar Inputs;

/* Parser Rules */
prog : param (';' param)*        #ParamList ;

param : arg ASSIGN constVal                      #ParamConst
		  |	valueType                                        #ParamType
		  | valueType PARAMS '(' classList ')'  #ParamParams ;

valueType : arg			                             #TypeGet
		  | arg SIGNALS '(' signalsList ')'  #TypeSignals		  
		  | identChain IDENT                      #TypeClass ;

classList : identChain (';' identChain)*  #ClassListGet ;

identChain : IDENT ('.' IDENT)*        #IdentChainGet ;

signalsList : argSignal? (';' argSignal)*     #SignalsListGet ;

argSignal : arg                             # ArgSignalArg
			   | DATATYPE SIGNAL  # ArgSignalDataType 	
			   | SIGNAL                    # ArgSignalSignal;
			   
arg : DATATYPE IDENT   #ArgDataType 
      | IDENT                     #ArgIdent ;

constVal : BOOL         #ConstBool	
		| INT 	         #ConstInt
		| STRING     #ConstString 
		| REAL          #ConstReal 
		| DATE         #ConstDate	;
					
/* Lexer Rules */
fragment SYMB : [_a-zA-Zà-ÿÀ-ß];
fragment DIG : [0-9] ;

BOOL : [01];
INT : DIG+;
REAL:  DIG+('.'DIG+)?('e' '-'? DIG+)? 
         | DIG+(','DIG+)?('e' '-'? DIG+)?;		
DATE: '#' DIG+ '.' DIG+ '.' DIG+ ' ' DIG+ ':' DIG+ ':' DIG+ '#' ;
STRING : '\'' .*? '\'';
SIGNAL: '{' .*? '}';
IDENT:  (SYMB | DIG)* SYMB (SYMB | DIG)*;
ASSIGN : '=';

COMMENT: '/*' .*? '*/' -> skip;
WS :  (' ' | '\t' | '\r' | '\n') -> skip;

SIGNALS : [Ss][Ii][Gg][Nn][Aa][Ll][Ss] | [Ññ][Èè][Ãã][Íí][Àà][Ëë][Ûû];
PARAMS : [Pp][Aa][Rr][Aa][Mm][Ee][Tt][Ee][Rr][Ss] | [Ïï][Àà][Ðð][Àà][Ìì][Åå][Òò][Ðð][Ûû] ;

DATATYPE : [Bb][Oo][Oo][Ll] | [Ëë][Îî][Ãã][Èè][×÷] 
				  | [Ii][Nn][Tt] | [Öö][Åå][Ëë][Îî][Åå]
				  | [Rr][Ee][Aa][Ll] | [Ää][Åå][Éé][Ññ][Òò][Ââ]
				  | [Tt][Ii][Mm][Ee] | [Ââ][Ðð][Åå][Ìì][ßÿ]
				  | [Ss][Tt][Rr][Ii][Nn][Gg] | [Ññ][Òò][Ðð][Îî][Êê][Àà]
				  | [Ss][Ee][Gg][Mm][Ee][Nn][Tt][Ss] | [Ññ][Åå][Ãã][Ìì][Åå][Íí][Òò][Ûû] ;
