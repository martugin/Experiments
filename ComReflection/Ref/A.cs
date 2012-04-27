using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ref
{
    public class A
    {
        public A()
        {
            MessageBox.Show("A");
        }

        public string B { get { return "B"; } }
    }
}
