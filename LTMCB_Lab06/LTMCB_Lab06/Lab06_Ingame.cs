using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace LTMCB_Lab06
{
    public partial class Lab06_Ingame : Form
    {
        // Variables
        private Lab06_MainForm parent;
        private TcpClient client = null;
        private Thread thread = null;
        private String joinUsername, joinIP = "127.0.0.1", joinPort, time;
        private bool isAuto = false;
        public bool isIngame = false, isServer = false;
        private int timeLeft = -1, startRange, endRange, valRange, lastSubmitTime;
        private List<int> trueVal = null;
        private Random rand;

        // Initialize
        public Lab06_Ingame(Lab06_MainForm parent, string joinUsername, string joinPort, String time)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.parent = parent;
            this.joinUsername = joinUsername;
            this.joinPort = joinPort;
            this.time = time;
            rand = new Random();
        }
        public string getRtbText()  
        {
            return rtb_Chat.Text;
        }

        private void Lab06_Ingame_Load(object sender, EventArgs e)
        {
            string username = joinUsername;
            IPAddress ip = null;
            int port = 0;
            if (username == "Username" || username == "") username = " ";
            try
            {
                ip = Dns.Resolve(joinIP).AddressList[0];
                port = Int32.Parse(joinPort);
            }
            catch
            {
                MessageBox.Show("IPEndpoint có lỗi.", "Lỗi");
                this.Close();
                return;
            }
            client = new TcpClient();
            try
            {
                client.Connect(ip, port);
            }
            catch
            {
                MessageBox.Show("Server chưa hoạt động!", "Lỗi");
                this.Close();
                return;
            }

            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(username);
            stream.Write(buffer, 0, buffer.Length);

            buffer = new byte[1024];
            int bytesCount = stream.Read(buffer, 0, buffer.Length);
            string res = Encoding.UTF8.GetString(buffer, 0, bytesCount);
            String[] ress = res.Split('\t');
            if (ress[0] == "Server")
            {
                isServer = true;
                btn_Ready.Enabled = btn_Submit.Enabled = btn_Clear.Enabled = label1.Enabled = false;
                tb_Answer.BorderStyle = BorderStyle.None;
            }
            else if (ress[0] == "@@@Ingame!@@@")
            {
                MessageBox.Show("Game đã được bắt đầu!", "Lỗi");
                this.Close();
                return;
            }
            else if (ress[0] == " ")
            {
                MessageBox.Show($"{username} đã được chọn. Vui lòng chọn tên khác", "Lỗi");
                this.Close();
                return;
            }

            if (!isServer)
            {
                MessageBox.Show($"Xin chào, {ress[0]}!", "Thành công");
                time = DateTime.Now.ToString("h:mm:ss tt");
            }

            this.Text = ress[0];
            if (ress.Length > 1) lb_NumOfPlayers.Text = $"{ress[1].Trim('\n')}";

            thread = new Thread(o => ReceiveData((TcpClient)o));
            thread.Start(client);
        }

        private void send(String message)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes($"{message}\n");
            stream.Write(buffer, 0, buffer.Length);
        }

        private void btn_Ready_Click(object sender, EventArgs e)
        {
            btn_Ready.Enabled = false;
            send("@@@Ready!@@@");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            send($"m{tb_Message.Text}");
            tb_Message.Clear();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            rtb_Chat.Clear();
        }

        private void lb_Result_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft > -1)
            {
                lb_Time.Text = timeLeft.ToString();
                if (timeLeft == 0)
                {
                    btn_Submit.Enabled = tb_Answer.Enabled = label3.Enabled = label4.Enabled = label6.Enabled = lb_Range.Enabled = lb_Result.Enabled = false;
                    send("@@@Timeup!@@@");
                }
                else if (isAuto && lastSubmitTime - timeLeft >= 3)
                    (new Thread(() => autoSubmit())).Start();
                else if (!isAuto && lastSubmitTime - timeLeft >= 3)
                {
                    btn_Submit.Enabled = tb_Answer.Enabled = true;
                    tb_Answer.Focus();
                    tb_Answer.Select();
                }
            }
            else
            {
                lb_Time.Text = "0";
                timer.Stop();
            }
        }

        private void Lab06_Ingame_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (isServer)
            {
                this.Hide();
                parent.Show();
                e.Cancel = true;
                return;
            }
            else if (isIngame)
            {
                e.Cancel = true;
                (new Thread(() => MessageBox.Show("Bạn phải ở lại để chơi hết phần chơi của mình!\nThoát trận ảnh hưởng đến những người chơi khác, và bạn sẽ có thể bị cấm chơi trong tương lai!\n", "Lỗi"))).Start();
                return;
            }

            if (this.Text != "Anonymous")
                try
                {
                    String path = Path.Combine(
                        Path.GetDirectoryName(Application.ExecutablePath),
                        $"History_{this.Text}.txt"
                    );
                    StreamWriter sw;
                    if (!File.Exists(path)) sw = File.CreateText(path);
                    else sw = File.AppendText(path);
                    String hostOrJoin;
                    if (this.Text == "Server") hostOrJoin = $">>> {time} - Server khởi tạo kết nối... <<<";
                    else hostOrJoin = $">>> {time} - {this.Text} kết nối tới Server... <<<";
                    rtb_Chat.Text = $"{hostOrJoin}\n\n{rtb_Chat.Text}\n>>> Kết nối đã bị đóng <<<\n\n\n\n";
                    foreach (String line in rtb_Chat.Lines)
                        sw.WriteLine(line);D
                    sw.Close();
                }
                catch
                {
                    MessageBox.Show("Không thể viết file lịch sử trò chơi.", "Lỗi");
                }

            if (thread != null) thread.Abort();

            if (client != null)
            {
                try
                {
                    client.Client.Shutdown(SocketShutdown.Send);
                }
                catch { }
                client.Close();
            }

            parent.Show();
        }

        private void lb_NumOfPlayers_Click(object sender, EventArgs e)
        {

        }

        private void lb_Time_Click(object sender, EventArgs e)
        {

        }

        private void tb_Message_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            submit(Int32.Parse(tb_Answer.Text));
            tb_Answer.Clear();
        }

        private void rtb_Chat_TextChanged(object sender, EventArgs e)
        {

        }
        private void submit(int val)
        {
            if (timeLeft <= 0 || lastSubmitTime - timeLeft < 3) return;
            (new Thread(() => send($"s{val}"))).Start();
            lastSubmitTime = timeLeft;
            if (!this.InvokeRequired)
                btn_Submit.Enabled = tb_Answer.Enabled = false;
            int index = trueVal.IndexOf(val);
            if (index != -1 && index <= valRange)
            {
                int temp = trueVal[valRange];
                trueVal[valRange] = trueVal[index];
                trueVal[index] = temp;
                valRange--;
            }
        }
        private void autoSubmit()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate ()
                {
                    autoSubmit();
                }));
            else
            {
                int val = rand.Next(0, valRange + 1);
                submit(trueVal[val]);
            }
        }
        //  thread body
        private void ReceiveData(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int bytesCount;

            while (Thread.CurrentThread.IsAlive)
            {
                try
                {
                    if ((bytesCount = stream.Read(receivedBytes, 0, receivedBytes.Length)) <= 0) break;
                }
                catch { break; }
                string respondFromServer = Encoding.UTF8.GetString(receivedBytes, 0, bytesCount);
                var dataList = respondFromServer.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String data in dataList)
                {
                    if (data[0] == 'm')
                        rtb_Chat.Invoke(new MethodInvoker(delegate ()
                        {
                            rtb_Chat.AppendText($"{data.Substring(1)}\n");
                            rtb_Chat.ScrollToCaret();
                        }));
                    else if (data[0] == '\t')
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            lb_NumOfPlayers.Text = $"{data.Substring(1)}";
                        }));

                    else if (data.StartsWith("@@@Nextround!@@@"))
                    {
                        if (!isIngame) isIngame = true;

                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            label3.Enabled = lb_Range.Enabled = true;
                        }));

                        var rand = data.Substring(16).Split(new String[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        startRange = Int32.Parse(rand[1]);
                        endRange = Int32.Parse(rand[2]);
                        valRange = endRange - startRange;
                        trueVal = Enumerable.Range(startRange, valRange + 1).ToList();
                        lb_Range.Invoke(new MethodInvoker(delegate ()
                        {
                            lb_Range.Text = $"[{startRange}, {endRange}]";
                        }));

                        if (isServer) lb_Result.Invoke(new MethodInvoker(delegate ()
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                label4.Enabled = lb_Result.Enabled = true;
                            }));
                            lb_Result.Text = rand[3];
                        }));
                        else
                        {
                            lastSubmitTime = 100;
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                btn_Submit.Enabled = tb_Answer.Enabled = true;
                                tb_Answer.Focus();
                                tb_Answer.Select();
                            }));
                        }

                        timeLeft = Int32.Parse(rand[0]);
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            lb_Time.Text = timeLeft.ToString();
                            timer.Start();
                        }));
                    }
                    else if (!isServer && data == "@@@Newgame!@@@")
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            btn_Ready.Enabled = true;
                            btn_Submit.Enabled = tb_Answer.Enabled = false;
                        }));
                        isIngame = isAuto = false;
                    }
                    else if (data == "@@@Exit!@@@")
                    {
                        closeWhenServerDown();
                        break;
                    }
                }
            }
            if (isIngame)
            {
                isIngame = false;
                closeWhenServerDown();
            }
            stream.Close();
        }

        private void closeWhenServerDown()
        {
            MessageBox.Show("Server đã tắt.", "Kết nối bị ngắt");
            (new Thread(() => this.Invoke(new MethodInvoker(delegate ()
            {
                this.Close();
            })))).Start();
        }
    }
}
