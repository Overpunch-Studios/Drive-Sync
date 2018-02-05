using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveSync
{
    public partial class frmLoader : Form
    {
        int loaderTime;
        frmSync frmSync;
        public bool loaded;
        public frmLoader(frmSync sync)
        {
            InitializeComponent();
            loaderTime = 0;
            this.frmSync = sync;
            loaded = false;
        }

        //This form just shows a loading screen (loads nothing just for looks and advertisement)
        private void LoadTimer_Tick(object sender, EventArgs e)
        {
            if(loaderTime < 5)
            {
                LoaderProg.PerformStep();
                loaderTime++;
            }
            else
            {
                loaded = true;
                frmSync.Show();
                this.Close();
            }
        }
    }
}
