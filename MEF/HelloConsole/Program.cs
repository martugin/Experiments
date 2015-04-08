using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            var lang = Console.ReadLine();
            var addingComposer = new AddingComposer();
            var hello = addingComposer
                       .GetHello(lang)
                       .SayHello();
            Console.WriteLine(hello);
            Console.ReadLine();
        }
    }
}
