using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace RunXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadXml_Click(object sender, EventArgs e)
        {
            var doc = new XmlDocument();
            doc.Load("file.xml");
            var root = doc.ChildNodes[1];
            foreach (XmlNode node in root.ChildNodes)
            {
                MessageBox.Show(node.Name);
                MessageBox.Show(node.Attributes["Prop1"].Value);
                
                foreach (XmlNode snode in node.ChildNodes)
                {
                    string s = snode.Name + ", " + snode.InnerText + ": ";
                    foreach (XmlAttribute attr in snode.Attributes)
                        s += attr.Name + "=" + attr.Value;
                    MessageBox.Show(s);
                }
            }
        }

        private void XPath_Click(object sender, EventArgs e)
        {
            var doc = new XmlDocument();
            doc.Load("file.xml");
            var nlist = doc.SelectNodes("/Root/Branch/Leaf");
            foreach (XmlNode node in nlist)
                MessageBox.Show(node.Name);
        }

        private void WriteXml_Click(object sender, EventArgs e)
        {
            var doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", null));
            var root = (XmlElement)doc.AppendChild(doc.CreateElement("root"));
            root.SetAttribute("Attr", "v");
            var node = (XmlElement)root.AppendChild(doc.CreateElement("node"));
            node.InnerText = "dd ff";
            doc.Save("file2.xml");
        }

        private void XDocument_Click(object sender, EventArgs e)
        {
            //var doc = new XDocument(new XElement("root", new XAttribute("p1", "aa"), new XElement("child", "text")));
            var doc = new XDocument();
            var xe = new XElement("root", new XElement("branch", "ddd"), new XAttribute("Prop1", "Value1"), new XComment("Comment1"));
            doc.Add(xe);
            xe.SetAttributeValue("Prop2", "Value2");
            xe.Add(new XElement("branch", "ccc"));
            xe.Add(new XComment("Comment2"));
            xe.Add(new XAttribute("Prop3", "Value3"));
            doc.Save("file3.xml");
        }

        private void XDocumentRead_Click(object sender, EventArgs e)
        {
            var doc = XDocument.Load("file.xml");
            foreach (var xe in doc.Root.Elements("Branch"))
                foreach (var node in xe.Elements())
                {
                    MessageBox.Show(node.Name + " - " + node.Value);
                    foreach (var attr in node.Attributes())
                        MessageBox.Show(attr.Name + " - " + attr.Value);
                    //MessageBox.Show(node.Attribute("LProp1").Value);
                }
        }
    }
}
