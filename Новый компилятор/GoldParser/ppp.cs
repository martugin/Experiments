
using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.Generic;

using GoldParser;

namespace Morozov.Parsing
{
		
    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                     =   0, // (EOF)
        SYMBOL_ERROR                   =   1, // (Error)
        SYMBOL_WHITESPACE              =   2, // (Whitespace)
        SYMBOL_MINUS                   =   3, // '-'
        SYMBOL_LPARAN                  =   4, // '('
        SYMBOL_RPARAN                  =   5, // ')'
        SYMBOL_TIMES                   =   6, // '*'
        SYMBOL_COMMA                   =   7, // ','
        SYMBOL_DOT                     =   8, // '.'
        SYMBOL_DOTDOT                  =   9, // '..'
        SYMBOL_DIV                     =  10, // '/'
        SYMBOL_COLON                   =  11, // ':'
        SYMBOL_COLONEQ                 =  12, // ':='
        SYMBOL_SEMI                    =  13, // ';'
        SYMBOL_LBRACKET                =  14, // '['
        SYMBOL_RBRACKET                =  15, // ']'
        SYMBOL_CARET                   =  16, // '^'
        SYMBOL_PLUS                    =  17, // '+'
        SYMBOL_LT                      =  18, // '<'
        SYMBOL_LTEQ                    =  19, // '<='
        SYMBOL_LTGT                    =  20, // '<>'
        SYMBOL_EQ                      =  21, // '='
        SYMBOL_GT                      =  22, // '>'
        SYMBOL_GTEQ                    =  23, // '>='
        SYMBOL_AND                     =  24, // AND
        SYMBOL_ARRAY                   =  25, // ARRAY
        SYMBOL_BEGIN                   =  26, // BEGIN
        SYMBOL_CASE                    =  27, // CASE
        SYMBOL_CHARLITERAL             =  28, // CharLiteral
        SYMBOL_CONST                   =  29, // CONST
        SYMBOL_DECLITERAL              =  30, // DecLiteral
        SYMBOL_DIV2                    =  31, // DIV
        SYMBOL_DO                      =  32, // DO
        SYMBOL_DOWNTO                  =  33, // DOWNTO
        SYMBOL_ELSE                    =  34, // ELSE
        SYMBOL_END                     =  35, // END
        SYMBOL_FILE                    =  36, // FILE
        SYMBOL_FLOATLITERAL            =  37, // FloatLiteral
        SYMBOL_FOR                     =  38, // FOR
        SYMBOL_FORWARD                 =  39, // FORWARD
        SYMBOL_FUNCTION                =  40, // FUNCTION
        SYMBOL_HEXLITERAL              =  41, // HexLiteral
        SYMBOL_ID                      =  42, // id
        SYMBOL_IF                      =  43, // IF
        SYMBOL_MOD                     =  44, // MOD
        SYMBOL_NOT                     =  45, // NOT
        SYMBOL_OF                      =  46, // OF
        SYMBOL_OR                      =  47, // OR
        SYMBOL_PROCEDURE               =  48, // PROCEDURE
        SYMBOL_PROGRAM                 =  49, // PROGRAM
        SYMBOL_RECORD                  =  50, // RECORD
        SYMBOL_REPEAT                  =  51, // REPEAT
        SYMBOL_STRINGLITERAL           =  52, // StringLiteral
        SYMBOL_THEN                    =  53, // THEN
        SYMBOL_TO                      =  54, // TO
        SYMBOL_TYPE                    =  55, // TYPE
        SYMBOL_UNTIL                   =  56, // UNTIL
        SYMBOL_VAR                     =  57, // VAR
        SYMBOL_WHILE                   =  58, // WHILE
        SYMBOL_ACTUALS                 =  59, // <Actuals>
        SYMBOL_ARG                     =  60, // <Arg>
        SYMBOL_ARGUMENTLIST            =  61, // <ArgumentList>
        SYMBOL_ARGUMENTS               =  62, // <Arguments>
        SYMBOL_ASSIGNMENTSTATEMENT     =  63, // <AssignmentStatement>
        SYMBOL_CASE2                   =  64, // <Case>
        SYMBOL_CASELIST                =  65, // <CaseList>
        SYMBOL_CASESTATEMENT           =  66, // <CaseStatement>
        SYMBOL_COMPOUNDSTATEMENT       =  67, // <CompoundStatement>
        SYMBOL_CONSTANT                =  68, // <constant>
        SYMBOL_CONSTANTDEF             =  69, // <ConstantDef>
        SYMBOL_CONSTANTDEFINITIONLIST  =  70, // <ConstantDefinitionList>
        SYMBOL_CONSTANTDEFINITIONS     =  71, // <ConstantDefinitions>
        SYMBOL_CONSTANTLIST            =  72, // <ConstantList>
        SYMBOL_DECLARATIONS            =  73, // <Declarations>
        SYMBOL_DIMENSION               =  74, // <Dimension>
        SYMBOL_DIMENSIONLIST           =  75, // <DimensionList>
        SYMBOL_EXPRESSION              =  76, // <Expression>
        SYMBOL_EXPRESSIONLIST          =  77, // <ExpressionList>
        SYMBOL_FACTOR                  =  78, // <Factor>
        SYMBOL_FIELD                   =  79, // <Field>
        SYMBOL_FIELDLIST               =  80, // <FieldList>
        SYMBOL_FORSTATEMENT            =  81, // <ForStatement>
        SYMBOL_FUNCTIONCALL            =  82, // <FunctionCall>
        SYMBOL_FUNCTIONHEADER          =  83, // <FunctionHeader>
        SYMBOL_IDLIST                  =  84, // <IdList>
        SYMBOL_IFSTATEMENT             =  85, // <IfStatement>
        SYMBOL_PROCEDURECALL           =  86, // <ProcedureCall>
        SYMBOL_PROCEDUREDEC            =  87, // <ProcedureDec>
        SYMBOL_PROCEDUREDECLARATIONS   =  88, // <ProcedureDeclarations>
        SYMBOL_PROCEDUREHEADER         =  89, // <ProcedureHeader>
        SYMBOL_PROGRAM2                =  90, // <Program>
        SYMBOL_PROGRAMHEADER           =  91, // <ProgramHeader>
        SYMBOL_REPEATSTATEMENT         =  92, // <RepeatStatement>
        SYMBOL_SIMPLEEXPRESSION        =  93, // <SimpleExpression>
        SYMBOL_STATEMENT               =  94, // <Statement>
        SYMBOL_STATEMENTLIST           =  95, // <StatementList>
        SYMBOL_TERM                    =  96, // <Term>
        SYMBOL_TYPEDEF                 =  97, // <TypeDef>
        SYMBOL_TYPEDEFINITIONLIST      =  98, // <TypeDefinitionList>
        SYMBOL_TYPEDEFINITIONS         =  99, // <TypeDefinitions>
        SYMBOL_TYPESPECIFIER           = 100, // <TypeSpecifier>
        SYMBOL_VARIABLE                = 101, // <Variable>
        SYMBOL_VARIABLEDEC             = 102, // <VariableDec>
        SYMBOL_VARIABLEDECLARATIONLIST = 103, // <VariableDeclarationList>
        SYMBOL_VARIABLEDECLARATIONS    = 104, // <VariableDeclarations>
        SYMBOL_WHILESTATEMENT          = 105  // <WhileStatement>
    };

    enum RuleConstants : int
    {
        RULE_CONSTANT_DECLITERAL                         =   0, // <constant> ::= DecLiteral
        RULE_CONSTANT_STRINGLITERAL                      =   1, // <constant> ::= StringLiteral
        RULE_CONSTANT_FLOATLITERAL                       =   2, // <constant> ::= FloatLiteral
        RULE_CONSTANT_HEXLITERAL                         =   3, // <constant> ::= HexLiteral
        RULE_CONSTANT_CHARLITERAL                        =   4, // <constant> ::= CharLiteral
        RULE_PROGRAM_DOT                                 =   5, // <Program> ::= <ProgramHeader> <Declarations> <CompoundStatement> '.'
        RULE_PROGRAMHEADER_PROGRAM_ID_SEMI               =   6, // <ProgramHeader> ::= PROGRAM id ';'
        RULE_PROGRAMHEADER_PROGRAM_ID_LPARAN_RPARAN_SEMI =   7, // <ProgramHeader> ::= PROGRAM id '(' <IdList> ')' ';'
        RULE_DECLARATIONS                                =   8, // <Declarations> ::= <ConstantDefinitions> <TypeDefinitions> <VariableDeclarations> <ProcedureDeclarations>
        RULE_CONSTANTDEFINITIONS_CONST                   =   9, // <ConstantDefinitions> ::= CONST <ConstantDefinitionList>
        RULE_CONSTANTDEFINITIONS                         =  10, // <ConstantDefinitions> ::= 
        RULE_CONSTANTDEFINITIONLIST                      =  11, // <ConstantDefinitionList> ::= <ConstantDef>
        RULE_CONSTANTDEFINITIONLIST2                     =  12, // <ConstantDefinitionList> ::= <ConstantDef> <ConstantDefinitionList>
        RULE_CONSTANTDEF_ID_EQ_SEMI                      =  13, // <ConstantDef> ::= id '=' <constant> ';'
        RULE_TYPEDEFINITIONS_TYPE                        =  14, // <TypeDefinitions> ::= TYPE <TypeDefinitionList>
        RULE_TYPEDEFINITIONS                             =  15, // <TypeDefinitions> ::= 
        RULE_TYPEDEFINITIONLIST                          =  16, // <TypeDefinitionList> ::= <TypeDef>
        RULE_TYPEDEFINITIONLIST2                         =  17, // <TypeDefinitionList> ::= <TypeDef> <TypeDefinitionList>
        RULE_TYPEDEF_ID_EQ_SEMI                          =  18, // <TypeDef> ::= id '=' <TypeSpecifier> ';'
        RULE_VARIABLEDECLARATIONS_VAR                    =  19, // <VariableDeclarations> ::= VAR <VariableDeclarationList>
        RULE_VARIABLEDECLARATIONS                        =  20, // <VariableDeclarations> ::= 
        RULE_VARIABLEDECLARATIONLIST                     =  21, // <VariableDeclarationList> ::= <VariableDec>
        RULE_VARIABLEDECLARATIONLIST2                    =  22, // <VariableDeclarationList> ::= <VariableDec> <VariableDeclarationList>
        RULE_VARIABLEDEC_COLON_SEMI                      =  23, // <VariableDec> ::= <IdList> ':' <TypeSpecifier> ';'
        RULE_PROCEDUREDECLARATIONS                       =  24, // <ProcedureDeclarations> ::= <ProcedureDec> <ProcedureDeclarations>
        RULE_PROCEDUREDECLARATIONS2                      =  25, // <ProcedureDeclarations> ::= 
        RULE_PROCEDUREDEC_FORWARD_SEMI                   =  26, // <ProcedureDec> ::= <ProcedureHeader> FORWARD ';'
        RULE_PROCEDUREDEC_SEMI                           =  27, // <ProcedureDec> ::= <ProcedureHeader> <Declarations> <CompoundStatement> ';'
        RULE_PROCEDUREDEC_FORWARD_SEMI2                  =  28, // <ProcedureDec> ::= <FunctionHeader> FORWARD ';'
        RULE_PROCEDUREDEC_SEMI2                          =  29, // <ProcedureDec> ::= <FunctionHeader> <Declarations> <CompoundStatement> ';'
        RULE_PROCEDUREHEADER_PROCEDURE_ID_SEMI           =  30, // <ProcedureHeader> ::= PROCEDURE id <Arguments> ';'
        RULE_FUNCTIONHEADER_FUNCTION_ID_COLON_SEMI       =  31, // <FunctionHeader> ::= FUNCTION id <Arguments> ':' <TypeSpecifier> ';'
        RULE_ARGUMENTS_LPARAN_RPARAN                     =  32, // <Arguments> ::= '(' <ArgumentList> ')'
        RULE_ARGUMENTS                                   =  33, // <Arguments> ::= 
        RULE_ARGUMENTLIST                                =  34, // <ArgumentList> ::= <Arg>
        RULE_ARGUMENTLIST_SEMI                           =  35, // <ArgumentList> ::= <Arg> ';' <ArgumentList>
        RULE_ARG_COLON                                   =  36, // <Arg> ::= <IdList> ':' <TypeSpecifier>
        RULE_ARG_VAR_COLON                               =  37, // <Arg> ::= VAR <IdList> ':' <TypeSpecifier>
        RULE_COMPOUNDSTATEMENT_BEGIN_END                 =  38, // <CompoundStatement> ::= BEGIN <StatementList> END
        RULE_STATEMENTLIST                               =  39, // <StatementList> ::= <Statement>
        RULE_STATEMENTLIST_SEMI                          =  40, // <StatementList> ::= <Statement> ';' <StatementList>
        RULE_STATEMENT                                   =  41, // <Statement> ::= <CompoundStatement>
        RULE_STATEMENT2                                  =  42, // <Statement> ::= <AssignmentStatement>
        RULE_STATEMENT3                                  =  43, // <Statement> ::= <ProcedureCall>
        RULE_STATEMENT4                                  =  44, // <Statement> ::= <ForStatement>
        RULE_STATEMENT5                                  =  45, // <Statement> ::= <WhileStatement>
        RULE_STATEMENT6                                  =  46, // <Statement> ::= <IfStatement>
        RULE_STATEMENT7                                  =  47, // <Statement> ::= <CaseStatement>
        RULE_STATEMENT8                                  =  48, // <Statement> ::= <RepeatStatement>
        RULE_STATEMENT9                                  =  49, // <Statement> ::= 
        RULE_ASSIGNMENTSTATEMENT_COLONEQ                 =  50, // <AssignmentStatement> ::= <Variable> ':=' <Expression>
        RULE_PROCEDURECALL_ID                            =  51, // <ProcedureCall> ::= id <Actuals>
        RULE_FORSTATEMENT_FOR_ID_COLONEQ_TO_DO           =  52, // <ForStatement> ::= FOR id ':=' <Expression> TO <Expression> DO <Statement>
        RULE_FORSTATEMENT_FOR_ID_COLONEQ_DOWNTO_DO       =  53, // <ForStatement> ::= FOR id ':=' <Expression> DOWNTO <Expression> DO <Statement>
        RULE_WHILESTATEMENT_WHILE_DO                     =  54, // <WhileStatement> ::= WHILE <Expression> DO <Statement>
        RULE_IFSTATEMENT_IF_THEN_ELSE                    =  55, // <IfStatement> ::= IF <Expression> THEN <Statement> ELSE <Statement>
        RULE_REPEATSTATEMENT_REPEAT_UNTIL                =  56, // <RepeatStatement> ::= REPEAT <StatementList> UNTIL <Expression>
        RULE_CASESTATEMENT_CASE_OF_END                   =  57, // <CaseStatement> ::= CASE <Expression> OF <CaseList> END
        RULE_CASELIST                                    =  58, // <CaseList> ::= <Case>
        RULE_CASELIST_SEMI                               =  59, // <CaseList> ::= <Case> ';' <CaseList>
        RULE_CASE_COLON                                  =  60, // <Case> ::= <ConstantList> ':' <Statement>
        RULE_CONSTANTLIST                                =  61, // <ConstantList> ::= <constant>
        RULE_CONSTANTLIST_COMMA                          =  62, // <ConstantList> ::= <constant> ',' <ConstantList>
        RULE_EXPRESSION                                  =  63, // <Expression> ::= <SimpleExpression>
        RULE_EXPRESSION_EQ                               =  64, // <Expression> ::= <SimpleExpression> '=' <SimpleExpression>
        RULE_EXPRESSION_LTGT                             =  65, // <Expression> ::= <SimpleExpression> '<>' <SimpleExpression>
        RULE_EXPRESSION_LT                               =  66, // <Expression> ::= <SimpleExpression> '<' <SimpleExpression>
        RULE_EXPRESSION_LTEQ                             =  67, // <Expression> ::= <SimpleExpression> '<=' <SimpleExpression>
        RULE_EXPRESSION_GT                               =  68, // <Expression> ::= <SimpleExpression> '>' <SimpleExpression>
        RULE_EXPRESSION_GTEQ                             =  69, // <Expression> ::= <SimpleExpression> '>=' <SimpleExpression>
        RULE_SIMPLEEXPRESSION                            =  70, // <SimpleExpression> ::= <Term>
        RULE_SIMPLEEXPRESSION_PLUS                       =  71, // <SimpleExpression> ::= <SimpleExpression> '+' <Term>
        RULE_SIMPLEEXPRESSION_MINUS                      =  72, // <SimpleExpression> ::= <SimpleExpression> '-' <Term>
        RULE_SIMPLEEXPRESSION_OR                         =  73, // <SimpleExpression> ::= <SimpleExpression> OR <Term>
        RULE_TERM                                        =  74, // <Term> ::= <Factor>
        RULE_TERM_TIMES                                  =  75, // <Term> ::= <Term> '*' <Factor>
        RULE_TERM_DIV                                    =  76, // <Term> ::= <Term> '/' <Factor>
        RULE_TERM_DIV2                                   =  77, // <Term> ::= <Term> DIV <Factor>
        RULE_TERM_MOD                                    =  78, // <Term> ::= <Term> MOD <Factor>
        RULE_TERM_AND                                    =  79, // <Term> ::= <Term> AND <Factor>
        RULE_FACTOR_LPARAN_RPARAN                        =  80, // <Factor> ::= '(' <Expression> ')'
        RULE_FACTOR_PLUS                                 =  81, // <Factor> ::= '+' <Factor>
        RULE_FACTOR_MINUS                                =  82, // <Factor> ::= '-' <Factor>
        RULE_FACTOR_NOT                                  =  83, // <Factor> ::= NOT <Factor>
        RULE_FACTOR                                      =  84, // <Factor> ::= <constant>
        RULE_FACTOR2                                     =  85, // <Factor> ::= <Variable>
        RULE_FUNCTIONCALL_ID                             =  86, // <FunctionCall> ::= id <Actuals>
        RULE_ACTUALS_LPARAN_RPARAN                       =  87, // <Actuals> ::= '(' <ExpressionList> ')'
        RULE_ACTUALS                                     =  88, // <Actuals> ::= 
        RULE_EXPRESSIONLIST                              =  89, // <ExpressionList> ::= <Expression>
        RULE_EXPRESSIONLIST_COMMA                        =  90, // <ExpressionList> ::= <Expression> ',' <ExpressionList>
        RULE_VARIABLE_ID                                 =  91, // <Variable> ::= id
        RULE_VARIABLE_DOT_ID                             =  92, // <Variable> ::= <Variable> '.' id
        RULE_VARIABLE_CARET                              =  93, // <Variable> ::= <Variable> '^'
        RULE_VARIABLE_LBRACKET_RBRACKET                  =  94, // <Variable> ::= <Variable> '[' <ExpressionList> ']'
        RULE_TYPESPECIFIER_ID                            =  95, // <TypeSpecifier> ::= id
        RULE_TYPESPECIFIER_CARET                         =  96, // <TypeSpecifier> ::= '^' <TypeSpecifier>
        RULE_TYPESPECIFIER_LPARAN_RPARAN                 =  97, // <TypeSpecifier> ::= '(' <IdList> ')'
        RULE_TYPESPECIFIER_DOTDOT                        =  98, // <TypeSpecifier> ::= <constant> '..' <constant>
        RULE_TYPESPECIFIER_ARRAY_LBRACKET_RBRACKET_OF    =  99, // <TypeSpecifier> ::= ARRAY '[' <DimensionList> ']' OF <TypeSpecifier>
        RULE_TYPESPECIFIER_RECORD_END                    = 100, // <TypeSpecifier> ::= RECORD <FieldList> END
        RULE_TYPESPECIFIER_FILE_OF                       = 101, // <TypeSpecifier> ::= FILE OF <TypeSpecifier>
        RULE_DIMENSIONLIST                               = 102, // <DimensionList> ::= <Dimension>
        RULE_DIMENSIONLIST_COMMA                         = 103, // <DimensionList> ::= <Dimension> ',' <DimensionList>
        RULE_DIMENSION_DOTDOT                            = 104, // <Dimension> ::= <constant> '..' <constant>
        RULE_DIMENSION_ID                                = 105, // <Dimension> ::= id
        RULE_FIELDLIST                                   = 106, // <FieldList> ::= <Field>
        RULE_FIELDLIST_SEMI                              = 107, // <FieldList> ::= <Field> ';' <FieldList>
        RULE_FIELD_COLON                                 = 108, // <Field> ::= <IdList> ':' <TypeSpecifier>
        RULE_IDLIST_ID                                   = 109, // <IdList> ::= id
        RULE_IDLIST_ID_COMMA                             = 110  // <IdList> ::= id ',' <IdList>
    };

        // this class will construct a parser without having to process
        //  the CGT tables with each creation.  It must be initialized
        //  before you can call CreateParser()
	public sealed class ParserFactory
	{
		static Grammar m_grammar;
		static bool _init;
		
		private ParserFactory()
		{
		}
		
		private static BinaryReader GetResourceReader(string resourceName)
		{  
			Assembly assembly = Assembly.GetExecutingAssembly();   
			Stream stream = assembly.GetManifestResourceStream(resourceName);
			return new BinaryReader(stream);
		}
		
		public static void InitializeFactoryFromFile(string FullCGTFilePath)
		{
			if (!_init)
			{
			   BinaryReader reader = new BinaryReader(new FileStream(FullCGTFilePath,FileMode.Open));
			   m_grammar = new Grammar( reader );
			   _init = true;
			}
		}
		
		public static void InitializeFactoryFromResource(string resourceName)
		{
			if (!_init)
			{
				BinaryReader reader = GetResourceReader(resourceName);
				m_grammar = new Grammar( reader );
				_init = true;
			}
		}
		
		public static Parser CreateParser(TextReader reader)
		{
		   if (_init)
		   {
				return new Parser(reader, m_grammar);
		   }
		   throw new Exception("You must first Initialize the Factory before creating a parser!");
		}
	}
        
	public abstract partial class ASTNode
	{
		public abstract bool IsTerminal
		{
			get;
		}
	}
	
	/// <summary>
	/// Derive this class for Terminal AST Nodes
	/// </summary>
	public partial class TerminalNode : ASTNode
	{
		private Symbol m_symbol;
		private string m_text;
		private int m_lineNumber;
		private int m_linePosition;

		public TerminalNode(Parser theParser)
		{
			m_symbol = theParser.TokenSymbol;
			m_text = theParser.TokenSymbol.ToString();
			m_lineNumber = theParser.LineNumber;
			m_linePosition = theParser.LinePosition;
		}

		public override bool IsTerminal
		{
			get
			{
				return true;
			}
		}
		
		public Symbol Symbol
		{
			get { return m_symbol; }
		}

		public string Text
		{
			get { return m_text; }
		}

		public override string ToString()
		{
			return m_text;
		}

		public int LineNumber 
		{
			get { return m_lineNumber; }
		}

		public int LinePosition
		{
			get { return m_linePosition; }
		}
	}
	
	/// <summary>
	/// Derive this class for NonTerminal AST Nodes
	/// </summary>
	public partial class NonTerminalNode : ASTNode
	{
		private int m_reductionNumber;
		private Rule m_rule;
		private List<ASTNode> m_array = new List<ASTNode>();

		public NonTerminalNode(Parser theParser)
		{
			m_rule = theParser.ReductionRule;
		}
		
		public override bool IsTerminal
		{
			get
			{
				return false;
			}
		}

		public int ReductionNumber 
		{
			get { return m_reductionNumber; }
			set { m_reductionNumber = value; }
		}

		public int Count 
		{
			get { return m_array.Count; }
		}

		public ASTNode this[int index]
		{
			get { return m_array[index]; }
		}

		public void AppendChildNode(ASTNode node)
		{
			if (node == null)
			{
				return ; 
			}
			m_array.Add(node);
		}

		public Rule Rule
		{
			get { return m_rule; }
		}

	}

    public partial class MyParser
    {
        MyParserContext m_context;
        ASTNode m_AST;
        string m_errorString;
        Parser m_parser;
        
        public int LineNumber
        {
            get
            {
                return m_parser.LineNumber;
            }
        }

        public int LinePosition
        {
            get
            {
                return m_parser.LinePosition;
            }
        }

        public string ErrorString
        {
            get
            {
                return m_errorString;
            }
        }

        public string ErrorLine
        {
            get
            {
                return m_parser.LineText;
            }
        }

        public ASTNode SyntaxTree
        {
            get
            {
                return m_AST;
            }
        }

        public bool Parse(string source)
        {
            return Parse(new StringReader(source));
        }

        public bool Parse(StringReader sourceReader)
        {
            m_parser = ParserFactory.CreateParser(sourceReader);
            m_parser.TrimReductions = true;
            m_context = new MyParserContext(m_parser);
            
            while (true)
            {
                switch (m_parser.Parse())
                {
                    case ParseMessage.LexicalError:
                        m_errorString = string.Format("Lexical Error. Line {0}. Token {1} was not expected.", m_parser.LineNumber, m_parser.TokenText);
                        return false;

                    case ParseMessage.SyntaxError:
                        StringBuilder text = new StringBuilder();
                        foreach (Symbol tokenSymbol in m_parser.GetExpectedTokens())
                        {
                            text.Append(' ');
                            text.Append(tokenSymbol.ToString());
                        }
                        m_errorString = string.Format("Syntax Error. Line {0}. Expecting: {1}.", m_parser.LineNumber, text.ToString());
                        
                        return false;
                    case ParseMessage.Reduction:
                        m_parser.TokenSyntaxNode = m_context.CreateASTNode();
                        break;

                    case ParseMessage.Accept:
                        m_AST = m_parser.TokenSyntaxNode as ASTNode;
                        m_errorString = null;
                        return true;

                    case ParseMessage.InternalError:
                        m_errorString = "Internal Error. Something is horribly wrong.";
                        return false;

                    case ParseMessage.NotLoadedError:
                        m_errorString = "Grammar Table is not loaded.";
                        return false;

                    case ParseMessage.CommentError:
                        m_errorString = "Comment Error. Unexpected end of input.";
                        
                        return false;

                    case ParseMessage.CommentBlockRead:
                    case ParseMessage.CommentLineRead:
                        // don't do anything 
                        break;
                }
            }
         }

    }

    public partial class MyParserContext
    {

		// instance fields
        private Parser m_parser;
		
        private TextReader m_inputReader;
		

		
		// constructor
        public MyParserContext(Parser prser)
        {
            m_parser = prser;	
        }
       

        private string GetTokenText()
        {
            // delete any of these that are non-terminals.

            switch (m_parser.TokenSymbol.Index)
            {

                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //Token Kind: 3
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //Token Kind: 7
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //(Whitespace)
                //Token Kind: 2
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LPARAN :
                //'('
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RPARAN :
                //')'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DOTDOT :
                //'..'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COLONEQ :
                //':='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_LTGT :
                //'<>'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_AND :
                //AND
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAY :
                //ARRAY
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //BEGIN
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //CASE
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CHARLITERAL :
                //CharLiteral
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONST :
                //CONST
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DECLITERAL :
                //DecLiteral
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DIV2 :
                //DIV
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //DO
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DOWNTO :
                //DOWNTO
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //ELSE
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //END
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FILE :
                //FILE
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FLOATLITERAL :
                //FloatLiteral
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //FOR
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FORWARD :
                //FORWARD
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //FUNCTION
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_HEXLITERAL :
                //HexLiteral
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //IF
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MOD :
                //MOD
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NOT :
                //NOT
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OF :
                //OF
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //OR
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROCEDURE :
                //PROCEDURE
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //PROGRAM
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_RECORD :
                //RECORD
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_REPEAT :
                //REPEAT
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_THEN :
                //THEN
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TO :
                //TO
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //TYPE
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_UNTIL :
                //UNTIL
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //VAR
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //WHILE
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ACTUALS :
                //<Actuals>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ARG :
                //<Arg>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTLIST :
                //<ArgumentList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTS :
                //<Arguments>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENTSTATEMENT :
                //<AssignmentStatement>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CASE2 :
                //<Case>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CASELIST :
                //<CaseList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CASESTATEMENT :
                //<CaseStatement>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_COMPOUNDSTATEMENT :
                //<CompoundStatement>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANT :
                //<constant>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDEF :
                //<ConstantDef>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDEFINITIONLIST :
                //<ConstantDefinitionList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDEFINITIONS :
                //<ConstantDefinitions>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTLIST :
                //<ConstantList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARATIONS :
                //<Declarations>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DIMENSION :
                //<Dimension>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_DIMENSIONLIST :
                //<DimensionList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSIONLIST :
                //<ExpressionList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FIELD :
                //<Field>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FIELDLIST :
                //<FieldList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FORSTATEMENT :
                //<ForStatement>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONCALL :
                //<FunctionCall>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONHEADER :
                //<FunctionHeader>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_IDLIST :
                //<IdList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATEMENT :
                //<IfStatement>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROCEDURECALL :
                //<ProcedureCall>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROCEDUREDEC :
                //<ProcedureDec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROCEDUREDECLARATIONS :
                //<ProcedureDeclarations>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROCEDUREHEADER :
                //<ProcedureHeader>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM2 :
                //<Program>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAMHEADER :
                //<ProgramHeader>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_REPEATSTATEMENT :
                //<RepeatStatement>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_SIMPLEEXPRESSION :
                //<SimpleExpression>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST :
                //<StatementList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<Term>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TYPEDEF :
                //<TypeDef>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TYPEDEFINITIONLIST :
                //<TypeDefinitionList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TYPEDEFINITIONS :
                //<TypeDefinitions>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_TYPESPECIFIER :
                //<TypeSpecifier>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLE :
                //<Variable>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDEC :
                //<VariableDec>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATIONLIST :
                //<VariableDeclarationList>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATIONS :
                //<VariableDeclarations>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_WHILESTATEMENT :
                //<WhileStatement>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                default:
                    throw new SymbolException("You don't want the text of a non-terminal symbol");

            }
            
        }

        public ASTNode CreateASTNode()
        {
            switch (m_parser.ReductionRule.Index)
            {
                case (int)RuleConstants.RULE_CONSTANT_DECLITERAL :
                //<constant> ::= DecLiteral
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_STRINGLITERAL :
                //<constant> ::= StringLiteral
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_FLOATLITERAL :
                //<constant> ::= FloatLiteral
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_HEXLITERAL :
                //<constant> ::= HexLiteral
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_CHARLITERAL :
                //<constant> ::= CharLiteral
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_DOT :
                //<Program> ::= <ProgramHeader> <Declarations> <CompoundStatement> '.'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROGRAMHEADER_PROGRAM_ID_SEMI :
                //<ProgramHeader> ::= PROGRAM id ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROGRAMHEADER_PROGRAM_ID_LPARAN_RPARAN_SEMI :
                //<ProgramHeader> ::= PROGRAM id '(' <IdList> ')' ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_DECLARATIONS :
                //<Declarations> ::= <ConstantDefinitions> <TypeDefinitions> <VariableDeclarations> <ProcedureDeclarations>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDEFINITIONS_CONST :
                //<ConstantDefinitions> ::= CONST <ConstantDefinitionList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDEFINITIONS :
                //<ConstantDefinitions> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDEFINITIONLIST :
                //<ConstantDefinitionList> ::= <ConstantDef>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDEFINITIONLIST2 :
                //<ConstantDefinitionList> ::= <ConstantDef> <ConstantDefinitionList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDEF_ID_EQ_SEMI :
                //<ConstantDef> ::= id '=' <constant> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPEDEFINITIONS_TYPE :
                //<TypeDefinitions> ::= TYPE <TypeDefinitionList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPEDEFINITIONS :
                //<TypeDefinitions> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPEDEFINITIONLIST :
                //<TypeDefinitionList> ::= <TypeDef>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPEDEFINITIONLIST2 :
                //<TypeDefinitionList> ::= <TypeDef> <TypeDefinitionList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPEDEF_ID_EQ_SEMI :
                //<TypeDef> ::= id '=' <TypeSpecifier> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATIONS_VAR :
                //<VariableDeclarations> ::= VAR <VariableDeclarationList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATIONS :
                //<VariableDeclarations> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATIONLIST :
                //<VariableDeclarationList> ::= <VariableDec>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATIONLIST2 :
                //<VariableDeclarationList> ::= <VariableDec> <VariableDeclarationList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDEC_COLON_SEMI :
                //<VariableDec> ::= <IdList> ':' <TypeSpecifier> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROCEDUREDECLARATIONS :
                //<ProcedureDeclarations> ::= <ProcedureDec> <ProcedureDeclarations>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROCEDUREDECLARATIONS2 :
                //<ProcedureDeclarations> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROCEDUREDEC_FORWARD_SEMI :
                //<ProcedureDec> ::= <ProcedureHeader> FORWARD ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROCEDUREDEC_SEMI :
                //<ProcedureDec> ::= <ProcedureHeader> <Declarations> <CompoundStatement> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROCEDUREDEC_FORWARD_SEMI2 :
                //<ProcedureDec> ::= <FunctionHeader> FORWARD ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROCEDUREDEC_SEMI2 :
                //<ProcedureDec> ::= <FunctionHeader> <Declarations> <CompoundStatement> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROCEDUREHEADER_PROCEDURE_ID_SEMI :
                //<ProcedureHeader> ::= PROCEDURE id <Arguments> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONHEADER_FUNCTION_ID_COLON_SEMI :
                //<FunctionHeader> ::= FUNCTION id <Arguments> ':' <TypeSpecifier> ';'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS_LPARAN_RPARAN :
                //<Arguments> ::= '(' <ArgumentList> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS :
                //<Arguments> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST :
                //<ArgumentList> ::= <Arg>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST_SEMI :
                //<ArgumentList> ::= <Arg> ';' <ArgumentList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARG_COLON :
                //<Arg> ::= <IdList> ':' <TypeSpecifier>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ARG_VAR_COLON :
                //<Arg> ::= VAR <IdList> ':' <TypeSpecifier>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_COMPOUNDSTATEMENT_BEGIN_END :
                //<CompoundStatement> ::= BEGIN <StatementList> END
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST :
                //<StatementList> ::= <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST_SEMI :
                //<StatementList> ::= <Statement> ';' <StatementList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <CompoundStatement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <AssignmentStatement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <ProcedureCall>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <ForStatement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<Statement> ::= <WhileStatement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT6 :
                //<Statement> ::= <IfStatement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT7 :
                //<Statement> ::= <CaseStatement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT8 :
                //<Statement> ::= <RepeatStatement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_STATEMENT9 :
                //<Statement> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTSTATEMENT_COLONEQ :
                //<AssignmentStatement> ::= <Variable> ':=' <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_PROCEDURECALL_ID :
                //<ProcedureCall> ::= id <Actuals>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORSTATEMENT_FOR_ID_COLONEQ_TO_DO :
                //<ForStatement> ::= FOR id ':=' <Expression> TO <Expression> DO <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FORSTATEMENT_FOR_ID_COLONEQ_DOWNTO_DO :
                //<ForStatement> ::= FOR id ':=' <Expression> DOWNTO <Expression> DO <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_WHILESTATEMENT_WHILE_DO :
                //<WhileStatement> ::= WHILE <Expression> DO <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_THEN_ELSE :
                //<IfStatement> ::= IF <Expression> THEN <Statement> ELSE <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_REPEATSTATEMENT_REPEAT_UNTIL :
                //<RepeatStatement> ::= REPEAT <StatementList> UNTIL <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CASESTATEMENT_CASE_OF_END :
                //<CaseStatement> ::= CASE <Expression> OF <CaseList> END
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CASELIST :
                //<CaseList> ::= <Case>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CASELIST_SEMI :
                //<CaseList> ::= <Case> ';' <CaseList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CASE_COLON :
                //<Case> ::= <ConstantList> ':' <Statement>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTLIST :
                //<ConstantList> ::= <constant>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_CONSTANTLIST_COMMA :
                //<ConstantList> ::= <constant> ',' <ConstantList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <SimpleExpression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQ :
                //<Expression> ::= <SimpleExpression> '=' <SimpleExpression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTGT :
                //<Expression> ::= <SimpleExpression> '<>' <SimpleExpression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT :
                //<Expression> ::= <SimpleExpression> '<' <SimpleExpression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTEQ :
                //<Expression> ::= <SimpleExpression> '<=' <SimpleExpression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT :
                //<Expression> ::= <SimpleExpression> '>' <SimpleExpression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTEQ :
                //<Expression> ::= <SimpleExpression> '>=' <SimpleExpression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SIMPLEEXPRESSION :
                //<SimpleExpression> ::= <Term>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SIMPLEEXPRESSION_PLUS :
                //<SimpleExpression> ::= <SimpleExpression> '+' <Term>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SIMPLEEXPRESSION_MINUS :
                //<SimpleExpression> ::= <SimpleExpression> '-' <Term>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_SIMPLEEXPRESSION_OR :
                //<SimpleExpression> ::= <SimpleExpression> OR <Term>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<Term> ::= <Factor>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<Term> ::= <Term> '*' <Factor>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<Term> ::= <Term> '/' <Factor>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV2 :
                //<Term> ::= <Term> DIV <Factor>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TERM_MOD :
                //<Term> ::= <Term> MOD <Factor>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TERM_AND :
                //<Term> ::= <Term> AND <Factor>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPARAN_RPARAN :
                //<Factor> ::= '(' <Expression> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FACTOR_PLUS :
                //<Factor> ::= '+' <Factor>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FACTOR_MINUS :
                //<Factor> ::= '-' <Factor>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FACTOR_NOT :
                //<Factor> ::= NOT <Factor>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<Factor> ::= <constant>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FACTOR2 :
                //<Factor> ::= <Variable>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONCALL_ID :
                //<FunctionCall> ::= id <Actuals>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACTUALS_LPARAN_RPARAN :
                //<Actuals> ::= '(' <ExpressionList> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_ACTUALS :
                //<Actuals> ::= 
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONLIST :
                //<ExpressionList> ::= <Expression>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONLIST_COMMA :
                //<ExpressionList> ::= <Expression> ',' <ExpressionList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_ID :
                //<Variable> ::= id
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DOT_ID :
                //<Variable> ::= <Variable> '.' id
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_CARET :
                //<Variable> ::= <Variable> '^'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_LBRACKET_RBRACKET :
                //<Variable> ::= <Variable> '[' <ExpressionList> ']'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPESPECIFIER_ID :
                //<TypeSpecifier> ::= id
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPESPECIFIER_CARET :
                //<TypeSpecifier> ::= '^' <TypeSpecifier>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPESPECIFIER_LPARAN_RPARAN :
                //<TypeSpecifier> ::= '(' <IdList> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPESPECIFIER_DOTDOT :
                //<TypeSpecifier> ::= <constant> '..' <constant>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPESPECIFIER_ARRAY_LBRACKET_RBRACKET_OF :
                //<TypeSpecifier> ::= ARRAY '[' <DimensionList> ']' OF <TypeSpecifier>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPESPECIFIER_RECORD_END :
                //<TypeSpecifier> ::= RECORD <FieldList> END
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_TYPESPECIFIER_FILE_OF :
                //<TypeSpecifier> ::= FILE OF <TypeSpecifier>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_DIMENSIONLIST :
                //<DimensionList> ::= <Dimension>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_DIMENSIONLIST_COMMA :
                //<DimensionList> ::= <Dimension> ',' <DimensionList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_DIMENSION_DOTDOT :
                //<Dimension> ::= <constant> '..' <constant>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_DIMENSION_ID :
                //<Dimension> ::= id
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FIELDLIST :
                //<FieldList> ::= <Field>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FIELDLIST_SEMI :
                //<FieldList> ::= <Field> ';' <FieldList>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_FIELD_COLON :
                //<Field> ::= <IdList> ':' <TypeSpecifier>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_IDLIST_ID :
                //<IdList> ::= id
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_IDLIST_ID_COMMA :
                //<IdList> ::= id ',' <IdList>
                //todo: Perhaps create an object in the AST.
                return null;

                default:
					throw new RuleException("Unknown rule: Does your CGT Match your Code Revision?");
            }
            
        }

    }
    
}
