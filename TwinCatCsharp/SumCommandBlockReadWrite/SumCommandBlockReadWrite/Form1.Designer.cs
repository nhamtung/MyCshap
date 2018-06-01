namespace SumCommandBlockReadWrite
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
            this.tbBool2 = new System.Windows.Forms.TextBox();
            this.tbDint2 = new System.Windows.Forms.TextBox();
            this.tbUint2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBool = new System.Windows.Forms.TextBox();
            this.tbDint = new System.Windows.Forms.TextBox();
            this.tbUint = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbBool2
            // 
            this.tbBool2.Location = new System.Drawing.Point(176, 64);
            this.tbBool2.Name = "tbBool2";
            this.tbBool2.Size = new System.Drawing.Size(100, 20);
            this.tbBool2.TabIndex = 24;
            // 
            // tbDint2
            // 
            this.tbDint2.Location = new System.Drawing.Point(176, 38);
            this.tbDint2.Name = "tbDint2";
            this.tbDint2.Size = new System.Drawing.Size(100, 20);
            this.tbDint2.TabIndex = 23;
            // 
            // tbUint2
            // 
            this.tbUint2.Location = new System.Drawing.Point(176, 12);
            this.tbUint2.Name = "tbUint2";
            this.tbUint2.Size = new System.Drawing.Size(100, 20);
            this.tbUint2.TabIndex = 22;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Write";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "boolValue:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "dintValue:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "uintValue:";
            // 
            // tbBool
            // 
            this.tbBool.Location = new System.Drawing.Point(70, 64);
            this.tbBool.Name = "tbBool";
            this.tbBool.Size = new System.Drawing.Size(100, 20);
            this.tbBool.TabIndex = 17;
            // 
            // tbDint
            // 
            this.tbDint.Location = new System.Drawing.Point(70, 38);
            this.tbDint.Name = "tbDint";
            this.tbDint.Size = new System.Drawing.Size(100, 20);
            this.tbDint.TabIndex = 16;
            // 
            // tbUint
            // 
            this.tbUint.Location = new System.Drawing.Point(70, 12);
            this.tbUint.Name = "tbUint";
            this.tbUint.Size = new System.Drawing.Size(100, 20);
            this.tbUint.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 123);
            this.Controls.Add(this.tbBool2);
            this.Controls.Add(this.tbDint2);
            this.Controls.Add(this.tbUint2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBool);
            this.Controls.Add(this.tbDint);
            this.Controls.Add(this.tbUint);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBool2;
        private System.Windows.Forms.TextBox tbDint2;
        private System.Windows.Forms.TextBox tbUint2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBool;
        private System.Windows.Forms.TextBox tbDint;
        private System.Windows.Forms.TextBox tbUint;
        private System.Windows.Forms.Button button1;
    }
}

