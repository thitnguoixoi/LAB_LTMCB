using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LTMCB_Lab02.Lab02_Bai4;


namespace LTMCB_Lab02
{
    public partial class Lab02_Bai4 : Form
    {
        string path = "F:\\LTMCB\\LAB02\\filelist\\input.txt";
        List<HocVien> dsHocVien = new List<HocVien>();
        BinaryFormatter formatter = new BinaryFormatter();

        public Lab02_Bai4()
        {
            InitializeComponent();
        }
        [Serializable]
        public class HocVien
        {
            public string MSSV { get; set; }
            public string HoTen { get; set; }
            public string DienThoai { get; set; }
            public float DiemToan { get; set; }
            public float DiemVan { get; set; }
            public float DTB
            {
                get {return (DiemToan + DiemVan) / 2;}
            }
            public override string ToString()
            {
                return $"{MSSV}\n{HoTen}\n{DienThoai}\n{DiemToan}\n{DiemVan}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)  //write to input.txt
        {
           
        }
        private void button2_Click(object sender, EventArgs e) //write to output.txt
        {
            List<HocVien> listHV = new List<HocVien>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    HocVien hocVien = new HocVien
                    {
                        MSSV = sr.ReadLine(),
                        HoTen = sr.ReadLine(),
                        DienThoai = sr.ReadLine(),
                        DiemToan = float.Parse(sr.ReadLine()),
                        DiemVan = float.Parse(sr.ReadLine())
                    };
                    listHV.Add(hocVien);
                    sr.ReadLine();
                    sr.ReadLine();
                }
            }
            path = path.Replace("input.txt", "output.txt");
            foreach (HocVien hocVien in listHV)
            {
                File.AppendAllText(path, hocVien.ToString() + Environment.NewLine + hocVien.DTB + Environment.NewLine);
                File.AppendAllText(path, Environment.NewLine + Environment.NewLine);
            }
            MessageBox.Show("Ghi dữ liệu ra file ouput thành công!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)  //enter new input
        {
            HocVien hv = new HocVien();
            hv.MSSV = textBox1.Text;
            hv.HoTen = textBox2.Text;
            hv.DienThoai = textBox3.Text;
            hv.DiemToan = float.Parse(textBox4.Text);
            hv.DiemVan = float.Parse(textBox5.Text);
            dsHocVien.Add(hv);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            MessageBox.Show("Thêm thông tin học viên thành công!");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)  //save data
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("data.bin", FileMode.Create))
            {
                formatter.Serialize(fs, dsHocVien);
            }
            List<HocVien> deserializedDSHV = new List<HocVien>();
            using (FileStream fs = new FileStream("data.bin", FileMode.Open))
            {
                deserializedDSHV = (List<HocVien>)formatter.Deserialize(fs);
                foreach (HocVien hv in deserializedDSHV)
                {
                    File.AppendAllText(path, hv.ToString() + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                }
            }
            FileStream fstream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fstream);
            string content = sr.ReadToEnd();
            richTextBox1.Text = content;
            MessageBox.Show("Lưu dữ liệu học viên thành công!");
            sr.Close();
            fstream.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Lab02_Bai4_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
