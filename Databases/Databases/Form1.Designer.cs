namespace Databases
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butReadAccess = new System.Windows.Forms.Button();
            this.butRunAccess = new System.Windows.Forms.Button();
            this.butInsertAccess = new System.Windows.Forms.Button();
            this.butMegaInsertAccess = new System.Windows.Forms.Button();
            this.butUpdateDeleteAccess = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.butReadSQL = new System.Windows.Forms.Button();
            this.butInsertSQL = new System.Windows.Forms.Button();
            this.butMegaInsertSQL = new System.Windows.Forms.Button();
            this.butSimpleLinkToSQL = new System.Windows.Forms.Button();
            this.butMegaLinqToSQL = new System.Windows.Forms.Button();
            this.butReadLinq = new System.Windows.Forms.Button();
            this.butUpdateLinq = new System.Windows.Forms.Button();
            this.butRunSQL = new System.Windows.Forms.Button();
            this.butReadCompact = new System.Windows.Forms.Button();
            this.butReadLinqContext = new System.Windows.Forms.Button();
            this.butInsertDAO = new System.Windows.Forms.Button();
            this.butMegaInsertDAO = new System.Windows.Forms.Button();
            this.butInsertIDAO = new System.Windows.Forms.Button();
            this.butReadOdbcAccess = new System.Windows.Forms.Button();
            this.butInsertOdbcAccess = new System.Windows.Forms.Button();
            this.butMegaInsertOdbcAccess = new System.Windows.Forms.Button();
            this.butInsertOdbcSQL = new System.Windows.Forms.Button();
            this.butMegaInsertOdbcSQL = new System.Windows.Forms.Button();
            this.butInsertADOSQL = new System.Windows.Forms.Button();
            this.butMegaInsertADOSQL = new System.Windows.Forms.Button();
            this.butMegaInsertCompact = new System.Windows.Forms.Button();
            this.butReadCompactDirect = new System.Windows.Forms.Button();
            this.butInsertCompactDirect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butReadAccess
            // 
            this.butReadAccess.Location = new System.Drawing.Point(12, 12);
            this.butReadAccess.Name = "butReadAccess";
            this.butReadAccess.Size = new System.Drawing.Size(138, 31);
            this.butReadAccess.TabIndex = 0;
            this.butReadAccess.Text = "ReadAccess";
            this.butReadAccess.UseVisualStyleBackColor = true;
            this.butReadAccess.Click += new System.EventHandler(this.butReadAccess_Click);
            // 
            // butRunAccess
            // 
            this.butRunAccess.Location = new System.Drawing.Point(12, 49);
            this.butRunAccess.Name = "butRunAccess";
            this.butRunAccess.Size = new System.Drawing.Size(138, 31);
            this.butRunAccess.TabIndex = 1;
            this.butRunAccess.Text = "RunAccess";
            this.butRunAccess.UseVisualStyleBackColor = true;
            this.butRunAccess.Click += new System.EventHandler(this.butRunAccess_Click);
            // 
            // butInsertAccess
            // 
            this.butInsertAccess.Location = new System.Drawing.Point(12, 86);
            this.butInsertAccess.Name = "butInsertAccess";
            this.butInsertAccess.Size = new System.Drawing.Size(138, 34);
            this.butInsertAccess.TabIndex = 2;
            this.butInsertAccess.Text = "InsertAccess";
            this.butInsertAccess.UseVisualStyleBackColor = true;
            this.butInsertAccess.Click += new System.EventHandler(this.butInsertAccess_Click);
            // 
            // butMegaInsertAccess
            // 
            this.butMegaInsertAccess.Location = new System.Drawing.Point(12, 126);
            this.butMegaInsertAccess.Name = "butMegaInsertAccess";
            this.butMegaInsertAccess.Size = new System.Drawing.Size(138, 35);
            this.butMegaInsertAccess.TabIndex = 3;
            this.butMegaInsertAccess.Text = "MegaInsertAccess";
            this.butMegaInsertAccess.UseVisualStyleBackColor = true;
            this.butMegaInsertAccess.Click += new System.EventHandler(this.butMegaInsertAccess_Click);
            // 
            // butUpdateDeleteAccess
            // 
            this.butUpdateDeleteAccess.Location = new System.Drawing.Point(12, 167);
            this.butUpdateDeleteAccess.Name = "butUpdateDeleteAccess";
            this.butUpdateDeleteAccess.Size = new System.Drawing.Size(138, 35);
            this.butUpdateDeleteAccess.TabIndex = 4;
            this.butUpdateDeleteAccess.Text = "UpdateDeleteAccess";
            this.butUpdateDeleteAccess.UseVisualStyleBackColor = true;
            this.butUpdateDeleteAccess.Click += new System.EventHandler(this.butUpdateDeleteAccess_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // butReadSQL
            // 
            this.butReadSQL.Location = new System.Drawing.Point(631, 12);
            this.butReadSQL.Name = "butReadSQL";
            this.butReadSQL.Size = new System.Drawing.Size(133, 31);
            this.butReadSQL.TabIndex = 5;
            this.butReadSQL.Text = "ReadSQL";
            this.butReadSQL.UseVisualStyleBackColor = true;
            this.butReadSQL.Click += new System.EventHandler(this.butReadSQL_Click);
            // 
            // butInsertSQL
            // 
            this.butInsertSQL.Location = new System.Drawing.Point(631, 86);
            this.butInsertSQL.Name = "butInsertSQL";
            this.butInsertSQL.Size = new System.Drawing.Size(133, 34);
            this.butInsertSQL.TabIndex = 6;
            this.butInsertSQL.Text = "InsertSQL";
            this.butInsertSQL.UseVisualStyleBackColor = true;
            this.butInsertSQL.Click += new System.EventHandler(this.butInsertSQL_Click);
            // 
            // butMegaInsertSQL
            // 
            this.butMegaInsertSQL.Location = new System.Drawing.Point(631, 126);
            this.butMegaInsertSQL.Name = "butMegaInsertSQL";
            this.butMegaInsertSQL.Size = new System.Drawing.Size(133, 36);
            this.butMegaInsertSQL.TabIndex = 7;
            this.butMegaInsertSQL.Text = "MegaInsertSQL";
            this.butMegaInsertSQL.UseVisualStyleBackColor = true;
            this.butMegaInsertSQL.Click += new System.EventHandler(this.butMegaInsertSQL_Click);
            // 
            // butSimpleLinkToSQL
            // 
            this.butSimpleLinkToSQL.Location = new System.Drawing.Point(769, 86);
            this.butSimpleLinkToSQL.Name = "butSimpleLinkToSQL";
            this.butSimpleLinkToSQL.Size = new System.Drawing.Size(135, 33);
            this.butSimpleLinkToSQL.TabIndex = 8;
            this.butSimpleLinkToSQL.Text = "SimpleLinkToSQL";
            this.butSimpleLinkToSQL.UseVisualStyleBackColor = true;
            this.butSimpleLinkToSQL.Click += new System.EventHandler(this.butSimpleLinkToSQL_Click);
            // 
            // butMegaLinqToSQL
            // 
            this.butMegaLinqToSQL.Location = new System.Drawing.Point(769, 126);
            this.butMegaLinqToSQL.Name = "butMegaLinqToSQL";
            this.butMegaLinqToSQL.Size = new System.Drawing.Size(135, 35);
            this.butMegaLinqToSQL.TabIndex = 9;
            this.butMegaLinqToSQL.Text = "butMegaLinqToSQL";
            this.butMegaLinqToSQL.UseVisualStyleBackColor = true;
            this.butMegaLinqToSQL.Click += new System.EventHandler(this.butMegaLinqToSQL_Click);
            // 
            // butReadLinq
            // 
            this.butReadLinq.Location = new System.Drawing.Point(769, 12);
            this.butReadLinq.Name = "butReadLinq";
            this.butReadLinq.Size = new System.Drawing.Size(135, 31);
            this.butReadLinq.TabIndex = 10;
            this.butReadLinq.Text = "ReadLinq";
            this.butReadLinq.UseVisualStyleBackColor = true;
            this.butReadLinq.Click += new System.EventHandler(this.butReadLinq_Click);
            // 
            // butUpdateLinq
            // 
            this.butUpdateLinq.Location = new System.Drawing.Point(769, 167);
            this.butUpdateLinq.Name = "butUpdateLinq";
            this.butUpdateLinq.Size = new System.Drawing.Size(135, 35);
            this.butUpdateLinq.TabIndex = 11;
            this.butUpdateLinq.Text = "UpdateDeleteLinq";
            this.butUpdateLinq.UseVisualStyleBackColor = true;
            this.butUpdateLinq.Click += new System.EventHandler(this.butUpdateLinq_Click);
            // 
            // butRunSQL
            // 
            this.butRunSQL.Location = new System.Drawing.Point(631, 50);
            this.butRunSQL.Name = "butRunSQL";
            this.butRunSQL.Size = new System.Drawing.Size(133, 30);
            this.butRunSQL.TabIndex = 12;
            this.butRunSQL.Text = "RunSQL";
            this.butRunSQL.UseVisualStyleBackColor = true;
            this.butRunSQL.Click += new System.EventHandler(this.butRunSQL_Click);
            // 
            // butReadCompact
            // 
            this.butReadCompact.Location = new System.Drawing.Point(304, 89);
            this.butReadCompact.Name = "butReadCompact";
            this.butReadCompact.Size = new System.Drawing.Size(144, 31);
            this.butReadCompact.TabIndex = 13;
            this.butReadCompact.Text = "ReadCompact";
            this.butReadCompact.UseVisualStyleBackColor = true;
            this.butReadCompact.Click += new System.EventHandler(this.butReadSQLCompact_Click);
            // 
            // butReadLinqContext
            // 
            this.butReadLinqContext.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.butReadLinqContext.Location = new System.Drawing.Point(771, 51);
            this.butReadLinqContext.Name = "butReadLinqContext";
            this.butReadLinqContext.Size = new System.Drawing.Size(132, 28);
            this.butReadLinqContext.TabIndex = 14;
            this.butReadLinqContext.Text = "ReadLinqContext";
            this.butReadLinqContext.UseVisualStyleBackColor = true;
            this.butReadLinqContext.Click += new System.EventHandler(this.butReadLinqContext_Click);
            // 
            // butInsertDAO
            // 
            this.butInsertDAO.Location = new System.Drawing.Point(156, 12);
            this.butInsertDAO.Name = "butInsertDAO";
            this.butInsertDAO.Size = new System.Drawing.Size(142, 31);
            this.butInsertDAO.TabIndex = 15;
            this.butInsertDAO.Text = "InsertDAO";
            this.butInsertDAO.UseVisualStyleBackColor = true;
            this.butInsertDAO.Click += new System.EventHandler(this.butInsertDAO_Click);
            // 
            // butMegaInsertDAO
            // 
            this.butMegaInsertDAO.Location = new System.Drawing.Point(156, 49);
            this.butMegaInsertDAO.Name = "butMegaInsertDAO";
            this.butMegaInsertDAO.Size = new System.Drawing.Size(142, 31);
            this.butMegaInsertDAO.TabIndex = 16;
            this.butMegaInsertDAO.Text = "MegaInsertDAO";
            this.butMegaInsertDAO.UseVisualStyleBackColor = true;
            this.butMegaInsertDAO.Click += new System.EventHandler(this.butMegaInsertDAO_Click);
            // 
            // butInsertIDAO
            // 
            this.butInsertIDAO.Location = new System.Drawing.Point(156, 86);
            this.butInsertIDAO.Name = "butInsertIDAO";
            this.butInsertIDAO.Size = new System.Drawing.Size(142, 33);
            this.butInsertIDAO.TabIndex = 17;
            this.butInsertIDAO.Text = "InsertIDAO";
            this.butInsertIDAO.UseVisualStyleBackColor = true;
            this.butInsertIDAO.Click += new System.EventHandler(this.butInsertIDAO_Click);
            // 
            // butReadOdbcAccess
            // 
            this.butReadOdbcAccess.Location = new System.Drawing.Point(12, 250);
            this.butReadOdbcAccess.Name = "butReadOdbcAccess";
            this.butReadOdbcAccess.Size = new System.Drawing.Size(138, 31);
            this.butReadOdbcAccess.TabIndex = 18;
            this.butReadOdbcAccess.Text = "ReadOdbcAccess";
            this.butReadOdbcAccess.UseVisualStyleBackColor = true;
            this.butReadOdbcAccess.Click += new System.EventHandler(this.butReadOdbcAccess_Click);
            // 
            // butInsertOdbcAccess
            // 
            this.butInsertOdbcAccess.Location = new System.Drawing.Point(12, 287);
            this.butInsertOdbcAccess.Name = "butInsertOdbcAccess";
            this.butInsertOdbcAccess.Size = new System.Drawing.Size(138, 34);
            this.butInsertOdbcAccess.TabIndex = 19;
            this.butInsertOdbcAccess.Text = "InsertOdbcAccess";
            this.butInsertOdbcAccess.UseVisualStyleBackColor = true;
            this.butInsertOdbcAccess.Click += new System.EventHandler(this.butInsertOdbcAccess_Click);
            // 
            // butMegaInsertOdbcAccess
            // 
            this.butMegaInsertOdbcAccess.Location = new System.Drawing.Point(12, 327);
            this.butMegaInsertOdbcAccess.Name = "butMegaInsertOdbcAccess";
            this.butMegaInsertOdbcAccess.Size = new System.Drawing.Size(138, 35);
            this.butMegaInsertOdbcAccess.TabIndex = 20;
            this.butMegaInsertOdbcAccess.Text = "MegaInsertOdbcAccess";
            this.butMegaInsertOdbcAccess.UseVisualStyleBackColor = true;
            this.butMegaInsertOdbcAccess.Click += new System.EventHandler(this.butMegaInsertOdbcAccess_Click);
            // 
            // butInsertOdbcSQL
            // 
            this.butInsertOdbcSQL.Location = new System.Drawing.Point(631, 202);
            this.butInsertOdbcSQL.Name = "butInsertOdbcSQL";
            this.butInsertOdbcSQL.Size = new System.Drawing.Size(133, 34);
            this.butInsertOdbcSQL.TabIndex = 21;
            this.butInsertOdbcSQL.Text = "InsertOdbcSQL";
            this.butInsertOdbcSQL.UseVisualStyleBackColor = true;
            this.butInsertOdbcSQL.Click += new System.EventHandler(this.butInsertOdbcSQL_Click_1);
            // 
            // butMegaInsertOdbcSQL
            // 
            this.butMegaInsertOdbcSQL.Location = new System.Drawing.Point(631, 242);
            this.butMegaInsertOdbcSQL.Name = "butMegaInsertOdbcSQL";
            this.butMegaInsertOdbcSQL.Size = new System.Drawing.Size(133, 35);
            this.butMegaInsertOdbcSQL.TabIndex = 22;
            this.butMegaInsertOdbcSQL.Text = "MegaInsertOdbcSQL";
            this.butMegaInsertOdbcSQL.UseVisualStyleBackColor = true;
            this.butMegaInsertOdbcSQL.Click += new System.EventHandler(this.butMegaInsertOdbcSQL_Click);
            // 
            // butInsertADOSQL
            // 
            this.butInsertADOSQL.Location = new System.Drawing.Point(631, 286);
            this.butInsertADOSQL.Name = "butInsertADOSQL";
            this.butInsertADOSQL.Size = new System.Drawing.Size(133, 34);
            this.butInsertADOSQL.TabIndex = 23;
            this.butInsertADOSQL.Text = "InsertADOSQL";
            this.butInsertADOSQL.UseVisualStyleBackColor = true;
            this.butInsertADOSQL.Click += new System.EventHandler(this.butInsertADOSQL_Click);
            // 
            // butMegaInsertADOSQL
            // 
            this.butMegaInsertADOSQL.Location = new System.Drawing.Point(631, 327);
            this.butMegaInsertADOSQL.Name = "butMegaInsertADOSQL";
            this.butMegaInsertADOSQL.Size = new System.Drawing.Size(133, 34);
            this.butMegaInsertADOSQL.TabIndex = 24;
            this.butMegaInsertADOSQL.Text = "MegaInsertADOSQL";
            this.butMegaInsertADOSQL.UseVisualStyleBackColor = true;
            this.butMegaInsertADOSQL.Click += new System.EventHandler(this.butMegaInsertADOSQL_Click);
            // 
            // butMegaInsertCompact
            // 
            this.butMegaInsertCompact.Location = new System.Drawing.Point(304, 127);
            this.butMegaInsertCompact.Name = "butMegaInsertCompact";
            this.butMegaInsertCompact.Size = new System.Drawing.Size(144, 34);
            this.butMegaInsertCompact.TabIndex = 25;
            this.butMegaInsertCompact.Text = "MegaInsertCompact";
            this.butMegaInsertCompact.UseVisualStyleBackColor = true;
            this.butMegaInsertCompact.Click += new System.EventHandler(this.butMegaInsertCompact_Click);
            // 
            // butReadCompactDirect
            // 
            this.butReadCompactDirect.Location = new System.Drawing.Point(304, 12);
            this.butReadCompactDirect.Name = "butReadCompactDirect";
            this.butReadCompactDirect.Size = new System.Drawing.Size(144, 31);
            this.butReadCompactDirect.TabIndex = 26;
            this.butReadCompactDirect.Text = "ReadCompactDirect";
            this.butReadCompactDirect.UseVisualStyleBackColor = true;
            this.butReadCompactDirect.Click += new System.EventHandler(this.butReadCompactDirect_Click);
            // 
            // butInsertCompactDirect
            // 
            this.butInsertCompactDirect.Location = new System.Drawing.Point(304, 49);
            this.butInsertCompactDirect.Name = "butInsertCompactDirect";
            this.butInsertCompactDirect.Size = new System.Drawing.Size(144, 31);
            this.butInsertCompactDirect.TabIndex = 27;
            this.butInsertCompactDirect.Text = "MegaInsertCompactDirect";
            this.butInsertCompactDirect.UseVisualStyleBackColor = true;
            this.butInsertCompactDirect.Click += new System.EventHandler(this.butMegaInsertCompactDirect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 419);
            this.Controls.Add(this.butInsertCompactDirect);
            this.Controls.Add(this.butReadCompactDirect);
            this.Controls.Add(this.butMegaInsertCompact);
            this.Controls.Add(this.butMegaInsertADOSQL);
            this.Controls.Add(this.butInsertADOSQL);
            this.Controls.Add(this.butMegaInsertOdbcSQL);
            this.Controls.Add(this.butInsertOdbcSQL);
            this.Controls.Add(this.butMegaInsertOdbcAccess);
            this.Controls.Add(this.butInsertOdbcAccess);
            this.Controls.Add(this.butReadOdbcAccess);
            this.Controls.Add(this.butInsertIDAO);
            this.Controls.Add(this.butMegaInsertDAO);
            this.Controls.Add(this.butInsertDAO);
            this.Controls.Add(this.butReadLinqContext);
            this.Controls.Add(this.butReadCompact);
            this.Controls.Add(this.butRunSQL);
            this.Controls.Add(this.butUpdateLinq);
            this.Controls.Add(this.butReadLinq);
            this.Controls.Add(this.butMegaLinqToSQL);
            this.Controls.Add(this.butSimpleLinkToSQL);
            this.Controls.Add(this.butMegaInsertSQL);
            this.Controls.Add(this.butInsertSQL);
            this.Controls.Add(this.butReadSQL);
            this.Controls.Add(this.butUpdateDeleteAccess);
            this.Controls.Add(this.butMegaInsertAccess);
            this.Controls.Add(this.butInsertAccess);
            this.Controls.Add(this.butRunAccess);
            this.Controls.Add(this.butReadAccess);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butReadAccess;
        private System.Windows.Forms.Button butRunAccess;
        private System.Windows.Forms.Button butInsertAccess;
        private System.Windows.Forms.Button butMegaInsertAccess;
        private System.Windows.Forms.Button butUpdateDeleteAccess;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button butReadSQL;
        private System.Windows.Forms.Button butInsertSQL;
        private System.Windows.Forms.Button butMegaInsertSQL;
        private System.Windows.Forms.Button butSimpleLinkToSQL;
        private System.Windows.Forms.Button butMegaLinqToSQL;
        private System.Windows.Forms.Button butReadLinq;
        private System.Windows.Forms.Button butUpdateLinq;
        private System.Windows.Forms.Button butRunSQL;
        private System.Windows.Forms.Button butReadCompact;
        private System.Windows.Forms.Button butReadLinqContext;
        private System.Windows.Forms.Button butInsertDAO;
        private System.Windows.Forms.Button butMegaInsertDAO;
        private System.Windows.Forms.Button butInsertIDAO;
        private System.Windows.Forms.Button butReadOdbcAccess;
        private System.Windows.Forms.Button butInsertOdbcAccess;
        private System.Windows.Forms.Button butMegaInsertOdbcAccess;
        private System.Windows.Forms.Button butInsertOdbcSQL;
        private System.Windows.Forms.Button butMegaInsertOdbcSQL;
        private System.Windows.Forms.Button butInsertADOSQL;
        private System.Windows.Forms.Button butMegaInsertADOSQL;
        private System.Windows.Forms.Button butMegaInsertCompact;
        private System.Windows.Forms.Button butReadCompactDirect;
        private System.Windows.Forms.Button butInsertCompactDirect;
    }
}

