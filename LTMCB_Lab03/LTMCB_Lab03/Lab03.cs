using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMCB_Lab03
{
    public partial class Lab03 : Form
    {
        public Lab03()
        {
            InitializeComponent();
        }

        private void Lab03_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab03_Bai1 a = new Lab03_Bai1();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab03_Bai2 a = new Lab03_Bai2();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab03_Bai3 a = new Lab03_Bai3();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lab03_Bai4 a = new Lab03_Bai4();
            a.Show();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
