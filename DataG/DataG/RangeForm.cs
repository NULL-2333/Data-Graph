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
            string fileName = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
            }
            if (System.IO.File.Exists(fileName))
            {

            }
            else
            {
                //File.Create(fileName);
                FileStream F = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                F.Close();
                StreamWriter sw = new StreamWriter(fileName);
                //F.Write()
                sw.WriteLine("x range: " + XRangeMinTextBox.Text + " - " + XRangeMaxTextBox.Text);
                sw.WriteLine("x scale: " + XScaleViewTextBox.Text);
                sw.WriteLine("x interval: " + IntervaltextBox.Text);
                sw.WriteLine("R1:");
                sw.WriteLine("y range: " + YRangeMinTextBox.Text + " - " + YRangeMaxTextBox.Text);
                sw.WriteLine("R2:");
                sw.WriteLine("y range: " + YRangeMinTextBox.Text + " - " + YRangeMaxTextBox.Text);
                sw.WriteLine("R3:");
                sw.WriteLine("y range: " + YRangeMinTextBox.Text + " - " + YRangeMaxTextBox.Text);
                sw.WriteLine("R4:");
                sw.WriteLine("y range: " + YRangeMinTextBox.Text + " - " + YRangeMaxTextBox.Text);
                sw.Close();
                
            }

            //save settings to log file
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
    }
}
