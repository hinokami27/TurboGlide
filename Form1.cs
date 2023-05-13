using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurboGlide
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbLogo.BackColor = Color.Transparent;
            btnStartGame.BackColor = Color.FromArgb(229, 90, 119);
            
            
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            

        }

        private void btnStartGame_MouseHover(object sender, EventArgs e)
        {
            btnStartGame.Cursor = Cursors.Hand;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            GameWindow gwf = new GameWindow();
            if(gwf.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
