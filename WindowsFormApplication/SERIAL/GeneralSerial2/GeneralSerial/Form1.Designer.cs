namespace GeneralSerial
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
            this.components = new System.ComponentModel.Container();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.Connect = new System.Windows.Forms.Button();
            this.Disconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.textBoxReceive = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnDisplayData = new System.Windows.Forms.Button();
            this.cbHex = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(649, 34);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(649, 89);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new System.Drawing.Point(12, 34);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxComPort.TabIndex = 2;
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "56000",
            "115200",
            "128000",
            "256000",
            "500000",
            "921600"});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(162, 34);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaudrate.TabIndex = 2;
            this.comboBoxBaudrate.Text = "921600";
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(316, 11);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 64);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Disconnect
            // 
            this.Disconnect.Location = new System.Drawing.Point(397, 11);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(75, 64);
            this.Disconnect.TabIndex = 0;
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "COM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baudrate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Send";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Receive";
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(564, 34);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(75, 21);
            this.textBoxSend.TabIndex = 4;
            this.textBoxSend.Text = "2";
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.Location = new System.Drawing.Point(15, 118);
            this.textBoxReceive.Multiline = true;
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxReceive.Size = new System.Drawing.Size(794, 819);
            this.textBoxReceive.TabIndex = 4;
            // 
            // btnDisplayData
            // 
            this.btnDisplayData.Location = new System.Drawing.Point(564, 89);
            this.btnDisplayData.Name = "btnDisplayData";
            this.btnDisplayData.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayData.TabIndex = 5;
            this.btnDisplayData.Text = "Display";
            this.btnDisplayData.UseVisualStyleBackColor = true;
            this.btnDisplayData.Click += new System.EventHandler(this.btnDisplayData_Click);
            // 
            // cbHex
            // 
            this.cbHex.AutoSize = true;
            this.cbHex.Location = new System.Drawing.Point(492, 93);
            this.cbHex.Name = "cbHex";
            this.cbHex.Size = new System.Drawing.Size(48, 17);
            this.cbHex.TabIndex = 6;
            this.cbHex.Text = "HEX";
            this.cbHex.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 949);
            this.Controls.Add(this.cbHex);
            this.Controls.Add(this.btnDisplayData);
            this.Controls.Add(this.textBoxReceive);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxBaudrate);
            this.Controls.Add(this.comboBoxComPort);
            this.Controls.Add(this.Disconnect);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Name = "Form1";
            this.Text = "7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox comboBoxComPort;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button Disconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxSend;
        public System.Windows.Forms.TextBox textBoxReceive;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnDisplayData;
        private System.Windows.Forms.CheckBox cbHex;
    }
}

