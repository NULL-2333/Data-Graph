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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void singleRunButton_Click(object sender, EventArgs e)
        {
            SingleRun singleRunForm = new SingleRun();
            singleRunForm.Show();
        }

        private void comparedRunButton_Click(object sender, EventArgs e)
        {
            ComparedRun comparedRunForm = new ComparedRun();
            comparedRunForm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void singleRunButton_Resize(object sender, EventArgs e)
        {
            //this.Controls.
            //int Move = 12;
            //this.Controls["singleRunButton"].Location = new Point(Move, Move);
            //this.Controls["singleRunButton"].Height = (this.Height - Move * 4) / 3;
            //this.Controls["singleRunButton"].Width = this.Width - Move * 2;

            //this.Controls["comparedRunButton"].Location = new Point(Move, Move * 2 + this.Controls["singleRunButton"].Height);
            //this.Controls["comparedRunButton"].Height = (this.Height - Move * 4) / 3;
            //this.Controls["comparedRunButton"].Width = this.Width - Move * 2;

            //this.Controls["singleRunButton"].Location = new Point(Move, Move * 3 + this.Controls["comparedRunButton"].Height);
            //this.Controls["singleRunButton"].Height = (this.Height - Move * 4) / 3;
            //this.Controls["singleRunButton"].Width = this.Width - Move * 2;

            //this.Refresh();
        }
    }
}
