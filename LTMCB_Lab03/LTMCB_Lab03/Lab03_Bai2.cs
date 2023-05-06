using System.Net.Sockets;
using System.Net;
using System.Text;

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


        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread listenerThread = new Thread(new ThreadStart(ListenForClients));
            listenerThread.Start();
        }
            
        private void ListenForClients()
        {
            while (true)
            {
               
                int bytesRecv =0 ;
                byte[] recv = new byte[1];
                Socket clientSocket;
                Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(-1);
                clientSocket = listenerSocket.Accept();
                richTextBox1.AppendText("connected\n");
                while (clientSocket.Connected)
                {
                    string text = "";
                    do
                    {
                        bytesRecv = clientSocket.Receive(recv);
                        text += Encoding.ASCII.GetString(recv);
                    } while (text[text.Length -1] != '\n');
                    richTextBox1.AppendText(text);
                }
                listenerSocket.Close();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}