using System;
using Antlr4.Runtime.Tree;
using CommonTypes;
using System.Linq;

namespace Generator.Generator
{
   //Функция
    internal class NodeFun : NodeExpr
    {
        public NodeFun(ITerminalNode terminal, //Имя функции
                                params NodeExpr[] args) //Аргументы
            : base(terminal)
        {
            if (terminal != null)
                _args = args;
        }

        public NodeFun(ITerminalNode terminal, //Имя функции
                                NodeList argsList) //Узел с аргументами
            : base(terminal)
        {
            if (terminal != null)
                _args = argsList.Children.Select(a => (NodeExpr) a).ToArray();
        }

        protected override string NodeType { get { return "Fun"; }}

        //Аргументы
        private readonly NodeExpr[] _args;

        public override string ToTestString()
        {
            return ToTestWithChildren(_args);
        }

        //Вычисленное значение
        public override Mean GetMean()
        {
            throw new NotImplementedException();
        }
    }

    //---------------------------------------------------------------------------------------------------------
    //Поле таблицы
    internal class NodeField : NodeExpr
    {
        public NodeField(ITerminalNode terminal) : base(terminal)
        {
            if (terminal != null)
                _field = terminal.Symbol.Text;
        }

        //Имя поля 
        private string _field;

        protected override string NodeType { get { return "Field"; }}

        //Вычисленное значение
        public override Mean GetMean()
        {
            throw new NotImplementedException();
        }
    }
}