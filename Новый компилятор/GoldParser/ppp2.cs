enum SymbolConstants : int
{
   /// <c> (EOF) </c>
   SYMBOL_EOF                     = 0,     
   /// <c> (Error) </c>
   SYMBOL_ERROR                   = 1,     
   /// <c> (Whitespace) </c>
   SYMBOL_WHITESPACE              = 2,     
   /// <c> '-' </c>
   SYMBOL_MINUS                   = 3,     
   /// <c> '(' </c>
   SYMBOL_LPARAN                  = 4,     
   /// <c> ')' </c>
   SYMBOL_RPARAN                  = 5,     
   /// <c> '*' </c>
   SYMBOL_TIMES                   = 6,     
   /// <c> ',' </c>
   SYMBOL_COMMA                   = 7,     
   /// <c> '.' </c>
   SYMBOL_DOT                     = 8,     
   /// <c> '..' </c>
   SYMBOL_DOTDOT                  = 9,     
   /// <c> '/' </c>
   SYMBOL_DIV                     = 10,     
   /// <c> ':' </c>
   SYMBOL_COLON                   = 11,     
   /// <c> ':=' </c>
   SYMBOL_COLONEQ                 = 12,     
   /// <c> ';' </c>
   SYMBOL_SEMI                    = 13,     
   /// <c> '[' </c>
   SYMBOL_LBRACKET                = 14,     
   /// <c> ']' </c>
   SYMBOL_RBRACKET                = 15,     
   /// <c> '^' </c>
   SYMBOL_CARET                   = 16,     
   /// <c> '+' </c>
   SYMBOL_PLUS                    = 17,     
   /// <c> '&lt;' </c>
   SYMBOL_LT                      = 18,     
   /// <c> '&lt;=' </c>
   SYMBOL_LTEQ                    = 19,     
   /// <c> '&lt;&gt;' </c>
   SYMBOL_LTGT                    = 20,     
   /// <c> '=' </c>
   SYMBOL_EQ                      = 21,     
   /// <c> '&gt;' </c>
   SYMBOL_GT                      = 22,     
   /// <c> '&gt;=' </c>
   SYMBOL_GTEQ                    = 23,     
   /// <c> AND </c>
   SYMBOL_AND                     = 24,     
   /// <c> ARRAY </c>
   SYMBOL_ARRAY                   = 25,     
   /// <c> BEGIN </c>
   SYMBOL_BEGIN                   = 26,     
   /// <c> CASE </c>
   SYMBOL_CASE                    = 27,     
   /// <c> CharLiteral </c>
   SYMBOL_CHARLITERAL             = 28,     
   /// <c> CONST </c>
   SYMBOL_CONST                   = 29,     
   /// <c> DecLiteral </c>
   SYMBOL_DECLITERAL              = 30,     
   /// <c> DIV </c>
   SYMBOL_DIV2                    = 31,     
   /// <c> DO </c>
   SYMBOL_DO                      = 32,     
   /// <c> DOWNTO </c>
   SYMBOL_DOWNTO                  = 33,     
   /// <c> ELSE </c>
   SYMBOL_ELSE                    = 34,     
   /// <c> END </c>
   SYMBOL_END                     = 35,     
   /// <c> FILE </c>
   SYMBOL_FILE                    = 36,     
   /// <c> FloatLiteral </c>
   SYMBOL_FLOATLITERAL            = 37,     
   /// <c> FOR </c>
   SYMBOL_FOR                     = 38,     
   /// <c> FORWARD </c>
   SYMBOL_FORWARD                 = 39,     
   /// <c> FUNCTION </c>
   SYMBOL_FUNCTION                = 40,     
   /// <c> HexLiteral </c>
   SYMBOL_HEXLITERAL              = 41,     
   /// <c> id </c>
   SYMBOL_ID                      = 42,     
   /// <c> IF </c>
   SYMBOL_IF                      = 43,     
   /// <c> MOD </c>
   SYMBOL_MOD                     = 44,     
   /// <c> NOT </c>
   SYMBOL_NOT                     = 45,     
   /// <c> OF </c>
   SYMBOL_OF                      = 46,     
   /// <c> OR </c>
   SYMBOL_OR                      = 47,     
   /// <c> PROCEDURE </c>
   SYMBOL_PROCEDURE               = 48,     
   /// <c> PROGRAM </c>
   SYMBOL_PROGRAM                 = 49,     
   /// <c> RECORD </c>
   SYMBOL_RECORD                  = 50,     
   /// <c> REPEAT </c>
   SYMBOL_REPEAT                  = 51,     
   /// <c> StringLiteral </c>
   SYMBOL_STRINGLITERAL           = 52,     
   /// <c> THEN </c>
   SYMBOL_THEN                    = 53,     
   /// <c> TO </c>
   SYMBOL_TO                      = 54,     
   /// <c> TYPE </c>
   SYMBOL_TYPE                    = 55,     
   /// <c> UNTIL </c>
   SYMBOL_UNTIL                   = 56,     
   /// <c> VAR </c>
   SYMBOL_VAR                     = 57,     
   /// <c> WHILE </c>
   SYMBOL_WHILE                   = 58,     
   /// <c> &lt;Actuals&gt; </c>
   SYMBOL_ACTUALS                 = 59,     
   /// <c> &lt;Arg&gt; </c>
   SYMBOL_ARG                     = 60,     
   /// <c> &lt;ArgumentList&gt; </c>
   SYMBOL_ARGUMENTLIST            = 61,     
   /// <c> &lt;Arguments&gt; </c>
   SYMBOL_ARGUMENTS               = 62,     
   /// <c> &lt;AssignmentStatement&gt; </c>
   SYMBOL_ASSIGNMENTSTATEMENT     = 63,     
   /// <c> &lt;Case&gt; </c>
   SYMBOL_CASE2                   = 64,     
   /// <c> &lt;CaseList&gt; </c>
   SYMBOL_CASELIST                = 65,     
   /// <c> &lt;CaseStatement&gt; </c>
   SYMBOL_CASESTATEMENT           = 66,     
   /// <c> &lt;CompoundStatement&gt; </c>
   SYMBOL_COMPOUNDSTATEMENT       = 67,     
   /// <c> &lt;constant&gt; </c>
   SYMBOL_CONSTANT                = 68,     
   /// <c> &lt;ConstantDef&gt; </c>
   SYMBOL_CONSTANTDEF             = 69,     
   /// <c> &lt;ConstantDefinitionList&gt; </c>
   SYMBOL_CONSTANTDEFINITIONLIST  = 70,     
   /// <c> &lt;ConstantDefinitions&gt; </c>
   SYMBOL_CONSTANTDEFINITIONS     = 71,     
   /// <c> &lt;ConstantList&gt; </c>
   SYMBOL_CONSTANTLIST            = 72,     
   /// <c> &lt;Declarations&gt; </c>
   SYMBOL_DECLARATIONS            = 73,     
   /// <c> &lt;Dimension&gt; </c>
   SYMBOL_DIMENSION               = 74,     
   /// <c> &lt;DimensionList&gt; </c>
   SYMBOL_DIMENSIONLIST           = 75,     
   /// <c> &lt;Expression&gt; </c>
   SYMBOL_EXPRESSION              = 76,     
   /// <c> &lt;ExpressionList&gt; </c>
   SYMBOL_EXPRESSIONLIST          = 77,     
   /// <c> &lt;Factor&gt; </c>
   SYMBOL_FACTOR                  = 78,     
   /// <c> &lt;Field&gt; </c>
   SYMBOL_FIELD                   = 79,     
   /// <c> &lt;FieldList&gt; </c>
   SYMBOL_FIELDLIST               = 80,     
   /// <c> &lt;ForStatement&gt; </c>
   SYMBOL_FORSTATEMENT            = 81,     
   /// <c> &lt;FunctionCall&gt; </c>
   SYMBOL_FUNCTIONCALL            = 82,     
   /// <c> &lt;FunctionHeader&gt; </c>
   SYMBOL_FUNCTIONHEADER          = 83,     
   /// <c> &lt;IdList&gt; </c>
   SYMBOL_IDLIST                  = 84,     
   /// <c> &lt;IfStatement&gt; </c>
   SYMBOL_IFSTATEMENT             = 85,     
   /// <c> &lt;ProcedureCall&gt; </c>
   SYMBOL_PROCEDURECALL           = 86,     
   /// <c> &lt;ProcedureDec&gt; </c>
   SYMBOL_PROCEDUREDEC            = 87,     
   /// <c> &lt;ProcedureDeclarations&gt; </c>
   SYMBOL_PROCEDUREDECLARATIONS   = 88,     
   /// <c> &lt;ProcedureHeader&gt; </c>
   SYMBOL_PROCEDUREHEADER         = 89,     
   /// <c> &lt;Program&gt; </c>
   SYMBOL_PROGRAM2                = 90,     
   /// <c> &lt;ProgramHeader&gt; </c>
   SYMBOL_PROGRAMHEADER           = 91,     
   /// <c> &lt;RepeatStatement&gt; </c>
   SYMBOL_REPEATSTATEMENT         = 92,     
   /// <c> &lt;SimpleExpression&gt; </c>
   SYMBOL_SIMPLEEXPRESSION        = 93,     
   /// <c> &lt;Statement&gt; </c>
   SYMBOL_STATEMENT               = 94,     
   /// <c> &lt;StatementList&gt; </c>
   SYMBOL_STATEMENTLIST           = 95,     
   /// <c> &lt;Term&gt; </c>
   SYMBOL_TERM                    = 96,     
   /// <c> &lt;TypeDef&gt; </c>
   SYMBOL_TYPEDEF                 = 97,     
   /// <c> &lt;TypeDefinitionList&gt; </c>
   SYMBOL_TYPEDEFINITIONLIST      = 98,     
   /// <c> &lt;TypeDefinitions&gt; </c>
   SYMBOL_TYPEDEFINITIONS         = 99,     
   /// <c> &lt;TypeSpecifier&gt; </c>
   SYMBOL_TYPESPECIFIER           = 100,     
   /// <c> &lt;Variable&gt; </c>
   SYMBOL_VARIABLE                = 101,     
   /// <c> &lt;VariableDec&gt; </c>
   SYMBOL_VARIABLEDEC             = 102,     
   /// <c> &lt;VariableDeclarationList&gt; </c>
   SYMBOL_VARIABLEDECLARATIONLIST = 103,     
   /// <c> &lt;VariableDeclarations&gt; </c>
   SYMBOL_VARIABLEDECLARATIONS    = 104,     
   /// <c> &lt;WhileStatement&gt; </c>
   SYMBOL_WHILESTATEMENT          = 105      
};

enum RuleConstants : int
{
   /// <c> &lt;constant&gt; ::= DecLiteral </c>
   RULE_CONSTANT_DECLITERAL                         = 0,    
   /// <c> &lt;constant&gt; ::= StringLiteral </c>
   RULE_CONSTANT_STRINGLITERAL                      = 1,    
   /// <c> &lt;constant&gt; ::= FloatLiteral </c>
   RULE_CONSTANT_FLOATLITERAL                       = 2,    
   /// <c> &lt;constant&gt; ::= HexLiteral </c>
   RULE_CONSTANT_HEXLITERAL                         = 3,    
   /// <c> &lt;constant&gt; ::= CharLiteral </c>
   RULE_CONSTANT_CHARLITERAL                        = 4,    
   /// <c> &lt;Program&gt; ::= &lt;ProgramHeader&gt; &lt;Declarations&gt; &lt;CompoundStatement&gt; '.' </c>
   RULE_PROGRAM_DOT                                 = 5,    
   /// <c> &lt;ProgramHeader&gt; ::= PROGRAM id ';' </c>
   RULE_PROGRAMHEADER_PROGRAM_ID_SEMI               = 6,    
   /// <c> &lt;ProgramHeader&gt; ::= PROGRAM id '(' &lt;IdList&gt; ')' ';' </c>
   RULE_PROGRAMHEADER_PROGRAM_ID_LPARAN_RPARAN_SEMI = 7,    
   /// <c> &lt;Declarations&gt; ::= &lt;ConstantDefinitions&gt; &lt;TypeDefinitions&gt; &lt;VariableDeclarations&gt; &lt;ProcedureDeclarations&gt; </c>
   RULE_DECLARATIONS                                = 8,    
   /// <c> &lt;ConstantDefinitions&gt; ::= CONST &lt;ConstantDefinitionList&gt; </c>
   RULE_CONSTANTDEFINITIONS_CONST                   = 9,    
   /// <c> &lt;ConstantDefinitions&gt; ::=  </c>
   RULE_CONSTANTDEFINITIONS                         = 10,    
   /// <c> &lt;ConstantDefinitionList&gt; ::= &lt;ConstantDef&gt; </c>
   RULE_CONSTANTDEFINITIONLIST                      = 11,    
   /// <c> &lt;ConstantDefinitionList&gt; ::= &lt;ConstantDef&gt; &lt;ConstantDefinitionList&gt; </c>
   RULE_CONSTANTDEFINITIONLIST2                     = 12,    
   /// <c> &lt;ConstantDef&gt; ::= id '=' &lt;constant&gt; ';' </c>
   RULE_CONSTANTDEF_ID_EQ_SEMI                      = 13,    
   /// <c> &lt;TypeDefinitions&gt; ::= TYPE &lt;TypeDefinitionList&gt; </c>
   RULE_TYPEDEFINITIONS_TYPE                        = 14,    
   /// <c> &lt;TypeDefinitions&gt; ::=  </c>
   RULE_TYPEDEFINITIONS                             = 15,    
   /// <c> &lt;TypeDefinitionList&gt; ::= &lt;TypeDef&gt; </c>
   RULE_TYPEDEFINITIONLIST                          = 16,    
   /// <c> &lt;TypeDefinitionList&gt; ::= &lt;TypeDef&gt; &lt;TypeDefinitionList&gt; </c>
   RULE_TYPEDEFINITIONLIST2                         = 17,    
   /// <c> &lt;TypeDef&gt; ::= id '=' &lt;TypeSpecifier&gt; ';' </c>
   RULE_TYPEDEF_ID_EQ_SEMI                          = 18,    
   /// <c> &lt;VariableDeclarations&gt; ::= VAR &lt;VariableDeclarationList&gt; </c>
   RULE_VARIABLEDECLARATIONS_VAR                    = 19,    
   /// <c> &lt;VariableDeclarations&gt; ::=  </c>
   RULE_VARIABLEDECLARATIONS                        = 20,    
   /// <c> &lt;VariableDeclarationList&gt; ::= &lt;VariableDec&gt; </c>
   RULE_VARIABLEDECLARATIONLIST                     = 21,    
   /// <c> &lt;VariableDeclarationList&gt; ::= &lt;VariableDec&gt; &lt;VariableDeclarationList&gt; </c>
   RULE_VARIABLEDECLARATIONLIST2                    = 22,    
   /// <c> &lt;VariableDec&gt; ::= &lt;IdList&gt; ':' &lt;TypeSpecifier&gt; ';' </c>
   RULE_VARIABLEDEC_COLON_SEMI                      = 23,    
   /// <c> &lt;ProcedureDeclarations&gt; ::= &lt;ProcedureDec&gt; &lt;ProcedureDeclarations&gt; </c>
   RULE_PROCEDUREDECLARATIONS                       = 24,    
   /// <c> &lt;ProcedureDeclarations&gt; ::=  </c>
   RULE_PROCEDUREDECLARATIONS2                      = 25,    
   /// <c> &lt;ProcedureDec&gt; ::= &lt;ProcedureHeader&gt; FORWARD ';' </c>
   RULE_PROCEDUREDEC_FORWARD_SEMI                   = 26,    
   /// <c> &lt;ProcedureDec&gt; ::= &lt;ProcedureHeader&gt; &lt;Declarations&gt; &lt;CompoundStatement&gt; ';' </c>
   RULE_PROCEDUREDEC_SEMI                           = 27,    
   /// <c> &lt;ProcedureDec&gt; ::= &lt;FunctionHeader&gt; FORWARD ';' </c>
   RULE_PROCEDUREDEC_FORWARD_SEMI2                  = 28,    
   /// <c> &lt;ProcedureDec&gt; ::= &lt;FunctionHeader&gt; &lt;Declarations&gt; &lt;CompoundStatement&gt; ';' </c>
   RULE_PROCEDUREDEC_SEMI2                          = 29,    
   /// <c> &lt;ProcedureHeader&gt; ::= PROCEDURE id &lt;Arguments&gt; ';' </c>
   RULE_PROCEDUREHEADER_PROCEDURE_ID_SEMI           = 30,    
   /// <c> &lt;FunctionHeader&gt; ::= FUNCTION id &lt;Arguments&gt; ':' &lt;TypeSpecifier&gt; ';' </c>
   RULE_FUNCTIONHEADER_FUNCTION_ID_COLON_SEMI       = 31,    
   /// <c> &lt;Arguments&gt; ::= '(' &lt;ArgumentList&gt; ')' </c>
   RULE_ARGUMENTS_LPARAN_RPARAN                     = 32,    
   /// <c> &lt;Arguments&gt; ::=  </c>
   RULE_ARGUMENTS                                   = 33,    
   /// <c> &lt;ArgumentList&gt; ::= &lt;Arg&gt; </c>
   RULE_ARGUMENTLIST                                = 34,    
   /// <c> &lt;ArgumentList&gt; ::= &lt;Arg&gt; ';' &lt;ArgumentList&gt; </c>
   RULE_ARGUMENTLIST_SEMI                           = 35,    
   /// <c> &lt;Arg&gt; ::= &lt;IdList&gt; ':' &lt;TypeSpecifier&gt; </c>
   RULE_ARG_COLON                                   = 36,    
   /// <c> &lt;Arg&gt; ::= VAR &lt;IdList&gt; ':' &lt;TypeSpecifier&gt; </c>
   RULE_ARG_VAR_COLON                               = 37,    
   /// <c> &lt;CompoundStatement&gt; ::= BEGIN &lt;StatementList&gt; END </c>
   RULE_COMPOUNDSTATEMENT_BEGIN_END                 = 38,    
   /// <c> &lt;StatementList&gt; ::= &lt;Statement&gt; </c>
   RULE_STATEMENTLIST                               = 39,    
   /// <c> &lt;StatementList&gt; ::= &lt;Statement&gt; ';' &lt;StatementList&gt; </c>
   RULE_STATEMENTLIST_SEMI                          = 40,    
   /// <c> &lt;Statement&gt; ::= &lt;CompoundStatement&gt; </c>
   RULE_STATEMENT                                   = 41,    
   /// <c> &lt;Statement&gt; ::= &lt;AssignmentStatement&gt; </c>
   RULE_STATEMENT2                                  = 42,    
   /// <c> &lt;Statement&gt; ::= &lt;ProcedureCall&gt; </c>
   RULE_STATEMENT3                                  = 43,    
   /// <c> &lt;Statement&gt; ::= &lt;ForStatement&gt; </c>
   RULE_STATEMENT4                                  = 44,    
   /// <c> &lt;Statement&gt; ::= &lt;WhileStatement&gt; </c>
   RULE_STATEMENT5                                  = 45,    
   /// <c> &lt;Statement&gt; ::= &lt;IfStatement&gt; </c>
   RULE_STATEMENT6                                  = 46,    
   /// <c> &lt;Statement&gt; ::= &lt;CaseStatement&gt; </c>
   RULE_STATEMENT7                                  = 47,    
   /// <c> &lt;Statement&gt; ::= &lt;RepeatStatement&gt; </c>
   RULE_STATEMENT8                                  = 48,    
   /// <c> &lt;Statement&gt; ::=  </c>
   RULE_STATEMENT9                                  = 49,    
   /// <c> &lt;AssignmentStatement&gt; ::= &lt;Variable&gt; ':=' &lt;Expression&gt; </c>
   RULE_ASSIGNMENTSTATEMENT_COLONEQ                 = 50,    
   /// <c> &lt;ProcedureCall&gt; ::= id &lt;Actuals&gt; </c>
   RULE_PROCEDURECALL_ID                            = 51,    
   /// <c> &lt;ForStatement&gt; ::= FOR id ':=' &lt;Expression&gt; TO &lt;Expression&gt; DO &lt;Statement&gt; </c>
   RULE_FORSTATEMENT_FOR_ID_COLONEQ_TO_DO           = 52,    
   /// <c> &lt;ForStatement&gt; ::= FOR id ':=' &lt;Expression&gt; DOWNTO &lt;Expression&gt; DO &lt;Statement&gt; </c>
   RULE_FORSTATEMENT_FOR_ID_COLONEQ_DOWNTO_DO       = 53,    
   /// <c> &lt;WhileStatement&gt; ::= WHILE &lt;Expression&gt; DO &lt;Statement&gt; </c>
   RULE_WHILESTATEMENT_WHILE_DO                     = 54,    
   /// <c> &lt;IfStatement&gt; ::= IF &lt;Expression&gt; THEN &lt;Statement&gt; ELSE &lt;Statement&gt; </c>
   RULE_IFSTATEMENT_IF_THEN_ELSE                    = 55,    
   /// <c> &lt;RepeatStatement&gt; ::= REPEAT &lt;StatementList&gt; UNTIL &lt;Expression&gt; </c>
   RULE_REPEATSTATEMENT_REPEAT_UNTIL                = 56,    
   /// <c> &lt;CaseStatement&gt; ::= CASE &lt;Expression&gt; OF &lt;CaseList&gt; END </c>
   RULE_CASESTATEMENT_CASE_OF_END                   = 57,    
   /// <c> &lt;CaseList&gt; ::= &lt;Case&gt; </c>
   RULE_CASELIST                                    = 58,    
   /// <c> &lt;CaseList&gt; ::= &lt;Case&gt; ';' &lt;CaseList&gt; </c>
   RULE_CASELIST_SEMI                               = 59,    
   /// <c> &lt;Case&gt; ::= &lt;ConstantList&gt; ':' &lt;Statement&gt; </c>
   RULE_CASE_COLON                                  = 60,    
   /// <c> &lt;ConstantList&gt; ::= &lt;constant&gt; </c>
   RULE_CONSTANTLIST                                = 61,    
   /// <c> &lt;ConstantList&gt; ::= &lt;constant&gt; ',' &lt;ConstantList&gt; </c>
   RULE_CONSTANTLIST_COMMA                          = 62,    
   /// <c> &lt;Expression&gt; ::= &lt;SimpleExpression&gt; </c>
   RULE_EXPRESSION                                  = 63,    
   /// <c> &lt;Expression&gt; ::= &lt;SimpleExpression&gt; '=' &lt;SimpleExpression&gt; </c>
   RULE_EXPRESSION_EQ                               = 64,    
   /// <c> &lt;Expression&gt; ::= &lt;SimpleExpression&gt; '&lt;&gt;' &lt;SimpleExpression&gt; </c>
   RULE_EXPRESSION_LTGT                             = 65,    
   /// <c> &lt;Expression&gt; ::= &lt;SimpleExpression&gt; '&lt;' &lt;SimpleExpression&gt; </c>
   RULE_EXPRESSION_LT                               = 66,    
   /// <c> &lt;Expression&gt; ::= &lt;SimpleExpression&gt; '&lt;=' &lt;SimpleExpression&gt; </c>
   RULE_EXPRESSION_LTEQ                             = 67,    
   /// <c> &lt;Expression&gt; ::= &lt;SimpleExpression&gt; '&gt;' &lt;SimpleExpression&gt; </c>
   RULE_EXPRESSION_GT                               = 68,    
   /// <c> &lt;Expression&gt; ::= &lt;SimpleExpression&gt; '&gt;=' &lt;SimpleExpression&gt; </c>
   RULE_EXPRESSION_GTEQ                             = 69,    
   /// <c> &lt;SimpleExpression&gt; ::= &lt;Term&gt; </c>
   RULE_SIMPLEEXPRESSION                            = 70,    
   /// <c> &lt;SimpleExpression&gt; ::= &lt;SimpleExpression&gt; '+' &lt;Term&gt; </c>
   RULE_SIMPLEEXPRESSION_PLUS                       = 71,    
   /// <c> &lt;SimpleExpression&gt; ::= &lt;SimpleExpression&gt; '-' &lt;Term&gt; </c>
   RULE_SIMPLEEXPRESSION_MINUS                      = 72,    
   /// <c> &lt;SimpleExpression&gt; ::= &lt;SimpleExpression&gt; OR &lt;Term&gt; </c>
   RULE_SIMPLEEXPRESSION_OR                         = 73,    
   /// <c> &lt;Term&gt; ::= &lt;Factor&gt; </c>
   RULE_TERM                                        = 74,    
   /// <c> &lt;Term&gt; ::= &lt;Term&gt; '*' &lt;Factor&gt; </c>
   RULE_TERM_TIMES                                  = 75,    
   /// <c> &lt;Term&gt; ::= &lt;Term&gt; '/' &lt;Factor&gt; </c>
   RULE_TERM_DIV                                    = 76,    
   /// <c> &lt;Term&gt; ::= &lt;Term&gt; DIV &lt;Factor&gt; </c>
   RULE_TERM_DIV2                                   = 77,    
   /// <c> &lt;Term&gt; ::= &lt;Term&gt; MOD &lt;Factor&gt; </c>
   RULE_TERM_MOD                                    = 78,    
   /// <c> &lt;Term&gt; ::= &lt;Term&gt; AND &lt;Factor&gt; </c>
   RULE_TERM_AND                                    = 79,    
   /// <c> &lt;Factor&gt; ::= '(' &lt;Expression&gt; ')' </c>
   RULE_FACTOR_LPARAN_RPARAN                        = 80,    
   /// <c> &lt;Factor&gt; ::= '+' &lt;Factor&gt; </c>
   RULE_FACTOR_PLUS                                 = 81,    
   /// <c> &lt;Factor&gt; ::= '-' &lt;Factor&gt; </c>
   RULE_FACTOR_MINUS                                = 82,    
   /// <c> &lt;Factor&gt; ::= NOT &lt;Factor&gt; </c>
   RULE_FACTOR_NOT                                  = 83,    
   /// <c> &lt;Factor&gt; ::= &lt;constant&gt; </c>
   RULE_FACTOR                                      = 84,    
   /// <c> &lt;Factor&gt; ::= &lt;Variable&gt; </c>
   RULE_FACTOR2                                     = 85,    
   /// <c> &lt;FunctionCall&gt; ::= id &lt;Actuals&gt; </c>
   RULE_FUNCTIONCALL_ID                             = 86,    
   /// <c> &lt;Actuals&gt; ::= '(' &lt;ExpressionList&gt; ')' </c>
   RULE_ACTUALS_LPARAN_RPARAN                       = 87,    
   /// <c> &lt;Actuals&gt; ::=  </c>
   RULE_ACTUALS                                     = 88,    
   /// <c> &lt;ExpressionList&gt; ::= &lt;Expression&gt; </c>
   RULE_EXPRESSIONLIST                              = 89,    
   /// <c> &lt;ExpressionList&gt; ::= &lt;Expression&gt; ',' &lt;ExpressionList&gt; </c>
   RULE_EXPRESSIONLIST_COMMA                        = 90,    
   /// <c> &lt;Variable&gt; ::= id </c>
   RULE_VARIABLE_ID                                 = 91,    
   /// <c> &lt;Variable&gt; ::= &lt;Variable&gt; '.' id </c>
   RULE_VARIABLE_DOT_ID                             = 92,    
   /// <c> &lt;Variable&gt; ::= &lt;Variable&gt; '^' </c>
   RULE_VARIABLE_CARET                              = 93,    
   /// <c> &lt;Variable&gt; ::= &lt;Variable&gt; '[' &lt;ExpressionList&gt; ']' </c>
   RULE_VARIABLE_LBRACKET_RBRACKET                  = 94,    
   /// <c> &lt;TypeSpecifier&gt; ::= id </c>
   RULE_TYPESPECIFIER_ID                            = 95,    
   /// <c> &lt;TypeSpecifier&gt; ::= '^' &lt;TypeSpecifier&gt; </c>
   RULE_TYPESPECIFIER_CARET                         = 96,    
   /// <c> &lt;TypeSpecifier&gt; ::= '(' &lt;IdList&gt; ')' </c>
   RULE_TYPESPECIFIER_LPARAN_RPARAN                 = 97,    
   /// <c> &lt;TypeSpecifier&gt; ::= &lt;constant&gt; '..' &lt;constant&gt; </c>
   RULE_TYPESPECIFIER_DOTDOT                        = 98,    
   /// <c> &lt;TypeSpecifier&gt; ::= ARRAY '[' &lt;DimensionList&gt; ']' OF &lt;TypeSpecifier&gt; </c>
   RULE_TYPESPECIFIER_ARRAY_LBRACKET_RBRACKET_OF    = 99,    
   /// <c> &lt;TypeSpecifier&gt; ::= RECORD &lt;FieldList&gt; END </c>
   RULE_TYPESPECIFIER_RECORD_END                    = 100,    
   /// <c> &lt;TypeSpecifier&gt; ::= FILE OF &lt;TypeSpecifier&gt; </c>
   RULE_TYPESPECIFIER_FILE_OF                       = 101,    
   /// <c> &lt;DimensionList&gt; ::= &lt;Dimension&gt; </c>
   RULE_DIMENSIONLIST                               = 102,    
   /// <c> &lt;DimensionList&gt; ::= &lt;Dimension&gt; ',' &lt;DimensionList&gt; </c>
   RULE_DIMENSIONLIST_COMMA                         = 103,    
   /// <c> &lt;Dimension&gt; ::= &lt;constant&gt; '..' &lt;constant&gt; </c>
   RULE_DIMENSION_DOTDOT                            = 104,    
   /// <c> &lt;Dimension&gt; ::= id </c>
   RULE_DIMENSION_ID                                = 105,    
   /// <c> &lt;FieldList&gt; ::= &lt;Field&gt; </c>
   RULE_FIELDLIST                                   = 106,    
   /// <c> &lt;FieldList&gt; ::= &lt;Field&gt; ';' &lt;FieldList&gt; </c>
   RULE_FIELDLIST_SEMI                              = 107,    
   /// <c> &lt;Field&gt; ::= &lt;IdList&gt; ':' &lt;TypeSpecifier&gt; </c>
   RULE_FIELD_COLON                                 = 108,    
   /// <c> &lt;IdList&gt; ::= id </c>
   RULE_IDLIST_ID                                   = 109,    
   /// <c> &lt;IdList&gt; ::= id ',' &lt;IdList&gt; </c>
   RULE_IDLIST_ID_COMMA                             = 110     
};
