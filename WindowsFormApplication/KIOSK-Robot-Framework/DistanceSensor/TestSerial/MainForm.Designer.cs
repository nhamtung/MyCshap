namespace TestSerial
{
    partial class MainForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSensorStatus = new System.Windows.Forms.Label();
            this.cbDisSens2 = new System.Windows.Forms.CheckBox();
            this.cbDisSens1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSensorStatus);
            this.groupBox2.Controls.Add(this.cbDisSens2);
            this.groupBox2.Controls.Add(this.cbDisSens1);
            this.groupBox2.Location = new System.Drawing.Point(94, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 144);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Distance Sensors ";
            // 
            // lblSensorStatus
            // 
            this.lblSensorStatus.AutoSize = true;
            this.lblSensorStatus.Location = new System.Drawing.Point(28, 110);
            this.lblSensorStatus.Name = "lblSensorStatus";
            this.lblSensorStatus.Size = new System.Drawing.Size(37, 13);
            this.lblSensorStatus.TabIndex = 11;
            this.lblSensorStatus.Text = "Status";
            // 
            // cbDisSens2
            // 
            this.cbDisSens2.AutoSize = true;
            this.cbDisSens2.Location = new System.Drawing.Point(31, 80);
            this.cbDisSens2.Name = "cbDisSens2";
            this.cbDisSens2.Size = new System.Drawing.Size(39, 17);
            this.cbDisSens2.TabIndex = 4;
            this.cbDisSens2.Text = "S2";
            this.cbDisSens2.UseVisualStyleBackColor = true;
            this.cbDisSens2.CheckedChanged += new System.EventHandler(this.cbDisSens2_CheckedChanged);
            // 
            // cbDisSens1
            // 
            this.cbDisSens1.AutoSize = true;
            this.cbDisSens1.Location = new System.Drawing.Point(31, 46);
            this.cbDisSens1.Name = "cbDisSens1";
            this.cbDisSens1.Size = new System.Drawing.Size(39, 17);
            this.cbDisSens1.TabIndex = 3;
            this.cbDisSens1.Text = "S1";
            this.cbDisSens1.UseVisualStyleBackColor = true;
            this.cbDisSens1.CheckedChanged += new System.EventHandler(this.cbDisSens1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Not connected ";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(79, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(142, 58);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(79, 137);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(142, 58);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 345);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Name = "MainForm";
            this.Text = "Robot Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox cbDisSens2;
        private System.Windows.Forms.CheckBox cbDisSens1;
        private System.Windows.Forms.Label lblSensorStatus;
    }
}

