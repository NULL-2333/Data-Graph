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
    public partial class XRangeForm : Form
    {
        public int xRangeMax = 10000;
        public int xRangeMin = 0;
        public int xScale = 10000;
        public XRangeForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            xRangeMax = int.Parse(XRangeMaxTextBox.Text);
            xRangeMin = int.Parse(XRangeMinTextBox.Text);
            xScale = int.Parse(XScaleViewTextBox.Text);
            this.Close();
        }

        private void XRangeForm_Load(object sender, EventArgs e)
        {
            int x = 10000;
            XRangeMaxTextBox.Text = x.ToString();
            XScaleViewTextBox.Text = x.ToString();
            x = 0;
            XRangeMinTextBox.Text = x.ToString();
        }
    }
}
