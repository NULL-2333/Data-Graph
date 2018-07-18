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
            this.loadFileButton = new System.Windows.Forms.Button();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.textBoxSensor = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.activatePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.checkedListBoxSensor = new System.Windows.Forms.CheckedListBox();
            this.displayPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            this.SuspendLayout();
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(957, 12);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(171, 41);
            this.loadFileButton.TabIndex = 0;
            this.loadFileButton.Text = "Load Files...";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // graphPanel
            // 
            this.graphPanel.BackColor = System.Drawing.SystemColors.Info;
            this.graphPanel.Location = new System.Drawing.Point(74, 12);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(864, 320);
            this.graphPanel.TabIndex = 1;
            this.graphPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseClick);
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
            this.activatePanel.Location = new System.Drawing.Point(683, 400);
            this.activatePanel.Name = "activatePanel";
            this.activatePanel.Size = new System.Drawing.Size(254, 224);
            this.activatePanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.checkedListBoxSensor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(470, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 225);
            this.panel1.TabIndex = 4;
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
            // trackBarX
            // 
            this.trackBarX.BackColor = System.Drawing.SystemColors.Info;
            this.trackBarX.Location = new System.Drawing.Point(12, 338);
            this.trackBarX.Maximum = 100;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(925, 56);
            this.trackBarX.TabIndex = 0;
            this.trackBarX.ValueChanged += new System.EventHandler(this.trackBarX_ValueChanged);
            // 
            // trackBarY
            // 
            this.trackBarY.BackColor = System.Drawing.SystemColors.Info;
            this.trackBarY.Location = new System.Drawing.Point(12, 12);
            this.trackBarY.Maximum = 100;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarY.Size = new System.Drawing.Size(56, 320);
            this.trackBarY.TabIndex = 5;
            this.trackBarY.ValueChanged += new System.EventHandler(this.trackBarY_ValueChanged);
            // 
            // checkedListBoxSensor
            // 
            this.checkedListBoxSensor.CheckOnClick = true;
            this.checkedListBoxSensor.FormattingEnabled = true;
            this.checkedListBoxSensor.Items.AddRange(new object[] {
            "SensorA",
            "SensorB",
            "SensorC",
            "SensorD"});
            this.checkedListBoxSensor.Location = new System.Drawing.Point(30, 74);
            this.checkedListBoxSensor.Name = "checkedListBoxSensor";
            this.checkedListBoxSensor.Size = new System.Drawing.Size(150, 124);
            this.checkedListBoxSensor.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 637);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.activatePanel);
            this.Controls.Add(this.displayPanel);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.loadFileButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.displayPanel.ResumeLayout(false);
            this.displayPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.Panel activatePanel;
        private System.Windows.Forms.TextBox textBoxSensor;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.CheckedListBox checkedListBoxSensor;
    }
}

