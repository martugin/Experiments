using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButCalc_Click(object sender, EventArgs e)
        {
            var reader = new StringReader(Formula.Text);
            var input = new AntlrInputStream(reader.ReadToEnd());
            var lexer = new ExpressionLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ExpressionParser(tokens);
            IParseTree tree = parser.expr();
            Tree.Text = tree.ToStringTree(parser);
            var visitor = new ExpressionVisitor();
            Result.Text = visitor.Visit(tree).ToString();
        }
    }
}
