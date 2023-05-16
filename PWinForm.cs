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
    public partial class PWinForm : Form
    {
        public PWinForm()
        {
            InitializeComponent();
        }

        private void PWinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 newGame = new Form1();
            newGame.ShowDialog();
            this.Close();
        }

        private void PWinForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
