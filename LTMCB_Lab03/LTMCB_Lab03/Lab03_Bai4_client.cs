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


        NetworkStream networkStream;
        TcpClient tcpClient;
        Thread receiveThread;
        bool shouldStop = false;

        private void Lab03_Bai4_client_Load(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, 8080);
            tcpClient.Connect(iPEndPoint);
            networkStream = tcpClient.GetStream();
            receiveThread = new Thread(ReceiveData);
            receiveThread.Start();
        }
        private void ReceiveData()
        {
            while (!shouldStop)
            {
                byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
                int bytesRead = networkStream.Read(buffer, 0, tcpClient.ReceiveBufferSize);
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                AppendTextToRichTextBox1(message);
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
            shouldStop = true;
            receiveThread.Join();
            string user = richTextBox2.Text.ToString();
            user.Trim();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(user + " quitted");
            networkStream.Write(data, 0, data.Length);
            tcpClient.Close();
        }
    }
}
