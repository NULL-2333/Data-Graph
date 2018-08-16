namespace DataG
{
    partial class InputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.latComboBox = new System.Windows.Forms.ComboBox();
            this.lonComboBox = new System.Windows.Forms.ComboBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(838, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Choose the Columns\' Name For Latitude and Longtitude";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Latitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(17, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Longtitude";
            // 
            // latComboBox
            // 
            this.latComboBox.FormattingEnabled = true;
            this.latComboBox.Location = new System.Drawing.Point(221, 123);
            this.latComboBox.Name = "latComboBox";
            this.latComboBox.Size = new System.Drawing.Size(450, 23);
            this.latComboBox.TabIndex = 3;
            // 
            // lonComboBox
            // 
            this.lonComboBox.FormattingEnabled = true;
            this.lonComboBox.Location = new System.Drawing.Point(221, 217);
            this.lonComboBox.Name = "lonComboBox";
            this.lonComboBox.Size = new System.Drawing.Size(450, 23);
            this.lonComboBox.TabIndex = 4;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(176, 331);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(179, 36);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(554, 331);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(179, 36);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(866, 397);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.lonComboBox);
            this.Controls.Add(this.latComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputForm";
            this.Text = "Input";
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox latComboBox;
        private System.Windows.Forms.ComboBox lonComboBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
    }
}