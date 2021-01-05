namespace NotificationMaker
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrBeforOnDay = new System.Windows.Forms.Timer(this.components);
            this.bwBD = new System.ComponentModel.BackgroundWorker();
            this.tmrDU = new System.Windows.Forms.Timer(this.components);
            this.bwDU = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ETAPM";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 39);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(508, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(21, 107);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(508, 228);
            this.listBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Log";
            // 
            // tmrBeforOnDay
            // 
            this.tmrBeforOnDay.Enabled = true;
            this.tmrBeforOnDay.Interval = 4320000;
            this.tmrBeforOnDay.Tick += new System.EventHandler(this.tmrBeforOnDay_Tick);
            // 
            // bwBD
            // 
            this.bwBD.WorkerReportsProgress = true;
            this.bwBD.WorkerSupportsCancellation = true;
            this.bwBD.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwBD_DoWork);
            this.bwBD.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwBD_ProgressChanged);
            this.bwBD.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwBD_RunWorkerCompleted);
            // 
            // tmrDU
            // 
            this.tmrDU.Enabled = true;
            this.tmrDU.Interval = 60000;
            this.tmrDU.Tick += new System.EventHandler(this.tmrDU_Tick);
            // 
            // bwDU
            // 
            this.bwDU.WorkerReportsProgress = true;
            this.bwDU.WorkerSupportsCancellation = true;
            this.bwDU.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDU_DoWork);
            this.bwDU.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwDU_ProgressChanged);
            this.bwDU.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDU_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(553, 359);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrBeforOnDay;
        private System.ComponentModel.BackgroundWorker bwBD;
        private System.Windows.Forms.Timer tmrDU;
        private System.ComponentModel.BackgroundWorker bwDU;
    }
}