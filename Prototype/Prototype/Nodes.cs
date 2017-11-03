using System.Collections.Generic;
using System.Windows.Forms;

namespace Prototype
{
    public enum NodeType
    {
        Project,
        Modules,
        Module,
        Task,
        Generation,
        Table,
        Param,
        Type,
        SubParam,
        Var,
        Connections,
        Connection,
        Object,
        Signal,
        Char,
        Reports,
        Report
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


    public static class NodesConv
    {
        public static NodeType ToNodeType(this string stype)
        {
            switch (stype)
            {
                case "Project":
                case "Проект":
                    return NodeType.Project;
                case "Module":
                case "Модули":
                    return NodeType.Module;
                case "Task":
                case "Задачи":
                    return NodeType.Task;
                case "Generation":
                case "Генерации":
                    return NodeType.Generation;
                case "Param":
                case "Иерархия параметров":
                    return NodeType.Param;
                case "Type":
                case "Расчтеные типы":
                    return NodeType.Type;
                case "SubParam":
                case "Иерархия подпараметров":
                    return NodeType.SubParam;
                case "Var":
                case "Переменные":
                    return NodeType.Var;
                case "Connection":
                case "Соединения":
                    return NodeType.Connection;
                case "Object":
                case "Объекты":
                    return NodeType.Object;
                case "Signal":
                case "Сигналы":
                    return NodeType.Signal;
            }
            return NodeType.Project;
        }
    }
}