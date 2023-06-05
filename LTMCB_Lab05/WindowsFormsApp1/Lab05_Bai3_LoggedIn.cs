using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Lab05_Bai3_LoggedIn : Form
    {
        private string myStr;
        public Lab05_Bai3_LoggedIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab05_Bai3_SendEmail lab05_Bai3_SendEmail = new Lab05_Bai3_SendEmail();
            lab05_Bai3_SendEmail.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lab05_Bai3_BrowseEmail lab05_Bai3_BrowseEmail = new Lab05_Bai3_BrowseEmail();
            lab05_Bai3_BrowseEmail.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
