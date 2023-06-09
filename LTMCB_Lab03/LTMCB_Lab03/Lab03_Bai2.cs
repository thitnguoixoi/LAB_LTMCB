﻿using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace LTMCB_Lab03
{
    public partial class Lab03_Bai2 : Form
    {
        public Lab03_Bai2()
        {
            InitializeComponent();
        }

        private void Lab03_Bai2_Load(object sender, EventArgs e)
        {

        }
        private TcpListener server = null;
        Thread listenerThread;
        private bool isRunning = true;
        private void button1_Click(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Loopback, 8080);
            server.Start();
            richTextBox1.AppendText("started\n");
            CheckForIllegalCrossThreadCalls = false;
            listenerThread = new Thread(()=>ListenForClients());
            listenerThread.Start();
            button1.Enabled = false;
        }

        private void ListenForClients()
        {
            while (isRunning)
            {
                Socket clientSocket;
                try
                {
                    int bytesRecv = 0;
                    byte[] recv = new byte[1];
                    clientSocket = server.AcceptSocket();
                    bool isConnected = true;
                    richTextBox1.AppendText("connected\n");

                    while (isConnected && isRunning)
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
        private void Lab03_Bai2_FormClosing(object sender, FormClosingEventArgs e)
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