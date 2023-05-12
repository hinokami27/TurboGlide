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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.pbPlayerB = new System.Windows.Forms.PictureBox();
            this.pbPlayerA = new System.Windows.Forms.PictureBox();
            this.pbPuck = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPuck)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayerB
            // 
            this.pbPlayerB.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayerB.Image = ((System.Drawing.Image)(resources.GetObject("pbPlayerB.Image")));
            this.pbPlayerB.Location = new System.Drawing.Point(200, 628);
            this.pbPlayerB.Name = "pbPlayerB";
            this.pbPlayerB.Size = new System.Drawing.Size(66, 66);
            this.pbPlayerB.TabIndex = 0;
            this.pbPlayerB.TabStop = false;
            // 
            // pbPlayerA
            // 
            this.pbPlayerA.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayerA.Image = ((System.Drawing.Image)(resources.GetObject("pbPlayerA.Image")));
            this.pbPlayerA.Location = new System.Drawing.Point(200, 79);
            this.pbPlayerA.Name = "pbPlayerA";
            this.pbPlayerA.Size = new System.Drawing.Size(66, 66);
            this.pbPlayerA.TabIndex = 1;
            this.pbPlayerA.TabStop = false;
            // 
            // pbPuck
            // 
            this.pbPuck.BackColor = System.Drawing.Color.Transparent;
            this.pbPuck.Image = ((System.Drawing.Image)(resources.GetObject("pbPuck.Image")));
            this.pbPuck.Location = new System.Drawing.Point(208, 359);
            this.pbPuck.Name = "pbPuck";
            this.pbPuck.Size = new System.Drawing.Size(50, 50);
            this.pbPuck.TabIndex = 2;
            this.pbPuck.TabStop = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(466, 764);
            this.Controls.Add(this.pbPuck);
            this.Controls.Add(this.pbPlayerA);
            this.Controls.Add(this.pbPlayerB);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPuck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayerB;
        private System.Windows.Forms.PictureBox pbPlayerA;
        private System.Windows.Forms.PictureBox pbPuck;
    }
}