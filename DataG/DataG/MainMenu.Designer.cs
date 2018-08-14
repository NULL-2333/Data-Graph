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
            this.comparedRunButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // singleRunButton
            // 
            this.singleRunButton.Location = new System.Drawing.Point(12, 12);
            this.singleRunButton.Name = "singleRunButton";
            this.singleRunButton.Size = new System.Drawing.Size(369, 100);
            this.singleRunButton.TabIndex = 1;
            this.singleRunButton.Text = "Single Run";
            this.singleRunButton.UseVisualStyleBackColor = true;
            this.singleRunButton.Click += new System.EventHandler(this.singleRunButton_Click);
            // 
            // comparedRunButton
            // 
            this.comparedRunButton.Location = new System.Drawing.Point(12, 138);
            this.comparedRunButton.Name = "comparedRunButton";
            this.comparedRunButton.Size = new System.Drawing.Size(369, 100);
            this.comparedRunButton.TabIndex = 2;
            this.comparedRunButton.Text = "Compared Run";
            this.comparedRunButton.UseVisualStyleBackColor = true;
            this.comparedRunButton.Click += new System.EventHandler(this.comparedRunButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 267);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(369, 100);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 384);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.comparedRunButton);
            this.Controls.Add(this.singleRunButton);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button singleRunButton;
        private System.Windows.Forms.Button comparedRunButton;
        private System.Windows.Forms.Button exitButton;
    }
}