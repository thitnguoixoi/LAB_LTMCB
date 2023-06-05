using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Lab05 : Form
    {
        public Lab05()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab05_Bai1 lab05_Bai1 = new Lab05_Bai1();
            lab05_Bai1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab05_Bai2 lab05_Bai2 = new Lab05_Bai2();
            lab05_Bai2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab05_Bai3 lab05_Bai3 = new Lab05_Bai3();
            lab05_Bai3.Show();
        }
    }
}
