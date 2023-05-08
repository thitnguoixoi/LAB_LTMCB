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
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace LTMCB_Lab03
{
    public partial class Lab03_Bai4_client : Form
    {
        public Lab03_Bai4_client()
        {
            InitializeComponent();
        }


        private NetworkStream networkStream;
        private TcpClient tcpClient;
        private Thread receiveThread;
        private IPEndPoint iPEndPoint;
        private Thread UpdateUI;


        private void Lab03_Bai4_client_Load(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient();
                iPEndPoint = new IPEndPoint(IPAddress.Loopback, 8080);
                tcpClient.Connect(iPEndPoint);
                networkStream = tcpClient.GetStream();
                receiveThread = new Thread(ReceiveData);
                receiveThread.Start();
            }
            catch (Exception)
            {
                tcpClient = null;
                iPEndPoint = null;
                this.Close();
            }
        }
        private void ReceiveData()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
                    int bytesRead = networkStream.Read(buffer, 0, tcpClient.ReceiveBufferSize);
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    UpdateUI = new Thread(() => UpdateUIThread(message));
                    UpdateUI.Start();
                    if (message == "server quit")
                    {
                        tcpClient.Close();
                        this.Dispose();
                        this.Close();
                        break;
                    }
                }
            }
            catch (Exception)
            {
                this.Close();
            }
        }

        private void AppendTextToRichTextBox1(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendTextToRichTextBox1), text);
            }
            else
            {
                richTextBox1.AppendText(text + "\n");
            }
        }
        private void UpdateUIThread(string text)
        {
            AppendTextToRichTextBox1(text);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string user = richTextBox2.Text.ToString();
            user.Trim();
            string msg = richTextBox3.Text.ToString();
            msg.Trim();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(user + ": " + msg);
            networkStream.Write(data, 0, data.Length);
        }
        private void Lab03_Bai4_client_FormClosing(object sender, FormClosingEventArgs e)
        {
            string user = richTextBox2.Text.ToString();
            user.Trim();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(user + " quitted");
            networkStream.Write(data, 0, data.Length);
            tcpClient.Close();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
