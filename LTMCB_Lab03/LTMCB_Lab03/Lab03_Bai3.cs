using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMCB_Lab03
{
    public partial class Lab03_Bai3 : Form
    {
        public Lab03_Bai3()
        {
            InitializeComponent();
        }

        private void Lab03_Bai3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab03_Bai3_server a = new Lab03_Bai3_server();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab03_Bai3_client a = new Lab03_Bai3_client();
            a.Show();
        }
    }
}
