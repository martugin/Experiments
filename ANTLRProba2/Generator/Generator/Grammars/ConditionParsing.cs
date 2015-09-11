using Antlr4.Runtime;

namespace Generator.Generator
{
    //Разбор условия генерации параметра
    internal class ConditionParsing : Parsing
    {
        public ConditionParsing(string fieldName, string fieldValue) 
            : base(fieldName, fieldValue) { }

        protected override Lexer GetLexer(ICharStream input)
        {
            return new ConditionLexer(input);
        }

        protected override Parser GetParser(ITokenStream tokens)
        {
            return new ConditionParser(tokens);
        }

        protected override Node RunVisitor(Parser parser, ParsingKeeper keeper)
        {
            return new ConditionVisitor(keeper).Go(((ConditionParser)parser).tablGen());
        }
    }

    //-------------------------------------------------------------------------------------------------------------------
    internal class ConditionSubParsing : Parsing
    {
        public ConditionSubParsing(string fieldName, string fieldValue)
            : base(fieldName, fieldValue) { }

        protected override Lexer GetLexer(ICharStream input)
        {
            return new ConditionLexer(input);
        }

        protected override Parser GetParser(ITokenStream tokens)
        {
            return new ConditionParser(tokens);
        }

        protected override Node RunVisitor(Parser parser, ParsingKeeper keeper)
        {
            return new ConditionVisitor(keeper).Go(((ConditionParser)parser).subTablGen());
        }
    }
}