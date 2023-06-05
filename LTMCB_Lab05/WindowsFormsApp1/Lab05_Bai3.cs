using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Lab05_Bai3 : Form
    {
        public Lab05_Bai3()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chịu, hết cứu!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.ToString().Trim();
            string password = textBox2.Text.ToString().Trim();
            StringStorage.email = email;
            StringStorage.password = password;
            if (email == "vanlong@nhom10.nt106" || email == "manhhung@nhom10.nt106")
            {
                if(password == "Nhom10.flexin!")
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    Lab05_Bai3_LoggedIn lab05_Bai3_LoggedIn = new Lab05_Bai3_LoggedIn();
                    lab05_Bai3_LoggedIn.Show();
                }
                else 
                {
                    MessageBox.Show("Biết nhập password không?");
                }
            }
            else
            {
                MessageBox.Show("Biết nhập email không?");
            } 
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
    public static class StringStorage
    {
        public static string email { get; set; }
        public static string password { get; set; }
    }
}
