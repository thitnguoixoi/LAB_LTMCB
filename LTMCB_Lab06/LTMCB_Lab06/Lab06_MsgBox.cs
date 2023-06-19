using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LTMCB_Lab06
{
    public partial class Lab06_MsgBox : Form
    {
        public Lab06_MsgBox(String text)
        {
            InitializeComponent();
            richTextBox1.Text = text;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
