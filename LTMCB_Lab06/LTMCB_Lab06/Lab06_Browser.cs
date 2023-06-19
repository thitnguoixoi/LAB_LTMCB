using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LTMCB_Lab06
{
    public partial class Lab06_Browser : Form
    {
        private String text;
        public Lab06_Browser(String text)
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            this.text = text;
        }
        private void Browser_Load(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("https://ctxt.io/");
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến https://ctxt.io/", "Lỗi");
                this.Close();
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (webBrowser1.Url.ToString() == "https://ctxt.io/")
                {
                    HtmlElement editable = FindEle("div", "className", "editable");
                    editable.InnerHtml = "";
                    String[] lines = text.Split('\n');
                    foreach (String line in lines) editable.InnerHtml += $"{line}<br>";
                    FindEle("select", "className", "select").SetAttribute("value", "1d");
                    FindEle("input", "className", "button").InvokeMember("click");
                }
                else
                {
                    var url = webBrowser1.Url.ToString();
                    this.Text = url;
                    (new Thread(() => (new Lab06_MsgBox($"Lịch sử trò chơi được lưu tại:\n{url}")).ShowDialog())).Start();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình gửi log lên https://ctxt.io/", "Lỗi");
                this.Close();
            }
        }
        private HtmlElement FindEle(String tag, String att, String attVal)
        {
            HtmlElementCollection elements = webBrowser1.Document.GetElementsByTagName(tag);
            foreach (HtmlElement element in elements)
            {
                if (element.GetAttribute(att).Equals(attVal)) return element;
            }
            return null;
        }
    }
}
