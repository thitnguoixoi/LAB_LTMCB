using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMCB_Lab02
{
    public partial class Lab02_Bai2 : Form
    {
        public Lab02_Bai2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            richTextBox1.Text = content;
            string name = ofd.SafeFileName.ToString();
            string url = fs.Name.ToString();
            int charCount = content.Length;
            int lineCount = richTextBox1.Lines.Count();
            string contentForWordCounting = content.Replace("\r\n", "\r");
            contentForWordCounting = contentForWordCounting.Replace('\r', ' ');
            string[] source = contentForWordCounting.Split(new char[] { '.', ',', ':', ';', '?', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = source.Count();
            textBox1.Text = name;
            textBox2.Text = url;
            textBox3.Text = lineCount.ToString();
            textBox4.Text = wordCount.ToString();
            textBox5.Text = charCount.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
