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
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)  //close button
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)  //calculate button
        {
            try
            {
                float num1, num2, num3;
                num1 = float.Parse(textBox1.Text.Trim());
                num2 = float.Parse(textBox2.Text.Trim());
                num3 = float.Parse(textBox3.Text.Trim());
                float min = num1, max = num1;  //finding min, max
                if (min > num2) min = num2;
                if (min > num3) min = num3;
                if (max < num2) max = num2;
                if (max < num3) max = num3;
                textBox4.Text = max.ToString();
                textBox5.Text = min.ToString();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException)
                    MessageBox.Show("Bạn chưa nhập số!");
                else if (ex is FormatException)
                    MessageBox.Show("Vui lòng nhập kiểu dữ liệu là số thực! ");
                else if (ex is OverflowException)
                    MessageBox.Show("Vui lòng nhập số trong khoảng 3.4E – 38 đến 3.4E + 38! ");
                else
                    MessageBox.Show("Dữ liệu không hợp lệ!");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)  //clear button
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
