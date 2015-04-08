using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Antlr4.Runtime.Tree;

namespace Tablik
{
    internal class InputsVisitor : InputsBaseVisitor<Node>
    {
        private Node[] VisitChilds(IParseTree context, string sep)
        {
            var list = new List<Node>();
            for (int i = 0; i < context.ChildCount; i++)
                if (context.GetChild(i).GetText() != sep)
                    list.Add(Visit(context.GetChild(i)));
            return list.ToArray();
        }

        public override Node VisitParamList(InputsParser.ParamListContext context)
        {
            var a = context.children[0];
            return new Node(NodeType.ParamList, null, VisitChilds(context, ";"));
        }

        public override Node VisitParamType(InputsParser.ParamTypeContext context)
        {
            return Visit(context.valueType());
        }

        public override Node VisitParamParams(InputsParser.ParamParamsContext context)
        {
            return new Node(NodeType.Params, context.PARAMS().Symbol, Visit(context.valueType()), Visit(context.classList()));
        }

        public override Node VisitParamConst(InputsParser.ParamConstContext context)
        {
            return new Node(NodeType.Assign, context.ASSIGN().Symbol, Visit(context.arg()), Visit(context.constVal()));
        }

        public override Node VisitTypeGet(InputsParser.TypeGetContext context)
        {
            return Visit(context.arg());
        }

        public override Node VisitTypeSignals(InputsParser.TypeSignalsContext context)
        {
            return new Node(NodeType.Signals, context.SIGNALS().Symbol, Visit(context.arg()), Visit(context.signalsList()));
        }

        public override Node VisitTypeClass(InputsParser.TypeClassContext context)
        {
            return new Node(NodeType.Var, context.IDENT().Symbol, Visit(context.identChain()));
        }

        public override Node VisitClassListGet(InputsParser.ClassListGetContext context)
        {
            return new Node(NodeType.ClassList, null, VisitChilds(context, ";"));
        }

        public override Node VisitIdentChainGet(InputsParser.IdentChainGetContext context)
        {
            return new Node(NodeType.IdentChain, null, VisitChilds(context, "."));
        }

        public override Node VisitSignalsListGet(InputsParser.SignalsListGetContext context)
        {
            return new Node(NodeType.SignalsList, null, VisitChilds(context, ";"));
        }

        public override Node VisitArgSignalArg(InputsParser.ArgSignalArgContext context)
        {
            return Visit(context.arg());
        }

        public override Node VisitArgSignalSignal(InputsParser.ArgSignalSignalContext context)
        {
            return new Node(NodeType.Signal, context.SIGNAL().Symbol);
        }

        public override Node VisitArgSignalDataType(InputsParser.ArgSignalDataTypeContext context)
        {
            return new Node(NodeType.Signal, context.SIGNAL().Symbol, Visit(context.DATATYPE()));
        }

        public override Node VisitArgIdent(InputsParser.ArgIdentContext context)
        {
            return new Node(NodeType.Var, context.IDENT().Symbol);
        }

        public override Node VisitArgDataType(InputsParser.ArgDataTypeContext context)
        {
            return new Node(NodeType.Var, context.IDENT().Symbol, Visit(context.DATATYPE()));
        }

        public override Node VisitConstBool(InputsParser.ConstBoolContext context)
        {
            return new Node(NodeType.Bool, context.BOOL().Symbol);
        }

        public override Node VisitConstInt(InputsParser.ConstIntContext context)
        {
            return new Node(NodeType.Int, context.INT().Symbol);
        }

        public override Node VisitConstReal(InputsParser.ConstRealContext context)
        {
            return new Node(NodeType.Real, context.REAL().Symbol);
        }

        public override Node VisitConstString(InputsParser.ConstStringContext context)
        {
            return new Node(NodeType.String, context.STRING().Symbol);
        }

        public override Node VisitConstDate(InputsParser.ConstDateContext context)
        {
            return new Node(NodeType.Date, context.DATE().Symbol);
        }
    }
}