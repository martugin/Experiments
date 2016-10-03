using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlProba;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DaoDb.RunDao(@"d:\Experiments\XmlProba\Test\Ktec2_Tep.accdb");
        }

        [TestMethod]
        public void TestMethod2()
        {
            DaoDb.RunDao(@"d:\Experiments\XmlProba\Test\Ktec2_Tep.accdb");
        }
    }
}
