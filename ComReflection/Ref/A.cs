using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bib;
using Sbor;

namespace Ref
{
    public class Fac
    {
        public A New()
        {
            return new A();
        }
    }

    public class A : IA
    {
        public A()
        {
            MessageBox.Show("A");
        }
        
        public string B { get { return "B"; } }

        public string J()
        {
            MessageBox.Show("J");
            return "J";
        }
    }
}
