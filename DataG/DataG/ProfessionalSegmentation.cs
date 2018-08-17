﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataG
{
    public partial class ProfessionalSegmentation : Form
    {
        public int start = 0;
        public int end = 100;
        public bool isOK = false;
        public double[] time = new double[2];
        public ProfessionalSegmentation()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            start = int.Parse(startTextBox.Text);
            end = int.Parse(endTextBox.Text);
            
            isOK = true;
            this.Close();
            
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {

            this.Refresh();
        }
    }
}
