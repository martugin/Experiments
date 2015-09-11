using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Generator
{
    //������� ����� ��� ����������� � ��������������� ������
    internal abstract class KeeperBase
    {
        protected KeeperBase(string fieldName)
        {
            FieldName = fieldName;
        }

        //��� ������������ ����
        protected string FieldName { get; private set; }

        //������ ������
        private readonly List<ParsingError> _errors = new List<ParsingError>();
        public List<ParsingError> Errors { get { return _errors; } }

        //�������� ������ � ������
        public ParsingError AddError(string errMess, IToken token)
        {
            var err = new ParsingError(FieldName, errMess, token);
            Errors.Add(err);
            return err;
        }
        public ParsingError AddError(string errMess, ITerminalNode terminal)
        {
            if (terminal == null) 
                return AddError(errMess, (IToken)null);
            return AddError(errMess, terminal.Symbol);
        }
        public ParsingError AddError(string errMess, string lexeme, int line, int pos, IToken token = null)
        {
            var err = new ParsingError(FieldName, errMess, lexeme, line, pos, token);
            Errors.Add(err);
            return err;
        }

        //������������� ��������� �� ������
        public string ErrMess 
        { 
            get 
            { 
                var s = "";
                foreach (var err in Errors)
                    s += err.ToString();
                return s;
            } 
        }
    }
}