using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var s =new Scanner("input.txt");
            s.Scan();
            var p = new Parser(s);
            p.Parse();
            Console.WriteLine(p.St);
        }
    }
}
