using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveSync
{
    public partial class frmSync : Form
    {
        private string cfgName = "drivesync.cfg";
        private string location1;
        private string location2;
        private int copyCountTotal;
        private int copyCountLeft;
        int count;
        string templateCountLeftText = "Files/Folders Left: ";
        bool stopSync;

        public frmSync()
        {
            InitializeComponent();
        }

        //Open Options form
        private void OpenOptions()
        {
            frmOptions frmOptions = new frmOptions(this, cfgName);
            frmOptions.Show();
        }

        //Check if the config is setup otherwise open the Options form
        private bool IsOptionsSetup()
        {
            if (File.Exists(cfgName))
            {
                StreamReader reader = new StreamReader(cfgName);
                if (reader.ReadLine().ToLower() == "location 1:")
                {
                    string line = reader.ReadLine();
                    if (Directory.Exists(line))
                    {
                        location1 = line;
                        if (reader.ReadLine().ToLower() == "location 2:")
                        {
                            line = reader.ReadLine();
                            if (Directory.Exists(line))
                            {
                                location2 = line;
                                reader.Close();
                                return true;
                            }
                            else
                                MessageBox.Show("Destination location not found!\nMake sure you selected the right folder!");
                        }
                    }
                    else
                        MessageBox.Show("Source location not found!\nCheck if your drive is connected!");
                }
                             
                reader.Close();
                return false;
            }
            else
            {
                return false;
            }
        }

        private void FrmSync_Shown(object sender, EventArgs e)
        {
            frmLoader loader = new frmLoader(this);
            loader.Show();
            this.Hide();
            CheckIfLoaded(loader);
            StopSync.Enabled = false;
        }

        
        private void Btn_Sync_Click(object sender, EventArgs e)
        {
            try
            {
                StartSync();
                CheckIfFinishedSyncing();
            }
            catch(Exception)
            {
                MessageBox.Show("Syncing failed!\nTry running as administrator.");
                SyncProgress.Value = 0;
                FileLeftCounter.Text = templateCountLeftText;
                count = 0;
            }
        }

        private void StartSync()
        {
            StopSync.Enabled = true;
            Btn_Sync.Enabled = false;
            stopSync = false;
            SyncLog.Items.Clear();
            count = 0;
            location1 = FromLocationSync.Text.Replace("Location 1: ", "");
            location2 = ToLocationSync.Text.Replace("Location 2: ", "");
            int location1Count = CountAllFilesAndFolders(location1);
            count = 0;
            int location2Count = CountAllFilesAndFolders(location2);
            copyCountTotal = location1Count + location2Count;
            copyCountLeft = copyCountTotal;
            SyncProgress.Maximum = copyCountTotal;
            FileLeftCounter.Text = templateCountLeftText + copyCountLeft.ToString();
            FileLeftCounter.Refresh();
            CopyFilesAndFolders(location1, location2);
        }

        //Check if everything is copied
        private async void CheckIfFinishedSyncing()
        {
            await Task.Delay(10);
            if ((SyncProgress.Value == SyncProgress.Maximum && copyCountLeft <= 0))
            {
                SyncLog.Items.Add("Syncronization Succesful! Synced " + copyCountTotal + " Files/Folders!");
                SyncLog.TopIndex = SyncLog.Items.Count - 1;
                FileLeftCounter.Text = templateCountLeftText + 0;
                MessageBox.Show("Syncing successful!", "Syncing successful!");
                SyncProgress.Value = 0;
                FileLeftCounter.Text = templateCountLeftText;
                count = 0;
                StopSync.Enabled = false;
                Btn_Sync.Enabled = true;
            }
            else if (stopSync)
            {
                SyncLog.Items.Add("Syncronization Cancelled! Synced " + copyCountTotal + " Files/Folders!");
                SyncLog.TopIndex = SyncLog.Items.Count - 1;
                FileLeftCounter.Text = templateCountLeftText + 0;
                MessageBox.Show("Syncing Cancelled!", "Syncing Cancelled!");
                SyncProgress.Value = 0;
                FileLeftCounter.Text = templateCountLeftText;
                count = 0;
                StopSync.Enabled = false;
                Btn_Sync.Enabled = true;
            }
            else
            {
                CheckIfFinishedSyncing();
            }
        }

        //Show Options Button
        private void SyncOptions_Click(object sender, EventArgs e)
        {
            OpenOptions();
            this.Hide();
        }

        //Counts all the files and folders needing for copy
        private int CountAllFilesAndFolders(string location)
        {
            try
            {
                foreach (string file in Directory.GetFiles(location))
                {
                    FileInfo info = new FileInfo(file);
                    if (!info.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        count++;
                    }
                }
                foreach (string directory in Directory.GetDirectories(location))
                {
                    DirectoryInfo dir = new DirectoryInfo(directory);
                    if (!dir.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        count++;
                        CountAllFilesAndFolders(directory);
                    }
                }
                return count;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Adds Logs in the list
        public void LogAdd(string filename, long percentage)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, long>(LogAdd), new object[] { filename, percentage });
                return;
            }
            Application.DoEvents();
            if(percentage == 0)
                SyncLog.Items.Add("["+ 0 + "] Copying: \"" + filename);
            else if(percentage >= 99)
            {
                try
                {
                    SyncLog.Items[SyncLog.Items.Count - 1] = "[OK] Copying: \"" + filename;
                }
                catch
                {
                    //SyncLog.Items.Add("[" + 0 + "] Copying: \"" + filename);
                    //SyncLog.Items[SyncLog.Items.Count - 1] = "[OK] Copying: \"" + filename;
                }
            }
            else
            {
                try
                {
                    SyncLog.Items[SyncLog.Items.Count - 1] = "[" + percentage + "%] Copying: \"" + filename;
                }
                catch
                {
                    //SyncLog.Items.Add("[" + 0 + "] Copying: \"" + filename);
                    //SyncLog.Items[SyncLog.Items.Count - 1] = "[" + percentage + "%] Copying: \"" + filename;
                }
            }
                

            SyncLog.TopIndex = SyncLog.Items.Count - 1;
        }

        //Updates the progress from the thread
        public void ProgressThread()
        {
            copyCountLeft--;
            UpdateProgressbarAndCheckProgress();
        }

        //Copy the Folders and starts the Copy Files Thread
        private void CopyFilesAndFolders(string source, string dest)
        {
            CopyTo(source, dest);
            foreach (string directory in Directory.GetDirectories(source))
            {
                DirectoryInfo dir = new DirectoryInfo(directory);
                if (!dir.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    string[] dirCut = directory.Split('\\');
                    string dirname = dirCut[dirCut.Length - 1];
                    if (!Directory.Exists(dest + "\\" + dirname))
                    {
                        Directory.CreateDirectory(dest + "\\" + dirname);
                    }
                    SyncLog.Items.Add("Creating directory in: \"" + dest + "\" called: \"" + dirname + "\"");
                    copyCountLeft--;
                    UpdateProgressbarAndCheckProgress();
                    SyncLog.TopIndex = SyncLog.Items.Count - 1;
                    CopyFilesAndFolders(source + "\\" + dirname, dest + "\\" + dirname);
                }
            }
        }

        public bool CopyTo(string source, string dest)
        {
            foreach (string file in Directory.GetFiles(source))
            {
                FileInfo info = new FileInfo(file);
                if (!info.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    string[] fileCut = file.Split('\\');
                    string filename = fileCut[fileCut.Length - 1];
                    if (File.Exists(dest + "\\" + filename))
                    {
                        DateTime file1 = File.GetLastWriteTime(file);
                        DateTime file2 = File.GetLastWriteTime(dest + "\\" + filename);
                        if (file1 > file2)
                        {
                            File.Copy(file, dest + "\\" + filename, true);
                            LogAdd(filename, 100);
                            ProgressThread();
                        }
                        else
                        {
                            LogAdd(filename, 100);
                            ProgressThread();
                        }
                    }

                    else
                    {
                        File.Copy(file, dest + "\\" + filename, true);
                        LogAdd(filename, 100);
                        ProgressThread();
                    }
                }
            }
            return true;
        }

        //Update the progress of copying the files and folders
        private void UpdateProgressbarAndCheckProgress()
        {
            SyncProgress.PerformStep();
            FileLeftCounter.Text = templateCountLeftText + copyCountLeft.ToString();
            if (copyCountLeft <= 0)
            {
                FileLeftCounter.Text = templateCountLeftText + 0;
                copyCountLeft = 0;
                SyncProgress.Value = SyncProgress.Maximum;
            }
        }

        //Shows the Info screen
        private void Help_Click(object sender, EventArgs e)
        {
            frmHelp frmHelp = new frmHelp();
            frmHelp.Show();
        }

        //Check if the load is finished
        private async void CheckIfLoaded(frmLoader loader)
        {
            await Task.Delay(1000);
            if (this.Visible)
            {
                if (loader.loaded)
                {
                    if (!IsOptionsSetup())
                    {
                        OpenOptions();
                        this.Hide();
                    }
                    else
                    {
                        FromLocationSync.Text = "Location 1: " + location1;
                        ToLocationSync.Text = "Location 2: " + location2;
                    }
                    SyncProgress.Value = 0;
                    FileLeftCounter.Text = templateCountLeftText;
                }
            }
            else
            {
                CheckIfLoaded(loader);
            }
        }

        //Stops syncing
        private void StopSync_Click(object sender, EventArgs e)
        {
            Btn_Sync.Enabled = true;
            StopSync.Enabled = false;
            stopSync = true;
            Task.Delay(500);
        }

        private void frmSync_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
