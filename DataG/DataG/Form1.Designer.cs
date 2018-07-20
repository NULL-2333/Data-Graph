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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.textBoxSensor = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.activatePanel = new System.Windows.Forms.Panel();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxSensorB = new System.Windows.Forms.CheckBox();
            this.checkBoxSensorA = new System.Windows.Forms.CheckBox();
            this.checkBoxAllSelection = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fileLoadingButton = new System.Windows.Forms.Button();
            this.sensorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.displayPanel.SuspendLayout();
            this.activatePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).BeginInit();
            this.SuspendLayout();
            // 
            // displayPanel
            // 
            this.displayPanel.BackColor = System.Drawing.SystemColors.Info;
            this.displayPanel.Controls.Add(this.textBoxSensor);
            this.displayPanel.Controls.Add(this.textBoxTime);
            this.displayPanel.Controls.Add(this.label2);
            this.displayPanel.Controls.Add(this.label1);
            this.displayPanel.Location = new System.Drawing.Point(12, 400);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(452, 225);
            this.displayPanel.TabIndex = 2;
            // 
            // textBoxSensor
            // 
            this.textBoxSensor.Location = new System.Drawing.Point(165, 90);
            this.textBoxSensor.Name = "textBoxSensor";
            this.textBoxSensor.Size = new System.Drawing.Size(119, 25);
            this.textBoxSensor.TabIndex = 4;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(165, 44);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(119, 25);
            this.textBoxTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(50, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sensor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(72, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time:";
            // 
            // activatePanel
            // 
            this.activatePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.activatePanel.Controls.Add(this.buttonStop);
            this.activatePanel.Controls.Add(this.buttonPlay);
            this.activatePanel.Location = new System.Drawing.Point(683, 400);
            this.activatePanel.Name = "activatePanel";
            this.activatePanel.Size = new System.Drawing.Size(254, 224);
            this.activatePanel.TabIndex = 3;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(143, 96);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(91, 31);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(22, 96);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(91, 31);
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
            this.panel1.Location = new System.Drawing.Point(470, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 225);
            this.panel1.TabIndex = 4;
            // 
            // checkBoxSensorB
            // 
            this.checkBoxSensorB.AutoSize = true;
            this.checkBoxSensorB.Location = new System.Drawing.Point(33, 121);
            this.checkBoxSensorB.Name = "checkBoxSensorB";
            this.checkBoxSensorB.Size = new System.Drawing.Size(85, 19);
            this.checkBoxSensorB.TabIndex = 4;
            this.checkBoxSensorB.Text = "SensorB";
            this.checkBoxSensorB.UseVisualStyleBackColor = true;
            this.checkBoxSensorB.Click += new System.EventHandler(this.checkBoxSensorB_Click);
            // 
            // checkBoxSensorA
            // 
            this.checkBoxSensorA.AutoSize = true;
            this.checkBoxSensorA.Location = new System.Drawing.Point(33, 96);
            this.checkBoxSensorA.Name = "checkBoxSensorA";
            this.checkBoxSensorA.Size = new System.Drawing.Size(85, 19);
            this.checkBoxSensorA.TabIndex = 3;
            this.checkBoxSensorA.Text = "SensorA";
            this.checkBoxSensorA.UseVisualStyleBackColor = true;
            this.checkBoxSensorA.Click += new System.EventHandler(this.checkBoxSensorA_Click);
            // 
            // checkBoxAllSelection
            // 
            this.checkBoxAllSelection.AutoSize = true;
            this.checkBoxAllSelection.Checked = true;
            this.checkBoxAllSelection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAllSelection.Location = new System.Drawing.Point(33, 71);
            this.checkBoxAllSelection.Name = "checkBoxAllSelection";
            this.checkBoxAllSelection.Size = new System.Drawing.Size(53, 19);
            this.checkBoxAllSelection.TabIndex = 2;
            this.checkBoxAllSelection.Text = "All";
            this.checkBoxAllSelection.UseVisualStyleBackColor = true;
            this.checkBoxAllSelection.Click += new System.EventHandler(this.checkBoxAllSelection_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(56, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "Display";
            // 
            // fileLoadingButton
            // 
            this.fileLoadingButton.Location = new System.Drawing.Point(943, 12);
            this.fileLoadingButton.Name = "fileLoadingButton";
            this.fileLoadingButton.Size = new System.Drawing.Size(165, 37);
            this.fileLoadingButton.TabIndex = 6;
            this.fileLoadingButton.Text = "Load File...";
            this.fileLoadingButton.UseVisualStyleBackColor = true;
            this.fileLoadingButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // sensorChart
            // 
            chartArea1.Name = "ChartArea1";
            this.sensorChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.sensorChart.Legends.Add(legend1);
            this.sensorChart.Location = new System.Drawing.Point(12, 12);
            this.sensorChart.Name = "sensorChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "SensorA";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "SensorB";
            this.sensorChart.Series.Add(series1);
            this.sensorChart.Series.Add(series2);
            this.sensorChart.Size = new System.Drawing.Size(925, 382);
            this.sensorChart.TabIndex = 8;
            this.sensorChart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 637);
            this.Controls.Add(this.sensorChart);
            this.Controls.Add(this.fileLoadingButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.activatePanel);
            this.Controls.Add(this.displayPanel);
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
        private System.Windows.Forms.TextBox textBoxSensor;
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
    }
}

