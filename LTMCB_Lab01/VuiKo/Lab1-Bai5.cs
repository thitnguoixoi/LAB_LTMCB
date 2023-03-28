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
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
        }

        private void Bai5_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim(); // Lấy giá trị nhập vào từ text box
            string[] numbers = input.Split(' '); // Tách chuỗi thành mảng các chuỗi con
            if (numbers.Length !=12 ) {
                MessageBox.Show("Điểm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            float sum = 0, max = float.Parse(numbers[0]), min= float.Parse(numbers[0]), dau = 0, rot = 0;
            foreach (string number in numbers)
            {
                float floatValue;
                if (float.TryParse(number, out floatValue)) // Kiểm tra số thực hợp lệ
                {
                    // Sử dụng số thực floatValue ở đây
                    if (floatValue < 0 || floatValue > 10) // Kiểm tra giá trị số thực nằm trong khoảng hợp lệ
                    {
                        MessageBox.Show("Điểm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                sum += floatValue;
                max = (max > floatValue) ? max : floatValue;
                min = (min < floatValue) ? min : floatValue;
                if (floatValue >= 5) dau++;
                else rot++;
            }
            float tb = sum / 12;
            mon1.Text = "Môn 1: " + numbers[0].Trim();
            mon2.Text = "Môn 2: " + numbers[1].Trim();
            mon3.Text = "Môn 3: " + numbers[2].Trim();
            mon4.Text = "Môn 4: " + numbers[3].Trim();
            mon5.Text = "Môn 5: " + numbers[4].Trim();
            mon6.Text = "Môn 6: " + numbers[5].Trim();
            mon7.Text = "Môn 7: " + numbers[6].Trim();
            mon8.Text = "Môn 8: " + numbers[7].Trim();
            mon9.Text = "Môn 9: " + numbers[8].Trim();
            mon10.Text = "Môn 10: " + numbers[9].Trim();
            mon11.Text = "Môn 11: " + numbers[10].Trim();
            mon12.Text = "Môn 12: " + numbers[11].Trim();
            TB.Text = "Điểm trung bình: " + tb;
            Max.Text = "Môn có điểm cao nhất: " + max;
            Min.Text = "Môn có điểm thấp nhất: " + min;
            Dau.Text = "Số môn đậu: " + dau;
            Rot.Text = "Số môn không rớt: " + rot;
            string hocluc;
            if (tb >= 8 && min >= 6.5) hocluc = "Giỏi";
            else if (tb >= 6.5 && min >= 5) hocluc = "Khá";
            else if (tb >= 5 && min >= 3.5) hocluc = "Trung bình";
            else if (tb >= 3.5 && min >= 2) hocluc = "Yếu";
            else hocluc = "Kém";
            HocLuc.Text = "Xếp loại học lực: " + hocluc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
