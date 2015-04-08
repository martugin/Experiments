using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using LangDefinition;

namespace EnglishHello
{
    [Export(typeof(ILanguage))]
    [ExportMetadata("Lang", "En")]
    public class EnHello : ILanguage
    {
        public string SayHello()
        {
            return "Hello";
        }
    }
}
