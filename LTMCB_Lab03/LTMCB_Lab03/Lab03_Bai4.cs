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
    public partial class Lab03_Bai4 : Form
    {
        public Lab03_Bai4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab03_Bai4_server a = new Lab03_Bai4_server();
            a.FormClosing += new FormClosingEventHandler(FormChildClosing1);
            button1.Enabled = false;
            a.Show();
        }
        private void FormChildClosing1(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Lab03_Bai4_client a = new Lab03_Bai4_client();
            a.Show();
        }
    }
}
