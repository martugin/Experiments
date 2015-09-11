namespace Generator
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
            this.Formula = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.TextBox();
            this.ButCondition = new System.Windows.Forms.Button();
            this.ButSubCondition = new System.Windows.Forms.Button();
            this.ButGenField = new System.Windows.Forms.Button();
            this.ButInputs = new System.Windows.Forms.Button();
            this.ButFormula = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Formula
            // 
            this.Formula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Formula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Formula.Location = new System.Drawing.Point(2, 2);
            this.Formula.Multiline = true;
            this.Formula.Name = "Formula";
            this.Formula.Size = new System.Drawing.Size(561, 123);
            this.Formula.TabIndex = 0;
            // 
            // Result
            // 
            this.Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Result.Location = new System.Drawing.Point(2, 203);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(561, 154);
            this.Result.TabIndex = 1;
            // 
            // ButCondition
            // 
            this.ButCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButCondition.Location = new System.Drawing.Point(2, 128);
            this.ButCondition.Name = "ButCondition";
            this.ButCondition.Size = new System.Drawing.Size(112, 36);
            this.ButCondition.TabIndex = 2;
            this.ButCondition.Text = "Условие";
            this.ButCondition.UseVisualStyleBackColor = true;
            this.ButCondition.Click += new System.EventHandler(this.ButCondition_Click);
            // 
            // ButSubCondition
            // 
            this.ButSubCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButSubCondition.Location = new System.Drawing.Point(2, 163);
            this.ButSubCondition.Name = "ButSubCondition";
            this.ButSubCondition.Size = new System.Drawing.Size(112, 36);
            this.ButSubCondition.TabIndex = 3;
            this.ButSubCondition.Text = "Подусловие";
            this.ButSubCondition.UseVisualStyleBackColor = true;
            this.ButSubCondition.Click += new System.EventHandler(this.ButSubCondition_Click);
            // 
            // ButGenField
            // 
            this.ButGenField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButGenField.Location = new System.Drawing.Point(113, 128);
            this.ButGenField.Name = "ButGenField";
            this.ButGenField.Size = new System.Drawing.Size(99, 71);
            this.ButGenField.TabIndex = 4;
            this.ButGenField.Text = "Поле генерации";
            this.ButGenField.UseVisualStyleBackColor = true;
            // 
            // ButInputs
            // 
            this.ButInputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButInputs.Location = new System.Drawing.Point(215, 128);
            this.ButInputs.Name = "ButInputs";
            this.ButInputs.Size = new System.Drawing.Size(99, 71);
            this.ButInputs.TabIndex = 5;
            this.ButInputs.Text = "Входы";
            this.ButInputs.UseVisualStyleBackColor = true;
            // 
            // ButFormula
            // 
            this.ButFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButFormula.Location = new System.Drawing.Point(314, 128);
            this.ButFormula.Name = "ButFormula";
            this.ButFormula.Size = new System.Drawing.Size(99, 71);
            this.ButFormula.TabIndex = 6;
            this.ButFormula.Text = "Формула";
            this.ButFormula.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 357);
            this.Controls.Add(this.ButFormula);
            this.Controls.Add(this.ButInputs);
            this.Controls.Add(this.ButGenField);
            this.Controls.Add(this.ButSubCondition);
            this.Controls.Add(this.ButCondition);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Formula);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Formula;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Button ButCondition;
        private System.Windows.Forms.Button ButSubCondition;
        private System.Windows.Forms.Button ButGenField;
        private System.Windows.Forms.Button ButInputs;
        private System.Windows.Forms.Button ButFormula;
    }
}

