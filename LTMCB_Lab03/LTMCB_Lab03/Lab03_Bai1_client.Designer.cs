namespace LTMCB_Lab03
{
    partial class Lab03_Bai1_client
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
            label1 = new Label();
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            portTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 28);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "IP Remote host";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 45);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(106, 23);
            textBox1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(20, 97);
            richTextBox1.Margin = new Padding(2, 2, 2, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(397, 119);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(20, 221);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(78, 20);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(309, 45);
            portTextBox.Margin = new Padding(2, 2, 2, 2);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(106, 23);
            portTextBox.TabIndex = 4;
            portTextBox.TextChanged += textBox2_TextChanged;
            // 
            // Lab03_Bai1_client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 248);
            Controls.Add(portTextBox);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Lab03_Bai1_client";
            Text = "Lab03_Bai1_client";
            FormClosing += Lab03_Bai1_client_FormClosing;
            Load += Lab03_Bai1_client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Button button1;
        private TextBox portTextBox;
    }
}