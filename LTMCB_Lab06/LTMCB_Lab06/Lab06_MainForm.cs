using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LTMCB_Lab06
{
    public partial class Lab06_MainForm : Form
    {
        // Variables 
        //// MainForm
        private Thread thread = null;
        private TcpListener serverSocket;
        private Lab06_Ingame serverForm = null;

        ////  Server
        private readonly object _lock = new object();
        private readonly Dictionary<String, TcpClient> clientsList = new Dictionary<string, TcpClient>();
        private Dictionary<String, int> scoreBoard = new Dictionary<string, int>();
        private Dictionary<String, bool> readyPlayers = new Dictionary<string, bool>();
        private int clientsCount = 0, luckyNumber, round = 0, currentRound, timeupCount, startRange, endRange;
        private bool ingame = false;
        private String correctPlayer, time = "";
        private Random rand;

        // Initialize
        public Lab06_MainForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            rand = new Random();
        }

        // Event handler
        private void Lab06_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ingame)
            {
                e.Cancel = true;
                (new Thread(() => MessageBox.Show("Vui lòng chờ cho đến khi game hiện tại kết thúc.", "Thông báo"))).Start();
                return;
            }

            if (serverForm != null)
            {
                string content = serverForm.getRtbText();
                this.Hide();

                String text = $">>> {time} - Server hosted a connection... <<<\n\n{content}\n>>> Connection closed <<<\n\n\n\n";
                (new Lab06_Browser(text)).ShowDialog();
                serverForm.isServer = serverForm.isIngame = false;
                serverForm.Close();
            }

            if (serverSocket != null) serverSocket.Stop();
            if (thread != null) thread.Abort();
        }
       
        private void Lab06_MainForm_Load(object sender, EventArgs e)
        {

        }

        // Button handler

        private void btn_Client_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            if (serverForm != null)
            {
                serverForm.Show();
                return;
            }
            serverForm = new Lab06_Ingame(this, tb_Username.Text, tb_Port.Text, time);
            serverForm.Show();
            if (thread == null) serverForm = null;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Server_Click(object sender, EventArgs e)
        {
            btn_Server.Enabled = false;
            thread = new Thread(serverThread);
            thread.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        // Server thread
        private void serverThread()
        {
            int port;
            try
            {
                port = Int32.Parse(tb_Port.Text);
                serverSocket = new TcpListener(IPAddress.Any, port);
                serverSocket.Start();
            }
            catch
            {
                btn_Server.Invoke(new MethodInvoker(delegate ()
                {
                    btn_Server.Enabled = true;
                }));
                MessageBox.Show("Port không khả dụng.", "Lỗi");
                return;
            }

            time = DateTime.Now.ToString("h:mm:ss tt");

            this.Invoke(new MethodInvoker(delegate ()
            {
                tb_Username.Text = "Server";
                tb_Username.Enabled = tb_Port.Enabled = false;
            }));

            (new Thread(() => this.Invoke(new MethodInvoker(delegate ()
            {
                btn_Client.PerformClick();
            })))).Start();

            MessageBox.Show($"Tạo phòng thành công tại port {port}.", "Thành công");

            while (Thread.CurrentThread.IsAlive)
            {
                TcpClient client = null;
                try
                {
                    client = serverSocket.AcceptTcpClient();
                }
                catch (SocketException e)
                {
                    if ((e.SocketErrorCode == SocketError.Interrupted)) break;
                }

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesCount = stream.Read(buffer, 0, buffer.Length);
                String username = Encoding.UTF8.GetString(buffer, 0, bytesCount);

                if (thread != null && ingame)
                {
                    buffer = Encoding.UTF8.GetBytes("@@@Ingame!@@@");
                    stream.Write(buffer, 0, buffer.Length);
                    continue;
                }
                if (username == " ") username = $"player {clientsCount}";  // assign username
                if (clientsList.ContainsKey(username))
                {
                    buffer = Encoding.UTF8.GetBytes(" ");
                    stream.Write(buffer, 0, buffer.Length);
                    continue;
                }
                buffer = Encoding.UTF8.GetBytes(username);
                stream.Write(buffer, 0, buffer.Length);

                lock (_lock) clientsList.Add(username, client);
                if (username != "Server")
                {
                    broadcast($"m>>> {username} đã tham gia.", username);
                    scoreBoard.Add(username, 0);
                }

                clientsCount++;

                Thread handlingThread = new Thread(o => clientsHandling((string)o));
                handlingThread.Start(username);
                broadcast($"\t{clientsList.Count - 1}");
            }

            btn_Server.Invoke(new MethodInvoker(delegate ()
            {
                btn_Server.Enabled = true;
                btn_Server.ResetText();
            }));
        }
        public void clientsHandling(string username)
        {
            TcpClient client;
            lock (_lock) client = clientsList[username];
            while (thread.IsAlive)
            {
                int bytesCount = 0;
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                try
                {
                    bytesCount = stream.Read(buffer, 0, buffer.Length);
                }
                catch { }
                if (bytesCount == 0) break;

                string requestFromClient = Encoding.UTF8.GetString(buffer, 0, bytesCount);
                var dataList = requestFromClient.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String data in dataList)
                    if (data[0] == 's')
                    {
                        if (correctPlayer == "" && timeupCount < readyPlayers.Count)
                            try
                            {
                                int ans = Int32.Parse(data.Substring(1));
                                if (ans == luckyNumber)
                                {
                                    correctPlayer = username;
                                    scoreBoard[username] += 10;
                                    broadcast($"mNgười chiến thắng round {currentRound - 1} là...");
                                }
                                if (ans != luckyNumber)
                                {
                                    broadcast($"m{username} đưa ra đáp án sai! ({ans}). -1p");
                                    scoreBoard[username]--;
                                }
                            }
                            catch
                            {
                                broadcast($"m{username} gửi đáp án không hợp lệ! -1p");
                                scoreBoard[username]--;
                            }
                    }
                    else if (data[0] == 'm') broadcast($"m{username}: {data.Substring(1)}");
                    else if (data == "@@@Timeup!@@@")
                    {
                        timeupCount++;
                        if (timeupCount == readyPlayers.Count) (new Thread(() => timeup())).Start();
                    }
                    else if (data == "@@@Ready!@@@")
                    {
                        broadcast($"m>>> {username} đã sẵn sàng!");
                        readyPlayers.Add(username, true);
                        readyCheck();
                    }
            }

            lock (_lock) clientsList.Remove(username);
            client.Client.Shutdown(SocketShutdown.Both);
            client.Close();

            if (username == "Server")
            {
                broadcast("@@@Exit!@@@");
            }
            else
            {
                broadcast($"m>>> {username} đã rời khỏi phòng.");
                if (clientsList.Count == 1)
                {
                    broadcast($"m>>> Tất cả người chơi đã rời trò chơi!");
                    if (ingame)
                    {
                        ingame = false;
                        endGame();
                    }
                }
                broadcast($"\t{clientsList.Count - 1}");
                scoreBoard.Remove(username);
                if (readyPlayers.ContainsKey(username)) readyPlayers.Remove(username);
                readyCheck();
            }
        }

        private void readyCheck()
        {
            if (readyPlayers.Count != 0 && readyPlayers.Count == clientsList.Count - 1)
            {
                ingame = true;
                broadcast($"mCó {readyPlayers.Count} người chơi.");
                (new Thread(roundStart)).Start();
            }
        }
        private void roundStart()
        {
            Thread.Sleep(2000);
            timeupCount = 0;
            if (round == 0)
            {
                round = 5;
                broadcast($"mGame sẽ có {round} vòng!");
                currentRound = 1;
            }
            startRange = rand.Next(0, 11) * 10;
            endRange = startRange + rand.Next(1, 6) * 10;
            luckyNumber = rand.Next(startRange, endRange + 1);
            broadcast($"m>>> Vòng {currentRound}: Nhập số trong khoảng [{startRange}, {endRange}].\n@@@Nextround!@@@{rand.Next(5, 11)}\t{startRange}\t{endRange}\t{luckyNumber}");
            currentRound++;
            correctPlayer = "";
        }
        private void timeup()
        {
            string message;
            if (correctPlayer == "") message = $"mKhông ai đoán đúng. Mấy bro biết chơi game không?";
            else message = $"mChúc mừng {correctPlayer} là người đưa ra câu trả lời đúng và nhanh nhất! +10p";
            broadcast($"{message}\nmSố chính xác là {luckyNumber}.\nm------------------------------");
            if (currentRound > round) (new Thread(endGame)).Start();
            else if (ingame) (new Thread(roundStart)).Start();
        }
        private void endGame()
        {
            if (ingame)
            {
                ingame = false;
                int highscore = Int32.MinValue;
                foreach (var i in scoreBoard)
                    if (i.Value > highscore) highscore = i.Value;

                string message;
                message = $"mĐiểm cao nhất: {highscore}\nmNgười chơi đạt điểm cao nhất:\n";
                foreach (var i in scoreBoard)
                    if (i.Value == highscore) message += $"m  + {i.Key}\n";

                foreach (var i in clientsList)
                {
                    try
                    {
                        NetworkStream stream = i.Value.GetStream();
                        byte[] buffer;
                        if (i.Key == "Server")
                            buffer = Encoding.UTF8.GetBytes($"{message}\n");
                        else
                            buffer = Encoding.UTF8.GetBytes($"{message}\nmĐiểm của bạn: {scoreBoard[i.Key]}\n");
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    catch { }
                }
            }

            broadcast($"m==============================\nm\nmĐang tạo phòng mới...\nmChờ người chơi...\n@@@Newgame!@@@");
            scoreBoard = scoreBoard.ToDictionary(p => p.Key, p => 0);
            round = 0;
            readyPlayers.Clear();
        }
        public void broadcast(string data, String except = "")
        {
            byte[] buffer = Encoding.UTF8.GetBytes($"{data}\n");
            lock (_lock)
            {
                foreach (var c in clientsList) if (c.Key != except)
                    {
                        NetworkStream stream = c.Value.GetStream();
                        stream.Write(buffer, 0, buffer.Length);
                    }
            }
        }
    }
}
