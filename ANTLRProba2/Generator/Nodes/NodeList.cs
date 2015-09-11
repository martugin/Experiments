using System.Collections.Generic;
using Antlr4.Runtime;

namespace Generator
{
    //Промежуточный узел, собирающий список узлов 
    internal class NodeList : Node
    {
        public NodeList(IEnumerable<Node> children)
            : base((IToken) null)
        {
            Children = children;
        }

        protected override string NodeType { get { return "NodeList"; }}

        // Список узлов 
        public IEnumerable<Node> Children { get; private set; }
    }
}