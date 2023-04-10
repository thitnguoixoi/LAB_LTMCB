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
    public partial class Lab02_Bai3 : Form
    {
        public Lab02_Bai3()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            path = path.Replace("input.txt", "output.txt");
            File.WriteAllText(path, string.Empty);
            string[] inputArray = richTextBox1.Text.Split('\n');
            string outputContent = "";
            foreach (string s in inputArray)
            {
                string[] parts = s.Split(' ');
                int num1 = int.Parse(parts[0]);
                int num2 = int.Parse(parts[2]);
                switch (parts[1])
                {
                    case "+":
                        outputContent += num1 + " + " + num2 + " = " + (num1 + num2) + "\n";
                        break;
                    case "-":
                        outputContent += num1 + " - " + num2 + " = " + (num1 - num2) + "\n";
                        break;
                    case "*":
                        outputContent += num1 + " * " + num2 + " = " + (num1 * num2) + "\n";
                        break;
                    case "/":
                        outputContent += num1 + " / " + num2 + " = " + (num1 / num2) + "\n";
                        break;
                }
            }
            richTextBox1.Text = outputContent;
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(outputContent);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
