using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CommonTypes;

namespace Generator
{
    //Интерфейс для всех узлов
    internal interface INode
    {
        //Ссылка на токен
        IToken Token { get; }
        //Запись в строку для тестов
        string ToTestString();
    }

    //-------------------------------------------------------------------------------------------------
    //Интерфейс для узлов, возвращающих текст
    internal interface INodeText : INode
    {
        //Возвращаемый текст
        string GetText();
    }

    //-------------------------------------------------------------------------------------------------
    //Базовый класс для узлов расчетных выражений
    internal abstract class NodeExpr : Node, INodeText
    {
        //Вычисляемое значение
        protected NodeExpr(ITerminalNode terminal) 
            : base(terminal) { }

        protected NodeExpr(IToken token) 
            : base(token) { }

        //Возвращаемое значение
        public abstract Mean GetMean();
        //Значение как текст
        public string GetText()
        {
            return GetMean().String;
        }
    }
}