using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Bib;
using System.Windows.Forms;

namespace Call
{
    public interface IA
    {
        string J();
    }

    public class C
    {
        public void D()
        {
            Assembly a = Assembly.LoadFile(@"f:\UTE\Experiments\ComReflection\Ref\bin\Debug\ref.dll");
            Type t = a.GetType("Ref.A");
            Type[] tt = Type.EmptyTypes;
            ConstructorInfo c = t.GetConstructor(tt);
            /*var pr = c.Invoke(new object[] { });
            PropertyInfo prop = t.GetProperty("B");
            MessageBox.Show((string)prop.GetValue(pr, null));*/
            dynamic pr = c.Invoke(new object[] { });
            pr.J();
        }
    }
}
