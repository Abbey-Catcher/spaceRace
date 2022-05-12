namespace spaceRace
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.subTitleLabel = new System.Windows.Forms.Label();
            this.p2ScoreLabel = new System.Windows.Forms.Label();
            this.p1ScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.titleLabel.ForeColor = System.Drawing.Color.Cyan;
            this.titleLabel.Location = new System.Drawing.Point(288, 131);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(243, 42);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "titleLabel";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // subTitleLabel
            // 
            this.subTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.subTitleLabel.ForeColor = System.Drawing.Color.Lime;
            this.subTitleLabel.Location = new System.Drawing.Point(245, 260);
            this.subTitleLabel.Name = "subTitleLabel";
            this.subTitleLabel.Size = new System.Drawing.Size(311, 78);
            this.subTitleLabel.TabIndex = 4;
            this.subTitleLabel.Text = "subTitleLabel";
            this.subTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // p2ScoreLabel
            // 
            this.p2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p2ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.p2ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.p2ScoreLabel.Location = new System.Drawing.Point(450, 359);
            this.p2ScoreLabel.Name = "p2ScoreLabel";
            this.p2ScoreLabel.Size = new System.Drawing.Size(311, 78);
            this.p2ScoreLabel.TabIndex = 5;
            this.p2ScoreLabel.Text = "p2ScoreLabel";
            this.p2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // p1ScoreLabel
            // 
            this.p1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p1ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.p1ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.p1ScoreLabel.Location = new System.Drawing.Point(35, 348);
            this.p1ScoreLabel.Name = "p1ScoreLabel";
            this.p1ScoreLabel.Size = new System.Drawing.Size(311, 78);
            this.p1ScoreLabel.TabIndex = 6;
            this.p1ScoreLabel.Text = "p1ScoreLabel";
            this.p1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.p1ScoreLabel);
            this.Controls.Add(this.p2ScoreLabel);
            this.Controls.Add(this.subTitleLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Space Race";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subTitleLabel;
        private System.Windows.Forms.Label p2ScoreLabel;
        private System.Windows.Forms.Label p1ScoreLabel;
    }
}

