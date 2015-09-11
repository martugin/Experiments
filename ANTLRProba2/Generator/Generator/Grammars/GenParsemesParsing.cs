using Antlr4.Runtime;
using Generator.Generator.Grammars;

namespace Generator.Generator
{
    //Разбор выражения для генерации поля параметра
    internal class GenParsemesParsing : Parsing
    {
        public GenParsemesParsing(string fieldName, string fieldValue) 
            : base(fieldName, fieldValue) { }

        protected override Lexer GetLexer(ICharStream input)
        {
            return new GenLexemes(input);
        }

        protected override Parser GetParser(ITokenStream tokens)
        {
            return new GenParsemes(tokens);
        }

        protected override Node RunVisitor(Parser parser, ParsingKeeper keeper)
        {
            return new GenParsemesVisitor(keeper).Go(((GenParsemes)parser).fieldGen());
        }
    }
}