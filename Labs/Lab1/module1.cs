using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab1
{
    public partial class module1 : Form
    {

        public string SelectedGroup { get; private set; } = string.Empty;

        public module1()
        {
            InitializeComponent();
        }

        private void module1_Load(object sender, EventArgs e)
        {
            string[] groups = { "ІМ-51", "ІМ-52", "ІМ-53", "ІМ-54", "ІМ-55", "ІМ-о51" };
            listBox1.Items.AddRange(groups);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                SelectedGroup = listBox1.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть групу зі списку!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
