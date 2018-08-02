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
    public partial class RangeForm : Form
    {
        
        public int yRangeMax = 200;
        public int yRangeMin = 0;
        public int yScale = 100;
        public int xRangeMax = 70;
        public int xRangeMin = 0;
        public int xScale = 1;
        public RangeForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            yRangeMax = int.Parse(YRangeMaxTextBox.Text);
            yRangeMin = int.Parse(YRangeMinTextBox.Text);
            yScale = int.Parse(YScaleViewTextBox.Text);
            xRangeMax = int.Parse(XRangeMaxTextBox.Text);
            xRangeMin = int.Parse(XRangeMinTextBox.Text);
            xScale = int.Parse(XScaleViewTextBox.Text);
            this.Close();
        }

        private void YRangeForm_Load(object sender, EventArgs e)
        {
            int x = yRangeMax;
            YRangeMaxTextBox.Text = x.ToString();
            x = yScale;
            YScaleViewTextBox.Text = x.ToString();
            x = yRangeMin;
            YRangeMinTextBox.Text = x.ToString();
            int y = xRangeMax;
            XRangeMaxTextBox.Text = y.ToString();
            y = xScale;
            XScaleViewTextBox.Text = y.ToString();
            y = xRangeMin;
            XRangeMinTextBox.Text = y.ToString();
        }
    }
}
