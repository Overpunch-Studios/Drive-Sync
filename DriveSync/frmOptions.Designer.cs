namespace DriveSync
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.SelectToBtn = new System.Windows.Forms.Button();
            this.ToLocationlbl = new System.Windows.Forms.Label();
            this.SaveLocationsBtn = new System.Windows.Forms.Button();
            this.FromDriveSelect = new System.Windows.Forms.ComboBox();
            this.FromLocationlbl = new System.Windows.Forms.Label();
            this.Btn_ReloadDrives = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectToBtn
            // 
            this.SelectToBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SelectToBtn.Location = new System.Drawing.Point(11, 100);
            this.SelectToBtn.Name = "SelectToBtn";
            this.SelectToBtn.Size = new System.Drawing.Size(153, 28);
            this.SelectToBtn.TabIndex = 3;
            this.SelectToBtn.Text = "Select location 2...";
            this.SelectToBtn.UseVisualStyleBackColor = true;
            this.SelectToBtn.Click += new System.EventHandler(this.SelectToBtn_Click);
            // 
            // ToLocationlbl
            // 
            this.ToLocationlbl.AutoSize = true;
            this.ToLocationlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ToLocationlbl.Location = new System.Drawing.Point(12, 71);
            this.ToLocationlbl.Name = "ToLocationlbl";
            this.ToLocationlbl.Size = new System.Drawing.Size(91, 20);
            this.ToLocationlbl.TabIndex = 2;
            this.ToLocationlbl.Text = "Location 2: ";
            // 
            // SaveLocationsBtn
            // 
            this.SaveLocationsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SaveLocationsBtn.Location = new System.Drawing.Point(574, 98);
            this.SaveLocationsBtn.Name = "SaveLocationsBtn";
            this.SaveLocationsBtn.Size = new System.Drawing.Size(75, 30);
            this.SaveLocationsBtn.TabIndex = 4;
            this.SaveLocationsBtn.Text = "Save";
            this.SaveLocationsBtn.UseVisualStyleBackColor = true;
            this.SaveLocationsBtn.Click += new System.EventHandler(this.SaveLocationsBtn_Click);
            // 
            // FromDriveSelect
            // 
            this.FromDriveSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FromDriveSelect.FormattingEnabled = true;
            this.FromDriveSelect.Location = new System.Drawing.Point(12, 33);
            this.FromDriveSelect.Name = "FromDriveSelect";
            this.FromDriveSelect.Size = new System.Drawing.Size(190, 28);
            this.FromDriveSelect.TabIndex = 6;
            // 
            // FromLocationlbl
            // 
            this.FromLocationlbl.AutoSize = true;
            this.FromLocationlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FromLocationlbl.Location = new System.Drawing.Point(12, 9);
            this.FromLocationlbl.Name = "FromLocationlbl";
            this.FromLocationlbl.Size = new System.Drawing.Size(139, 20);
            this.FromLocationlbl.TabIndex = 7;
            this.FromLocationlbl.Text = "Location 1 (USB): ";
            // 
            // Btn_ReloadDrives
            // 
            this.Btn_ReloadDrives.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Btn_ReloadDrives.Location = new System.Drawing.Point(208, 33);
            this.Btn_ReloadDrives.Name = "Btn_ReloadDrives";
            this.Btn_ReloadDrives.Size = new System.Drawing.Size(74, 28);
            this.Btn_ReloadDrives.TabIndex = 8;
            this.Btn_ReloadDrives.Text = "Reload";
            this.Btn_ReloadDrives.UseVisualStyleBackColor = true;
            this.Btn_ReloadDrives.Click += new System.EventHandler(this.Btn_ReloadDrives_Click);
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 140);
            this.Controls.Add(this.Btn_ReloadDrives);
            this.Controls.Add(this.FromLocationlbl);
            this.Controls.Add(this.FromDriveSelect);
            this.Controls.Add(this.SaveLocationsBtn);
            this.Controls.Add(this.SelectToBtn);
            this.Controls.Add(this.ToLocationlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.Text = "Drive-Sync Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptions_FormClosing);
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SelectToBtn;
        private System.Windows.Forms.Label ToLocationlbl;
        private System.Windows.Forms.Button SaveLocationsBtn;
        private System.Windows.Forms.ComboBox FromDriveSelect;
        private System.Windows.Forms.Label FromLocationlbl;
        private System.Windows.Forms.Button Btn_ReloadDrives;
    }
}