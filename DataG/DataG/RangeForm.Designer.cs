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
            this.YRangeMinTextBox = new System.Windows.Forms.TextBox();
            this.YRangeMaxTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.YScaleViewTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.XScaleViewTextBox = new System.Windows.Forms.TextBox();
            this.XRangeMinTextBox = new System.Windows.Forms.TextBox();
            this.XRangeMaxTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // YRangeMinTextBox
            // 
            this.YRangeMinTextBox.Location = new System.Drawing.Point(273, 72);
            this.YRangeMinTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YRangeMinTextBox.Name = "YRangeMinTextBox";
            this.YRangeMinTextBox.Size = new System.Drawing.Size(167, 25);
            this.YRangeMinTextBox.TabIndex = 9;
            // 
            // YRangeMaxTextBox
            // 
            this.YRangeMaxTextBox.Location = new System.Drawing.Point(273, 31);
            this.YRangeMaxTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YRangeMaxTextBox.Name = "YRangeMaxTextBox";
            this.YRangeMaxTextBox.Size = new System.Drawing.Size(167, 25);
            this.YRangeMaxTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "Minimum Value:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "X|Y Coordinate";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(579, 361);
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
            this.confirmButton.Location = new System.Drawing.Point(141, 361);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(179, 36);
            this.confirmButton.TabIndex = 10;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // YScaleViewTextBox
            // 
            this.YScaleViewTextBox.Location = new System.Drawing.Point(273, 111);
            this.YScaleViewTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YScaleViewTextBox.Name = "YScaleViewTextBox";
            this.YScaleViewTextBox.Size = new System.Drawing.Size(167, 25);
            this.YScaleViewTextBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(5, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 33);
            this.label4.TabIndex = 12;
            this.label4.Text = "Scale View Size:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.YScaleViewTextBox);
            this.groupBox1.Controls.Add(this.YRangeMaxTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.YRangeMinTextBox);
            this.groupBox1.Location = new System.Drawing.Point(19, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(461, 190);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Y";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.XScaleViewTextBox);
            this.groupBox2.Controls.Add(this.XRangeMinTextBox);
            this.groupBox2.Controls.Add(this.XRangeMaxTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(529, 70);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(425, 190);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "X";
            // 
            // XScaleViewTextBox
            // 
            this.XScaleViewTextBox.Location = new System.Drawing.Point(268, 112);
            this.XScaleViewTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.XScaleViewTextBox.Name = "XScaleViewTextBox";
            this.XScaleViewTextBox.Size = new System.Drawing.Size(132, 25);
            this.XScaleViewTextBox.TabIndex = 15;
            // 
            // XRangeMinTextBox
            // 
            this.XRangeMinTextBox.Location = new System.Drawing.Point(267, 71);
            this.XRangeMinTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.XRangeMinTextBox.Name = "XRangeMinTextBox";
            this.XRangeMinTextBox.Size = new System.Drawing.Size(132, 25);
            this.XRangeMinTextBox.TabIndex = 14;
            // 
            // XRangeMaxTextBox
            // 
            this.XRangeMaxTextBox.Location = new System.Drawing.Point(267, 26);
            this.XRangeMaxTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.XRangeMaxTextBox.Name = "XRangeMaxTextBox";
            this.XRangeMaxTextBox.Size = new System.Drawing.Size(132, 25);
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
            // RangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(971, 418);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RangeForm";
            this.Text = "RangeForm";
            this.Load += new System.EventHandler(this.YRangeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox YRangeMinTextBox;
        private System.Windows.Forms.TextBox YRangeMaxTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox YScaleViewTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox XScaleViewTextBox;
        private System.Windows.Forms.TextBox XRangeMinTextBox;
        private System.Windows.Forms.TextBox XRangeMaxTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}