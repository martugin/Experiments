
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
        SYMBOL_EOF        =  0, // (EOF)
        SYMBOL_ERROR      =  1, // (Error)
        SYMBOL_WHITESPACE =  2, // (Whitespace)
        SYMBOL_MINUS      =  3, // '-'
        SYMBOL_LPARAN     =  4, // '('
        SYMBOL_RPARAN     =  5, // ')'
        SYMBOL_TIMES      =  6, // '*'
        SYMBOL_DIV        =  7, // '/'
        SYMBOL_PLUS       =  8, // '+'
        SYMBOL_ID         =  9, // Id
        SYMBOL_INTEGER    = 10, // Integer
        SYMBOL_EXPRESSION = 11, // <Expression>
        SYMBOL_MULTEXP    = 12, // <Mult Exp>
        SYMBOL_NEGATEEXP  = 13, // <Negate Exp>
        SYMBOL_VALUE      = 14  // <Value>
    };

    enum RuleConstants : int
    {
        RULE_EXPRESSION_PLUS     =  0, // <Expression> ::= <Expression> '+' <Mult Exp>
        RULE_EXPRESSION_MINUS    =  1, // <Expression> ::= <Expression> '-' <Mult Exp>
        RULE_EXPRESSION          =  2, // <Expression> ::= <Mult Exp>
        RULE_MULTEXP_TIMES       =  3, // <Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
        RULE_MULTEXP_DIV         =  4, // <Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
        RULE_MULTEXP             =  5, // <Mult Exp> ::= <Negate Exp>
        RULE_NEGATEEXP_MINUS     =  6, // <Negate Exp> ::= '-' <Value>
        RULE_NEGATEEXP           =  7, // <Negate Exp> ::= <Value>
        RULE_VALUE_ID            =  8, // <Value> ::= Id
        RULE_VALUE_INTEGER       =  9, // <Value> ::= Integer
        RULE_VALUE_LPARAN_RPARAN = 10  // <Value> ::= '(' <Expression> ')'
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

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
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

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //Integer
                //Token Kind: 1
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<Negate Exp>
                //Token Kind: 0
                //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                // return m_parser.TokenString;
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
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
                case (int)RuleConstants.RULE_EXPRESSION_PLUS :
                //<Expression> ::= <Expression> '+' <Mult Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUS :
                //<Expression> ::= <Expression> '-' <Mult Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Mult Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Negate Exp>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<Negate Exp> ::= '-' <Value>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<Negate Exp> ::= <Value>
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VALUE_ID :
                //<Value> ::= Id
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VALUE_INTEGER :
                //<Value> ::= Integer
                //todo: Perhaps create an object in the AST.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPARAN_RPARAN :
                //<Value> ::= '(' <Expression> ')'
                //todo: Perhaps create an object in the AST.
                return null;

                default:
					throw new RuleException("Unknown rule: Does your CGT Match your Code Revision?");
            }
            
        }

    }
    
}
