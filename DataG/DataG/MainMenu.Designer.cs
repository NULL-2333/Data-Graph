namespace DataG
{
    partial class MainMenu
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
            this.singleRunButton = new System.Windows.Forms.Button();
            this.dualRunButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // singleRunButton
            // 
            this.singleRunButton.Location = new System.Drawing.Point(12, 12);
            this.singleRunButton.Name = "singleRunButton";
            this.singleRunButton.Size = new System.Drawing.Size(369, 100);
            this.singleRunButton.TabIndex = 0;
            this.singleRunButton.Text = "Single Run";
            this.singleRunButton.UseVisualStyleBackColor = true;
            this.singleRunButton.Click += new System.EventHandler(this.singleRunButton_Click);
            // 
            // dualRunButton
            // 
            this.dualRunButton.Location = new System.Drawing.Point(12, 138);
            this.dualRunButton.Name = "dualRunButton";
            this.dualRunButton.Size = new System.Drawing.Size(369, 100);
            this.dualRunButton.TabIndex = 1;
            this.dualRunButton.Text = "Dual Run";
            this.dualRunButton.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 254);
            this.Controls.Add(this.dualRunButton);
            this.Controls.Add(this.singleRunButton);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button singleRunButton;
        private System.Windows.Forms.Button dualRunButton;
    }
}