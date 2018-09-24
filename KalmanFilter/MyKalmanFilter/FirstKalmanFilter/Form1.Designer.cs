namespace FirstKalmanFilter
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.stopResumeTicker = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numProcessNoise = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numMeasurementNoise = new System.Windows.Forms.NumericUpDown();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProcessNoise)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMeasurementNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // stopResumeTicker
            // 
            this.stopResumeTicker.Location = new System.Drawing.Point(12, 38);
            this.stopResumeTicker.Name = "stopResumeTicker";
            this.stopResumeTicker.Size = new System.Drawing.Size(113, 23);
            this.stopResumeTicker.TabIndex = 0;
            this.stopResumeTicker.Text = "Stop/Resume";
            this.stopResumeTicker.UseVisualStyleBackColor = true;
            this.stopResumeTicker.Click += new System.EventHandler(this.stopResumeTicker_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numProcessNoise);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 47);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process noise";
            // 
            // numProcessNoise
            // 
            this.numProcessNoise.DecimalPlaces = 1;
            this.numProcessNoise.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numProcessNoise.Location = new System.Drawing.Point(6, 19);
            this.numProcessNoise.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numProcessNoise.Name = "numProcessNoise";
            this.numProcessNoise.Size = new System.Drawing.Size(102, 20);
            this.numProcessNoise.TabIndex = 6;
            this.numProcessNoise.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numProcessNoise.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numMeasurementNoise);
            this.groupBox2.Location = new System.Drawing.Point(12, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 44);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Measurement noise";
            // 
            // numMeasurementNoise
            // 
            this.numMeasurementNoise.DecimalPlaces = 1;
            this.numMeasurementNoise.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMeasurementNoise.Location = new System.Drawing.Point(6, 19);
            this.numMeasurementNoise.Name = "numMeasurementNoise";
            this.numMeasurementNoise.Size = new System.Drawing.Size(102, 20);
            this.numMeasurementNoise.TabIndex = 6;
            this.numMeasurementNoise.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numMeasurementNoise.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(156, 30);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(631, 402);
            this.chart.TabIndex = 5;
            this.chart.Text = "chart1";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 464);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.stopResumeTicker);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numProcessNoise)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMeasurementNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button stopResumeTicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.NumericUpDown numProcessNoise;
        private System.Windows.Forms.NumericUpDown numMeasurementNoise;
        private System.Windows.Forms.Timer timer;
    }
}

