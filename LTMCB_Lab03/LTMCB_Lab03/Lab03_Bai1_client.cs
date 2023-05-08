using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMCB_Lab03
{
    public partial class Lab03_Bai1_client : Form
    {
        public Lab03_Bai1_client()
        {
            InitializeComponent();
        }

        private void Lab03_Bai1_client_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Loopback, int.Parse(portTextBox.Text));
            string message = richTextBox1.Text;
            UdpClient udpClient = new UdpClient();
            Byte[] sendBytes = Encoding.UTF8.GetBytes(message);
            udpClient.Send(sendBytes, sendBytes.Length, "127.0.0.1", RemoteIpEndPoint.Port);

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
