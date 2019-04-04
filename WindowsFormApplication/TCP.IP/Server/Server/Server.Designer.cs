namespace Server
{
    partial class Server
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
            this.btnServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDataReceive = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.labState = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbDataSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnServer
            // 
            this.btnServer.Location = new System.Drawing.Point(9, 91);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(91, 23);
            this.btnServer.TabIndex = 0;
            this.btnServer.Text = "Server Connect";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Address";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(57, 24);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(154, 20);
            this.tbAddress.TabIndex = 4;
            this.tbAddress.Text = "192.168.7.112";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(57, 54);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(154, 20);
            this.tbPort.TabIndex = 4;
            this.tbPort.Text = "8001";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDataReceive);
            this.groupBox1.Location = new System.Drawing.Point(12, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 45);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data receive";
            // 
            // tbDataReceive
            // 
            this.tbDataReceive.Location = new System.Drawing.Point(7, 19);
            this.tbDataReceive.Name = "tbDataReceive";
            this.tbDataReceive.Size = new System.Drawing.Size(204, 20);
            this.tbDataReceive.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnDisconnect);
            this.groupBox2.Controls.Add(this.btnServer);
            this.groupBox2.Controls.Add(this.tbPort);
            this.groupBox2.Controls.Add(this.labState);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbAddress);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 155);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server connect";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(9, 120);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(91, 23);
            this.btnDisconnect.TabIndex = 0;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(106, 96);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(66, 13);
            this.labState.TabIndex = 3;
            this.labState.Text = "State Broker";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbDataSend);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(227, 96);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Send Data";
            // 
            // tbDataSend
            // 
            this.tbDataSend.Location = new System.Drawing.Point(75, 28);
            this.tbDataSend.Name = "tbDataSend";
            this.tbDataSend.Size = new System.Drawing.Size(136, 20);
            this.tbDataSend.TabIndex = 7;
            this.tbDataSend.Text = "Send data from server";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(76, 62);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Data Send";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 352);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDataReceive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbDataSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label4;
    }
}

