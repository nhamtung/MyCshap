namespace example_Delegate_Event_Invoke
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
            this.btnStart = new System.Windows.Forms.Button();
            this.cbSensor1 = new System.Windows.Forms.CheckBox();
            this.cbSensor2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(55, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbSensor1
            // 
            this.cbSensor1.AutoSize = true;
            this.cbSensor1.Location = new System.Drawing.Point(73, 63);
            this.cbSensor1.Name = "cbSensor1";
            this.cbSensor1.Size = new System.Drawing.Size(39, 17);
            this.cbSensor1.TabIndex = 1;
            this.cbSensor1.Text = "S1";
            this.cbSensor1.UseVisualStyleBackColor = true;
            this.cbSensor1.CheckedChanged += new System.EventHandler(this.cbSensor1_CheckedChanged);
            // 
            // cbSensor2
            // 
            this.cbSensor2.AutoSize = true;
            this.cbSensor2.Location = new System.Drawing.Point(73, 86);
            this.cbSensor2.Name = "cbSensor2";
            this.cbSensor2.Size = new System.Drawing.Size(39, 17);
            this.cbSensor2.TabIndex = 2;
            this.cbSensor2.Text = "S2";
            this.cbSensor2.UseVisualStyleBackColor = true;
            this.cbSensor2.CheckedChanged += new System.EventHandler(this.cbSensor2_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 136);
            this.Controls.Add(this.cbSensor2);
            this.Controls.Add(this.cbSensor1);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox cbSensor1;
        private System.Windows.Forms.CheckBox cbSensor2;
    }
}

