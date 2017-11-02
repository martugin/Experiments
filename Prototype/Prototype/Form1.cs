using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            foreach (var dm in dms.GetDirectories())
            {
                var modNode = projNode.Nodes.Add(dm.Name, dm.Name, "Module.png");
                var mod = new Node(NodeType.Module, dm.Name, modNode);
                _nodes.Add(dm.Name, mod);
                _tree.Nodes.Add(dm.Name, mod);
                foreach (var file in dm.GetFiles())
                {
                    if (file.Extension == ".txt")
                    {
                        var tname = file.Name.Substring(0, file.Name.Length-4);
                        var taskNode = modNode.Nodes.Add(tname, tname, "Task.png");
                        var task = new Node(NodeType.Task, tname, taskNode);
                        _nodes.Add(tname, task);
                        mod.Nodes.Add(tname, task);
                    }
                }
            }


        }
    }
}
