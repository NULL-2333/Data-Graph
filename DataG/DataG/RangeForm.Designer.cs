﻿namespace DataG
{
    partial class RangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.IntervaltextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.XScaleViewTextBox = new System.Windows.Forms.TextBox();
            this.XRangeMinTextBox = new System.Windows.Forms.TextBox();
            this.XRangeMaxTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.YAxisComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.YRangeMaxTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.YRangeMinTextBox = new System.Windows.Forms.TextBox();
            this.settingSaveButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(594, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "Configuration";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(818, 320);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(179, 36);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(416, 320);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(179, 36);
            this.confirmButton.TabIndex = 10;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.IntervaltextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.XScaleViewTextBox);
            this.groupBox2.Controls.Add(this.XRangeMinTextBox);
            this.groupBox2.Controls.Add(this.XRangeMaxTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(19, 72);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(425, 190);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "X Axis";
            // 
            // IntervaltextBox
            // 
            this.IntervaltextBox.Location = new System.Drawing.Point(277, 152);
            this.IntervaltextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IntervaltextBox.Name = "IntervaltextBox";
            this.IntervaltextBox.Size = new System.Drawing.Size(100, 25);
            this.IntervaltextBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.label8.Location = new System.Drawing.Point(8, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 33);
            this.label8.TabIndex = 16;
            this.label8.Text = "Interval:";
            // 
            // XScaleViewTextBox
            // 
            this.XScaleViewTextBox.Location = new System.Drawing.Point(277, 112);
            this.XScaleViewTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XScaleViewTextBox.Name = "XScaleViewTextBox";
            this.XScaleViewTextBox.Size = new System.Drawing.Size(100, 25);
            this.XScaleViewTextBox.TabIndex = 15;
            // 
            // XRangeMinTextBox
            // 
            this.XRangeMinTextBox.Location = new System.Drawing.Point(277, 70);
            this.XRangeMinTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XRangeMinTextBox.Name = "XRangeMinTextBox";
            this.XRangeMinTextBox.Size = new System.Drawing.Size(100, 25);
            this.XRangeMinTextBox.TabIndex = 14;
            // 
            // XRangeMaxTextBox
            // 
            this.XRangeMaxTextBox.Location = new System.Drawing.Point(277, 25);
            this.XRangeMaxTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XRangeMaxTextBox.Name = "XRangeMaxTextBox";
            this.XRangeMaxTextBox.Size = new System.Drawing.Size(100, 25);
            this.XRangeMaxTextBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(7, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 33);
            this.label5.TabIndex = 6;
            this.label5.Text = "Maximum Value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(7, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 33);
            this.label6.TabIndex = 7;
            this.label6.Text = "Minimum Value:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(7, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 33);
            this.label7.TabIndex = 12;
            this.label7.Text = "Scale View Size:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.YAxisComboBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.YRangeMaxTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.YRangeMinTextBox);
            this.groupBox1.Location = new System.Drawing.Point(467, 72);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(461, 190);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Y Axis";
            // 
            // YAxisComboBox
            // 
            this.YAxisComboBox.FormattingEnabled = true;
            this.YAxisComboBox.Items.AddRange(new object[] {
            "R1",
            "R2",
            "R3",
            "R4"});
            this.YAxisComboBox.Location = new System.Drawing.Point(265, 114);
            this.YAxisComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YAxisComboBox.Name = "YAxisComboBox";
            this.YAxisComboBox.Size = new System.Drawing.Size(165, 23);
            this.YAxisComboBox.TabIndex = 19;
            this.YAxisComboBox.SelectedIndexChanged += new System.EventHandler(this.YAxisComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.label9.Location = new System.Drawing.Point(8, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 33);
            this.label9.TabIndex = 18;
            this.label9.Text = "Y Axis Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "Maximum Value:";
            // 
            // YRangeMaxTextBox
            // 
            this.YRangeMaxTextBox.Location = new System.Drawing.Point(264, 29);
            this.YRangeMaxTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YRangeMaxTextBox.Name = "YRangeMaxTextBox";
            this.YRangeMaxTextBox.Size = new System.Drawing.Size(167, 25);
            this.YRangeMaxTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "Minimum Value:";
            // 
            // YRangeMinTextBox
            // 
            this.YRangeMinTextBox.Location = new System.Drawing.Point(264, 70);
            this.YRangeMinTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YRangeMinTextBox.Name = "YRangeMinTextBox";
            this.YRangeMinTextBox.Size = new System.Drawing.Size(167, 25);
            this.YRangeMinTextBox.TabIndex = 9;
            // 
            // settingSaveButton
            // 
            this.settingSaveButton.Location = new System.Drawing.Point(616, 320);
            this.settingSaveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settingSaveButton.Name = "settingSaveButton";
            this.settingSaveButton.Size = new System.Drawing.Size(179, 36);
            this.settingSaveButton.TabIndex = 17;
            this.settingSaveButton.Text = "Save Setting...";
            this.settingSaveButton.UseVisualStyleBackColor = true;
            this.settingSaveButton.Click += new System.EventHandler(this.settingSaveButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.speedTextBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(950, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 189);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Others";
            // 
            // speedTextBox
            // 
            this.speedTextBox.Location = new System.Drawing.Point(184, 25);
            this.speedTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(167, 25);
            this.speedTextBox.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 33);
            this.label4.TabIndex = 19;
            this.label4.Text = "Speed:";
            // 
            // RangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1322, 378);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.settingSaveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RangeForm";
            this.Load += new System.EventHandler(this.YRangeForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox XScaleViewTextBox;
        private System.Windows.Forms.TextBox XRangeMinTextBox;
        private System.Windows.Forms.TextBox XRangeMaxTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox IntervaltextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox YRangeMaxTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox YRangeMinTextBox;
        private System.Windows.Forms.ComboBox YAxisComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button settingSaveButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.Label label4;
    }
}