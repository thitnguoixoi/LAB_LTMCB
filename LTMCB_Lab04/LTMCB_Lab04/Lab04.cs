using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMCB_Lab04
{
    public partial class Lab04 : Form
    {
        public Lab04()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab04_Bai1 lab04_Bai1 = new Lab04_Bai1();
            lab04_Bai1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab04_Bai2 lab04_Bai2 = new Lab04_Bai2();
            lab04_Bai2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab04_Bai3 lab04_Bai3 = new Lab04_Bai3();
            lab04_Bai3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lab04_Bai4 lab04_Bai4 = new Lab04_Bai4();
            lab04_Bai4.Show();
        }
    }
}
