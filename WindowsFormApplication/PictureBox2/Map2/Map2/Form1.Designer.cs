namespace Map2
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
            this.btnZone = new System.Windows.Forms.Button();
            this.btnMapRight = new System.Windows.Forms.Button();
            this.btnMapLeft = new System.Windows.Forms.Button();
            this.btnMapDown = new System.Windows.Forms.Button();
            this.btnMapUp = new System.Windows.Forms.Button();
            this.btnOverView = new System.Windows.Forms.Button();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.comboBoxZone = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnZone
            // 
            this.btnZone.Location = new System.Drawing.Point(421, 68);
            this.btnZone.Name = "btnZone";
            this.btnZone.Size = new System.Drawing.Size(100, 50);
            this.btnZone.TabIndex = 1;
            this.btnZone.Text = "Zone";
            this.btnZone.UseVisualStyleBackColor = true;
            this.btnZone.Click += new System.EventHandler(this.btnZone_Click);
            // 
            // btnMapRight
            // 
            this.btnMapRight.Location = new System.Drawing.Point(527, 68);
            this.btnMapRight.Name = "btnMapRight";
            this.btnMapRight.Size = new System.Drawing.Size(100, 50);
            this.btnMapRight.TabIndex = 6;
            this.btnMapRight.Text = "RIGHT";
            this.btnMapRight.UseVisualStyleBackColor = true;
            this.btnMapRight.Click += new System.EventHandler(this.btnMapRight_Click);
            // 
            // btnMapLeft
            // 
            this.btnMapLeft.Location = new System.Drawing.Point(315, 68);
            this.btnMapLeft.Name = "btnMapLeft";
            this.btnMapLeft.Size = new System.Drawing.Size(100, 50);
            this.btnMapLeft.TabIndex = 5;
            this.btnMapLeft.Text = "LEFT";
            this.btnMapLeft.UseVisualStyleBackColor = true;
            this.btnMapLeft.Click += new System.EventHandler(this.btnMapLeft_Click);
            // 
            // btnMapDown
            // 
            this.btnMapDown.Location = new System.Drawing.Point(421, 124);
            this.btnMapDown.Name = "btnMapDown";
            this.btnMapDown.Size = new System.Drawing.Size(100, 50);
            this.btnMapDown.TabIndex = 4;
            this.btnMapDown.Text = "DOWN";
            this.btnMapDown.UseVisualStyleBackColor = true;
            this.btnMapDown.Click += new System.EventHandler(this.btnMapDown_Click);
            // 
            // btnMapUp
            // 
            this.btnMapUp.Location = new System.Drawing.Point(421, 12);
            this.btnMapUp.Name = "btnMapUp";
            this.btnMapUp.Size = new System.Drawing.Size(100, 50);
            this.btnMapUp.TabIndex = 3;
            this.btnMapUp.Text = "UP";
            this.btnMapUp.UseVisualStyleBackColor = true;
            this.btnMapUp.Click += new System.EventHandler(this.btnMapUp_Click);
            // 
            // btnOverView
            // 
            this.btnOverView.Location = new System.Drawing.Point(169, 68);
            this.btnOverView.Name = "btnOverView";
            this.btnOverView.Size = new System.Drawing.Size(100, 50);
            this.btnOverView.TabIndex = 7;
            this.btnOverView.Text = "Over View Map";
            this.btnOverView.UseVisualStyleBackColor = true;
            this.btnOverView.Click += new System.EventHandler(this.btnOverView_Click);
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.Image = global::Map2.Properties.Resources.MapZoom;
            this.pictureBoxMap.Location = new System.Drawing.Point(12, 229);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(950, 407);
            this.pictureBoxMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMap.TabIndex = 2;
            this.pictureBoxMap.TabStop = false;
            this.pictureBoxMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseClick);
            this.pictureBoxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseMove);
            // 
            // comboBoxZone
            // 
            this.comboBoxZone.FormattingEnabled = true;
            this.comboBoxZone.Items.AddRange(new object[] {
            "OriginToVip",
            "VipToOrigin",
            "OriginToFuji",
            "FujiToOrigin"});
            this.comboBoxZone.Location = new System.Drawing.Point(737, 84);
            this.comboBoxZone.Name = "comboBoxZone";
            this.comboBoxZone.Size = new System.Drawing.Size(121, 21);
            this.comboBoxZone.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(699, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Zone";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxZone);
            this.Controls.Add(this.btnOverView);
            this.Controls.Add(this.btnMapDown);
            this.Controls.Add(this.btnMapUp);
            this.Controls.Add(this.btnMapLeft);
            this.Controls.Add(this.btnMapRight);
            this.Controls.Add(this.pictureBoxMap);
            this.Controls.Add(this.btnZone);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnZone;
        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.Button btnMapRight;
        private System.Windows.Forms.Button btnMapLeft;
        private System.Windows.Forms.Button btnMapDown;
        private System.Windows.Forms.Button btnMapUp;
        private System.Windows.Forms.Button btnOverView;
        private System.Windows.Forms.ComboBox comboBoxZone;
        private System.Windows.Forms.Label label1;
    }
}

