﻿namespace LTMCB_Lab03
{
    partial class Lab03
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
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(267, 31);
            button1.Name = "button1";
            button1.Size = new Size(120, 72);
            button1.TabIndex = 0;
            button1.Text = "Bài 1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(267, 155);
            button2.Name = "button2";
            button2.Size = new Size(120, 72);
            button2.TabIndex = 1;
            button2.Text = "Bài 2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(267, 279);
            button3.Name = "button3";
            button3.Size = new Size(120, 72);
            button3.TabIndex = 2;
            button3.Text = "Bài 3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.AutoSize = true;
            button4.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(267, 403);
            button4.Name = "button4";
            button4.Size = new Size(120, 72);
            button4.TabIndex = 3;
            button4.Text = "Bài 4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Lab03
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 515);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Lab03";
            Text = "Lab03";
            Load += Lab03_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}