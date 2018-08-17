using System;
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
    public partial class ProfessionalSegmentationTime : Form
    {
        public double[] time = new double[2];
        public ProfessionalSegmentationTime()
        {
            InitializeComponent();
        }

        private void ProfessionalSegmentationTime_Load(object sender, EventArgs e)
        {
            firstTimeLabel.Text = time[0].ToString();
            secondTimeLabel.Text = time[1].ToString();
        }
    }
}
