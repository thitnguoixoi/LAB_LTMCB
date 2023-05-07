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
            bool IsConnected = tcpClient.Connected;
            while (IsConnected)
            {
                StreamReader reader = new StreamReader(networkStream);
                string message = reader.ReadLine();
                AppendTextToRichTextBox1(message);
                IsConnected = tcpClient.Connected;
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
            byte[] data = System.Text.Encoding.UTF8.GetBytes(user + ": " +msg+"\n");
            networkStream.Write(data, 0, data.Length);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string user = richTextBox2.Text.ToString();
            user.Trim();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(user + " quited\n");
            networkStream.Write(data, 0, data.Length);
            networkStream.Close();
            richTextBox1.AppendText("closed");
            tcpClient.Close();
            richTextBox1.AppendText("closed");
            receiveThread.Join();
            richTextBox1.AppendText("joined");
            this.Close();
        }
    }
}
