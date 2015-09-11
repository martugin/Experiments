parser grammar GenParsemes;
options { tokenVocab=GenLexemes; }

fieldGen : element* EOF;

element : text+        #ElementText
            | prog         #ElementProg			
			;

text : SPECIAL                                       #TextSpecial
       | (TSTRING | TSIGNAL | TEXT)    #GetText
	   ; 

prog : voidProg                    #ProgVoid
        | valueProg                  #ProgValue        
		;

valueProg : voidProg SEP expr    #ValueProgComplex
               | expr                       #ValueProgSimple
			   ;

voidProg : voidExpr (SEP voidExpr)* ;

//Выражения без значения
voidExpr : VOID                                                #VoidExprVoid 
              | IDENT SET expr                              #VoidExprVar
              | IF LPAREN ifVoidPars RPAREN                            #VoidExprIf
			  | WHILE LPAREN expr COLON voidProg RPAREN   #VoidExprWhile
			  ;

ifVoidPars : expr COLON voidProg (COLON expr COLON voidProg)* voidProg?;

//Выражения со значением
expr : cons                                              #ExprCons		
		| LPAREN expr RPAREN                 #ExprParen		
		| IF LPAREN ifPars RPAREN                                                         #ExprIf
		| WHILE LPAREN expr COLON valueProg COLON expr RPAREN   #ExprWhile
		| PARENT LPAREN prog RPAREN                                                 #ExprParent  
		| CHILDREN LPAREN valueProg (COLON valueProg)* RPAREN      #ExprChildren
		| IDENT                                                     #ExprIdent		
		| IDENT LPAREN pars RPAREN                  #ExprFun	
		| expr DOT IDENT LPAREN pars RPAREN  #ExprMet	
		| MINUS expr                 #ExprUnary 
		| NOT expr                      #ExprUnary
		| expr OPER5 expr           #ExprOper		
		| expr OPER4 expr           #ExprOper		
		| expr OPER3 expr           #ExprOper		
		| expr OPER2 expr           #ExprOper		
		| expr OPER1 expr            #ExprOper		
		//Ошибки		
		| IDENT LPAREN pars                                #ExprFunParenLost		
		| IDENT LPAREN pars RPAREN RPAREN    #ExprFunParenExtra		
		;

pars : expr (COLON expr)*    #ParamsList
       |                                     #ParamsEmpty              
	   ;

ifPars : expr COLON valueProg (COLON expr COLON valueProg)* valueProg?;

//Константы
cons : INT                      #ConsInt
       | REAL                    #ConsReal 
	   | TIME                    #ConsTime
	   | STRING                #ConsString
	   ;