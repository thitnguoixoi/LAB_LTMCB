namespace VuiKo
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)  //clear button
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)  //calculate button
        {
            try
            {
                int num1, num2;
                long sum = 0;
                num1 = Int32.Parse(textBox1.Text.Trim());
                num2 = Int32.Parse(textBox2.Text.Trim());
                sum = num1 + num2;
                textBox3.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException)
                    MessageBox.Show("Bạn chưa nhập số!");
                else if (ex is FormatException)
                    MessageBox.Show("Vui lòng nhập kiểu dữ liệu là số nguyên! ");
                else if (ex is OverflowException)
                    MessageBox.Show("Vui lòng nhập số trong khoảng -2,147,483,648 đến 2,147,483,647! ");
                else
                    MessageBox.Show("Dữ liệu không hợp lệ!");
            }
        }

        private void button3_Click(object sender, EventArgs e)  //close button
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}