namespace DataG
{
    partial class ProfessionalSegmentationTime
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
            this.secondTimeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.firstTimeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // secondTimeLabel
            // 
            this.secondTimeLabel.AutoSize = true;
            this.secondTimeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.secondTimeLabel.Location = new System.Drawing.Point(244, 136);
            this.secondTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.secondTimeLabel.Name = "secondTimeLabel";
            this.secondTimeLabel.Size = new System.Drawing.Size(73, 30);
            this.secondTimeLabel.TabIndex = 14;
            this.secondTimeLabel.Text = "NULL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(3, 136);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 30);
            this.label6.TabIndex = 13;
            this.label6.Text = "1st Driver Time[s]:";
            // 
            // firstTimeLabel
            // 
            this.firstTimeLabel.AutoSize = true;
            this.firstTimeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.firstTimeLabel.Location = new System.Drawing.Point(244, 94);
            this.firstTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.firstTimeLabel.Name = "firstTimeLabel";
            this.firstTimeLabel.Size = new System.Drawing.Size(73, 30);
            this.firstTimeLabel.TabIndex = 12;
            this.firstTimeLabel.Text = "NULL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(3, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 30);
            this.label5.TabIndex = 11;
            this.label5.Text = "1st Driver Time[s]:";
            // 
            // ProfessionalSegmentationTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 233);
            this.Controls.Add(this.secondTimeLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.firstTimeLabel);
            this.Controls.Add(this.label5);
            this.Name = "ProfessionalSegmentationTime";
            this.Text = "ProfessionalSegmentationTime";
            this.Load += new System.EventHandler(this.ProfessionalSegmentationTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label secondTimeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label firstTimeLabel;
        private System.Windows.Forms.Label label5;
    }
}