namespace RunXml
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
            this.ReadXml = new System.Windows.Forms.Button();
            this.WriteXml = new System.Windows.Forms.Button();
            this.XPath = new System.Windows.Forms.Button();
            this.XDocumentWrite = new System.Windows.Forms.Button();
            this.XDocumentRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReadXml
            // 
            this.ReadXml.Location = new System.Drawing.Point(40, 37);
            this.ReadXml.Name = "ReadXml";
            this.ReadXml.Size = new System.Drawing.Size(149, 60);
            this.ReadXml.TabIndex = 0;
            this.ReadXml.Text = "ReadXml";
            this.ReadXml.UseVisualStyleBackColor = true;
            this.ReadXml.Click += new System.EventHandler(this.ReadXml_Click);
            // 
            // WriteXml
            // 
            this.WriteXml.Location = new System.Drawing.Point(214, 37);
            this.WriteXml.Name = "WriteXml";
            this.WriteXml.Size = new System.Drawing.Size(149, 60);
            this.WriteXml.TabIndex = 1;
            this.WriteXml.Text = "WriteXml";
            this.WriteXml.UseVisualStyleBackColor = true;
            this.WriteXml.Click += new System.EventHandler(this.WriteXml_Click);
            // 
            // XPath
            // 
            this.XPath.Location = new System.Drawing.Point(40, 103);
            this.XPath.Name = "XPath";
            this.XPath.Size = new System.Drawing.Size(149, 60);
            this.XPath.TabIndex = 2;
            this.XPath.Text = "XPath";
            this.XPath.UseVisualStyleBackColor = true;
            this.XPath.Click += new System.EventHandler(this.XPath_Click);
            // 
            // XDocumentWrite
            // 
            this.XDocumentWrite.Location = new System.Drawing.Point(214, 103);
            this.XDocumentWrite.Name = "XDocumentWrite";
            this.XDocumentWrite.Size = new System.Drawing.Size(149, 60);
            this.XDocumentWrite.TabIndex = 3;
            this.XDocumentWrite.Text = "XDocumentWrite";
            this.XDocumentWrite.UseVisualStyleBackColor = true;
            this.XDocumentWrite.Click += new System.EventHandler(this.XDocument_Click);
            // 
            // XDocumentRead
            // 
            this.XDocumentRead.Location = new System.Drawing.Point(40, 169);
            this.XDocumentRead.Name = "XDocumentRead";
            this.XDocumentRead.Size = new System.Drawing.Size(149, 60);
            this.XDocumentRead.TabIndex = 4;
            this.XDocumentRead.Text = "XDocumentRead";
            this.XDocumentRead.UseVisualStyleBackColor = true;
            this.XDocumentRead.Click += new System.EventHandler(this.XDocumentRead_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 412);
            this.Controls.Add(this.XDocumentRead);
            this.Controls.Add(this.XDocumentWrite);
            this.Controls.Add(this.XPath);
            this.Controls.Add(this.WriteXml);
            this.Controls.Add(this.ReadXml);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadXml;
        private System.Windows.Forms.Button WriteXml;
        private System.Windows.Forms.Button XPath;
        private System.Windows.Forms.Button XDocumentWrite;
        private System.Windows.Forms.Button XDocumentRead;
    }
}

