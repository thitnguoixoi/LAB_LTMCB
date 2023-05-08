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
    public partial class Lab03_Bai1_server : Form
    {
        public Lab03_Bai1_server()
        {
            InitializeComponent();
        }

        private void Lab03_Bai1_server_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*CheckForIllegalCrossThreadCalls = false;*/
            Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.Start();
        }
        UdpClient udpClient;
        public void serverThread()
        {
            int port = int.Parse(textBox1.Text);
            udpClient = new UdpClient(port);
            while (true)
            {
                IPEndPoint RemotelpEndPoint = new IPEndPoint(IPAddress.Loopback, port);
                Byte[] receiveBytes = udpClient.Receive(ref RemotelpEndPoint);
                string returnData = Encoding.UTF8.GetString(receiveBytes);
                string mess = RemotelpEndPoint.Address.ToString() + ":" +
                returnData.ToString();
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(RemotelpEndPoint.Address.ToString());
                item.SubItems.Add(RemotelpEndPoint.Port.ToString());
                item.SubItems.Add(mess);
                listView1.Invoke(new Action(() => { listView1.Items.Add(item); }));
            }
            udpClient.Close();
        }

    }
}
