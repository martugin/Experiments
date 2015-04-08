using Antlr4.Runtime.Tree;

namespace Proba2
{
    public class CalcVisitor : CalcBaseVisitor<Node>
    {
        public override Node VisitInt(CalcParser.IntContext context)
        {
            return new IntNode(context.INT());
        }

        public override Node VisitSign(CalcParser.SignContext context)
        {
            Node p = Visit(context.expr());
            var node = new SignNode(context, context.Op);
            node.Children.Add(p);
            return node;
        }

        public override Node VisitAddSub(CalcParser.AddSubContext context)
        {
            Node left = Visit(context.expr(0));
            Node right = Visit(context.expr(1));
            var node = new FunNode(context, context.Op);
            node.Children.Add(left);
            node.Children.Add(right);
            return node;
        }

        public override Node VisitMulDiv(CalcParser.MulDivContext context)
        {
            Node left = Visit(context.expr(0));
            Node right = Visit(context.expr(1));
            var node = new FunNode(context, context.Op);
            node.Children.Add(left);
            node.Children.Add(right);
            return node;
        }

        public override Node VisitParens(CalcParser.ParensContext context)
        {
            return Visit(context.expr());
        }
    }
}