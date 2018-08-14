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
    public partial class ComparedRun_FileLoadingForm : Form
    {
        public string firstFileName = "";
        public string secondFileName = "";
        //bool 
        public ComparedRun_FileLoadingForm()
        {
            InitializeComponent();
        }

        private void firstFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c://";
            openFileDialog.Filter = "Data Files|*.csv";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                firstFileName = openFileDialog.FileName;
            }
            if (firstFileName == "")
            {
                MessageBox.Show("No file selected", "Warning");
                return;
            }
            else
            {
                firstFileTextBox.Text = firstFileName;
            }
        }

        private void secondFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c://";
            openFileDialog.Filter = "Data Files|*.csv";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                secondFileName = openFileDialog.FileName;
            }
            if (firstFileName == "")
            {
                MessageBox.Show("No file selected", "Warning");
                return;
            }
            else
            {
                secondFileTextBox.Text = secondFileName;
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
