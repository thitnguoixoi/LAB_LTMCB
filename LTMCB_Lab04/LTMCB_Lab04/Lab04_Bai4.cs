using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace LTMCB_Lab04
{
    public partial class Lab04_Bai4 : Form
    {
        public Lab04_Bai4()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private string getSource(string szURL)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = textBox1.Text;
                webBrowser1.Navigate(url);
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "D:\\OneDrive - Trường ĐH CNTT - University of Information Technology\\Nam2\\Ky2\\LTMCB\\LAB\\Lab04_Path";
            string url = textBox1.Text;
            HttpClient httpClient = new HttpClient();
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load(url);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (HtmlNode link in document.DocumentNode.Descendants("a").Where(x => x.Attributes["href"] != null))
            {
                string linkUrl = link.Attributes["href"].Value;

                Uri uri = new Uri(url);
                Uri linkUri = new Uri(uri, linkUrl);
                string filePath = Path.Combine(path, linkUri.Segments.Last());

                HttpResponseMessage response = httpClient.GetAsync(linkUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    byte[] content = response.Content.ReadAsByteArrayAsync().Result;
                    File.WriteAllBytes(filePath, content);
                }
            }
            foreach (HtmlNode img in document.DocumentNode.Descendants("img").Where(x => x.Attributes["src"] != null))
            {
                string imgUrl = img.Attributes["src"].Value;

                Uri uri = new Uri(url);
                Uri imgUri = new Uri(uri, imgUrl);
                string filePath = Path.Combine(path, imgUri.Segments.Last());

                HttpResponseMessage response = httpClient.GetAsync(imgUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    byte[] content = response.Content.ReadAsByteArrayAsync().Result;
                    File.WriteAllBytes(filePath, content);
                }
                File.WriteAllText(Path.Combine(path, "index.html"), document.DocumentNode.OuterHtml);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Lab04_Bai4_Source lab04_Bai4_Source = new Lab04_Bai4_Source(getSource(textBox1.Text)); 
            lab04_Bai4_Source.Show();
        }
    }
}
