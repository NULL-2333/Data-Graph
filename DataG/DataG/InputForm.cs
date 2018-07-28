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
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }
        public string latName = "";
        public string lonName = "";
        public string[] Names;
        private void confirmButton_Click(object sender, EventArgs e)
        {
            latName = latComboBox.Text;
            lonName = lonComboBox.Text;
           
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Names.Length; i++)
            {
                latComboBox.Items.Add(Names[i]);
                lonComboBox.Items.Add(Names[i]);
            }
            latComboBox.SelectedIndex = 1;
            lonComboBox.SelectedIndex = 0;
        }
    }
}
