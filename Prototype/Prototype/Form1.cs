using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Prototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButLoadProject_Click(object sender, EventArgs e)
        {
            try { FolderBrowser.SelectedPath = ProjectDir.Text; }
            catch { }
            FolderBrowser.ShowDialog();
            ProjectDir.Text = FolderBrowser.SelectedPath;
        }

        private Node _tree;
        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();

        private void ButProjectTree_Click(object sender, EventArgs e)
        {
            _nodes.Clear();
            _tree = null;
            Tree.Nodes.Clear();
            var dir = new DirectoryInfo(ProjectDir.Text);
            if (!dir.Exists)
            {
                MessageBox.Show("Каталог проекта не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var projNode = Tree.Nodes.Add(dir.Name, dir.Name, "Project.png");
            _tree = new Node(NodeType.Project,  dir.Name, projNode);
            _nodes.Add(dir.Name, _tree);
            
            var dms = new DirectoryInfo(dir.FullName + @"\Modules");
            var modulesNode = projNode.Nodes.Add("Модули", "Модули", "Modules.png");
            var modules = new Node(NodeType.Modules, "Modules", modulesNode);
            _nodes.Add("Modules", modules);
            _tree.Nodes.Add("Modules", modules);
            
            foreach (var dm in dms.GetDirectories())
            {
                var modNode = modulesNode.Nodes.Add(dm.Name, dm.Name, "Module.png");
                var mod = new Node(NodeType.Module, dm.Name, modNode);
                _nodes.Add(dm.Name, mod);
                modules.Nodes.Add(dm.Name, mod);

                foreach (var file in dm.GetFiles())
                {
                    if (file.Extension == ".txt")
                    {
                        var tname = file.Name.Substring(0, file.Name.Length-4);
                        var taskNode = modNode.Nodes.Add(tname, tname, "Task.png");
                        var task = new Node(NodeType.Task, tname, taskNode) {File =  file.FullName};
                        _nodes.Add(tname, task);
                        mod.Nodes.Add(tname, task);
                    }
                }
            }

            var elems = XDocument.Load(dir.FullName + @"\ProjectProperties.xml").Element("ProjectProperties").Elements().First().Elements();
            var consNode = projNode.Nodes.Add("Соединения", "Соединения", "Connections.png");
            var cons = new Node(NodeType.Connections, "Connections", consNode);
            _nodes.Add("Connections", cons);
            _tree.Nodes.Add("Connections", cons);

            foreach (var elem in elems)
            {
                var conCode = elem.Attribute("Code").Value;
                var conNode = consNode.Nodes.Add(conCode, conCode, "Connection.png");
                var con = new Node(NodeType.Connection, conCode, conNode);
                _nodes.Add(conCode, con);
                cons.Nodes.Add(conCode, con);
            }

            var drs = new DirectoryInfo(dir.FullName + @"\ReportsExcel");
            var repsNode = projNode.Nodes.Add("Отчеты", "Отчеты", "Reports.png");
            var reps = new Node(NodeType.Reports, "Reports", repsNode);
            _nodes.Add("Reports", reps);
            _tree.Nodes.Add("Reports", reps);
            foreach (var dr in drs.GetFiles())
            {
                var repNode = repsNode.Nodes.Add(dr.Name, dr.Name, "Report.png");
                var rep = new Node(NodeType.Report, dr.Name, repNode);
                _nodes.Add(dr.Name, rep);
                reps.Nodes.Add(dr.Name, rep);
            }
        }

        private bool _isText1 = true;

        private void Tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = _nodes[e.Node.Name];
            if (node.Type == NodeType.Task)
            {
                (_isText1 ? Text1Caption : Text2Caption).Text = e.Node.Name;
                (_isText1 ? Text1 : Text2).Text = ReadFile(node.File);
                _isText1 = !_isText1;
            }
        }

        private string ReadFile(string file)
        {
            var sb = new StringBuilder();
            var r = new StreamReader(file, Encoding.GetEncoding("windows-1251"));
            while (!r.EndOfStream)
            {
                string s = r.ReadLine();
                sb.Append(s).Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButDerived_Click(object sender, EventArgs e)
        {
            _nodes.Clear();
            _tree = null;
            Tree.Nodes.Clear();
            var dir = new DirectoryInfo(ProjectDir.Text);
            if (!dir.Exists)
            {
                MessageBox.Show("Каталог проекта не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var elem = XDocument.Load(dir.FullName + @"\Derived.xml").Element("Project");
            var projName = elem.Attribute("Code").Value;
            var projNode = Tree.Nodes.Add(projName, projName, "Project.png");
            _tree = new Node(NodeType.Project, projName, projNode);
            //_nodes.Add("Проект_" + projName, _tree);
            foreach (var el in elem.Elements())
                VisitElem(el, _tree, projNode);
        }

        private string _curPar;

        private void VisitElem(XElement elem, Node parNode, TreeNode parTree)
        {
            string code = elem.Attribute("Code").Value;
            var stype = elem.Name.LocalName;
            var tnode = parTree.Nodes.Add(code, code, stype + ".png");
            var nodeType = stype.ToNodeType();
            var node = new Node(nodeType, code, tnode);
            //_nodes.Add(stype + "_" + code, node);
            parNode.Nodes.Add(code, node);
            foreach (var el in elem.Elements())
                VisitElem(el, node, tnode);
        }
    }
}
