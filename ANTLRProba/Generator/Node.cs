using Antlr4.Runtime;

namespace Generator
{
    internal enum NodeType
    {
        Text,
        CombinedText,
        
        Parent,
        Children,
        ChildrenCond,

        Field,
        Const,
        Oper,
        Or,
        And,
        Not
    }

    //-----------------------------------------------------------------------------------------

    internal class Node
    {
        public Node(NodeType ntype, IToken token = null, params Node[] children)
        {
            NodeType = ntype;
            Token = token;
            Children = children;
        }

        //Тип вершины
        public NodeType NodeType { get; private set; }
        //Ссылка на токен
        public IToken Token { get; private set; }
        //Дети-подвыражения
        public Node[] Children { get; private set; }

        public override string ToString()
        {
            string s = NodeType.ToString() + ": ";
            //s += Token == null ? "" : ("[" + Token.Text + ", lin " + Token.Line + ", col " + Token.Column + ", start " + Token.StartIndex + ", stop " + Token.StopIndex + "] ");
            s += Token == null ? "" : Token.Text;
            if (Children != null && Children.Length != 0)
            {
                s += " (";
                for (int i = 0; i < Children.Length; i++)
                {
                    if (i > 0) s += ", ";
                    if (Children[i] != null)
                        s += Children[i].ToString();
                }
                s += ")";
            }
            return s;
        }
    }
}