namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (module1 dialog1 = new module1())
            {
                this.Hide();
                if (dialog1.ShowDialog() == DialogResult.OK)
                {
                    lblResult.Text = "Ваша група: " + dialog1.SelectedGroup;
                }
                this.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (module2 dialog2 = new module2())
            {
                this.Hide();
                if (dialog2.ShowDialog() == DialogResult.OK)
                {
                    lblResult2.Text = "Ваш ПІ: " + dialog2.SelectedGroup;
                }
                this.Show();
            }
        }
    }
}
