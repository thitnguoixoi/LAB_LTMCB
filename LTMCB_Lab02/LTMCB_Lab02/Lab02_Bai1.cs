﻿using System;
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
    public partial class Lab02_Bai1 : Form
    {
        public Lab02_Bai1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string path;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            path = fs.Name.ToString();
            string content = sr.ReadToEnd();
            richTextBox1.Text = content;
            fs.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            string upcasedText = richTextBox1.Text.ToUpper();
            richTextBox1.Text = upcasedText;
            path = path.Replace("input.txt", "output.txt");
            File.WriteAllText(path, string.Empty);
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(upcasedText);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
