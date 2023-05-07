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
    public partial class Lab03_Bai3_server : Form
    {
        public Lab03_Bai3_server()
        {
            InitializeComponent();
        }

        private void Lab03_Bai3_server_Load(object sender, EventArgs e)
        {

        }

        private TcpListener server;
        Thread listenerThread;
        private void button1_Click(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Loopback, 8080);
            server.Start();
            richTextBox1.AppendText("started\n");
            CheckForIllegalCrossThreadCalls = false;
            listenerThread = new Thread(new ThreadStart(ListenForClients));
            listenerThread.Start();
        }

        private void ListenForClients()
        {
            int bytesRecv = 0;
            byte[] recv = new byte[1];
            Socket clientSocket;
            /*Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipepServer);
            listenerSocket.Listen(-1);*/
            clientSocket = server.AcceptSocket();
            richTextBox1.AppendText("connected\n");
            bool isConnected = true;

            while (isConnected)
            {
                string text = "";
                do
                {
                    bytesRecv = clientSocket.Receive(recv);
                    text += Encoding.ASCII.GetString(recv);
                } while (text[text.Length - 1] != '\n');
                byte[] buffer = new byte[1024];
                richTextBox1.AppendText(text);
                if (clientSocket.Receive(buffer) == 0)
                {
                    // Kết nối đã bị ngắt
                    isConnected = false;
                }
            }
            server.Stop();
            richTextBox1.AppendText("disconnected\n");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            listenerThread.Join();
            this.Close();
        }
    }
}
