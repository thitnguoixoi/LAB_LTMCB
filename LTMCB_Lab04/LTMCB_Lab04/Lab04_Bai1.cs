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
    public partial class Lab04_Bai1 : Form
    {
        public Lab04_Bai1()
        {
            InitializeComponent();
        }

        private void Lab04_Bai1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.AppendText(getHTML(textBox1.Text.ToString().Trim()));
            }
            catch
            {
                MessageBox.Show("biết nhập URL không?");
            }
        }
        private string getHTML(string szURL)
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(szURL);
            // Get the response. 
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server. 
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access. 
            StreamReader reader = new StreamReader(dataStream);
            // Read the content. 
            string responseFromServer = reader.ReadToEnd();
            // Close the response. 
            response.Close();
            return responseFromServer;
        }
    }
}
