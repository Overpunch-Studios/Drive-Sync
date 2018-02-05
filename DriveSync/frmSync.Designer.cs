namespace DriveSync
{
    partial class frmSync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSync));
            this.Btn_Sync = new System.Windows.Forms.Button();
            this.SyncOptions = new System.Windows.Forms.Button();
            this.FromLocationSync = new System.Windows.Forms.Label();
            this.ToLocationSync = new System.Windows.Forms.Label();
            this.SyncProgress = new System.Windows.Forms.ProgressBar();
            this.FileLeftCounter = new System.Windows.Forms.Label();
            this.SyncLog = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Help = new System.Windows.Forms.ToolStripButton();
            this.Copying = new System.ComponentModel.BackgroundWorker();
            this.StopSync = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Sync
            // 
            this.Btn_Sync.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Sync.Location = new System.Drawing.Point(12, 38);
            this.Btn_Sync.Name = "Btn_Sync";
            this.Btn_Sync.Size = new System.Drawing.Size(89, 32);
            this.Btn_Sync.TabIndex = 1;
            this.Btn_Sync.Text = "Sync";
            this.Btn_Sync.UseVisualStyleBackColor = true;
            this.Btn_Sync.Click += new System.EventHandler(this.Btn_Sync_Click);
            // 
            // SyncOptions
            // 
            this.SyncOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyncOptions.Location = new System.Drawing.Point(613, 37);
            this.SyncOptions.Name = "SyncOptions";
            this.SyncOptions.Size = new System.Drawing.Size(89, 32);
            this.SyncOptions.TabIndex = 2;
            this.SyncOptions.Text = "Options";
            this.SyncOptions.UseVisualStyleBackColor = true;
            this.SyncOptions.Click += new System.EventHandler(this.SyncOptions_Click);
            // 
            // FromLocationSync
            // 
            this.FromLocationSync.AutoSize = true;
            this.FromLocationSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromLocationSync.Location = new System.Drawing.Point(13, 82);
            this.FromLocationSync.Name = "FromLocationSync";
            this.FromLocationSync.Size = new System.Drawing.Size(87, 20);
            this.FromLocationSync.TabIndex = 4;
            this.FromLocationSync.Text = "Location 1:";
            // 
            // ToLocationSync
            // 
            this.ToLocationSync.AutoSize = true;
            this.ToLocationSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToLocationSync.Location = new System.Drawing.Point(13, 110);
            this.ToLocationSync.Name = "ToLocationSync";
            this.ToLocationSync.Size = new System.Drawing.Size(87, 20);
            this.ToLocationSync.TabIndex = 5;
            this.ToLocationSync.Text = "Location 2:";
            // 
            // SyncProgress
            // 
            this.SyncProgress.Location = new System.Drawing.Point(12, 141);
            this.SyncProgress.Name = "SyncProgress";
            this.SyncProgress.Size = new System.Drawing.Size(690, 33);
            this.SyncProgress.Step = 1;
            this.SyncProgress.TabIndex = 6;
            // 
            // FileLeftCounter
            // 
            this.FileLeftCounter.AutoSize = true;
            this.FileLeftCounter.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLeftCounter.Location = new System.Drawing.Point(12, 184);
            this.FileLeftCounter.Name = "FileLeftCounter";
            this.FileLeftCounter.Size = new System.Drawing.Size(140, 19);
            this.FileLeftCounter.TabIndex = 7;
            this.FileLeftCounter.Text = "Files/Folders Left:";
            // 
            // SyncLog
            // 
            this.SyncLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SyncLog.FormattingEnabled = true;
            this.SyncLog.ItemHeight = 16;
            this.SyncLog.Location = new System.Drawing.Point(12, 215);
            this.SyncLog.Name = "SyncLog";
            this.SyncLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.SyncLog.Size = new System.Drawing.Size(690, 116);
            this.SyncLog.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(714, 22);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Help
            // 
            this.Help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Help.Image = ((System.Drawing.Image)(resources.GetObject("Help.Image")));
            this.Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(37, 19);
            this.Help.Text = "Help";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // StopSync
            // 
            this.StopSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopSync.Location = new System.Drawing.Point(107, 38);
            this.StopSync.Name = "StopSync";
            this.StopSync.Size = new System.Drawing.Size(94, 32);
            this.StopSync.TabIndex = 10;
            this.StopSync.Text = "Stop Sync";
            this.StopSync.UseVisualStyleBackColor = true;
            this.StopSync.Click += new System.EventHandler(this.StopSync_Click);
            // 
            // frmSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(714, 347);
            this.Controls.Add(this.StopSync);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.SyncLog);
            this.Controls.Add(this.FileLeftCounter);
            this.Controls.Add(this.SyncProgress);
            this.Controls.Add(this.ToLocationSync);
            this.Controls.Add(this.FromLocationSync);
            this.Controls.Add(this.SyncOptions);
            this.Controls.Add(this.Btn_Sync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSync";
            this.Text = "Drive-Sync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSync_FormClosing);
            this.Shown += new System.EventHandler(this.FrmSync_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_Sync;
        private System.Windows.Forms.Button SyncOptions;
        public System.Windows.Forms.Label FromLocationSync;
        public System.Windows.Forms.Label ToLocationSync;
        private System.Windows.Forms.ProgressBar SyncProgress;
        private System.Windows.Forms.Label FileLeftCounter;
        private System.Windows.Forms.ListBox SyncLog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Help;
        private System.ComponentModel.BackgroundWorker Copying;
        private System.Windows.Forms.Button StopSync;
    }
}

