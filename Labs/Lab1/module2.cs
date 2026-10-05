using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab1
{
    public partial class module2 : Form
    {
        public string SelectedGroup { get; private set; } = string.Empty;
        public module2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                SelectedGroup = textBox1.Text.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
