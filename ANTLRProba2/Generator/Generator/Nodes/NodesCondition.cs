using Antlr4.Runtime.Tree;

namespace Generator.Generator
{
    //Узел - вызывающий генерацию ряда или обработку подчиненного свойства
    internal abstract class NodeIter : Node
    {
        protected NodeIter(ITerminalNode terminal, NodeIter prop) 
            : base(terminal)
        {
            Prop = prop;
        }

        //Следующее свойство в цепочке
        public NodeIter Prop { get; set; }
    }

    //----------------------------------------------------------------------------------------------------
    //Узел - проход по таблице
    internal class NodeCTabl : NodeIter
    {
        public NodeCTabl(ITerminalNode terminal, NodeIter prop = null)
            : base(terminal, prop)
        {
            if (terminal != null)
                _tablName = terminal.Symbol.Text;
        }

        //Имя таблицы
        private string _tablName;

        //Тип узла
        protected override string NodeType { get { return "Tabl"; }}

        public override string ToTestString()
        {
            return ToTestWithChildren(Prop);
        }
    }

    //----------------------------------------------------------------------------------------------------
    //Узел - родительский ряд для таблицы
    internal class NodeCParent : NodeIter
    {
        public NodeCParent(ITerminalNode parent)
            : base(parent, null)
        {
        }
        
        //Тип узла
        protected override string NodeType { get { return "Parent"; } }
    }

    //----------------------------------------------------------------------------------------------------
    //Узел - перебор рядов подтаблицы
    internal class NodeCChildren : NodeIter
    {
        public NodeCChildren(ITerminalNode children, NodeIter prop = null)
            : base(children, prop)
        {
        }

        //Тип узла
        protected override string NodeType { get { return "Children"; } }

        public override string ToTestString()
        {
            return ToTestWithChildren(Prop);
        }
    }

    //----------------------------------------------------------------------------------------------------
    //Узел - наложение условия на ряд
    internal class NodeCCond : NodeIter
    {
        public NodeCCond(ITerminalNode cond, NodeExpr expr)
            : base(cond, null)
        {
            _expr = expr;
        }

        //Выражение для условия
        private readonly NodeExpr _expr;

        //Тип узла
        protected override string NodeType { get { return "Children"; } }

        public override string ToTestString()
        {
            return ToTestWithChildren(_expr, Prop);
        }
    }

    //----------------------------------------------------------------------------------------------------
    //Узел - пустое условие
    internal class NodeEmpty : NodeIter
    {
        public NodeEmpty() : base(null, null)
        {
        }

        protected override string NodeType { get { return "Empty"; }}
    }

}