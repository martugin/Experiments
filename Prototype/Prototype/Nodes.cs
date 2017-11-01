using System.Collections.Generic;
using System.Windows.Forms;

namespace Prototype
{
    public enum NodeType
    {
        Project,
        Module,
        Task,
        Generation,
        Table,
        Param,
        Type,
        SubParam,
        Var,
        Connection,
        Object,
        Signal,
        Char
    }
    
    public class Node
    {
        public Node(NodeType type, string code, TreeNode treeNode)
        {
            Type = type;
            Code = code;
            TreeNode = treeNode;
        }

        public NodeType Type { get; set; }
        public string Code { get; set; }
        public string Dir { get; set; }
        public string File { get; set; }
        public TreeNode TreeNode { get; set; }

        public Dictionary<string, Node> Nodes = new Dictionary<string, Node>();
    }
}