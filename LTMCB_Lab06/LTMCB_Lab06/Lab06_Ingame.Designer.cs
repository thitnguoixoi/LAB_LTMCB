namespace LTMCB_Lab06
{
    partial class Lab06_Ingame
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
            this.components = new System.ComponentModel.Container();
            this.rtb_Chat = new System.Windows.Forms.RichTextBox();
            this.lb_Time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Answer = new System.Windows.Forms.TextBox();
            this.tb_Message = new System.Windows.Forms.TextBox();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Ready = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_Range = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_NumOfPlayers = new System.Windows.Forms.Label();
            this.lb_Result = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rtb_Chat
            // 
            this.rtb_Chat.Location = new System.Drawing.Point(12, 100);
            this.rtb_Chat.Name = "rtb_Chat";
            this.rtb_Chat.Size = new System.Drawing.Size(866, 383);
            this.rtb_Chat.TabIndex = 0;
            this.rtb_Chat.Text = "";
            this.rtb_Chat.TextChanged += new System.EventHandler(this.rtb_Chat_TextChanged);
            // 
            // lb_Time
            // 
            this.lb_Time.AutoSize = true;
            this.lb_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Time.Location = new System.Drawing.Point(58, 30);
            this.lb_Time.Name = "lb_Time";
            this.lb_Time.Size = new System.Drawing.Size(35, 37);
            this.lb_Time.TabIndex = 1;
            this.lb_Time.Text = "0";
            this.lb_Time.Click += new System.EventHandler(this.lb_Time_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chat: ";
            // 
            // tb_Answer
            // 
            this.tb_Answer.Location = new System.Drawing.Point(311, 12);
            this.tb_Answer.Name = "tb_Answer";
            this.tb_Answer.Size = new System.Drawing.Size(100, 26);
            this.tb_Answer.TabIndex = 4;
            this.tb_Answer.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tb_Message
            // 
            this.tb_Message.Location = new System.Drawing.Point(311, 56);
            this.tb_Message.Name = "tb_Message";
            this.tb_Message.Size = new System.Drawing.Size(567, 26);
            this.tb_Message.TabIndex = 5;
            this.tb_Message.TextChanged += new System.EventHandler(this.tb_Message_TextChanged);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(441, 4);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(77, 39);
            this.btn_Submit.TabIndex = 6;
            this.btn_Submit.Text = "Chốt!";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Ready
            // 
            this.btn_Ready.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ready.Location = new System.Drawing.Point(921, 4);
            this.btn_Ready.Name = "btn_Ready";
            this.btn_Ready.Size = new System.Drawing.Size(158, 39);
            this.btn_Ready.TabIndex = 7;
            this.btn_Ready.Text = "Sẵn sàng!";
            this.btn_Ready.UseVisualStyleBackColor = true;
            this.btn_Ready.Click += new System.EventHandler(this.btn_Ready_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Send.Location = new System.Drawing.Point(921, 50);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(158, 39);
            this.btn_Send.TabIndex = 8;
            this.btn_Send.Text = "Gửi";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(965, 428);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(114, 55);
            this.btn_Exit.TabIndex = 9;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.Location = new System.Drawing.Point(965, 95);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(114, 66);
            this.btn_Clear.TabIndex = 10;
            this.btn_Clear.Text = "Xóa khung chat";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(884, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "Khoảng dự đoán:";
            // 
            // lb_Range
            // 
            this.lb_Range.AutoSize = true;
            this.lb_Range.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Range.Location = new System.Drawing.Point(884, 217);
            this.lb_Range.Name = "lb_Range";
            this.lb_Range.Size = new System.Drawing.Size(65, 29);
            this.lb_Range.TabIndex = 12;
            this.lb_Range.Text = "[0, 0]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(884, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Số người chơi:";
            // 
            // lb_NumOfPlayers
            // 
            this.lb_NumOfPlayers.AutoSize = true;
            this.lb_NumOfPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NumOfPlayers.Location = new System.Drawing.Point(884, 302);
            this.lb_NumOfPlayers.Name = "lb_NumOfPlayers";
            this.lb_NumOfPlayers.Size = new System.Drawing.Size(26, 29);
            this.lb_NumOfPlayers.TabIndex = 14;
            this.lb_NumOfPlayers.Text = "0";
            // 
            // lb_Result
            // 
            this.lb_Result.AutoSize = true;
            this.lb_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Result.Location = new System.Drawing.Point(884, 369);
            this.lb_Result.Name = "lb_Result";
            this.lb_Result.Size = new System.Drawing.Size(26, 29);
            this.lb_Result.TabIndex = 16;
            this.lb_Result.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(884, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 29);
            this.label6.TabIndex = 15;
            this.label6.Text = "Đáp án:";
            // 
            // Lab06_Ingame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 495);
            this.Controls.Add(this.lb_Result);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_NumOfPlayers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_Range);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.btn_Ready);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.tb_Message);
            this.Controls.Add(this.tb_Answer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_Time);
            this.Controls.Add(this.rtb_Chat);
            this.Name = "Lab06_Ingame";
            this.Text = "Lab06_Ingame";
            this.Load += new System.EventHandler(this.Lab06_Ingame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_Chat;
        private System.Windows.Forms.Label lb_Time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Answer;
        private System.Windows.Forms.TextBox tb_Message;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Ready;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_Range;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_NumOfPlayers;
        private System.Windows.Forms.Label lb_Result;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer;
    }
}