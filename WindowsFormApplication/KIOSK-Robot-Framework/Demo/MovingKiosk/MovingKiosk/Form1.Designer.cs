namespace MovingKiosk
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
            this.btForward = new System.Windows.Forms.Button();
            this.btBackward = new System.Windows.Forms.Button();
            this.btTurnLeft = new System.Windows.Forms.Button();
            this.btTurnRight = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.cboSpeed = new System.Windows.Forms.ComboBox();
            this.cboCom = new System.Windows.Forms.ComboBox();
            this.labSpeed = new System.Windows.Forms.Label();
            this.labCOM = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btForward
            // 
            this.btForward.Location = new System.Drawing.Point(112, 124);
            this.btForward.Name = "btForward";
            this.btForward.Size = new System.Drawing.Size(82, 53);
            this.btForward.TabIndex = 0;
            this.btForward.Text = "Forward";
            this.btForward.UseVisualStyleBackColor = true;
            this.btForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btForward_MouseDown);
            this.btForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btForward_MouseUp);
            // 
            // btBackward
            // 
            this.btBackward.Location = new System.Drawing.Point(112, 256);
            this.btBackward.Name = "btBackward";
            this.btBackward.Size = new System.Drawing.Size(82, 53);
            this.btBackward.TabIndex = 0;
            this.btBackward.Text = "Backward";
            this.btBackward.UseVisualStyleBackColor = true;
            this.btBackward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btBackward_MouseDown);
            this.btBackward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btBackward_MouseUp);
            // 
            // btTurnLeft
            // 
            this.btTurnLeft.Location = new System.Drawing.Point(12, 189);
            this.btTurnLeft.Name = "btTurnLeft";
            this.btTurnLeft.Size = new System.Drawing.Size(82, 53);
            this.btTurnLeft.TabIndex = 0;
            this.btTurnLeft.Text = "TurnLeft";
            this.btTurnLeft.UseVisualStyleBackColor = true;
            this.btTurnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btTurnLeft_MouseDown);
            this.btTurnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btTurnLeft_MouseUp);
            // 
            // btTurnRight
            // 
            this.btTurnRight.Location = new System.Drawing.Point(219, 189);
            this.btTurnRight.Name = "btTurnRight";
            this.btTurnRight.Size = new System.Drawing.Size(82, 53);
            this.btTurnRight.TabIndex = 0;
            this.btTurnRight.Text = "TurnRight";
            this.btTurnRight.UseVisualStyleBackColor = true;
            this.btTurnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btTurnRight_MouseDown);
            this.btTurnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btTurnRight_MouseUp);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(219, 37);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(82, 53);
            this.btConnect.TabIndex = 0;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // cboSpeed
            // 
            this.cboSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpeed.FormattingEnabled = true;
            this.cboSpeed.Items.AddRange(new object[] {
            "Slow",
            "Fast"});
            this.cboSpeed.Location = new System.Drawing.Point(129, 353);
            this.cboSpeed.Name = "cboSpeed";
            this.cboSpeed.Size = new System.Drawing.Size(121, 21);
            this.cboSpeed.TabIndex = 1;
            this.cboSpeed.SelectedIndexChanged += new System.EventHandler(this.cboSpeed_SelectedIndexChanged);
            // 
            // cboCom
            // 
            this.cboCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCom.FormattingEnabled = true;
            this.cboCom.Location = new System.Drawing.Point(85, 54);
            this.cboCom.Name = "cboCom";
            this.cboCom.Size = new System.Drawing.Size(107, 21);
            this.cboCom.TabIndex = 1;
            this.cboCom.DropDown += new System.EventHandler(this.cboCom_DropDown);
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.Location = new System.Drawing.Point(45, 356);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(38, 13);
            this.labSpeed.TabIndex = 2;
            this.labSpeed.Text = "Speed";
            // 
            // labCOM
            // 
            this.labCOM.AutoSize = true;
            this.labCOM.Location = new System.Drawing.Point(12, 57);
            this.labCOM.Name = "labCOM";
            this.labCOM.Size = new System.Drawing.Size(53, 13);
            this.labCOM.TabIndex = 2;
            this.labCOM.Text = "COM Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 406);
            this.Controls.Add(this.labCOM);
            this.Controls.Add(this.labSpeed);
            this.Controls.Add(this.cboCom);
            this.Controls.Add(this.cboSpeed);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.btTurnRight);
            this.Controls.Add(this.btTurnLeft);
            this.Controls.Add(this.btBackward);
            this.Controls.Add(this.btForward);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovingKiosk";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btForward;
        private System.Windows.Forms.Button btBackward;
        private System.Windows.Forms.Button btTurnLeft;
        private System.Windows.Forms.Button btTurnRight;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.ComboBox cboSpeed;
        private System.Windows.Forms.ComboBox cboCom;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.Label labCOM;
    }
}

