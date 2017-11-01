namespace Prototype
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Tree = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Text1 = new System.Windows.Forms.RichTextBox();
            this.Text2 = new System.Windows.Forms.RichTextBox();
            this.ButLoadProject = new System.Windows.Forms.Button();
            this.ButProjectTree = new System.Windows.Forms.Button();
            this.ButDerived = new System.Windows.Forms.Button();
            this.ProjectDir = new System.Windows.Forms.TextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(-1, 44);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Tree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1201, 659);
            this.splitContainer1.SplitterDistance = 388;
            this.splitContainer1.TabIndex = 1;
            // 
            // Tree
            // 
            this.Tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tree.ImageIndex = 0;
            this.Tree.ImageList = this.ImageList;
            this.Tree.Location = new System.Drawing.Point(3, 3);
            this.Tree.Name = "Tree";
            this.Tree.SelectedImageIndex = 0;
            this.Tree.Size = new System.Drawing.Size(382, 656);
            this.Tree.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Text1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.Text2);
            this.splitContainer2.Size = new System.Drawing.Size(809, 659);
            this.splitContainer2.SplitterDistance = 405;
            this.splitContainer2.TabIndex = 0;
            // 
            // Text1
            // 
            this.Text1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Text1.Location = new System.Drawing.Point(2, 2);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(400, 657);
            this.Text1.TabIndex = 0;
            this.Text1.Text = "";
            // 
            // Text2
            // 
            this.Text2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Text2.Location = new System.Drawing.Point(0, 1);
            this.Text2.Name = "Text2";
            this.Text2.Size = new System.Drawing.Size(399, 658);
            this.Text2.TabIndex = 1;
            this.Text2.Text = "";
            // 
            // ButLoadProject
            // 
            this.ButLoadProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButLoadProject.Location = new System.Drawing.Point(284, 2);
            this.ButLoadProject.Name = "ButLoadProject";
            this.ButLoadProject.Size = new System.Drawing.Size(103, 43);
            this.ButLoadProject.TabIndex = 2;
            this.ButLoadProject.Text = "Загрузить проект";
            this.ButLoadProject.UseVisualStyleBackColor = true;
            this.ButLoadProject.Click += new System.EventHandler(this.ButLoadProject_Click);
            // 
            // ButProjectTree
            // 
            this.ButProjectTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButProjectTree.Location = new System.Drawing.Point(2, 2);
            this.ButProjectTree.Name = "ButProjectTree";
            this.ButProjectTree.Size = new System.Drawing.Size(103, 43);
            this.ButProjectTree.TabIndex = 3;
            this.ButProjectTree.Text = "Дерево проекта";
            this.ButProjectTree.UseVisualStyleBackColor = true;
            this.ButProjectTree.Click += new System.EventHandler(this.ButProjectTree_Click);
            // 
            // ButDerived
            // 
            this.ButDerived.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButDerived.Location = new System.Drawing.Point(107, 2);
            this.ButDerived.Name = "ButDerived";
            this.ButDerived.Size = new System.Drawing.Size(119, 43);
            this.ButDerived.TabIndex = 4;
            this.ButDerived.Text = "Порожденные параметры";
            this.ButDerived.UseVisualStyleBackColor = true;
            // 
            // ProjectDir
            // 
            this.ProjectDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProjectDir.Location = new System.Drawing.Point(391, 13);
            this.ProjectDir.Name = "ProjectDir";
            this.ProjectDir.Size = new System.Drawing.Size(809, 22);
            this.ProjectDir.TabIndex = 5;
            this.ProjectDir.Text = "d:\\InfoTask2\\Information\\Thinking\\PrototypeProject";
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Char.png");
            this.ImageList.Images.SetKeyName(1, "Connection.png");
            this.ImageList.Images.SetKeyName(2, "Generation.png");
            this.ImageList.Images.SetKeyName(3, "Object.png");
            this.ImageList.Images.SetKeyName(4, "Param.png");
            this.ImageList.Images.SetKeyName(5, "Project.png");
            this.ImageList.Images.SetKeyName(6, "Report.png");
            this.ImageList.Images.SetKeyName(7, "Signal.png");
            this.ImageList.Images.SetKeyName(8, "SubParam.png");
            this.ImageList.Images.SetKeyName(9, "Table.png");
            this.ImageList.Images.SetKeyName(10, "Task.png");
            this.ImageList.Images.SetKeyName(11, "Type.png");
            this.ImageList.Images.SetKeyName(12, "Var.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 705);
            this.Controls.Add(this.ProjectDir);
            this.Controls.Add(this.ButDerived);
            this.Controls.Add(this.ButProjectTree);
            this.Controls.Add(this.ButLoadProject);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Проект";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox Text1;
        private System.Windows.Forms.RichTextBox Text2;
        private System.Windows.Forms.Button ButLoadProject;
        private System.Windows.Forms.Button ButProjectTree;
        private System.Windows.Forms.Button ButDerived;
        private System.Windows.Forms.TextBox ProjectDir;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.ImageList ImageList;
    }
}

