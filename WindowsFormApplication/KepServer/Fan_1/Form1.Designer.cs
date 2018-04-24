namespace Fan_1
{
    partial class Form1
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
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.Btn_Disconnect = new System.Windows.Forms.Button();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Btn_Stops = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Bt_Write = new System.Windows.Forms.Button();
            this.Tb_Write = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.BackColor = System.Drawing.Color.Blue;
            this.Btn_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Connect.Location = new System.Drawing.Point(12, 60);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(108, 30);
            this.Btn_Connect.TabIndex = 0;
            this.Btn_Connect.Text = "CONNECT";
            this.Btn_Connect.UseVisualStyleBackColor = false;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // Btn_Disconnect
            // 
            this.Btn_Disconnect.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Btn_Disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Disconnect.Location = new System.Drawing.Point(126, 60);
            this.Btn_Disconnect.Name = "Btn_Disconnect";
            this.Btn_Disconnect.Size = new System.Drawing.Size(116, 30);
            this.Btn_Disconnect.TabIndex = 1;
            this.Btn_Disconnect.Text = "DISCONNECT";
            this.Btn_Disconnect.UseVisualStyleBackColor = false;
            this.Btn_Disconnect.Click += new System.EventHandler(this.Btn_Disconnect_Click);
            // 
            // Btn_Start
            // 
            this.Btn_Start.BackColor = System.Drawing.Color.LawnGreen;
            this.Btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Start.Location = new System.Drawing.Point(12, 138);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(108, 34);
            this.Btn_Start.TabIndex = 2;
            this.Btn_Start.Text = "START";
            this.Btn_Start.UseVisualStyleBackColor = false;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            this.Btn_Start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Btn_Start_KeyPress);
            // 
            // Btn_Stops
            // 
            this.Btn_Stops.BackColor = System.Drawing.Color.Red;
            this.Btn_Stops.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Stops.Location = new System.Drawing.Point(12, 199);
            this.Btn_Stops.Name = "Btn_Stops";
            this.Btn_Stops.Size = new System.Drawing.Size(108, 36);
            this.Btn_Stops.TabIndex = 3;
            this.Btn_Stops.Text = "STOPS";
            this.Btn_Stops.UseVisualStyleBackColor = false;
            this.Btn_Stops.Click += new System.EventHandler(this.Btn_Stops_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(370, 60);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(65, 30);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "STATUS :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(30, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(475, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Điều Khiển Và Giám Sát Trạm Bơm Nước Sạch 60m3/Ngày";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(-1, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(686, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Xem Thông Tin";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(193, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 145);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SpringGreen;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 35);
            this.button2.TabIndex = 9;
            this.button2.Text = "Chuyển Trang";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Bt_Write
            // 
            this.Bt_Write.BackColor = System.Drawing.Color.SteelBlue;
            this.Bt_Write.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Write.Location = new System.Drawing.Point(498, 121);
            this.Bt_Write.Name = "Bt_Write";
            this.Bt_Write.Size = new System.Drawing.Size(130, 53);
            this.Bt_Write.TabIndex = 10;
            this.Bt_Write.Text = "WriTe";
            this.Bt_Write.UseVisualStyleBackColor = false;
            this.Bt_Write.Click += new System.EventHandler(this.Bt_Write_Click);
            // 
            // Tb_Write
            // 
            this.Tb_Write.Location = new System.Drawing.Point(498, 199);
            this.Tb_Write.Multiline = true;
            this.Tb_Write.Name = "Tb_Write";
            this.Tb_Write.Size = new System.Drawing.Size(130, 36);
            this.Tb_Write.TabIndex = 11;
            this.Tb_Write.TextChanged += new System.EventHandler(this.Tb_Write_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(391, 261);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 39);
            this.button3.TabIndex = 12;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 395);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Tb_Write);
            this.Controls.Add(this.Bt_Write);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Btn_Stops);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.Btn_Disconnect);
            this.Controls.Add(this.Btn_Connect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.Button Btn_Disconnect;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Button Btn_Stops;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Bt_Write;
        private System.Windows.Forms.TextBox Tb_Write;
        private System.Windows.Forms.Button button3;
    }
}

