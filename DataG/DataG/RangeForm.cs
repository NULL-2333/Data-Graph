using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace DataG
{
    public partial class RangeForm : Form
    {
        
        public int yRangeMax = 200;
        public int yRangeMin = 0;
        public int xRangeMax = 70;
        public int xRangeMin = 0;
        public int xScale = 1;
        public double interval = 2;
        public string yType = "R1";
        public double yMax2 = 0;
        public double yMax3 = 0;
        public double yMax4 = 0;
        public double yMin2 = 0;
        public double yMin3 = 0;
        public double yMin4 = 0;

        MainForm mf = new MainForm();
        

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
            //yScale = int.Parse(YScaleViewTextBox.Text);
            xRangeMax = int.Parse(XRangeMaxTextBox.Text);
            xRangeMin = int.Parse(XRangeMinTextBox.Text);
            xScale = int.Parse(XScaleViewTextBox.Text);
            interval = double.Parse(IntervaltextBox.Text);
            yType = YAxisComboBox.Text;
            
            this.Close();
        }

        private void YRangeForm_Load(object sender, EventArgs e)
        {
            int x = yRangeMax;
            YRangeMaxTextBox.Text = x.ToString();
            x = yRangeMin;
            YRangeMinTextBox.Text = x.ToString();
            int y = xRangeMax;
            XRangeMaxTextBox.Text = y.ToString();
            y = xScale;
            XScaleViewTextBox.Text = y.ToString();
            y = xRangeMin;
            XRangeMinTextBox.Text = y.ToString();
            double z = interval;
            IntervaltextBox.Text = z.ToString();
            string yt = yType;
            YAxisComboBox.Text = yt;
            
        }

        private void settingSaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c://";
            saveFileDialog.Filter = "Log Files|*.log";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FilterIndex = 1;
            FileStream fs;
            string fileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }

            fs = new FileStream(fileName, FileMode.Create);
            fs.Close();
            //fs.Write();
            List<string> lines = new List<string>(File.ReadAllLines(fileName));
            //save logs about x axis
            lines[0] = "x range: " + XRangeMinTextBox.Text + " - " + XRangeMaxTextBox.Text;
            lines[1] = "x scale: " + XScaleViewTextBox.Text;
            lines[2] = "x interval: " + IntervaltextBox.Text;
            //save logs about y axis
            int i = int.Parse(YAxisComboBox.Text[1].ToString());
            if (i != 1)
            {
                lines[i * 2 + 1] = YAxisComboBox.Text + ":";
                lines[i * 2 + 2] = "y range: " + YRangeMinTextBox.Text + " - " + YRangeMaxTextBox.Text;
            }
            else
            {
                lines[i * 2 + 1] = YAxisComboBox.Text + ":";
                lines[i * 2 + 2] = "y range: " + YRangeMinTextBox.Text + " - " + YRangeMaxTextBox.Text;
            }

            File.WriteAllLines(fileName, lines.ToArray());
        }

        private void YAxisComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YAxisComboBox.SelectedIndex == 1)
            {
                YRangeMaxTextBox.Text = yMax2.ToString();
                YRangeMinTextBox.Text = yMin2.ToString();
            }
            else if (YAxisComboBox.SelectedIndex == 2)
            {
                YRangeMaxTextBox.Text = yMax3.ToString();
                YRangeMinTextBox.Text = yMin3.ToString();
            }
            else if (YAxisComboBox.SelectedIndex == 3)
            {
                YRangeMaxTextBox.Text = yMax4.ToString();
                YRangeMinTextBox.Text = yMin4.ToString();
            }
        }
    }
}
