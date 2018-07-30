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
    public partial class YRangeForm : Form
    {
        
        public int yRangeMax = 200;
        public int yRangeMin = 0;
        public int yScale = 100;
        public YRangeForm()
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
            this.Close();
        }

        private void YRangeForm_Load(object sender, EventArgs e)
        {
            int x = 200;
            YRangeMaxTextBox.Text = x.ToString();
            x = 100;
            YScaleViewTextBox.Text = x.ToString();
            x = 0;
            YRangeMinTextBox.Text = x.ToString();
        }
    }
}
