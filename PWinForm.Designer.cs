
namespace TurboGlide
{
    partial class PWinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PWinForm));
            this.SuspendLayout();
            // 
            // PWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TurboGlide.Properties.Resources.PinkTeamWin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(764, 468);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(780, 507);
            this.MinimumSize = new System.Drawing.Size(780, 507);
            this.Name = "PWinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TurboGlide";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PWinForm_FormClosed);
            this.Load += new System.EventHandler(this.PWinForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PWinForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}