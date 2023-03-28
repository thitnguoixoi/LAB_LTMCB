using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VuiKo
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num;
                num = Int32.Parse(textBox1.Text.Trim());
                string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };  
                string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
                bool isNegative = false;
                string sNum;
                if (num < 0)  //convert negative to positive
                {
                    num = -num;
                    sNum = num.ToString();
                    isNegative = true;
                }
                sNum = num.ToString();
                int ones, tens, hundreds;  
                int positionDigit = sNum.Length;  //current digit working at, start from right to left
                string result = " ";
                if (sNum == "0")
                    result = unitNumbers[0] + result;
                else
                {
                    int placeValue = 0;  //current triad of digits working at
                    while (positionDigit > 0)
                    {
                        tens = hundreds = -1;  //initialization
                        ones = Convert.ToInt32(sNum.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            tens = Convert.ToInt32(sNum.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNum.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                        if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                            result = placeValues[placeValue] + result;  // add the reading of triad
                        placeValue++;

                        if ((ones == 1) && (tens > 1))
                            result = "mốt " + result;  //"hai mươi mốt", not "hai mươi một"
                        else
                        {
                            if ((ones == 5) && (tens > 0))
                                result = "lăm " + result;  //"lăm" at the end, not "năm"
                            else if (ones > 0)
                                result = unitNumbers[ones] + " " + result;    //ones digit reading
                        }
                        if (tens < 0) break;  //tens digit reading
                        else
                        {
                            if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                            if (tens == 1) result = "mười " + result;
                            if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                        }
                        if (hundreds < 0) break;  //hundreds digit reading
                        else
                        {
                            if ((hundreds > 0) || (tens > 0) || (ones > 0))
                                result = unitNumbers[hundreds] + " trăm " + result;
                        }
                        result = " " + result;
                    }
                    result = result.Trim();
                    if (isNegative)
                        result = "Âm " + result;
                }
                textBox2.Text = result;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)  //clear button
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
