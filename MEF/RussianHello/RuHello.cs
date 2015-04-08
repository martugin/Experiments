using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using LangDefinition;

namespace RussianHello
{
    [Export(typeof(ILanguage))]
    [ExportMetadata("Lang", "Ru")]
    public class RuHello : ILanguage
    {
        public string SayHello()
        {
            return "Привет";
        }
    }
}
