using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Call
{
    public class C
    {
        public void D()
        {
            Assembly a = Assembly.LoadFile(@"f:\UTE\Experiments\ComReflection\Ref\bin\Debug\ref.dll");
            Type t = a.GetType("Ref.A");
            Type[] tt = Type.EmptyTypes;
            ConstructorInfo c = t.GetConstructor(tt);
            var pr = c.Invoke(new object[] { });
            //PropertyInfo prop = t.GetProperty("Code");
            //var code = (string)prop.GetValue(pr, null);          
        }
    }
}
