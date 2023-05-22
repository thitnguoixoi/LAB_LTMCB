using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTMCB_Lab04
{
    public partial class Lab04_Bai4_Source : Form
    {
        public Lab04_Bai4_Source()
        {
            InitializeComponent();
        }

        public Lab04_Bai4_Source(string source) : this()
        {
            richTextBox1.Text = source;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
