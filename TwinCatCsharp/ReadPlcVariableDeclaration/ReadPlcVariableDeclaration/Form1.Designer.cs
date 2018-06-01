namespace ReadPlcVariableDeclaration
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.tbDatatypeId = new System.Windows.Forms.TextBox();
            this.tbDatatype = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.tbIndexGroup = new System.Windows.Forms.TextBox();
            this.tbIndexOffset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReadSymbolInfo = new System.Windows.Forms.Button();
            this.tbSymbolname = new System.Windows.Forms.TextBox();
            this.btnFindSymbol = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFlat = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.treeViewSymbols = new System.Windows.Forms.TreeView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(395, 20);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(144, 20);
            this.tbName.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(315, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 45;
            this.label7.Text = "Name:";
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(315, 252);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(80, 23);
            this.btnWrite.TabIndex = 43;
            this.btnWrite.Text = "Write Value";
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(315, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 42;
            this.label6.Text = "Value:";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(395, 212);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(144, 20);
            this.tbValue.TabIndex = 41;
            // 
            // tbDatatypeId
            // 
            this.tbDatatypeId.Location = new System.Drawing.Point(395, 180);
            this.tbDatatypeId.Name = "tbDatatypeId";
            this.tbDatatypeId.ReadOnly = true;
            this.tbDatatypeId.Size = new System.Drawing.Size(144, 20);
            this.tbDatatypeId.TabIndex = 39;
            // 
            // tbDatatype
            // 
            this.tbDatatype.Location = new System.Drawing.Point(395, 148);
            this.tbDatatype.Name = "tbDatatype";
            this.tbDatatype.ReadOnly = true;
            this.tbDatatype.Size = new System.Drawing.Size(144, 20);
            this.tbDatatype.TabIndex = 36;
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(395, 116);
            this.tbSize.Name = "tbSize";
            this.tbSize.ReadOnly = true;
            this.tbSize.Size = new System.Drawing.Size(144, 20);
            this.tbSize.TabIndex = 34;
            // 
            // tbIndexGroup
            // 
            this.tbIndexGroup.Location = new System.Drawing.Point(395, 52);
            this.tbIndexGroup.Name = "tbIndexGroup";
            this.tbIndexGroup.ReadOnly = true;
            this.tbIndexGroup.Size = new System.Drawing.Size(144, 20);
            this.tbIndexGroup.TabIndex = 32;
            // 
            // tbIndexOffset
            // 
            this.tbIndexOffset.Location = new System.Drawing.Point(395, 84);
            this.tbIndexOffset.Name = "tbIndexOffset";
            this.tbIndexOffset.ReadOnly = true;
            this.tbIndexOffset.Size = new System.Drawing.Size(144, 20);
            this.tbIndexOffset.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(315, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 23);
            this.label5.TabIndex = 40;
            this.label5.Text = "Datatype Id:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnReadSymbolInfo);
            this.groupBox2.Controls.Add(this.tbSymbolname);
            this.groupBox2.Controls.Add(this.btnFindSymbol);
            this.groupBox2.Location = new System.Drawing.Point(11, 356);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 88);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Symbol Info";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Symbol Name:";
            // 
            // btnReadSymbolInfo
            // 
            this.btnReadSymbolInfo.Location = new System.Drawing.Point(8, 56);
            this.btnReadSymbolInfo.Name = "btnReadSymbolInfo";
            this.btnReadSymbolInfo.Size = new System.Drawing.Size(104, 23);
            this.btnReadSymbolInfo.TabIndex = 19;
            this.btnReadSymbolInfo.Text = "Read Symbol Info";
            this.btnReadSymbolInfo.Click += new System.EventHandler(this.btnReadSymbolInfo_Click);
            // 
            // tbSymbolname
            // 
            this.tbSymbolname.Location = new System.Drawing.Point(88, 24);
            this.tbSymbolname.Name = "tbSymbolname";
            this.tbSymbolname.Size = new System.Drawing.Size(368, 20);
            this.tbSymbolname.TabIndex = 20;
            this.tbSymbolname.Text = "MAIN.INT32_1";
            // 
            // btnFindSymbol
            // 
            this.btnFindSymbol.Location = new System.Drawing.Point(120, 56);
            this.btnFindSymbol.Name = "btnFindSymbol";
            this.btnFindSymbol.Size = new System.Drawing.Size(104, 23);
            this.btnFindSymbol.TabIndex = 18;
            this.btnFindSymbol.Text = "Find Symbol";
            this.btnFindSymbol.Click += new System.EventHandler(this.btnFindSymbol_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(315, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Datatype:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(315, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 35;
            this.label9.Text = "Size:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(315, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 33;
            this.label2.Text = "Index Group:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(315, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Index Offset:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFlat);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.treeViewSymbols);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 336);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Symbols";
            // 
            // cbFlat
            // 
            this.cbFlat.Location = new System.Drawing.Point(120, 304);
            this.cbFlat.Name = "cbFlat";
            this.cbFlat.Size = new System.Drawing.Size(72, 24);
            this.cbFlat.TabIndex = 2;
            this.cbFlat.Text = "flat";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(8, 304);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(104, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Symbols";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // treeViewSymbols
            // 
            this.treeViewSymbols.Location = new System.Drawing.Point(8, 16);
            this.treeViewSymbols.Name = "treeViewSymbols";
            this.treeViewSymbols.Size = new System.Drawing.Size(280, 280);
            this.treeViewSymbols.TabIndex = 0;
            this.treeViewSymbols.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSymbols_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 464);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.tbDatatypeId);
            this.Controls.Add(this.tbDatatype);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.tbIndexGroup);
            this.Controls.Add(this.tbIndexOffset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.TextBox tbDatatypeId;
        private System.Windows.Forms.TextBox tbDatatype;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.TextBox tbIndexGroup;
        private System.Windows.Forms.TextBox tbIndexOffset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReadSymbolInfo;
        private System.Windows.Forms.TextBox tbSymbolname;
        private System.Windows.Forms.Button btnFindSymbol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbFlat;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TreeView treeViewSymbols;
    }
}

