using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMCB_Lab02
{
    public partial class Lab02 : Form
    {
        public Lab02()
        {
            InitializeComponent();
        }

        private void Lab02_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Lab02_Bai1 Bai = new Lab02_Bai1();
            Bai.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab02_Bai2 Bai = new Lab02_Bai2();
            Bai.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab02_Bai3 Bai = new Lab02_Bai3();
            Bai.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Lab02_Bai4 Bai = new Lab02_Bai4();
            Bai.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Lab02_Bai5 Bai = new Lab02_Bai5();
            Bai.ShowDialog();
        }
    }
}
