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
    public partial class Lab03_Bai1 : Form
    {
        public Lab03_Bai1()
        {
            InitializeComponent();
        }

        private void Lab03_Bai1_Load(object sender, EventArgs e)
        {
            // CheckForlllegalCrossThreadCalls = false;
            /*Thread thdUDPServer = new Thread(new Thread Start(serverThread()));
            thdUDPServer.Start();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab03_Bai1_client cl = new Lab03_Bai1_client();
            cl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab03_Bai1_server sv = new Lab03_Bai1_server();
            sv.Show();
        }
    }
}
