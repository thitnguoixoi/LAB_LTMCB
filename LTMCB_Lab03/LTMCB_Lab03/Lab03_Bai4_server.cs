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
            while (true)
            {
                try
                {
                    Socket clientSocket = server.AcceptSocket();
                    clients.Add(clientSocket);
                    IPEndPoint clientEndPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
                    string clientInfo = string.Format("Client {0}:{1} connected", clientEndPoint.Address, clientEndPoint.Port);
                    richTextBox1.AppendText(clientInfo + "\n");

                    CheckForIllegalCrossThreadCalls = false;
                    Thread clientThread = new Thread(() =>
                    {
                        bool isConnected = true;
                        while (isConnected)
                        {
                            try
                            {   
                                byte[] buffer = new byte[1024];
                                int bytesRead = clientSocket.Receive(buffer);
                                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                                richTextBox1.AppendText(message);

                                if (bytesRead == 0)
                                {
                                    // Kết nối đã bị ngắt
                                    isConnected = false;
                                    clientSocket.Shutdown(SocketShutdown.Both);
                                    clientSocket.Close();
                                    clients.Remove(clientSocket);
                                    richTextBox1.AppendText("Disconnected\n");
                                }
                                else
                                {
                                    Broadcast(message);
                                }
                            }
                            catch (SocketException ex)
                            {
                                if (ex.SocketErrorCode == SocketError.ConnectionReset || ex.SocketErrorCode == SocketError.TimedOut)
                                {
                                    // Handle the case where the client abruptly closes the connection
                                    isConnected = false;
                                    clientSocket.Shutdown(SocketShutdown.Both);
                                    clientSocket.Close();
                                    clients.Remove(clientSocket);
                                    richTextBox1.AppendText("Disconnected\n");
                                }
                                else
                                {
                                    // Rethrow any other socket exceptions
                                    throw;
                                }
                            }

                        }
                    });
                    clientThreads.Add(clientThread);
                    clientThread.IsBackground = true;
                    clientThread.Start();

                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.Interrupted)
                    {
                        break;
                    }
                }

            }
        }
        private void Broadcast(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            foreach (Socket clientSocket in clients)
            {
                if (clientSocket != null)
                {
                    clientSocket.Send(buffer);
                    richTextBox1.AppendText("sent\n");
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Thread clientThread in clientThreads)
            {
                if (clientThread != null)
                {
                    clientThread.Join();
                }
            }
            server.Stop();
            listenerThread.Join();
            this.Close();
        }
    }
}
