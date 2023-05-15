namespace TurboGlide
{
    partial class GameWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.pbPlayerB = new System.Windows.Forms.PictureBox();
            this.pbPlayerA = new System.Windows.Forms.PictureBox();
            this.pbPuck = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbGoalB = new System.Windows.Forms.PictureBox();
            this.pbGoalA = new System.Windows.Forms.PictureBox();
            this.lbPointsA = new System.Windows.Forms.Label();
            this.lbPointsB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPuck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGoalB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGoalA)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayerB
            // 
            this.pbPlayerB.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayerB.Image = ((System.Drawing.Image)(resources.GetObject("pbPlayerB.Image")));
            this.pbPlayerB.Location = new System.Drawing.Point(311, 459);
            this.pbPlayerB.Name = "pbPlayerB";
            this.pbPlayerB.Size = new System.Drawing.Size(66, 66);
            this.pbPlayerB.TabIndex = 0;
            this.pbPlayerB.TabStop = false;
            // 
            // pbPlayerA
            // 
            this.pbPlayerA.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayerA.Image = ((System.Drawing.Image)(resources.GetObject("pbPlayerA.Image")));
            this.pbPlayerA.Location = new System.Drawing.Point(89, 186);
            this.pbPlayerA.Name = "pbPlayerA";
            this.pbPlayerA.Size = new System.Drawing.Size(66, 66);
            this.pbPlayerA.TabIndex = 1;
            this.pbPlayerA.TabStop = false;
            // 
            // pbPuck
            // 
            this.pbPuck.BackColor = System.Drawing.Color.Transparent;
            this.pbPuck.Image = ((System.Drawing.Image)(resources.GetObject("pbPuck.Image")));
            this.pbPuck.Location = new System.Drawing.Point(209, 359);
            this.pbPuck.Name = "pbPuck";
            this.pbPuck.Size = new System.Drawing.Size(50, 50);
            this.pbPuck.TabIndex = 2;
            this.pbPuck.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbGoalB
            // 
            this.pbGoalB.BackColor = System.Drawing.Color.Transparent;
            this.pbGoalB.Location = new System.Drawing.Point(171, 709);
            this.pbGoalB.Name = "pbGoalB";
            this.pbGoalB.Size = new System.Drawing.Size(124, 28);
            this.pbGoalB.TabIndex = 3;
            this.pbGoalB.TabStop = false;
            // 
            // pbGoalA
            // 
            this.pbGoalA.BackColor = System.Drawing.Color.Transparent;
            this.pbGoalA.Location = new System.Drawing.Point(171, 30);
            this.pbGoalA.Name = "pbGoalA";
            this.pbGoalA.Size = new System.Drawing.Size(124, 28);
            this.pbGoalA.TabIndex = 4;
            this.pbGoalA.TabStop = false;
            // 
            // lbPointsA
            // 
            this.lbPointsA.AutoSize = true;
            this.lbPointsA.Location = new System.Drawing.Point(13, 13);
            this.lbPointsA.Name = "lbPointsA";
            this.lbPointsA.Size = new System.Drawing.Size(0, 13);
            this.lbPointsA.TabIndex = 5;
            // 
            // lbPointsB
            // 
            this.lbPointsB.AutoSize = true;
            this.lbPointsB.Location = new System.Drawing.Point(397, 9);
            this.lbPointsB.Name = "lbPointsB";
            this.lbPointsB.Size = new System.Drawing.Size(0, 13);
            this.lbPointsB.TabIndex = 6;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TurboGlide.Properties.Resources.BaseBoard00;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(466, 764);
            this.Controls.Add(this.lbPointsB);
            this.Controls.Add(this.lbPointsA);
            this.Controls.Add(this.pbPuck);
            this.Controls.Add(this.pbPlayerA);
            this.Controls.Add(this.pbPlayerB);
            this.Controls.Add(this.pbGoalA);
            this.Controls.Add(this.pbGoalB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(482, 803);
            this.Name = "GameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TurboGlide";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPuck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGoalB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGoalA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayerB;
        private System.Windows.Forms.PictureBox pbPlayerA;
        private System.Windows.Forms.PictureBox pbPuck;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbGoalB;
        private System.Windows.Forms.PictureBox pbGoalA;
        private System.Windows.Forms.Label lbPointsA;
        private System.Windows.Forms.Label lbPointsB;
    }
}