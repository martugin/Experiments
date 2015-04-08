using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Sbor
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
            MessageBox.Show("Create");
            dynamic dyn = a.CreateInstance("Ref.A");
            MessageBox.Show("Type name: " + dyn.GetType().FullName);
            IA pr = (IA) dyn;
            MessageBox.Show("Type name: " + pr.GetType().FullName);
            MessageBox.Show(pr.J());

            /*Type t = a.GetType("Ref.A");
            Type[] tt = Type.EmptyTypes;
            MessageBox.Show("GetConstructor");
            ConstructorInfo c = t.GetConstructor(tt);
            MessageBox.Show("Invoke");
            var pr = (IA)c.Invoke(new object[] { });
            MessageBox.Show("pr.J");
            pr.J();*/


            //Type t = a.GetType("Ref.Fac");
            //dynamic fac = c.Invoke(new object[] { });
            //MessageBox.Show("New");
            //var p = fac.New();
            //IA pr = (IA)p;
            //I pr  = (I)fac.New();
            //PropertyInfo prop = t.GetProperty("B");
            //MessageBox.Show((string)prop.GetValue(pr, null));
            //dynamic pr = c.Invoke(new object[] { });
            //pr.J();
        }
    }
}
