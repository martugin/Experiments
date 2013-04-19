namespace OPCWiz
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
            this.label5 = new System.Windows.Forms.Label();
            this.PointValue1 = new System.Windows.Forms.TextBox();
            this.PointType1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PointTag1 = new System.Windows.Forms.TextBox();
            this.butCheckRec = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Node = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OPCServerName = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PointType2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PointValue2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PointTag2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PointType3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PointValue3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.PointTag3 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PointType4 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.PointValue4 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.PointTag4 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(36, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Тип данных";
            // 
            // PointValue1
            // 
            this.PointValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointValue1.Location = new System.Drawing.Point(125, 52);
            this.PointValue1.Name = "PointValue1";
            this.PointValue1.Size = new System.Drawing.Size(204, 22);
            this.PointValue1.TabIndex = 17;
            // 
            // PointType1
            // 
            this.PointType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointType1.FormattingEnabled = true;
            this.PointType1.Items.AddRange(new object[] {
            "Bool",
            "Int32",
            "Int8",
            "Int16",
            "UInt16",
            "Float",
            "Double"});
            this.PointType1.Location = new System.Drawing.Point(125, 28);
            this.PointType1.Name = "PointType1";
            this.PointType1.Size = new System.Drawing.Size(204, 24);
            this.PointType1.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PointType1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.PointValue1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PointTag1);
            this.panel1.Location = new System.Drawing.Point(41, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 83);
            this.panel1.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(46, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Значение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "OPC Tag Точки";
            // 
            // PointTag1
            // 
            this.PointTag1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointTag1.Location = new System.Drawing.Point(125, 7);
            this.PointTag1.Name = "PointTag1";
            this.PointTag1.Size = new System.Drawing.Size(204, 22);
            this.PointTag1.TabIndex = 15;
            // 
            // butCheckRec
            // 
            this.butCheckRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCheckRec.Location = new System.Drawing.Point(241, 302);
            this.butCheckRec.Name = "butCheckRec";
            this.butCheckRec.Size = new System.Drawing.Size(148, 32);
            this.butCheckRec.TabIndex = 13;
            this.butCheckRec.Text = "Проверка записи";
            this.butCheckRec.UseVisualStyleBackColor = true;
            this.butCheckRec.Click += new System.EventHandler(this.butCheckRec_Click);
            // 
            // butCancel
            // 
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCancel.Location = new System.Drawing.Point(395, 302);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(148, 32);
            this.butCancel.TabIndex = 18;
            this.butCancel.Text = "Отмена";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butCheck
            // 
            this.butCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCheck.Location = new System.Drawing.Point(286, 65);
            this.butCheck.Name = "butCheck";
            this.butCheck.Size = new System.Drawing.Size(199, 32);
            this.butCheck.TabIndex = 23;
            this.butCheck.Text = "Проверка соединения";
            this.butCheck.UseVisualStyleBackColor = true;
            this.butCheck.Click += new System.EventHandler(this.butCheck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(184, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Рабочая станция";
            // 
            // Node
            // 
            this.Node.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Node.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Node.Location = new System.Drawing.Point(329, 37);
            this.Node.Name = "Node";
            this.Node.Size = new System.Drawing.Size(288, 22);
            this.Node.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(184, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Имя OPC-сервера";
            // 
            // OPCServerName
            // 
            this.OPCServerName.FormattingEnabled = true;
            this.OPCServerName.Items.AddRange(new object[] {
            "Matrikon.OPC.Simulation.1",
            "Ovation.OPC.4",
            "Progress.OpenOPC.2"});
            this.OPCServerName.Location = new System.Drawing.Point(329, 9);
            this.OPCServerName.Name = "OPCServerName";
            this.OPCServerName.Size = new System.Drawing.Size(288, 21);
            this.OPCServerName.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.PointType2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.PointValue2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.PointTag2);
            this.panel2.Location = new System.Drawing.Point(395, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 83);
            this.panel2.TabIndex = 25;
            // 
            // PointType2
            // 
            this.PointType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointType2.FormattingEnabled = true;
            this.PointType2.Items.AddRange(new object[] {
            "Bool",
            "Int32",
            "Int8",
            "Int16",
            "UInt16",
            "Float",
            "Double"});
            this.PointType2.Location = new System.Drawing.Point(125, 28);
            this.PointType2.Name = "PointType2";
            this.PointType2.Size = new System.Drawing.Size(204, 24);
            this.PointType2.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(36, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Тип данных";
            // 
            // PointValue2
            // 
            this.PointValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointValue2.Location = new System.Drawing.Point(125, 52);
            this.PointValue2.Name = "PointValue2";
            this.PointValue2.Size = new System.Drawing.Size(204, 22);
            this.PointValue2.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(46, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Значение";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "OPC Tag Точки";
            // 
            // PointTag2
            // 
            this.PointTag2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointTag2.Location = new System.Drawing.Point(125, 7);
            this.PointTag2.Name = "PointTag2";
            this.PointTag2.Size = new System.Drawing.Size(204, 22);
            this.PointTag2.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.PointType3);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.PointValue3);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.PointTag3);
            this.panel3.Location = new System.Drawing.Point(41, 204);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(348, 83);
            this.panel3.TabIndex = 26;
            // 
            // PointType3
            // 
            this.PointType3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointType3.FormattingEnabled = true;
            this.PointType3.Items.AddRange(new object[] {
            "Bool",
            "Int32",
            "Int8",
            "Int16",
            "UInt16",
            "Float",
            "Double"});
            this.PointType3.Location = new System.Drawing.Point(125, 28);
            this.PointType3.Name = "PointType3";
            this.PointType3.Size = new System.Drawing.Size(204, 24);
            this.PointType3.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(36, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Тип данных";
            // 
            // PointValue3
            // 
            this.PointValue3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointValue3.Location = new System.Drawing.Point(125, 52);
            this.PointValue3.Name = "PointValue3";
            this.PointValue3.Size = new System.Drawing.Size(204, 22);
            this.PointValue3.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(46, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Значение";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(12, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "OPC Tag Точки";
            // 
            // PointTag3
            // 
            this.PointTag3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointTag3.Location = new System.Drawing.Point(125, 7);
            this.PointTag3.Name = "PointTag3";
            this.PointTag3.Size = new System.Drawing.Size(204, 22);
            this.PointTag3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.PointType4);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.PointValue4);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.PointTag4);
            this.panel4.Location = new System.Drawing.Point(395, 204);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(348, 83);
            this.panel4.TabIndex = 27;
            // 
            // PointType4
            // 
            this.PointType4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointType4.FormattingEnabled = true;
            this.PointType4.Items.AddRange(new object[] {
            "Bool",
            "Int32",
            "Int8",
            "Int16",
            "UInt16",
            "Float",
            "Double"});
            this.PointType4.Location = new System.Drawing.Point(125, 28);
            this.PointType4.Name = "PointType4";
            this.PointType4.Size = new System.Drawing.Size(204, 24);
            this.PointType4.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(36, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 16);
            this.label12.TabIndex = 18;
            this.label12.Text = "Тип данных";
            // 
            // PointValue4
            // 
            this.PointValue4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointValue4.Location = new System.Drawing.Point(125, 52);
            this.PointValue4.Name = "PointValue4";
            this.PointValue4.Size = new System.Drawing.Size(204, 22);
            this.PointValue4.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(46, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 16;
            this.label13.Text = "Значение";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(12, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 16);
            this.label14.TabIndex = 14;
            this.label14.Text = "OPC Tag Точки";
            // 
            // PointTag4
            // 
            this.PointTag4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PointTag4.Location = new System.Drawing.Point(125, 7);
            this.PointTag4.Name = "PointTag4";
            this.PointTag4.Size = new System.Drawing.Size(204, 22);
            this.PointTag4.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(787, 346);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.OPCServerName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butCheck);
            this.Controls.Add(this.butCheckRec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Node);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PointValue1;
        private System.Windows.Forms.ComboBox PointType1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butCheckRec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PointTag1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Node;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox OPCServerName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox PointType2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PointValue2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PointTag2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox PointType3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PointValue3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox PointTag3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox PointType4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox PointValue4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox PointTag4;
    }
}

