using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using LangDefinition;

namespace HelloConsole
{
    public class AddingComposer
    {
        [ImportMany(typeof(ILanguage))]
        private Lazy<ILanguage, IDictionary<string, object>>[] langVaults { get; set; }

        private void LoadAddings()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(@"D:\Experiments\MEF\Adding"));
            
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        public ILanguage GetHello(string type)
        {
            LoadAddings();
            return (from codeVault in langVaults
                    where (string)codeVault.Metadata["Lang"] == type
                    select codeVault).Single().Value;
        }
    }
}