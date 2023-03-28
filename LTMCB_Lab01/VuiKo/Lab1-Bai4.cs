using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VuiKo
{
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string result;
                string indexNum = textBox1.Text.Trim();
                if (comboBox1.Text == "Decimal" && comboBox2.Text == "Binary")
                {
                    result = Convert.ToString(Int32.Parse(indexNum), 2);
                    textBox2.Text = result;
                }
                if (comboBox1.Text == "Decimal" && comboBox2.Text == "Hexadecimal")
                {
                    result = Convert.ToString(Int32.Parse(indexNum), 16);
                    textBox2.Text = result;
                }
                if (comboBox1.Text == comboBox2.Text)
                {
                    MessageBox.Show("không thể chuyển 2 kiểu giống nhau");
                }
                if (comboBox1.Text == "Binary" && comboBox2.Text == "Decimal")
                {
                    result = Convert.ToInt32(indexNum, 2).ToString();
                    textBox2.Text = result;
                }
                if (comboBox1.Text == "Binary" && comboBox2.Text == "Hexadecimal")
                {
                    result = Convert.ToInt32(indexNum, 2).ToString("X");
                    textBox2.Text = result;
                }
                if (comboBox1.Text == "Hexadecimal" && comboBox2.Text == "Decimal")
                {
                    result = Convert.ToInt32(indexNum, 16).ToString();
                    textBox2.Text = result;
                }
                if (comboBox1.Text == "Hexadecimal" && comboBox2.Text == "Binary")
                {
                    result = Convert.ToString(Convert.ToInt64(indexNum, 16), 2);
                    textBox2.Text = result;
                }
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
    }
}
