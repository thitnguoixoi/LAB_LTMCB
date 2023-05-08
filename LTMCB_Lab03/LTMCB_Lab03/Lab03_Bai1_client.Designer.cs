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
            label1.Location = new Point(29, 47);
            label1.Name = "label1";
            label1.Size = new Size(133, 25);
            label1.TabIndex = 0;
            label1.Text = "IP Remote host";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 75);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(29, 162);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(565, 195);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(29, 368);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(441, 75);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(150, 31);
            portTextBox.TabIndex = 4;
            portTextBox.TextChanged += textBox2_TextChanged;
            // 
            // Lab03_Bai1_client
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 414);
            Controls.Add(portTextBox);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Lab03_Bai1_client";
            Text = "Lab03_Bai1_client";
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