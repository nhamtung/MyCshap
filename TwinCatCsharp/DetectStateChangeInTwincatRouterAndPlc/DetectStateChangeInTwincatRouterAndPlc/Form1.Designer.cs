namespace DetectStateChangeInTwincatRouterAndPlc
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
            this._exitButton = new System.Windows.Forms.Button();
            this._plcLabelValue = new System.Windows.Forms.Label();
            this._routerLabelValue = new System.Windows.Forms.Label();
            this._plcLabelTitle = new System.Windows.Forms.Label();
            this._routerLabelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _exitButton
            // 
            this._exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._exitButton.Location = new System.Drawing.Point(138, 124);
            this._exitButton.Margin = new System.Windows.Forms.Padding(2);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(96, 34);
            this._exitButton.TabIndex = 9;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this._exitButton_Click_1);
            // 
            // _plcLabelValue
            // 
            this._plcLabelValue.AutoSize = true;
            this._plcLabelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._plcLabelValue.Location = new System.Drawing.Point(157, 68);
            this._plcLabelValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._plcLabelValue.Name = "_plcLabelValue";
            this._plcLabelValue.Size = new System.Drawing.Size(0, 24);
            this._plcLabelValue.TabIndex = 8;
            // 
            // _routerLabelValue
            // 
            this._routerLabelValue.AutoSize = true;
            this._routerLabelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._routerLabelValue.Location = new System.Drawing.Point(157, 17);
            this._routerLabelValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._routerLabelValue.Name = "_routerLabelValue";
            this._routerLabelValue.Size = new System.Drawing.Size(0, 24);
            this._routerLabelValue.TabIndex = 7;
            // 
            // _plcLabelTitle
            // 
            this._plcLabelTitle.AutoSize = true;
            this._plcLabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._plcLabelTitle.Location = new System.Drawing.Point(8, 68);
            this._plcLabelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._plcLabelTitle.Name = "_plcLabelTitle";
            this._plcLabelTitle.Size = new System.Drawing.Size(106, 24);
            this._plcLabelTitle.TabIndex = 6;
            this._plcLabelTitle.Text = "PLC State:";
            // 
            // _routerLabelTitle
            // 
            this._routerLabelTitle.AutoSize = true;
            this._routerLabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._routerLabelTitle.Location = new System.Drawing.Point(8, 17);
            this._routerLabelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._routerLabelTitle.Name = "_routerLabelTitle";
            this._routerLabelTitle.Size = new System.Drawing.Size(130, 24);
            this._routerLabelTitle.TabIndex = 5;
            this._routerLabelTitle.Text = "Router State:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 173);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._plcLabelValue);
            this.Controls.Add(this._routerLabelValue);
            this.Controls.Add(this._plcLabelTitle);
            this.Controls.Add(this._routerLabelTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _exitButton;
        private System.Windows.Forms.Label _plcLabelValue;
        private System.Windows.Forms.Label _routerLabelValue;
        private System.Windows.Forms.Label _plcLabelTitle;
        private System.Windows.Forms.Label _routerLabelTitle;
    }
}

