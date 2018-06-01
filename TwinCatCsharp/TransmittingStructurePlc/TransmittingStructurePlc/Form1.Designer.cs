namespace TransmittingStructurePlc
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbByte = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLReal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbReal = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbReal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbLReal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbByte);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDint);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbInt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PLC Struct";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Int value:";
            // 
            // tbInt
            // 
            this.tbInt.Location = new System.Drawing.Point(74, 25);
            this.tbInt.Name = "tbInt";
            this.tbInt.Size = new System.Drawing.Size(96, 20);
            this.tbInt.TabIndex = 1;
            this.tbInt.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "DInt value:";
            // 
            // tbDint
            // 
            this.tbDint.Location = new System.Drawing.Point(74, 51);
            this.tbDint.Name = "tbDint";
            this.tbDint.Size = new System.Drawing.Size(96, 20);
            this.tbDint.TabIndex = 1;
            this.tbDint.Text = "10000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Byte value:";
            // 
            // tbByte
            // 
            this.tbByte.Location = new System.Drawing.Point(74, 77);
            this.tbByte.Name = "tbByte";
            this.tbByte.Size = new System.Drawing.Size(96, 20);
            this.tbByte.TabIndex = 1;
            this.tbByte.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "LReal value:";
            // 
            // tbLReal
            // 
            this.tbLReal.Location = new System.Drawing.Point(74, 103);
            this.tbLReal.Name = "tbLReal";
            this.tbLReal.Size = new System.Drawing.Size(96, 20);
            this.tbLReal.TabIndex = 1;
            this.tbLReal.Text = "3.145";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Real value:";
            // 
            // tbReal
            // 
            this.tbReal.Location = new System.Drawing.Point(74, 129);
            this.tbReal.Name = "tbReal";
            this.tbReal.Size = new System.Drawing.Size(96, 20);
            this.tbReal.TabIndex = 1;
            this.tbReal.Text = "3.14";
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(13, 183);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(181, 23);
            this.btnWrite.TabIndex = 1;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 216);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbReal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbLReal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbByte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWrite;
    }
}

