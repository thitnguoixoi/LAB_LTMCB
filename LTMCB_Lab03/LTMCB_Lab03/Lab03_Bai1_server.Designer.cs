namespace LTMCB_Lab03
{
    partial class Lab03_Bai1_server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(463, 31);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(78, 34);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 42);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(106, 23);
            textBox1.TabIndex = 2;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 70);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(529, 196);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // Lab03_Bai1_server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 278);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Lab03_Bai1_server";
            Text = "Lab03_Bai1_server";
            FormClosing += Lab03_Bai1_server_FormClosing;
            Load += Lab03_Bai1_server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
    }
}