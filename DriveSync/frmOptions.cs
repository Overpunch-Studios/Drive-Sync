using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveSync
{
    public partial class frmOptions : Form
    {
        private frmSync frmSync;
        private string location2;
        private string location1;
        private string cfgName;
        private string dest;
        private bool save;

        //Shows the Options form
        public frmOptions(frmSync frmSync, string cfgName)
        {
            InitializeComponent();
            this.frmSync = frmSync;
            this.cfgName = cfgName;
            location2 = "";
            location1 = "";
            dest = "";
            save = false;
        }

        //Sets the basic info from the config if it exists
        private void frmOptions_Load(object sender, EventArgs e)
        {
            LoadDrives();
            if (File.Exists(cfgName))
            {
                StreamReader reader = new StreamReader(cfgName);
                reader.ReadLine();
                string src = reader.ReadLine();
                FromLocationlbl.Text = "Location 1 (USB): " + src;
                reader.ReadLine();
                dest = reader.ReadLine();
                ToLocationlbl.Text = "Location 2: " + dest;
                reader.Close();
            }
        }

        //If it closes check if everything is setup
        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!save)
            {
                DialogResult resultExit = MessageBox.Show("Do you want to exit this program?", "Exit?", MessageBoxButtons.YesNo);
                if (resultExit == DialogResult.Yes)
                {
                    frmSync.Close();
                }
                else
                {
                    if (File.Exists(cfgName))
                        if (Directory.Exists(FromDriveSelect.SelectedItem.ToString().Split(' ')[1]) || Directory.Exists(location2))
                            frmSync.Show();
                        else
                        {
                            MessageBox.Show("Source location not found!\nCheck if your drive is connected");
                            e.Cancel = true;
                        }
                    else
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please setup the settings and press save.");
                    }
                }
            }
            else
            {
                if (File.Exists(cfgName))
                    if (Directory.Exists(FromDriveSelect.SelectedItem.ToString().Split(' ')[1]) || Directory.Exists(location2))
                        frmSync.Show();
                    else
                    {
                        MessageBox.Show("Source location not found!\nCheck if your drive is connected");
                        e.Cancel = true;
                    }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Please setup the settings and press save.");
                }
            }
        }

        //Loads all available drives
        private void LoadDrives()
        {
            DriveInfo[] listAllDrives = DriveInfo.GetDrives();
            List<string> drives = new List<string>();
            foreach(DriveInfo drive in listAllDrives)
            {
                if(drive.IsReady)
                    if(drive.VolumeLabel == "")
                        drives.Add("[" + drive.DriveType + "] " + drive.Name);
                    else
                        drives.Add("[" + drive.VolumeLabel + "] " + drive.Name);
            }
            FromDriveSelect.DataSource = drives;
        }


        //Selects the location on your computer to sync to
        private void SelectToBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            if (folderBrowser.SelectedPath != "" || folderBrowser.SelectedPath != null)
            {
                location2 = folderBrowser.SelectedPath;
                ToLocationlbl.Text = "Location 2: " + location2;
            }
        }


        //Save button to save everything to the config
        private void SaveLocationsBtn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(location2))
                location2 = dest;

            if (Directory.Exists(location2))
            {
                location1 = FromDriveSelect.SelectedItem.ToString().Split(' ')[1];
                DriveInfo[] listAllDrives = DriveInfo.GetDrives();
                bool driveExists = false;
                foreach (DriveInfo drive in listAllDrives)
                {
                    if (drive.IsReady)
                        if (drive.Name == location1)
                            driveExists = true;
                }
                if (driveExists)
                {
                    StreamWriter file = new StreamWriter(cfgName, false);
                    file.WriteLine("Location 1:");
                    file.WriteLine(location1);
                    file.WriteLine("Location 2:");
                    file.WriteLine(location2);
                    file.Close();

                    frmSync.FromLocationSync.Text = "Location 1: " + location1;
                    frmSync.ToLocationSync.Text = "Location 2: " + location2;

                    save = true;
                    this.Close();
                }
                else
                    MessageBox.Show("Your source folder '" + location1 + "' does not exist!\nCheck if your drive has been inserted and is correct.");
            }
            else
                MessageBox.Show("The destination folder: '" + location2 + "' does not exist!\nPlease check your settings.");
        }

        private void Btn_ReloadDrives_Click(object sender, EventArgs e)
        {
            LoadDrives();
        }
    }
}
