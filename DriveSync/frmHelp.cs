﻿using System;
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
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {

        }

        private void donate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://paypal.me/PvanHalm");
        }
    }
}
