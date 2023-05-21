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
        //Controls positioning and styling
        private void Form1_Load(object sender, EventArgs e)
        {
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location= new Point(71, 162);
            btnStartGame.BackColor = Color.FromArgb(229, 90, 119);
            btnStartGame.Location = new Point(120, 460);
            btnRules.Location = new Point(120, 541);
            button2.Location = new Point(246, 541);
        }
        //Launch game window and start game
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameWindow gw = new GameWindow();
            gw.ShowDialog();
            this.Close();
        }
        //Show rules form
        private void btnRules_Click(object sender, EventArgs e)
        {
            RulesForm rf = new RulesForm();
            rf.ShowDialog();
        }
        //Show controls form
        private void button2_Click(object sender, EventArgs e)
        {
            ControlsForm cf = new ControlsForm();
            cf.ShowDialog();
        }
        //Pointer cursor on hover
        private void btnStartGame_MouseHover(object sender, EventArgs e)
        {
            btnStartGame.Cursor = Cursors.Hand;
        }
        private void btnRules_MouseHover(object sender, EventArgs e)
        {
            btnRules.Cursor = Cursors.Hand;
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Cursor = Cursors.Hand;
        }
    }
}
