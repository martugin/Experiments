using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Proba2
{
    public class Node
    {
        public Node(IParseTree context, IToken token)
        {
            Context = context;
            Token = token;
        }


        public IParseTree Context { get; private set; }
        public IToken Token { get; private set; }

        private readonly List<Node> _children = new List<Node>();
        public List<Node> Children { get { return _children; } }

        protected string String { get { return "[" + Token.Text + ", lin " + Token.Line + ", col " + Token.Column + ", start " + Token.StartIndex + ", stop " + Token.StopIndex + "]"; } }
    }


    public class IntNode : Node
    {
        public IntNode(ITerminalNode tnode) : base(tnode, tnode.Symbol)
        {
        }

        public override string ToString()
        {
            return String;
        }
    }

    public class FunNode : Node
    {
        public FunNode(ParserRuleContext context, IToken token) : base(context, token)
        {
        }

        public override string ToString()
        {
            return String + " (" + Children[0] + "; " + Children[1] + ")";
        }
    }

    public class SignNode : Node
    {
        public SignNode(ParserRuleContext context, IToken token)
            : base(context, token)
        {
        }

        public override string ToString()
        {
            return String + " (" + Children[0] + ")";
        }
    }
}