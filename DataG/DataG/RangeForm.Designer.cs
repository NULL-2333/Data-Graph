namespace DataG
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
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(148, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "X And Y Coordinate Range Adjustment";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(425, 264);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(134, 29);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(124, 264);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(134, 29);
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
            this.groupBox2.Location = new System.Drawing.Point(14, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 152);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "X";
            // 
            // IntervaltextBox
            // 
            this.IntervaltextBox.Location = new System.Drawing.Point(208, 122);
            this.IntervaltextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IntervaltextBox.Name = "IntervaltextBox";
            this.IntervaltextBox.Size = new System.Drawing.Size(76, 21);
            this.IntervaltextBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.label8.Location = new System.Drawing.Point(6, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 29);
            this.label8.TabIndex = 16;
            this.label8.Text = "Interval:";
            // 
            // XScaleViewTextBox
            // 
            this.XScaleViewTextBox.Location = new System.Drawing.Point(208, 90);
            this.XScaleViewTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.XScaleViewTextBox.Name = "XScaleViewTextBox";
            this.XScaleViewTextBox.Size = new System.Drawing.Size(76, 21);
            this.XScaleViewTextBox.TabIndex = 15;
            // 
            // XRangeMinTextBox
            // 
            this.XRangeMinTextBox.Location = new System.Drawing.Point(208, 56);
            this.XRangeMinTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.XRangeMinTextBox.Name = "XRangeMinTextBox";
            this.XRangeMinTextBox.Size = new System.Drawing.Size(76, 21);
            this.XRangeMinTextBox.TabIndex = 14;
            // 
            // XRangeMaxTextBox
            // 
            this.XRangeMaxTextBox.Location = new System.Drawing.Point(208, 20);
            this.XRangeMaxTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.XRangeMaxTextBox.Name = "XRangeMaxTextBox";
            this.XRangeMaxTextBox.Size = new System.Drawing.Size(76, 21);
            this.XRangeMaxTextBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(5, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "Maximum Value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(5, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "Minimum Value:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(5, 83);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 29);
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
            this.groupBox1.Location = new System.Drawing.Point(350, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 152);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Y";
            // 
            // YAxisComboBox
            // 
            this.YAxisComboBox.FormattingEnabled = true;
            this.YAxisComboBox.Items.AddRange(new object[] {
            "R1",
            "R2",
            "R3",
            "R4"});
            this.YAxisComboBox.Location = new System.Drawing.Point(199, 91);
            this.YAxisComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.YAxisComboBox.Name = "YAxisComboBox";
            this.YAxisComboBox.Size = new System.Drawing.Size(125, 20);
            this.YAxisComboBox.TabIndex = 19;
            this.YAxisComboBox.SelectedIndexChanged += new System.EventHandler(this.YAxisComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.label9.Location = new System.Drawing.Point(6, 87);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 29);
            this.label9.TabIndex = 18;
            this.label9.Text = "Y Axis Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Maximum Value:";
            // 
            // YRangeMaxTextBox
            // 
            this.YRangeMaxTextBox.Location = new System.Drawing.Point(198, 23);
            this.YRangeMaxTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.YRangeMaxTextBox.Name = "YRangeMaxTextBox";
            this.YRangeMaxTextBox.Size = new System.Drawing.Size(126, 21);
            this.YRangeMaxTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(5, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Minimum Value:";
            // 
            // YRangeMinTextBox
            // 
            this.YRangeMinTextBox.Location = new System.Drawing.Point(198, 56);
            this.YRangeMinTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.YRangeMinTextBox.Name = "YRangeMinTextBox";
            this.YRangeMinTextBox.Size = new System.Drawing.Size(126, 21);
            this.YRangeMinTextBox.TabIndex = 9;
            // 
            // settingSaveButton
            // 
            this.settingSaveButton.Location = new System.Drawing.Point(274, 264);
            this.settingSaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.settingSaveButton.Name = "settingSaveButton";
            this.settingSaveButton.Size = new System.Drawing.Size(134, 29);
            this.settingSaveButton.TabIndex = 17;
            this.settingSaveButton.Text = "Save Setting...";
            this.settingSaveButton.UseVisualStyleBackColor = true;
            this.settingSaveButton.Click += new System.EventHandler(this.settingSaveButton_Click);
            // 
            // RangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(706, 302);
            this.Controls.Add(this.settingSaveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RangeForm";
            this.Load += new System.EventHandler(this.YRangeForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}