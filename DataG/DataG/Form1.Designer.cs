namespace DataG
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.textBoxSensorB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSensorA = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.activatePanel = new System.Windows.Forms.Panel();
            this.resetButton = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxSensorB = new System.Windows.Forms.CheckBox();
            this.checkBoxSensorA = new System.Windows.Forms.CheckBox();
            this.checkBoxAllSelection = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fileLoadingButton = new System.Windows.Forms.Button();
            this.sensorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTimer = new System.Windows.Forms.Timer(this.components);
            this.GPSPanel = new System.Windows.Forms.Panel();
            this.displayPanel.SuspendLayout();
            this.activatePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).BeginInit();
            this.SuspendLayout();
            // 
            // displayPanel
            // 
            this.displayPanel.BackColor = System.Drawing.SystemColors.Info;
            this.displayPanel.Controls.Add(this.textBoxSensorB);
            this.displayPanel.Controls.Add(this.label3);
            this.displayPanel.Controls.Add(this.textBoxSensorA);
            this.displayPanel.Controls.Add(this.textBoxTime);
            this.displayPanel.Controls.Add(this.label2);
            this.displayPanel.Controls.Add(this.label1);
            this.displayPanel.Location = new System.Drawing.Point(12, 400);
            this.displayPanel.Margin = new System.Windows.Forms.Padding(2);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(244, 150);
            this.displayPanel.TabIndex = 2;
            // 
            // textBoxSensorB
            // 
            this.textBoxSensorB.Location = new System.Drawing.Point(137, 106);
            this.textBoxSensorB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSensorB.Name = "textBoxSensorB";
            this.textBoxSensorB.Size = new System.Drawing.Size(90, 21);
            this.textBoxSensorB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Speed:";
            // 
            // textBoxSensorA
            // 
            this.textBoxSensorA.Location = new System.Drawing.Point(137, 60);
            this.textBoxSensorA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSensorA.Name = "textBoxSensorA";
            this.textBoxSensorA.Size = new System.Drawing.Size(90, 21);
            this.textBoxSensorA.TabIndex = 4;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(137, 15);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(90, 21);
            this.textBoxTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sensor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time:";
            // 
            // activatePanel
            // 
            this.activatePanel.BackColor = System.Drawing.SystemColors.Info;
            this.activatePanel.Controls.Add(this.resetButton);
            this.activatePanel.Controls.Add(this.buttonStop);
            this.activatePanel.Controls.Add(this.buttonPlay);
            this.activatePanel.Location = new System.Drawing.Point(420, 400);
            this.activatePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.activatePanel.Name = "activatePanel";
            this.activatePanel.Size = new System.Drawing.Size(232, 150);
            this.activatePanel.TabIndex = 3;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(20, 81);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(189, 33);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.Location = new System.Drawing.Point(127, 33);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(82, 31);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPlay.Location = new System.Drawing.Point(20, 33);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(82, 31);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.checkBoxSensorB);
            this.panel1.Controls.Add(this.checkBoxSensorA);
            this.panel1.Controls.Add(this.checkBoxAllSelection);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(259, 400);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 150);
            this.panel1.TabIndex = 4;
            // 
            // checkBoxSensorB
            // 
            this.checkBoxSensorB.AutoSize = true;
            this.checkBoxSensorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxSensorB.Location = new System.Drawing.Point(25, 86);
            this.checkBoxSensorB.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSensorB.Name = "checkBoxSensorB";
            this.checkBoxSensorB.Size = new System.Drawing.Size(62, 19);
            this.checkBoxSensorB.TabIndex = 4;
            this.checkBoxSensorB.Text = "Speed";
            this.checkBoxSensorB.UseVisualStyleBackColor = true;
            this.checkBoxSensorB.Click += new System.EventHandler(this.checkBoxSensorB_Click);
            // 
            // checkBoxSensorA
            // 
            this.checkBoxSensorA.AutoSize = true;
            this.checkBoxSensorA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxSensorA.Location = new System.Drawing.Point(25, 63);
            this.checkBoxSensorA.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSensorA.Name = "checkBoxSensorA";
            this.checkBoxSensorA.Size = new System.Drawing.Size(65, 19);
            this.checkBoxSensorA.TabIndex = 3;
            this.checkBoxSensorA.Text = "Sensor";
            this.checkBoxSensorA.UseVisualStyleBackColor = true;
            this.checkBoxSensorA.Click += new System.EventHandler(this.checkBoxSensorA_Click);
            // 
            // checkBoxAllSelection
            // 
            this.checkBoxAllSelection.AutoSize = true;
            this.checkBoxAllSelection.Checked = true;
            this.checkBoxAllSelection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAllSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxAllSelection.Location = new System.Drawing.Point(25, 40);
            this.checkBoxAllSelection.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxAllSelection.Name = "checkBoxAllSelection";
            this.checkBoxAllSelection.Size = new System.Drawing.Size(39, 19);
            this.checkBoxAllSelection.TabIndex = 2;
            this.checkBoxAllSelection.Text = "All";
            this.checkBoxAllSelection.UseVisualStyleBackColor = true;
            this.checkBoxAllSelection.Click += new System.EventHandler(this.checkBoxAllSelection_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(44, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Display";
            // 
            // fileLoadingButton
            // 
            this.fileLoadingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileLoadingButton.Location = new System.Drawing.Point(658, 12);
            this.fileLoadingButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileLoadingButton.Name = "fileLoadingButton";
            this.fileLoadingButton.Size = new System.Drawing.Size(124, 30);
            this.fileLoadingButton.TabIndex = 6;
            this.fileLoadingButton.Text = "Load File...";
            this.fileLoadingButton.UseVisualStyleBackColor = true;
            this.fileLoadingButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // sensorChart
            // 
            chartArea2.Name = "ChartArea1";
            this.sensorChart.ChartAreas.Add(chartArea2);
            this.sensorChart.Cursor = System.Windows.Forms.Cursors.Hand;
            legend2.Name = "Legend1";
            this.sensorChart.Legends.Add(legend2);
            this.sensorChart.Location = new System.Drawing.Point(12, 12);
            this.sensorChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sensorChart.Name = "sensorChart";
            this.sensorChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "SensorA";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "SensorB";
            this.sensorChart.Series.Add(series3);
            this.sensorChart.Series.Add(series4);
            this.sensorChart.Size = new System.Drawing.Size(640, 382);
            this.sensorChart.TabIndex = 8;
            this.sensorChart.TabStop = false;
            this.sensorChart.Text = "chart1";
            this.sensorChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sensorChart_MouseClick);
            // 
            // chartTimer
            // 
            this.chartTimer.Tick += new System.EventHandler(this.chartTimer_Tick);
            // 
            // GPSPanel
            // 
            this.GPSPanel.BackColor = System.Drawing.SystemColors.Info;
            this.GPSPanel.Location = new System.Drawing.Point(658, 55);
            this.GPSPanel.Name = "GPSPanel";
            this.GPSPanel.Size = new System.Drawing.Size(521, 495);
            this.GPSPanel.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 555);
            this.Controls.Add(this.GPSPanel);
            this.Controls.Add(this.sensorChart);
            this.Controls.Add(this.fileLoadingButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.activatePanel);
            this.Controls.Add(this.displayPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.displayPanel.ResumeLayout(false);
            this.displayPanel.PerformLayout();
            this.activatePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.Panel activatePanel;
        private System.Windows.Forms.TextBox textBoxSensorA;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button fileLoadingButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart sensorChart;
        private System.Windows.Forms.CheckBox checkBoxAllSelection;
        private System.Windows.Forms.CheckBox checkBoxSensorB;
        private System.Windows.Forms.CheckBox checkBoxSensorA;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.TextBox textBoxSensorB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer chartTimer;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Panel GPSPanel;
    }
}

