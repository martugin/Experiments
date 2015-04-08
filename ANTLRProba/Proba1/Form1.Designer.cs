namespace Proba1
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
            this.ButCalc = new System.Windows.Forms.Button();
            this.Formula = new System.Windows.Forms.TextBox();
            this.Tree = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButCalc
            // 
            this.ButCalc.Location = new System.Drawing.Point(12, 91);
            this.ButCalc.Name = "ButCalc";
            this.ButCalc.Size = new System.Drawing.Size(126, 49);
            this.ButCalc.TabIndex = 0;
            this.ButCalc.Text = "Расчет";
            this.ButCalc.UseVisualStyleBackColor = true;
            this.ButCalc.Click += new System.EventHandler(this.button1_Click);
            // 
            // Formula
            // 
            this.Formula.Location = new System.Drawing.Point(12, 30);
            this.Formula.Multiline = true;
            this.Formula.Name = "Formula";
            this.Formula.Size = new System.Drawing.Size(321, 55);
            this.Formula.TabIndex = 1;
            // 
            // Tree
            // 
            this.Tree.Location = new System.Drawing.Point(12, 146);
            this.Tree.Multiline = true;
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(321, 91);
            this.Tree.TabIndex = 2;
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(12, 243);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(321, 24);
            this.Result.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 339);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Tree);
            this.Controls.Add(this.Formula);
            this.Controls.Add(this.ButCalc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButCalc;
        private System.Windows.Forms.TextBox Formula;
        private System.Windows.Forms.TextBox Tree;
        private System.Windows.Forms.TextBox Result;
    }
}

