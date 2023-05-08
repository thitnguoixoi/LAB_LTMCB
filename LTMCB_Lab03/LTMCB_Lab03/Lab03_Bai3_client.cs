using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMCB_Lab03
{
    public partial class Lab03_Bai3_client : Form
    {
        public Lab03_Bai3_client()
        {
            InitializeComponent();
        }

        private void Lab03_Bai4_client_Load(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient();
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, 8080);
                tcpClient.Connect(iPEndPoint);
                networkStream = tcpClient.GetStream();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
        }
        NetworkStream networkStream;
        TcpClient tcpClient;
        bool check = false;
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes("hello\n");
            networkStream.Write(data, 0, data.Length);
        }


        private void Lab03_Bai3_client_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (check)
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes("quit\n");
                networkStream.Write(data, 0, data.Length);
                networkStream.Close();
                tcpClient.Close();
            }
        }
    }
}
