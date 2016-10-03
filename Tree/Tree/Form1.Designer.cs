namespace Tree
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Фун1(x)                       x+5");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Пар4                       1");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Параметр2                   Фун1(Пар4)", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Параметр3");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Параметр1                    a=Параметр2 + Параметр3 : a", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.TreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView.Location = new System.Drawing.Point(2, 3);
            this.TreeView.Name = "TreeView";
            treeNode1.Name = "Узел5";
            treeNode1.Text = "Фун1(x)                       x+5";
            treeNode1.ToolTipText = "x+5";
            treeNode2.Name = "Узел6";
            treeNode2.Text = "Пар4                       1";
            treeNode2.ToolTipText = "1";
            treeNode3.Name = "Узел2";
            treeNode3.Text = "Параметр2                   Фун1(Пар4)";
            treeNode3.ToolTipText = "Фун1(Пар4)";
            treeNode4.Name = "Узел4";
            treeNode4.Text = "Параметр3";
            treeNode5.Name = "Узел1";
            treeNode5.Text = "Параметр1                    a=Параметр2 + Параметр3 : a";
            treeNode5.ToolTipText = "Парметр2 + Парметр3";
            this.TreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.TreeView.Size = new System.Drawing.Size(517, 487);
            this.TreeView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 491);
            this.Controls.Add(this.TreeView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView;
    }
}

