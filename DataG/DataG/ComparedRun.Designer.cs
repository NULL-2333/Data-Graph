namespace DataG
{
    partial class ComparedRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparedRun));
            this.activatePanel = new System.Windows.Forms.Panel();
            this.resetButton = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.allSelectedCheckBox2 = new System.Windows.Forms.CheckBox();
            this.sensorCheckedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.allSelectedCheckBox = new System.Windows.Forms.CheckBox();
            this.sensorCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fileLoadingButton = new System.Windows.Forms.Button();
            this.sensorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTimer = new System.Windows.Forms.Timer(this.components);
            this.GPSPanel = new System.Windows.Forms.Panel();
            this.radioButtonLine2 = new System.Windows.Forms.RadioButton();
            this.radioButtonLine1 = new System.Windows.Forms.RadioButton();
            this.ConfigureButton = new System.Windows.Forms.Button();
            this.GPSGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton_Accelerate = new System.Windows.Forms.RadioButton();
            this.radioButton_Speed = new System.Windows.Forms.RadioButton();
            this.radioButton_Normal = new System.Windows.Forms.RadioButton();
            this.YPanel = new System.Windows.Forms.Panel();
            this.settingButton = new System.Windows.Forms.Button();
            this.standardButton = new System.Windows.Forms.Button();
            this.firstDriverGroupBox = new System.Windows.Forms.GroupBox();
            this.firstDriverTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.secondDriverGroupBox = new System.Windows.Forms.GroupBox();
            this.secondDriverTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.thirdTrackBar = new System.Windows.Forms.TrackBar();
            this.secondTrackBar = new System.Windows.Forms.TrackBar();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.firstTrackBar = new System.Windows.Forms.TrackBar();
            this.activatePanel.SuspendLayout();
            this.displayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).BeginInit();
            this.GPSPanel.SuspendLayout();
            this.GPSGroupBox.SuspendLayout();
            this.firstDriverGroupBox.SuspendLayout();
            this.firstDriverTableLayoutPanel.SuspendLayout();
            this.secondDriverGroupBox.SuspendLayout();
            this.secondDriverTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thirdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // activatePanel
            // 
            this.activatePanel.BackColor = System.Drawing.SystemColors.Info;
            this.activatePanel.Controls.Add(this.resetButton);
            this.activatePanel.Controls.Add(this.buttonStop);
            this.activatePanel.Controls.Add(this.buttonPlay);
            this.activatePanel.Location = new System.Drawing.Point(1154, 595);
            this.activatePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.activatePanel.Name = "activatePanel";
            this.activatePanel.Size = new System.Drawing.Size(204, 159);
            this.activatePanel.TabIndex = 3;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resetButton.Location = new System.Drawing.Point(19, 84);
            this.resetButton.Margin = new System.Windows.Forms.Padding(4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(157, 40);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.Location = new System.Drawing.Point(108, 38);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(68, 40);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPlay.Location = new System.Drawing.Point(19, 38);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(70, 40);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // displayPanel
            // 
            this.displayPanel.BackColor = System.Drawing.SystemColors.Info;
            this.displayPanel.Controls.Add(this.allSelectedCheckBox2);
            this.displayPanel.Controls.Add(this.sensorCheckedListBox2);
            this.displayPanel.Controls.Add(this.allSelectedCheckBox);
            this.displayPanel.Controls.Add(this.sensorCheckedListBox);
            this.displayPanel.Controls.Add(this.label4);
            this.displayPanel.Location = new System.Drawing.Point(12, 595);
            this.displayPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(454, 159);
            this.displayPanel.TabIndex = 4;
            // 
            // allSelectedCheckBox2
            // 
            this.allSelectedCheckBox2.AutoSize = true;
            this.allSelectedCheckBox2.Checked = true;
            this.allSelectedCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allSelectedCheckBox2.Location = new System.Drawing.Point(240, 35);
            this.allSelectedCheckBox2.Margin = new System.Windows.Forms.Padding(2);
            this.allSelectedCheckBox2.Name = "allSelectedCheckBox2";
            this.allSelectedCheckBox2.Size = new System.Drawing.Size(42, 16);
            this.allSelectedCheckBox2.TabIndex = 4;
            this.allSelectedCheckBox2.Text = "All";
            this.allSelectedCheckBox2.UseVisualStyleBackColor = true;
            this.allSelectedCheckBox2.CheckedChanged += new System.EventHandler(this.allSelectedCheckBox2_CheckedChanged);
            // 
            // sensorCheckedListBox2
            // 
            this.sensorCheckedListBox2.CheckOnClick = true;
            this.sensorCheckedListBox2.FormattingEnabled = true;
            this.sensorCheckedListBox2.Location = new System.Drawing.Point(238, 56);
            this.sensorCheckedListBox2.Margin = new System.Windows.Forms.Padding(2);
            this.sensorCheckedListBox2.Name = "sensorCheckedListBox2";
            this.sensorCheckedListBox2.Size = new System.Drawing.Size(207, 84);
            this.sensorCheckedListBox2.TabIndex = 3;
            this.sensorCheckedListBox2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.sensorCheckedListBox2_ItemCheck);
            // 
            // allSelectedCheckBox
            // 
            this.allSelectedCheckBox.AutoSize = true;
            this.allSelectedCheckBox.Checked = true;
            this.allSelectedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allSelectedCheckBox.Location = new System.Drawing.Point(12, 35);
            this.allSelectedCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.allSelectedCheckBox.Name = "allSelectedCheckBox";
            this.allSelectedCheckBox.Size = new System.Drawing.Size(42, 16);
            this.allSelectedCheckBox.TabIndex = 2;
            this.allSelectedCheckBox.Text = "All";
            this.allSelectedCheckBox.UseVisualStyleBackColor = true;
            this.allSelectedCheckBox.CheckedChanged += new System.EventHandler(this.allSelectedCheckBox_CheckedChanged);
            // 
            // sensorCheckedListBox
            // 
            this.sensorCheckedListBox.CheckOnClick = true;
            this.sensorCheckedListBox.FormattingEnabled = true;
            this.sensorCheckedListBox.Location = new System.Drawing.Point(10, 56);
            this.sensorCheckedListBox.Margin = new System.Windows.Forms.Padding(2);
            this.sensorCheckedListBox.Name = "sensorCheckedListBox";
            this.sensorCheckedListBox.Size = new System.Drawing.Size(207, 84);
            this.sensorCheckedListBox.TabIndex = 1;
            this.sensorCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.sensorCheckedListBox_ItemCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(166, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Display";
            // 
            // fileLoadingButton
            // 
            this.fileLoadingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileLoadingButton.Location = new System.Drawing.Point(801, 595);
            this.fileLoadingButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileLoadingButton.Name = "fileLoadingButton";
            this.fileLoadingButton.Size = new System.Drawing.Size(223, 50);
            this.fileLoadingButton.TabIndex = 6;
            this.fileLoadingButton.Text = "Load CSV...";
            this.fileLoadingButton.UseVisualStyleBackColor = true;
            this.fileLoadingButton.Click += new System.EventHandler(this.fileLoadingButton_Click);
            // 
            // sensorChart
            // 
            chartArea1.AxisX.LabelStyle.Format = "N3";
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 81.35392F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 3F;
            this.sensorChart.ChartAreas.Add(chartArea1);
            this.sensorChart.Cursor = System.Windows.Forms.Cursors.Hand;
            legend1.Name = "Legend1";
            this.sensorChart.Legends.Add(legend1);
            this.sensorChart.Location = new System.Drawing.Point(16, 11);
            this.sensorChart.Margin = new System.Windows.Forms.Padding(7, 2, 7, 2);
            this.sensorChart.Name = "sensorChart";
            this.sensorChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sensorChart.Size = new System.Drawing.Size(855, 574);
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
            this.chartTimer.Interval = 1;
            this.chartTimer.Tick += new System.EventHandler(this.chartTimer_Tick);
            // 
            // GPSPanel
            // 
            this.GPSPanel.BackColor = System.Drawing.SystemColors.Info;
            this.GPSPanel.Controls.Add(this.radioButtonLine2);
            this.GPSPanel.Controls.Add(this.radioButtonLine1);
            this.GPSPanel.Location = new System.Drawing.Point(1104, 11);
            this.GPSPanel.Margin = new System.Windows.Forms.Padding(4);
            this.GPSPanel.Name = "GPSPanel";
            this.GPSPanel.Size = new System.Drawing.Size(255, 574);
            this.GPSPanel.TabIndex = 9;
            this.GPSPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GPSPanel_Paint);
            this.GPSPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GPSPanel_MouseClick);
            this.GPSPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GPSPanel_MouseDown);
            this.GPSPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GPSPanel_MouseMove);
            this.GPSPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GPSPanel_MouseUp);
            // 
            // radioButtonLine2
            // 
            this.radioButtonLine2.AutoSize = true;
            this.radioButtonLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F);
            this.radioButtonLine2.Location = new System.Drawing.Point(135, 553);
            this.radioButtonLine2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonLine2.Name = "radioButtonLine2";
            this.radioButtonLine2.Size = new System.Drawing.Size(52, 19);
            this.radioButtonLine2.TabIndex = 1;
            this.radioButtonLine2.TabStop = true;
            this.radioButtonLine2.Text = "line2";
            this.radioButtonLine2.UseVisualStyleBackColor = true;
            this.radioButtonLine2.Click += new System.EventHandler(this.radioButtonLine2_Click);
            // 
            // radioButtonLine1
            // 
            this.radioButtonLine1.AutoSize = true;
            this.radioButtonLine1.Checked = true;
            this.radioButtonLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F);
            this.radioButtonLine1.Location = new System.Drawing.Point(50, 553);
            this.radioButtonLine1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonLine1.Name = "radioButtonLine1";
            this.radioButtonLine1.Size = new System.Drawing.Size(52, 19);
            this.radioButtonLine1.TabIndex = 0;
            this.radioButtonLine1.TabStop = true;
            this.radioButtonLine1.Text = "line1";
            this.radioButtonLine1.UseVisualStyleBackColor = true;
            this.radioButtonLine1.Click += new System.EventHandler(this.radioButtonLine1_Click);
            // 
            // ConfigureButton
            // 
            this.ConfigureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfigureButton.Location = new System.Drawing.Point(915, 652);
            this.ConfigureButton.Margin = new System.Windows.Forms.Padding(2);
            this.ConfigureButton.Name = "ConfigureButton";
            this.ConfigureButton.Size = new System.Drawing.Size(109, 50);
            this.ConfigureButton.TabIndex = 10;
            this.ConfigureButton.Text = "Configuration";
            this.ConfigureButton.UseVisualStyleBackColor = true;
            this.ConfigureButton.Click += new System.EventHandler(this.ConfigureButton_Click);
            // 
            // GPSGroupBox
            // 
            this.GPSGroupBox.Controls.Add(this.radioButton_Accelerate);
            this.GPSGroupBox.Controls.Add(this.radioButton_Speed);
            this.GPSGroupBox.Controls.Add(this.radioButton_Normal);
            this.GPSGroupBox.Location = new System.Drawing.Point(1031, 595);
            this.GPSGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.GPSGroupBox.Name = "GPSGroupBox";
            this.GPSGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.GPSGroupBox.Size = new System.Drawing.Size(114, 160);
            this.GPSGroupBox.TabIndex = 12;
            this.GPSGroupBox.TabStop = false;
            this.GPSGroupBox.Text = "GPS";
            // 
            // radioButton_Accelerate
            // 
            this.radioButton_Accelerate.AutoSize = true;
            this.radioButton_Accelerate.Location = new System.Drawing.Point(8, 122);
            this.radioButton_Accelerate.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_Accelerate.Name = "radioButton_Accelerate";
            this.radioButton_Accelerate.Size = new System.Drawing.Size(95, 16);
            this.radioButton_Accelerate.TabIndex = 2;
            this.radioButton_Accelerate.TabStop = true;
            this.radioButton_Accelerate.Text = "Acceleration";
            this.radioButton_Accelerate.UseVisualStyleBackColor = true;
            this.radioButton_Accelerate.CheckedChanged += new System.EventHandler(this.radioButton_Accelerate_CheckedChanged);
            // 
            // radioButton_Speed
            // 
            this.radioButton_Speed.AutoSize = true;
            this.radioButton_Speed.Location = new System.Drawing.Point(8, 76);
            this.radioButton_Speed.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_Speed.Name = "radioButton_Speed";
            this.radioButton_Speed.Size = new System.Drawing.Size(53, 16);
            this.radioButton_Speed.TabIndex = 1;
            this.radioButton_Speed.TabStop = true;
            this.radioButton_Speed.Text = "Speed";
            this.radioButton_Speed.UseVisualStyleBackColor = true;
            this.radioButton_Speed.CheckedChanged += new System.EventHandler(this.radioButton_Speed_CheckedChanged);
            // 
            // radioButton_Normal
            // 
            this.radioButton_Normal.AutoSize = true;
            this.radioButton_Normal.Checked = true;
            this.radioButton_Normal.Location = new System.Drawing.Point(8, 22);
            this.radioButton_Normal.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_Normal.Name = "radioButton_Normal";
            this.radioButton_Normal.Size = new System.Drawing.Size(59, 16);
            this.radioButton_Normal.TabIndex = 0;
            this.radioButton_Normal.TabStop = true;
            this.radioButton_Normal.Text = "Normal";
            this.radioButton_Normal.UseVisualStyleBackColor = true;
            this.radioButton_Normal.CheckedChanged += new System.EventHandler(this.radioButton_Normal_CheckedChanged);
            // 
            // YPanel
            // 
            this.YPanel.AutoScroll = true;
            this.YPanel.BackColor = System.Drawing.SystemColors.Info;
            this.YPanel.Location = new System.Drawing.Point(471, 595);
            this.YPanel.Margin = new System.Windows.Forms.Padding(2);
            this.YPanel.Name = "YPanel";
            this.YPanel.Size = new System.Drawing.Size(324, 159);
            this.YPanel.TabIndex = 13;
            // 
            // settingButton
            // 
            this.settingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.settingButton.Location = new System.Drawing.Point(801, 651);
            this.settingButton.Margin = new System.Windows.Forms.Padding(4);
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(108, 50);
            this.settingButton.TabIndex = 14;
            this.settingButton.Text = "Load Settings";
            this.settingButton.UseVisualStyleBackColor = true;
            this.settingButton.Click += new System.EventHandler(this.settingButton_Click);
            // 
            // standardButton
            // 
            this.standardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.standardButton.Location = new System.Drawing.Point(801, 706);
            this.standardButton.Margin = new System.Windows.Forms.Padding(2);
            this.standardButton.Name = "standardButton";
            this.standardButton.Size = new System.Drawing.Size(223, 48);
            this.standardButton.TabIndex = 15;
            this.standardButton.Text = "Standard Segmentation";
            this.standardButton.UseVisualStyleBackColor = true;
            this.standardButton.Click += new System.EventHandler(this.segmentationButton_Click);
            // 
            // firstDriverGroupBox
            // 
            this.firstDriverGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.firstDriverGroupBox.Controls.Add(this.firstDriverTableLayoutPanel);
            this.firstDriverGroupBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.firstDriverGroupBox.Location = new System.Drawing.Point(880, 309);
            this.firstDriverGroupBox.Name = "firstDriverGroupBox";
            this.firstDriverGroupBox.Size = new System.Drawing.Size(217, 135);
            this.firstDriverGroupBox.TabIndex = 1;
            this.firstDriverGroupBox.TabStop = false;
            this.firstDriverGroupBox.Text = "1st Driver";
            // 
            // firstDriverTableLayoutPanel
            // 
            this.firstDriverTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.firstDriverTableLayoutPanel.ColumnCount = 2;
            this.firstDriverTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.firstDriverTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.firstDriverTableLayoutPanel.Controls.Add(this.label6, 0, 2);
            this.firstDriverTableLayoutPanel.Controls.Add(this.label1, 1, 0);
            this.firstDriverTableLayoutPanel.Controls.Add(this.label3, 0, 1);
            this.firstDriverTableLayoutPanel.Controls.Add(this.label2, 0, 3);
            this.firstDriverTableLayoutPanel.Controls.Add(this.label5, 0, 4);
            this.firstDriverTableLayoutPanel.Controls.Add(this.label11, 1, 1);
            this.firstDriverTableLayoutPanel.Controls.Add(this.label12, 1, 2);
            this.firstDriverTableLayoutPanel.Controls.Add(this.label13, 1, 3);
            this.firstDriverTableLayoutPanel.Controls.Add(this.label14, 1, 4);
            this.firstDriverTableLayoutPanel.Location = new System.Drawing.Point(0, 32);
            this.firstDriverTableLayoutPanel.Name = "firstDriverTableLayoutPanel";
            this.firstDriverTableLayoutPanel.RowCount = 5;
            this.firstDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.firstDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.firstDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.firstDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.firstDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.firstDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.firstDriverTableLayoutPanel.Size = new System.Drawing.Size(217, 103);
            this.firstDriverTableLayoutPanel.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "2nd Section";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time[s]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "1st Section";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "3rd Section";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "4th Section";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(132, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "NULL";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(132, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 17);
            this.label12.TabIndex = 6;
            this.label12.Text = "NULL";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(132, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 17);
            this.label13.TabIndex = 7;
            this.label13.Text = "NULL";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(132, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 17);
            this.label14.TabIndex = 8;
            this.label14.Text = "NULL";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondDriverGroupBox
            // 
            this.secondDriverGroupBox.Controls.Add(this.secondDriverTableLayoutPanel);
            this.secondDriverGroupBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.secondDriverGroupBox.Location = new System.Drawing.Point(880, 450);
            this.secondDriverGroupBox.Name = "secondDriverGroupBox";
            this.secondDriverGroupBox.Size = new System.Drawing.Size(217, 135);
            this.secondDriverGroupBox.TabIndex = 2;
            this.secondDriverGroupBox.TabStop = false;
            this.secondDriverGroupBox.Text = "2nd Driver";
            // 
            // secondDriverTableLayoutPanel
            // 
            this.secondDriverTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.secondDriverTableLayoutPanel.ColumnCount = 2;
            this.secondDriverTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.secondDriverTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.secondDriverTableLayoutPanel.Controls.Add(this.label10, 0, 4);
            this.secondDriverTableLayoutPanel.Controls.Add(this.label7, 1, 0);
            this.secondDriverTableLayoutPanel.Controls.Add(this.label8, 0, 1);
            this.secondDriverTableLayoutPanel.Controls.Add(this.label9, 0, 2);
            this.secondDriverTableLayoutPanel.Controls.Add(this.label15, 0, 3);
            this.secondDriverTableLayoutPanel.Controls.Add(this.label21, 1, 1);
            this.secondDriverTableLayoutPanel.Controls.Add(this.label22, 1, 2);
            this.secondDriverTableLayoutPanel.Controls.Add(this.label23, 1, 3);
            this.secondDriverTableLayoutPanel.Controls.Add(this.label24, 1, 4);
            this.secondDriverTableLayoutPanel.Location = new System.Drawing.Point(0, 32);
            this.secondDriverTableLayoutPanel.Name = "secondDriverTableLayoutPanel";
            this.secondDriverTableLayoutPanel.RowCount = 5;
            this.secondDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.secondDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.secondDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.secondDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.secondDriverTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.secondDriverTableLayoutPanel.Size = new System.Drawing.Size(217, 103);
            this.secondDriverTableLayoutPanel.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "4th Section";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(126, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Time[s]";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "1st Section";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "2nd Section";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 17);
            this.label15.TabIndex = 6;
            this.label15.Text = "3rd Section";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(132, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 17);
            this.label21.TabIndex = 8;
            this.label21.Text = "NULL";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(132, 42);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 17);
            this.label22.TabIndex = 9;
            this.label22.Text = "NULL";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(132, 62);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(39, 17);
            this.label23.TabIndex = 10;
            this.label23.Text = "NULL";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(132, 83);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 17);
            this.label24.TabIndex = 11;
            this.label24.Text = "NULL";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.thirdTrackBar, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.secondTrackBar, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.firstTrackBar, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(880, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(217, 291);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // thirdTrackBar
            // 
            this.thirdTrackBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.thirdTrackBar.Location = new System.Drawing.Point(4, 235);
            this.thirdTrackBar.Maximum = 100;
            this.thirdTrackBar.Name = "thirdTrackBar";
            this.thirdTrackBar.Size = new System.Drawing.Size(209, 45);
            this.thirdTrackBar.TabIndex = 7;
            this.thirdTrackBar.TickFrequency = 10;
            this.thirdTrackBar.Value = 75;
            this.thirdTrackBar.ValueChanged += new System.EventHandler(this.thirdTrackBar_ValueChanged);
            // 
            // secondTrackBar
            // 
            this.secondTrackBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.secondTrackBar.Location = new System.Drawing.Point(4, 138);
            this.secondTrackBar.Maximum = 100;
            this.secondTrackBar.Name = "secondTrackBar";
            this.secondTrackBar.Size = new System.Drawing.Size(209, 45);
            this.secondTrackBar.TabIndex = 6;
            this.secondTrackBar.TickFrequency = 10;
            this.secondTrackBar.Value = 50;
            this.secondTrackBar.ValueChanged += new System.EventHandler(this.secondTrackBar_ValueChanged);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft YaHei UI", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(62, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 25);
            this.label17.TabIndex = 2;
            this.label17.Text = "1st Point";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft YaHei UI", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(58, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 25);
            this.label16.TabIndex = 3;
            this.label16.Text = "2nd Point";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft YaHei UI", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(60, 196);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 25);
            this.label18.TabIndex = 4;
            this.label18.Text = "3rd Point";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstTrackBar
            // 
            this.firstTrackBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.firstTrackBar.Location = new System.Drawing.Point(4, 42);
            this.firstTrackBar.Maximum = 100;
            this.firstTrackBar.Name = "firstTrackBar";
            this.firstTrackBar.Size = new System.Drawing.Size(209, 45);
            this.firstTrackBar.TabIndex = 5;
            this.firstTrackBar.TickFrequency = 10;
            this.firstTrackBar.Value = 25;
            this.firstTrackBar.ValueChanged += new System.EventHandler(this.firstTrackBar_ValueChanged);
            // 
            // ComparedRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.secondDriverGroupBox);
            this.Controls.Add(this.firstDriverGroupBox);
            this.Controls.Add(this.settingButton);
            this.Controls.Add(this.standardButton);
            this.Controls.Add(this.YPanel);
            this.Controls.Add(this.GPSGroupBox);
            this.Controls.Add(this.ConfigureButton);
            this.Controls.Add(this.GPSPanel);
            this.Controls.Add(this.sensorChart);
            this.Controls.Add(this.fileLoadingButton);
            this.Controls.Add(this.displayPanel);
            this.Controls.Add(this.activatePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ComparedRun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Compared Run";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.activatePanel.ResumeLayout(false);
            this.displayPanel.ResumeLayout(false);
            this.displayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).EndInit();
            this.GPSPanel.ResumeLayout(false);
            this.GPSPanel.PerformLayout();
            this.GPSGroupBox.ResumeLayout(false);
            this.GPSGroupBox.PerformLayout();
            this.firstDriverGroupBox.ResumeLayout(false);
            this.firstDriverTableLayoutPanel.ResumeLayout(false);
            this.firstDriverTableLayoutPanel.PerformLayout();
            this.secondDriverGroupBox.ResumeLayout(false);
            this.secondDriverTableLayoutPanel.ResumeLayout(false);
            this.secondDriverTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thirdTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel activatePanel;
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
        private System.Windows.Forms.Button ConfigureButton;
        private System.Windows.Forms.GroupBox GPSGroupBox;
        private System.Windows.Forms.RadioButton radioButton_Accelerate;
        private System.Windows.Forms.RadioButton radioButton_Speed;
        private System.Windows.Forms.RadioButton radioButton_Normal;
        private System.Windows.Forms.Panel YPanel;
        private System.Windows.Forms.Button settingButton;
        private System.Windows.Forms.CheckBox allSelectedCheckBox2;
        private System.Windows.Forms.CheckedListBox sensorCheckedListBox2;
        private System.Windows.Forms.RadioButton radioButtonLine2;
        private System.Windows.Forms.RadioButton radioButtonLine1;
        private System.Windows.Forms.Button standardButton;
        private System.Windows.Forms.GroupBox firstDriverGroupBox;
        private System.Windows.Forms.TableLayoutPanel firstDriverTableLayoutPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox secondDriverGroupBox;
        private System.Windows.Forms.TableLayoutPanel secondDriverTableLayoutPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.Label label24;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar thirdTrackBar;
        private System.Windows.Forms.TrackBar secondTrackBar;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TrackBar firstTrackBar;
    }
}

