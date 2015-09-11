using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;
using P = Generator.Generator.ConditionParser;

namespace Generator.Generator
{
    internal class ConditionVisitor : ConditionBaseVisitor<Node>
    {
        public ConditionVisitor(ParsingKeeper keeper)
        {
            _keeper = keeper;
        }
        //Формирование строки ошибки
        private readonly ParsingKeeper _keeper;

        public Node Go(IParseTree tree)
        {
            if (tree == null) return null;
            return Visit(tree);
        }

        public override Node VisitTablGenProps(P.TablGenPropsContext context)
        {
            return new NodeCTabl(context.IDENT(), (NodeIter)Go(context.props()));
        }

        public override Node VisitTablGenParent(P.TablGenParentContext context)
        {
            return new NodeCTabl(context.IDENT(), new NodeCParent(context.PARENT()));
        }
        
        public override Node VisitSubTablGen(P.SubTablGenContext context)
        {
            return new NodeCChildren(context.CHILDREN(), (NodeIter)Go(context.props()));
        }

        public override Node VisitProps(P.PropsContext context)
        {
            if (context.prop().Length == 0) return null;
            var props = new NodeIter[context.prop().Length];
            for (int i = 0; i < context.prop().Length; i++)
            {
                props[i] = (NodeIter) Go(context.prop()[i]);
                if (i != 0) props[i-1].Prop = props[i];
            }
            return props[0];
        }

        public override Node VisitPropChildren(P.PropChildrenContext context)
        {
            return new NodeCChildren(context.CHILDREN());
        }

        public override Node VisitPropCond(P.PropCondContext context)
        {
            return new NodeCCond(context.COND(), (NodeExpr)Go(context.expr()));
        }

        public override Node VisitPropCondError(P.PropCondErrorContext context)
        {
            _keeper.AddError("Не задано условие", context.COND());
            return new NodeCCond(context.COND(), null);
        }

        public override Node VisitPropCondParenLost(P.PropCondParenLostContext context)
        {
            _keeper.AddError("Не закрытая скобка", context.LPAREN());
            return new NodeCCond(context.COND(), (NodeExpr)Go(context.expr()));
        }

        public override Node VisitPropCondParenExtra(P.PropCondParenExtraContext context)
        {
            _keeper.AddError("Лишняя закрывающаяся скобка", context.RPAREN());
            return new NodeCCond(context.COND(), (NodeExpr)Go(context.expr()));
        }

        //Выражения со значением

        public override Node VisitExprCons(P.ExprConsContext context)
        {
            return Go(context.cons());
        }

        public override Node VisitExprParen(P.ExprParenContext context)
        {
            return Go(context.expr());
        }

        public override Node VisitExprIdent(P.ExprIdentContext context)
        {
            return new NodeField(context.IDENT());
        }

        public override Node VisitExprFun(P.ExprFunContext context)
        {
            return new NodeFun(context.IDENT(), (NodeList)Go(context.pars()));
        }

        public override Node VisitExprUnary(P.ExprUnaryContext context)
        {
            var fun = (ITerminalNode) context.children[0];
            return new NodeFun(fun, (NodeExpr)Go(context.expr()));
        }

        public override Node VisitExprOper(P.ExprOperContext context)
        {
            var fun = (ITerminalNode)context.children[1];
            return new NodeFun(fun, (NodeExpr)Go(context.expr(0)), (NodeExpr)Go(context.expr(1)));
        }

        public override Node VisitExprFunParenLost(P.ExprFunParenLostContext context)
        {
            _keeper.AddError("Не закрытая скобка", context.LPAREN());
            return new NodeFun(context.IDENT(), (NodeList)Go(context.pars()));
        }

        public override Node VisitExprFunParenExtra(P.ExprFunParenExtraContext context)
        {
            _keeper.AddError("Лишняя закрывающаяся скобка", context.RPAREN());
            return new NodeFun(context.IDENT(), (NodeList)Go(context.pars()));
        }

        public override Node VisitParamsList(P.ParamsListContext context)
        {
            return new NodeList(context.expr().Select(Visit));
        }

        public override Node VisitParamsEmpty(P.ParamsEmptyContext context)
        {
            return new NodeList(new List<Node>());
        }

        //Константы

        public override Node VisitConsInt(P.ConsIntContext context)
        {
            return _keeper.CheckInt(context.INT());
        }

        public override Node VisitConsReal(P.ConsRealContext context)
        {
            return _keeper.CheckReal(context.REAL());
        }

        public override Node VisitConsTime(P.ConsTimeContext context)
        {
            return _keeper.CheckTime(context.TIME());
        }

        public override Node VisitConsString(P.ConsStringContext context)
        {
            return _keeper.CheckString(context.STRING());
        }
    }
}