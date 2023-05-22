using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LTMCB_Lab04
{
    public partial class Lab04_Bai2 : Form
    {
        public Lab04_Bai2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Post(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                string postData = textBox2.Text;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();

                using (dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    richTextBox1.Text = responseFromServer;
                }

                response.Close();
            }
            catch (Exception ex)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri result) && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps))
            {
                Post(url);
            }
            else
            {
                MessageBox.Show("Biết nhập URL không?");
            }
        }
    }
}
