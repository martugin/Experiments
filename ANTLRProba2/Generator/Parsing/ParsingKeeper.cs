﻿using Antlr4.Runtime.Tree;
using BaseLibrary;

namespace Generator
{
    internal class ParsingKeeper : KeeperBase
    {
        public ParsingKeeper(string fieldName)
            : base(fieldName) {}

        //Обработка токена целого числа
        public NodeConst CheckInt(ITerminalNode terminal)
        {
            if (terminal == null || terminal.Symbol == null)
                return new NodeConst(null, 0);
            var token = terminal.Symbol;
            int res;
            if (!int.TryParse(token.Text, out res))
                AddError("Недопустимое целое число", token);
            if (res == 1) return new NodeConst(token, true);
            if (res == 0) return new NodeConst(token, false);
            return new NodeConst(token, res);
        }

        //Обработка токена действительного числа 
        public NodeConst CheckReal(ITerminalNode terminal)
        {
            if (terminal == null || terminal.Symbol == null)
                return new NodeConst(null, 0.0);
            var token = terminal.Symbol;
            var d = token.Text.ToDouble();
            if (double.IsNaN(d))
            {
                AddError("Недопустимое число с плавающей точкой", token);
                d = 0;
            }
            return new NodeConst(token, d);
        }

        //Обработка токена временной константы
        public NodeConst CheckTime(ITerminalNode terminal)
        {
            if (terminal == null || terminal.Symbol == null)
                return new NodeConst(null, Different.MinDate);
            var token = terminal.Symbol;
            var t = token.Text.ToDateTime();
            if (t == Different.MinDate)
                AddError("Недопустимое число с плавающей точкой", token);
            return new NodeConst(token, t);
        }

        //Обработка токена строковой константы
        public NodeConst CheckString(ITerminalNode terminal)
        {
            if (terminal == null || terminal.Symbol == null)
                return new NodeConst(null, "");
            return new NodeConst(terminal.Symbol, terminal.Symbol.Text);
        }
    }
}