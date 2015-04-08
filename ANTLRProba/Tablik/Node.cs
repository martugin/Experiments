using Antlr4.Runtime;

namespace Tablik
{
    internal enum NodeType
    {
        ParamList,
        Params,
        Assign,
        Signals,
        Var,
        ClassList,
        IdentChain,
        SignalsList,
        Signal,
        DataType,
        Bool,
        Int,
        String,
        Real,
        Date
    }

    internal class Node
    {
        public Node(NodeType ntype, IToken token = null, params Node[] children)
        {
            NodeType = ntype;
            Token = token;
            Children = children;
        }

        //Тип вершины
        public NodeType NodeType { get; private set; }
        //Ссылка на токен
        public IToken Token { get; private set; }
        //Дети-подвыражения
        public Node[] Children { get; private set; }

        public override string ToString()
        {
            string s = NodeType.ToString() + "-";
            s += Token == null ? "" : ("[" + Token.Text + ", lin " + Token.Line + ", col " + Token.Column + ", start " + Token.StartIndex + ", stop " + Token.StopIndex + "] ");
            s += "(";
            if (Children != null)
                for (int i = 0; i < Children.Length; i++)
                {
                    if (i > 0) s += "; ";
                    if (Children[i] != null)
                        s += Children[i].ToString();
                }
            return s + ")";
        }
    }

    //Типы данных
    public enum DataType
    {
        Value, //Время, недостоверность и ошибка без начения
        Boolean, //Логическое значение
        Integer, //Целое значение
        Time, //Значение тип Время
        Real, //Действительное значение
        String, //Строковое значение
        Variant, //Значение неопределенного типа
        Segments, //Набор сегментов
        Error //Задан неверный тип
    }
}