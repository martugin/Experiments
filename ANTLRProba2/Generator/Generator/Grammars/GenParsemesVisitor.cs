using Antlr4.Runtime.Tree;
using Generator.Generator.Grammars;

namespace Generator.Generator
{
    internal class GenParsemesVisitor : GenParsemesBaseVisitor<Node>
    {
        public GenParsemesVisitor(ParsingKeeper keeper)
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
    }
}