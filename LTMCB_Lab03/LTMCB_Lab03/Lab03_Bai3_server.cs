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
        private Thread listenerThread;
        private bool isRunning = true;

        private void button1_Click(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Loopback, 8080);
            server.Start();
            richTextBox1.AppendText("started\n");
            CheckForIllegalCrossThreadCalls = false;
            listenerThread = new Thread(new ThreadStart(ListenForClients));
            listenerThread.Start();
            button1.Enabled = false;
        }

        private void ListenForClients()
        {
            while (isRunning)
            {
                Socket clientSocket = null;
                try
                {
                    clientSocket = server.AcceptSocket();
                    bool isConnected = true;
                    richTextBox1.AppendText("connected\n");

                    while (isConnected && isRunning)
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = clientSocket.Receive(buffer);
                        string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        richTextBox1.AppendText(message);

                        if (bytesRead == 0)
                        {
                            // Kết nối đã bị ngắt
                            isConnected = false;
                        }
                    }
                    clientSocket.Close();
                    richTextBox1.AppendText("disconnected\n");

                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.Interrupted)
                    {
                        isRunning = false;
                    }
                }
            }
        }


        private void Lab03_Bai3_server_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (server != null)
                {
                    isRunning = false;
                    server.Stop();
                    listenerThread.Join();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
