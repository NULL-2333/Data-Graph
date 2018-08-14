namespace DataG
{
    partial class ComparedRun_FileLoadingForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.firstFileTextBox = new System.Windows.Forms.TextBox();
            this.secondFileTextBox = new System.Windows.Forms.TextBox();
            this.firstFileButton = new System.Windows.Forms.Button();
            this.secondFileButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(48, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "The 1st File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(48, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "The 2rd File:";
            // 
            // firstFileTextBox
            // 
            this.firstFileTextBox.Location = new System.Drawing.Point(248, 63);
            this.firstFileTextBox.Name = "firstFileTextBox";
            this.firstFileTextBox.Size = new System.Drawing.Size(393, 25);
            this.firstFileTextBox.TabIndex = 2;
            // 
            // secondFileTextBox
            // 
            this.secondFileTextBox.Location = new System.Drawing.Point(248, 164);
            this.secondFileTextBox.Name = "secondFileTextBox";
            this.secondFileTextBox.Size = new System.Drawing.Size(393, 25);
            this.secondFileTextBox.TabIndex = 3;
            // 
            // firstFileButton
            // 
            this.firstFileButton.Location = new System.Drawing.Point(657, 63);
            this.firstFileButton.Name = "firstFileButton";
            this.firstFileButton.Size = new System.Drawing.Size(140, 25);
            this.firstFileButton.TabIndex = 4;
            this.firstFileButton.Text = "Loading...";
            this.firstFileButton.UseVisualStyleBackColor = true;
            this.firstFileButton.Click += new System.EventHandler(this.firstFileButton_Click);
            // 
            // secondFileButton
            // 
            this.secondFileButton.Location = new System.Drawing.Point(657, 164);
            this.secondFileButton.Name = "secondFileButton";
            this.secondFileButton.Size = new System.Drawing.Size(140, 25);
            this.secondFileButton.TabIndex = 5;
            this.secondFileButton.Text = "Loading...";
            this.secondFileButton.UseVisualStyleBackColor = true;
            this.secondFileButton.Click += new System.EventHandler(this.secondFileButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(226, 262);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(162, 42);
            this.confirmButton.TabIndex = 6;
            this.confirmButton.Text = "Comfirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(467, 262);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(162, 42);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ComparedRun_FileLoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 316);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.secondFileButton);
            this.Controls.Add(this.firstFileButton);
            this.Controls.Add(this.secondFileTextBox);
            this.Controls.Add(this.firstFileTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ComparedRun_FileLoadingForm";
            this.Text = "File Loading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstFileTextBox;
        private System.Windows.Forms.TextBox secondFileTextBox;
        private System.Windows.Forms.Button firstFileButton;
        private System.Windows.Forms.Button secondFileButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
    }
}