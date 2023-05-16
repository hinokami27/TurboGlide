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

        private void btnStartGame_MouseHover(object sender, EventArgs e)
        {
            btnStartGame.Cursor = Cursors.Hand;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameWindow gw = new GameWindow();
            gw.ShowDialog();
            this.Close();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            RulesForm rf = new RulesForm();
            rf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ControlsForm cf = new ControlsForm();
            cf.ShowDialog();
        }
    }
}
