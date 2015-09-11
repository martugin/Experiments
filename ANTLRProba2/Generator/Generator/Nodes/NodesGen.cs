using System;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CommonTypes;

namespace Generator.Generator
{
    //Узел содержащий текст
    internal class NodeText : Node, INodeText
    {
        public NodeText(ITerminalNode terminal) : base(terminal)
        {
            if (terminal == null || terminal.Symbol == null)
                _text = "";
            else _text = terminal.Symbol.Text;
        }

        public NodeText(ITerminalNode terminal, string text) : base(terminal)
        {
            _text = text;
        }

        //Тип узла
        protected override string NodeType { get { return "Text"; } }

        //Текст
        private readonly string _text;
        public string GetText()
        {
            return _text;
        }
    }

    //--------------------------------------------------------------------------------------------
    //Узел - программа, возвращающая значение
    internal class NodeValueProg : NodeExpr
    {
        public NodeValueProg(NodeVoidProg voidProg, NodeExpr expr)
            : base((IToken)null)
        {
            _voidProg = voidProg;
            _expr = expr;
        }

        //Программа без возвращаемого значения и завершающее выражение
        private readonly NodeVoidProg _voidProg;
        private readonly NodeExpr _expr;

        //Тип узла
        protected override string NodeType { get { return "ValueProg"; } }
        //Возвращаемое значение
        public override Mean GetMean()
        {
            return _expr.GetMean();
        }
    }

    //--------------------------------------------------------------------------------------------
    //Базовый класс для узлов - программ без значения
    internal abstract class NodeVoidBase : Node, INodeText
    {
        protected NodeVoidBase(ITerminalNode terminal) 
            : base(terminal) { }

        protected NodeVoidBase(IToken token) 
            : base(token) { }

        //Возвращаемый текст
        public string GetText()
        {
            return "";
        }
    }

    //--------------------------------------------------------------------------------------------
    //Узел - программа без возвращаемого значения
    internal class NodeVoidProg : NodeVoidBase
    {
        public NodeVoidProg(params NodeVoidBase[] progs) 
            : base((IToken)null)
        {
            _progs = progs;
        }

        public NodeVoidProg(NodeList list) : base((IToken) null)
        {
            _progs = list.Children.Select(a => (NodeVoidBase) a).ToArray();
        }

        //Части, из которых состоят программа
        private NodeVoidBase[] _progs;

        //Тип узла
        protected override string NodeType { get { return "VoidProg"; }}
        
    }

    //--------------------------------------------------------------------------------------------
    //Узел - VOID
    internal class NodeVoid : NodeVoidBase
    {
        public NodeVoid(ITerminalNode terminal) 
            : base(terminal) { }

        protected override string NodeType { get { return "Void"; }}
    }

    //--------------------------------------------------------------------------------------------
    //Узел присвоение
    internal class NodeSet : NodeVoidBase
    {
        public NodeSet(ITerminalNode terminal)
            : base(terminal)
        {
            throw new NotImplementedException();
        }

        protected override string NodeType { get { return "Set"; }}
    }
}