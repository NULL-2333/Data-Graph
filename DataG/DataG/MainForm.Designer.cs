namespace DataG
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.activatePanel = new System.Windows.Forms.Panel();
            this.resetButton = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.allSelectedCheckBox = new System.Windows.Forms.CheckBox();
            this.sensorCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fileLoadingButton = new System.Windows.Forms.Button();
            this.sensorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTimer = new System.Windows.Forms.Timer(this.components);
            this.GPSPanel = new System.Windows.Forms.Panel();
            this.YRangeButton = new System.Windows.Forms.Button();
            this.XRangeButton = new System.Windows.Forms.Button();
            this.dataPanel.SuspendLayout();
            this.activatePanel.SuspendLayout();
            this.displayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataPanel
            // 
            this.dataPanel.AutoScroll = true;
            this.dataPanel.BackColor = System.Drawing.SystemColors.Info;
            this.dataPanel.Controls.Add(this.textBoxTime);
            this.dataPanel.Controls.Add(this.timeLabel);
            this.dataPanel.Location = new System.Drawing.Point(16, 744);
            this.dataPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(589, 199);
            this.dataPanel.TabIndex = 2;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(432, 11);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(119, 25);
            this.textBoxTime.TabIndex = 3;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeLabel.Location = new System.Drawing.Point(20, 11);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(303, 29);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time:                                      ";
            // 
            // activatePanel
            // 
            this.activatePanel.BackColor = System.Drawing.SystemColors.Info;
            this.activatePanel.Controls.Add(this.resetButton);
            this.activatePanel.Controls.Add(this.buttonStop);
            this.activatePanel.Controls.Add(this.buttonPlay);
            this.activatePanel.Location = new System.Drawing.Point(1467, 744);
            this.activatePanel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.activatePanel.Name = "activatePanel";
            this.activatePanel.Size = new System.Drawing.Size(427, 199);
            this.activatePanel.TabIndex = 3;
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resetButton.Location = new System.Drawing.Point(67, 128);
            this.resetButton.Margin = new System.Windows.Forms.Padding(5);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(340, 51);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.Location = new System.Drawing.Point(267, 51);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(140, 49);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPlay.Location = new System.Drawing.Point(67, 51);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(132, 49);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // displayPanel
            // 
            this.displayPanel.BackColor = System.Drawing.SystemColors.Info;
            this.displayPanel.Controls.Add(this.allSelectedCheckBox);
            this.displayPanel.Controls.Add(this.sensorCheckedListBox);
            this.displayPanel.Controls.Add(this.label4);
            this.displayPanel.Location = new System.Drawing.Point(612, 744);
            this.displayPanel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(452, 199);
            this.displayPanel.TabIndex = 4;
            // 
            // allSelectedCheckBox
            // 
            this.allSelectedCheckBox.AutoSize = true;
            this.allSelectedCheckBox.Checked = true;
            this.allSelectedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allSelectedCheckBox.Location = new System.Drawing.Point(21, 55);
            this.allSelectedCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.allSelectedCheckBox.Name = "allSelectedCheckBox";
            this.allSelectedCheckBox.Size = new System.Drawing.Size(53, 19);
            this.allSelectedCheckBox.TabIndex = 2;
            this.allSelectedCheckBox.Text = "All";
            this.allSelectedCheckBox.UseVisualStyleBackColor = true;
            this.allSelectedCheckBox.CheckedChanged += new System.EventHandler(this.allSelectedCheckBox_CheckedChanged);
            // 
            // sensorCheckedListBox
            // 
            this.sensorCheckedListBox.CheckOnClick = true;
            this.sensorCheckedListBox.FormattingEnabled = true;
            this.sensorCheckedListBox.Location = new System.Drawing.Point(19, 88);
            this.sensorCheckedListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sensorCheckedListBox.Name = "sensorCheckedListBox";
            this.sensorCheckedListBox.Size = new System.Drawing.Size(417, 104);
            this.sensorCheckedListBox.TabIndex = 1;
            this.sensorCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.sensorCheckedListBox_ItemCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(173, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Display";
            // 
            // fileLoadingButton
            // 
            this.fileLoadingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileLoadingButton.Location = new System.Drawing.Point(1072, 746);
            this.fileLoadingButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.fileLoadingButton.Name = "fileLoadingButton";
            this.fileLoadingButton.Size = new System.Drawing.Size(387, 60);
            this.fileLoadingButton.TabIndex = 6;
            this.fileLoadingButton.Text = "Load File...";
            this.fileLoadingButton.UseVisualStyleBackColor = true;
            this.fileLoadingButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // sensorChart
            // 
            chartArea1.Name = "ChartArea1";
            this.sensorChart.ChartAreas.Add(chartArea1);
            this.sensorChart.Cursor = System.Windows.Forms.Cursors.Hand;
            legend1.Name = "Legend1";
            this.sensorChart.Legends.Add(legend1);
            this.sensorChart.Location = new System.Drawing.Point(21, 19);
            this.sensorChart.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.sensorChart.Name = "sensorChart";
            this.sensorChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sensorChart.Size = new System.Drawing.Size(1437, 721);
            this.sensorChart.TabIndex = 8;
            this.sensorChart.TabStop = false;
            this.sensorChart.Text = "chart1";
            this.sensorChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sensorChart_MouseClick);
            this.sensorChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sensorChart_MouseDown);
            this.sensorChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sensorChart_MouseMove);
            this.sensorChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sensorChart_MouseUp);
            // 
            // chartTimer
            // 
            this.chartTimer.Interval = 200;
            this.chartTimer.Tick += new System.EventHandler(this.chartTimer_Tick);
            // 
            // GPSPanel
            // 
            this.GPSPanel.BackColor = System.Drawing.SystemColors.Info;
            this.GPSPanel.Location = new System.Drawing.Point(1467, 19);
            this.GPSPanel.Margin = new System.Windows.Forms.Padding(4);
            this.GPSPanel.Name = "GPSPanel";
            this.GPSPanel.Size = new System.Drawing.Size(427, 718);
            this.GPSPanel.TabIndex = 9;
            // 
            // YRangeButton
            // 
            this.YRangeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.YRangeButton.Location = new System.Drawing.Point(1072, 883);
            this.YRangeButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.YRangeButton.Name = "YRangeButton";
            this.YRangeButton.Size = new System.Drawing.Size(387, 60);
            this.YRangeButton.TabIndex = 10;
            this.YRangeButton.Text = "Y-Range";
            this.YRangeButton.UseVisualStyleBackColor = true;
            this.YRangeButton.Click += new System.EventHandler(this.YRangeButton_Click);
            // 
            // XRangeButton
            // 
            this.XRangeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XRangeButton.Location = new System.Drawing.Point(1072, 814);
            this.XRangeButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.XRangeButton.Name = "XRangeButton";
            this.XRangeButton.Size = new System.Drawing.Size(387, 60);
            this.XRangeButton.TabIndex = 11;
            this.XRangeButton.Text = "X-Range";
            this.XRangeButton.UseVisualStyleBackColor = true;
            this.XRangeButton.Click += new System.EventHandler(this.XRangeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1827, 950);
            this.Controls.Add(this.XRangeButton);
            this.Controls.Add(this.YRangeButton);
            this.Controls.Add(this.GPSPanel);
            this.Controls.Add(this.sensorChart);
            this.Controls.Add(this.fileLoadingButton);
            this.Controls.Add(this.displayPanel);
            this.Controls.Add(this.activatePanel);
            this.Controls.Add(this.dataPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            this.activatePanel.ResumeLayout(false);
            this.displayPanel.ResumeLayout(false);
            this.displayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.Panel activatePanel;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button fileLoadingButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart sensorChart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Timer chartTimer;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Panel GPSPanel;
        private System.Windows.Forms.CheckedListBox sensorCheckedListBox;
        private System.Windows.Forms.CheckBox allSelectedCheckBox;
        private System.Windows.Forms.Button YRangeButton;
        private System.Windows.Forms.Button XRangeButton;
    }
}

