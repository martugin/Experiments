using System.Collections.Generic;
using System.Windows.Forms;
using Antlr4.Runtime.Tree;

namespace Generator
{
    internal class ExpressionVisitor : ExpressionBaseVisitor<Node>
    {
        public override Node VisitCombinedText(ExpressionParser.CombinedTextContext context)
        {
            var ch = new Node[context.ChildCount-1];
            for (int i = 0; i < context.ChildCount-1; i++)
                ch[i] = Visit(context.GetChild(i));
            return new Node(NodeType.CombinedText, null, ch);
        }

        public override Node VisitElementTag(ExpressionParser.ElementTagContext context)
        {
            return Visit(context.tag());
        }

        public override Node VisitElementString(ExpressionParser.ElementStringContext context)
        {
            return new Node(NodeType.Text, context.STRING().Symbol);
        }

        public override Node VisitElementSignal(ExpressionParser.ElementSignalContext context)
        {
            return new Node(NodeType.Text, context.SIGNAL().Symbol);
        }

        public override Node VisitElementComment(ExpressionParser.ElementCommentContext context)
        {
            return new Node(NodeType.Text, context.COMMENT().Symbol);
        }

        public override Node VisitElementText(ExpressionParser.ElementTextContext context)
        {
            return Visit(context.text());
        }

        public override Node VisitTextKeyword(ExpressionParser.TextKeywordContext context)
        {
            return Visit(context.keyword());
        }

        public override Node VisitTextText(ExpressionParser.TextTextContext context)
        {
            return new Node(NodeType.Text, ((ITerminalNode)context.GetChild(0)).Symbol);
        }

        public override Node VisitGetKeyword(ExpressionParser.GetKeywordContext context)
        {
            return new Node(NodeType.Text, ((ITerminalNode)context.GetChild(0)).Symbol);
        }

        public override Node VisitTagIdent(ExpressionParser.TagIdentContext context)
        {
            return new Node(NodeType.Field, context.IDENT().Symbol);
        }

        public override Node VisitTagParent(ExpressionParser.TagParentContext context)
        {
            return new Node(NodeType.Parent, context.PARENT().Symbol,
                new[] { Visit(context.expr()) });
        }

        public override Node VisitTagChildren(ExpressionParser.TagChildrenContext context)
        {
            return new Node(NodeType.Children, context.CHILDREN().Symbol,
                new[] { Visit(context.expr()) });
        }

        public override Node VisitTagChildrenCond(ExpressionParser.TagChildrenCondContext context)
        {
            return new Node(NodeType.ChildrenCond, context.CHILDRENCOND().Symbol,
                new[] { Visit(context.cond()), Visit(context.expr()) });
        }

        public override Node VisitCondSimple(ExpressionParser.CondSimpleContext context)
        {
            return new Node(NodeType.Oper, context.OPER().Symbol, 
                new[] {
                    new Node(NodeType.Field, context.IDENT(0).Symbol), 
                    new Node(NodeType.Const, context.IDENT(1).Symbol)
                });
        }

        public override Node VisitCondParents(ExpressionParser.CondParentsContext context)
        {
            return Visit(context.cond());
        }

        public override Node VisitCondOr(ExpressionParser.CondOrContext context)
        {
            return new Node(NodeType.Or, context.OR().Symbol, 
                new[] { Visit(context.cond(0)), Visit(context.cond(1)) });
        }

        public override Node VisitCondAnd(ExpressionParser.CondAndContext context)
        {
            return new Node(NodeType.And, context.AND().Symbol, 
                new[] { Visit(context.cond(0)), Visit(context.cond(1)) });
        }

        public override Node VisitCondNot(ExpressionParser.CondNotContext context)
        {
            return new Node(NodeType.Not, context.NOT().Symbol, 
                new [] { Visit(context.cond()) });
        }
    }
}