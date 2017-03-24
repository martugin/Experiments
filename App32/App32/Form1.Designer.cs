namespace App32
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
            this.ButDao = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ButDao64 = new System.Windows.Forms.Button();
            this.ButAny = new System.Windows.Forms.Button();
            this.ButKosmAny = new System.Windows.Forms.Button();
            this.ButKosm = new System.Windows.Forms.Button();
            this.ButKosmLib32 = new System.Windows.Forms.Button();
            this.ButKosmLib64 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButDao
            // 
            this.ButDao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButDao.Location = new System.Drawing.Point(12, 8);
            this.ButDao.Name = "ButDao";
            this.ButDao.Size = new System.Drawing.Size(198, 54);
            this.ButDao.TabIndex = 0;
            this.ButDao.Text = "DAO";
            this.ButDao.UseVisualStyleBackColor = true;
            this.ButDao.Click += new System.EventHandler(this.ButDao_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "DAO Lib32";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButDao64
            // 
            this.ButDao64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButDao64.Location = new System.Drawing.Point(12, 128);
            this.ButDao64.Name = "ButDao64";
            this.ButDao64.Size = new System.Drawing.Size(198, 54);
            this.ButDao64.TabIndex = 2;
            this.ButDao64.Text = "DAO Lib64";
            this.ButDao64.UseVisualStyleBackColor = true;
            this.ButDao64.Click += new System.EventHandler(this.ButDao64_Click);
            // 
            // ButAny
            // 
            this.ButAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButAny.Location = new System.Drawing.Point(12, 188);
            this.ButAny.Name = "ButAny";
            this.ButAny.Size = new System.Drawing.Size(198, 54);
            this.ButAny.TabIndex = 3;
            this.ButAny.Text = "DAO LibAny";
            this.ButAny.UseVisualStyleBackColor = true;
            this.ButAny.Click += new System.EventHandler(this.ButAny_Click);
            // 
            // ButKosmAny
            // 
            this.ButKosmAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButKosmAny.Location = new System.Drawing.Point(234, 188);
            this.ButKosmAny.Name = "ButKosmAny";
            this.ButKosmAny.Size = new System.Drawing.Size(198, 54);
            this.ButKosmAny.TabIndex = 5;
            this.ButKosmAny.Text = "Kosm LibAny";
            this.ButKosmAny.UseVisualStyleBackColor = true;
            this.ButKosmAny.Click += new System.EventHandler(this.ButKosmAny_Click);
            // 
            // ButKosm
            // 
            this.ButKosm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButKosm.Location = new System.Drawing.Point(234, 8);
            this.ButKosm.Name = "ButKosm";
            this.ButKosm.Size = new System.Drawing.Size(198, 54);
            this.ButKosm.TabIndex = 6;
            this.ButKosm.Text = "Kosm";
            this.ButKosm.UseVisualStyleBackColor = true;
            this.ButKosm.Click += new System.EventHandler(this.ButKosm_Click);
            // 
            // ButKosmLib32
            // 
            this.ButKosmLib32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButKosmLib32.Location = new System.Drawing.Point(234, 68);
            this.ButKosmLib32.Name = "ButKosmLib32";
            this.ButKosmLib32.Size = new System.Drawing.Size(198, 54);
            this.ButKosmLib32.TabIndex = 7;
            this.ButKosmLib32.Text = "Kosm Lib32";
            this.ButKosmLib32.UseVisualStyleBackColor = true;
            this.ButKosmLib32.Click += new System.EventHandler(this.ButKosmLib32_Click);
            // 
            // ButKosmLib64
            // 
            this.ButKosmLib64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButKosmLib64.Location = new System.Drawing.Point(234, 128);
            this.ButKosmLib64.Name = "ButKosmLib64";
            this.ButKosmLib64.Size = new System.Drawing.Size(198, 54);
            this.ButKosmLib64.TabIndex = 8;
            this.ButKosmLib64.Text = "Kosm Lib64";
            this.ButKosmLib64.UseVisualStyleBackColor = true;
            this.ButKosmLib64.Click += new System.EventHandler(this.ButKosmLib64_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 269);
            this.Controls.Add(this.ButKosmLib64);
            this.Controls.Add(this.ButKosmLib32);
            this.Controls.Add(this.ButKosm);
            this.Controls.Add(this.ButKosmAny);
            this.Controls.Add(this.ButAny);
            this.Controls.Add(this.ButDao64);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButDao);
            this.Name = "Form1";
            this.Text = "32 bit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButDao;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ButDao64;
        private System.Windows.Forms.Button ButAny;
        private System.Windows.Forms.Button ButKosmAny;
        private System.Windows.Forms.Button ButKosm;
        private System.Windows.Forms.Button ButKosmLib32;
        private System.Windows.Forms.Button ButKosmLib64;
    }
}

