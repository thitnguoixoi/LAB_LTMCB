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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace LTMCB_Lab02
{
    public partial class Lab02_Bai5 : Form
    {
        public Lab02_Bai5()
        {
            InitializeComponent();
        }

        private void Lab02_Bai5_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            string folderPath = "";
            if (result == DialogResult.OK)
            {
                folderPath = dialog.SelectedPath;
                DirectoryInfo folder = new DirectoryInfo(folderPath);
                FileInfo[] files = folder.GetFiles();
                foreach (FileInfo file in files)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { file.Name, file.Length.ToString(), file.CreationTime.ToString(), file.Extension }));
                }

            }
        }
    }
}
