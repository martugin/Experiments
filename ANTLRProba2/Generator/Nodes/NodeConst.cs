using System;
using Antlr4.Runtime;
using CommonTypes;

namespace Generator
{
    internal class NodeConst : NodeExpr, INodeText
    {
        public NodeConst(IToken token, bool b) : base(token)
        {
            _mean = new MeanBool(b);
        }

        public NodeConst(IToken token, int i) : base(token)
        {
            _mean = new MeanInteger(i);
        }

        public NodeConst(IToken token, double r) : base(token)
        {
            _mean = new MeanReal(r);
        }

        public NodeConst(IToken token, DateTime t) : base(token)
        {
            _mean = new MeanTime(t);
        }

        public NodeConst(IToken token, string s) : base(token)
        {
            _mean = new MeanString(s);
        }

        //Тип узла
        protected override string NodeType { get { return _mean.DataType.ToString(); }}

        //Значение константы
        private readonly Mean _mean;
        public override Mean GetMean()
        {
            return _mean;
        }
    }
}