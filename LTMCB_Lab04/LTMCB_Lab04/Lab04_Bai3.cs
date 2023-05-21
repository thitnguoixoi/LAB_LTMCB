using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMCB_Lab04
{
    public partial class Lab04_Bai3 : Form
    {
        public Lab04_Bai3()
        {
            InitializeComponent();
        }

        private void Lab04_Bai3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.DeselectAll();
                WebRequest request = WebRequest.Create(textBox1.Text.ToString().Trim());
                WebResponse response = request.GetResponse(); 
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                response.Close();
                richTextBox1.AppendText(responseFromServer);

                WebClient myClient = new WebClient();
                Stream responseHTML = myClient.OpenRead(textBox1.Text.ToString().Trim());
                myClient.DownloadFile(textBox1.Text.ToString().Trim(), textBox2.Text.ToString().Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("biết nhập URL không?");
            }
        }
    }
}
