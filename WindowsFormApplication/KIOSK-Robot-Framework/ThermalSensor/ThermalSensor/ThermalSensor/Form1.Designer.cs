namespace ThermalSensor
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.labStateStatus = new System.Windows.Forms.Label();
            this.cbThermalSensor = new System.Windows.Forms.CheckBox();
            this.labThermalSensorStatus = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(92, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 41);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(92, 101);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(102, 42);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // labStateStatus
            // 
            this.labStateStatus.AutoSize = true;
            this.labStateStatus.Location = new System.Drawing.Point(89, 72);
            this.labStateStatus.Name = "labStateStatus";
            this.labStateStatus.Size = new System.Drawing.Size(79, 13);
            this.labStateStatus.TabIndex = 2;
            this.labStateStatus.Text = "Not Connected";
            // 
            // cbThermalSensor
            // 
            this.cbThermalSensor.AutoSize = true;
            this.cbThermalSensor.Location = new System.Drawing.Point(21, 36);
            this.cbThermalSensor.Name = "cbThermalSensor";
            this.cbThermalSensor.Size = new System.Drawing.Size(98, 17);
            this.cbThermalSensor.TabIndex = 3;
            this.cbThermalSensor.Text = "Thermal sensor";
            this.cbThermalSensor.UseVisualStyleBackColor = true;
            this.cbThermalSensor.CheckedChanged += new System.EventHandler(this.cbThermalSensor_CheckedChanged_1);
            // 
            // labThermalSensorStatus
            // 
            this.labThermalSensorStatus.AutoSize = true;
            this.labThermalSensorStatus.Location = new System.Drawing.Point(18, 69);
            this.labThermalSensorStatus.Name = "labThermalSensorStatus";
            this.labThermalSensorStatus.Size = new System.Drawing.Size(37, 13);
            this.labThermalSensorStatus.TabIndex = 4;
            this.labThermalSensorStatus.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbThermalSensor);
            this.groupBox1.Controls.Add(this.labThermalSensorStatus);
            this.groupBox1.Location = new System.Drawing.Point(41, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 96);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thermal Sensor";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labStateStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label labStateStatus;
        private System.Windows.Forms.CheckBox cbThermalSensor;
        private System.Windows.Forms.Label labThermalSensorStatus;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

