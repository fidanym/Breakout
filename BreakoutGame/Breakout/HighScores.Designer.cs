namespace Breakout
{
    partial class HighScores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighScores));
            this.lbHighScores = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbHighScores
            // 
            this.lbHighScores.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbHighScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbHighScores.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHighScores.ForeColor = System.Drawing.Color.Orange;
            this.lbHighScores.FormattingEnabled = true;
            this.lbHighScores.ItemHeight = 19;
            this.lbHighScores.Location = new System.Drawing.Point(12, 12);
            this.lbHighScores.Name = "lbHighScores";
            this.lbHighScores.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbHighScores.Size = new System.Drawing.Size(268, 285);
            this.lbHighScores.TabIndex = 0;
            // 
            // HighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(292, 318);
            this.Controls.Add(this.lbHighScores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(308, 357);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(308, 357);
            this.Name = "HighScores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HighScores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbHighScores;
    }
}