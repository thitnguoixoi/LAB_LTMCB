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
        private TcpListener server;
        Thread listenerThread;
        List<Thread> clientThreads = new List<Thread>();
        List<Socket> clients = new List<Socket>();


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
            try
            {
                while (true)
                {
                    Socket clientSocket = server.AcceptSocket();
                    clients.Add(clientSocket);
                    IPEndPoint clientEndPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
                    string clientInfo = string.Format("Client {0}:{1} connected", clientEndPoint.Address, clientEndPoint.Port);
                    richTextBox1.AppendText(clientInfo + "\n");
                    CheckForIllegalCrossThreadCalls = false;
                    Thread clientThread = new Thread(() =>
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
                                    clientSocket.Close();
                                    clientSocket=null;
                                    clients.Remove(clientSocket);
                                    richTextBox1.AppendText("Disconnected\n");
                                    break;
                                }
                        }
                    });
                    clientThread.IsBackground = true;
                    clientThreads.Add(clientThread);
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
            }
        }
        private void Broadcast(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            foreach (Socket clientSocket in clients)
            {
                if(clientSocket !=null) 
                clientSocket.Send(buffer);
            }
        }
        private void Lab03_Bai4_server_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
            foreach (Thread clientThread in clientThreads)
            {
                if (clientThread != null)
                {
                    clientThread.Join();
                }
            }
            listenerThread.Join();
        }
    }
}
