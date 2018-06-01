namespace ReadAndWriteVariableAnyType
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
            this.btnDeleteNotifications = new System.Windows.Forms.Button();
            this.btnAddNotifications = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.tbComplexStruct_dintArr = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.tbComplexStruct_ByteVal = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.tbComplexStruct_SimpleStruct1_lrealVal = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.tbComplexStruct_SimpleStruct_dintVal = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.tbComplexStruct_stringVal = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.tbComplexStruct_boolVal = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.tbComplexStruct_IntVal = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.tbStr2 = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.tbStr1 = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.tblreal1 = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.tbUsint1 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.tbDint1 = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.tbBool1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeleteNotifications
            // 
            this.btnDeleteNotifications.Location = new System.Drawing.Point(479, 118);
            this.btnDeleteNotifications.Name = "btnDeleteNotifications";
            this.btnDeleteNotifications.Size = new System.Drawing.Size(112, 23);
            this.btnDeleteNotifications.TabIndex = 20;
            this.btnDeleteNotifications.Text = "Delete Notifications";
            this.btnDeleteNotifications.Click += new System.EventHandler(this.btnDeleteNotifications_Click);
            // 
            // btnAddNotifications
            // 
            this.btnAddNotifications.Location = new System.Drawing.Point(479, 86);
            this.btnAddNotifications.Name = "btnAddNotifications";
            this.btnAddNotifications.Size = new System.Drawing.Size(112, 23);
            this.btnAddNotifications.TabIndex = 19;
            this.btnAddNotifications.Text = "Add Notifications";
            this.btnAddNotifications.Click += new System.EventHandler(this.btnAddNotifications_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(479, 54);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(112, 23);
            this.btnWrite.TabIndex = 18;
            this.btnWrite.Text = "Write";
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(479, 22);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(112, 23);
            this.btnRead.TabIndex = 17;
            this.btnRead.Text = "Read";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.tbComplexStruct_dintArr);
            this.GroupBox3.Controls.Add(this.Label14);
            this.GroupBox3.Controls.Add(this.tbComplexStruct_ByteVal);
            this.GroupBox3.Controls.Add(this.Label13);
            this.GroupBox3.Controls.Add(this.tbComplexStruct_SimpleStruct1_lrealVal);
            this.GroupBox3.Controls.Add(this.Label12);
            this.GroupBox3.Controls.Add(this.tbComplexStruct_SimpleStruct_dintVal);
            this.GroupBox3.Controls.Add(this.Label11);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.tbComplexStruct_stringVal);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Controls.Add(this.tbComplexStruct_boolVal);
            this.GroupBox3.Controls.Add(this.Label9);
            this.GroupBox3.Controls.Add(this.tbComplexStruct_IntVal);
            this.GroupBox3.Controls.Add(this.Label10);
            this.GroupBox3.Location = new System.Drawing.Point(191, 14);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(272, 280);
            this.GroupBox3.TabIndex = 16;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Complex Structure";
            // 
            // tbComplexStruct_dintArr
            // 
            this.tbComplexStruct_dintArr.Location = new System.Drawing.Point(64, 56);
            this.tbComplexStruct_dintArr.Name = "tbComplexStruct_dintArr";
            this.tbComplexStruct_dintArr.Size = new System.Drawing.Size(192, 20);
            this.tbComplexStruct_dintArr.TabIndex = 20;
            // 
            // Label14
            // 
            this.Label14.Location = new System.Drawing.Point(8, 56);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(48, 16);
            this.Label14.TabIndex = 19;
            this.Label14.Text = "dintArr:";
            // 
            // tbComplexStruct_ByteVal
            // 
            this.tbComplexStruct_ByteVal.Location = new System.Drawing.Point(64, 120);
            this.tbComplexStruct_ByteVal.Name = "tbComplexStruct_ByteVal";
            this.tbComplexStruct_ByteVal.Size = new System.Drawing.Size(192, 20);
            this.tbComplexStruct_ByteVal.TabIndex = 18;
            // 
            // Label13
            // 
            this.Label13.Location = new System.Drawing.Point(8, 120);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(56, 16);
            this.Label13.TabIndex = 17;
            this.Label13.Text = "byteVal:";
            // 
            // tbComplexStruct_SimpleStruct1_lrealVal
            // 
            this.tbComplexStruct_SimpleStruct1_lrealVal.Location = new System.Drawing.Point(104, 216);
            this.tbComplexStruct_SimpleStruct1_lrealVal.Name = "tbComplexStruct_SimpleStruct1_lrealVal";
            this.tbComplexStruct_SimpleStruct1_lrealVal.Size = new System.Drawing.Size(152, 20);
            this.tbComplexStruct_SimpleStruct1_lrealVal.TabIndex = 16;
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(48, 216);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(48, 16);
            this.Label12.TabIndex = 15;
            this.Label12.Text = "lrealVal:";
            // 
            // tbComplexStruct_SimpleStruct_dintVal
            // 
            this.tbComplexStruct_SimpleStruct_dintVal.Location = new System.Drawing.Point(104, 248);
            this.tbComplexStruct_SimpleStruct_dintVal.Name = "tbComplexStruct_SimpleStruct_dintVal";
            this.tbComplexStruct_SimpleStruct_dintVal.Size = new System.Drawing.Size(152, 20);
            this.tbComplexStruct_SimpleStruct_dintVal.TabIndex = 14;
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(48, 248);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(48, 16);
            this.Label11.TabIndex = 13;
            this.Label11.Text = "dintVal:";
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(8, 184);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(80, 23);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "simpleStruct1:";
            // 
            // tbComplexStruct_stringVal
            // 
            this.tbComplexStruct_stringVal.Location = new System.Drawing.Point(64, 152);
            this.tbComplexStruct_stringVal.Name = "tbComplexStruct_stringVal";
            this.tbComplexStruct_stringVal.Size = new System.Drawing.Size(192, 20);
            this.tbComplexStruct_stringVal.TabIndex = 11;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(8, 152);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(56, 16);
            this.Label3.TabIndex = 10;
            this.Label3.Text = "stringVal:";
            // 
            // tbComplexStruct_boolVal
            // 
            this.tbComplexStruct_boolVal.Location = new System.Drawing.Point(64, 88);
            this.tbComplexStruct_boolVal.Name = "tbComplexStruct_boolVal";
            this.tbComplexStruct_boolVal.Size = new System.Drawing.Size(192, 20);
            this.tbComplexStruct_boolVal.TabIndex = 3;
            // 
            // Label9
            // 
            this.Label9.Location = new System.Drawing.Point(8, 88);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(48, 16);
            this.Label9.TabIndex = 2;
            this.Label9.Text = "boolVal:";
            // 
            // tbComplexStruct_IntVal
            // 
            this.tbComplexStruct_IntVal.Location = new System.Drawing.Point(64, 27);
            this.tbComplexStruct_IntVal.Name = "tbComplexStruct_IntVal";
            this.tbComplexStruct_IntVal.Size = new System.Drawing.Size(192, 20);
            this.tbComplexStruct_IntVal.TabIndex = 1;
            // 
            // Label10
            // 
            this.Label10.Location = new System.Drawing.Point(8, 27);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(40, 16);
            this.Label10.TabIndex = 0;
            this.Label10.Text = "intVal:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.tbStr2);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.tbStr1);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Location = new System.Drawing.Point(15, 174);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(168, 88);
            this.GroupBox2.TabIndex = 15;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "String Types";
            // 
            // tbStr2
            // 
            this.tbStr2.Location = new System.Drawing.Point(48, 56);
            this.tbStr2.Name = "tbStr2";
            this.tbStr2.Size = new System.Drawing.Size(104, 20);
            this.tbStr2.TabIndex = 3;
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(8, 58);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(40, 16);
            this.Label7.TabIndex = 2;
            this.Label7.Text = "str2:";
            // 
            // tbStr1
            // 
            this.tbStr1.Location = new System.Drawing.Point(48, 24);
            this.tbStr1.Name = "tbStr1";
            this.tbStr1.Size = new System.Drawing.Size(104, 20);
            this.tbStr1.TabIndex = 1;
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(8, 27);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(40, 16);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "str1:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.tblreal1);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.tbUsint1);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.tbDint1);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.tbBool1);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(15, 14);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(168, 152);
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Primitive Types";
            // 
            // tblreal1
            // 
            this.tblreal1.Location = new System.Drawing.Point(48, 120);
            this.tblreal1.Name = "tblreal1";
            this.tblreal1.Size = new System.Drawing.Size(104, 20);
            this.tblreal1.TabIndex = 11;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(8, 120);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(40, 16);
            this.Label6.TabIndex = 10;
            this.Label6.Text = "lreal1:";
            // 
            // tbUsint1
            // 
            this.tbUsint1.Location = new System.Drawing.Point(48, 88);
            this.tbUsint1.Name = "tbUsint1";
            this.tbUsint1.Size = new System.Drawing.Size(104, 20);
            this.tbUsint1.TabIndex = 7;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(8, 88);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(40, 16);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "usint1:";
            // 
            // tbDint1
            // 
            this.tbDint1.Location = new System.Drawing.Point(48, 58);
            this.tbDint1.Name = "tbDint1";
            this.tbDint1.Size = new System.Drawing.Size(104, 20);
            this.tbDint1.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(8, 58);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 16);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "dint1:";
            // 
            // tbBool1
            // 
            this.tbBool1.Location = new System.Drawing.Point(48, 27);
            this.tbBool1.Name = "tbBool1";
            this.tbBool1.Size = new System.Drawing.Size(104, 20);
            this.tbBool1.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 27);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "bool1:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 301);
            this.Controls.Add(this.btnDeleteNotifications);
            this.Controls.Add(this.btnAddNotifications);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnDeleteNotifications;
        internal System.Windows.Forms.Button btnAddNotifications;
        internal System.Windows.Forms.Button btnWrite;
        internal System.Windows.Forms.Button btnRead;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.TextBox tbComplexStruct_dintArr;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox tbComplexStruct_ByteVal;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox tbComplexStruct_SimpleStruct1_lrealVal;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox tbComplexStruct_SimpleStruct_dintVal;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox tbComplexStruct_stringVal;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox tbComplexStruct_boolVal;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox tbComplexStruct_IntVal;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox tbStr2;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox tbStr1;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox tblreal1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox tbUsint1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox tbDint1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox tbBool1;
        internal System.Windows.Forms.Label Label1;
    }
}

