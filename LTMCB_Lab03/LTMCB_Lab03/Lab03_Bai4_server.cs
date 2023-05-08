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
using System.Reflection;

namespace LTMCB_Lab03
{
    public partial class Lab03_Bai4_server : Form
    {
        public Lab03_Bai4_server()
        {
            InitializeComponent();
        }
        private TcpListener server = null;
        Thread listenerThread;
        List<Socket> clients;


        private void button1_Click(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Loopback, 8080);
            server.Start();
            richTextBox1.AppendText("started\n");
            CheckForIllegalCrossThreadCalls = false;
            listenerThread = new Thread(() => ListenForClients());
            listenerThread.Start();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void ListenForClients()
        {
            try
            {
                clients = new List<Socket>();
                while (true)
                {
                    Socket clientSocket = server.AcceptSocket();
                    clients.Add(clientSocket);
                    IPEndPoint clientEndPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
                    string clientInfo = string.Format("Client {0}:{1} connected", clientEndPoint.Address, clientEndPoint.Port);
                    richTextBox1.AppendText(clientInfo + "\n");
                    CheckForIllegalCrossThreadCalls = false;
                    Thread clientThread = new Thread(() => ReceiveDataThread(clientSocket));
                    clientThread.Start();
                }
            }
            catch (Exception)
            {
                if (server != null)
                {
                    Broadcast("server quit");
                    server.Stop();
                }

                foreach (var item in clients.ToArray())
                {
                    CloseClientConnection(item);
                }

                clients.Clear();
                richTextBox1.Clear();
            }
        }
        private void ReceiveDataThread(Socket clientSocket)
        {
            try
            {
                while (clientSocket.Connected)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = clientSocket.Receive(buffer);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    richTextBox1.AppendText(message + "\n");

                    Broadcast(message);
                    if (message.Contains("quitted"))
                    {
                        // Kết nối đã bị ngắt
                        CloseClientConnection(clientSocket);
                    }
                }
            }

            catch
            {
            }
        }
        private void CloseClientConnection(Socket clientSocket)
        {
            clientSocket.Close();
            foreach (var item in clients.ToArray())
            {
                if (item == clientSocket)
                {
                    clients.RemoveAt(clients.IndexOf(item));
                }
            }
        }
        private void Broadcast(string message)
        {
            foreach (var item in clients)
            {
                SendData(message, item);

            }
        }
        private void SendData(string message, Socket client)
        {
            Byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            client.Send(data);
        }
        private void Lab03_Bai4_server_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (server != null)
            {
                Broadcast("server quit");
                server.Stop();
            }

            foreach (var item in clients.ToArray())
            {
                CloseClientConnection(item);
            }

            clients.Clear();
            richTextBox1.Clear();
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void Lab03_Bai4_server_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
    }
}
