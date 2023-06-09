﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace TurboGlide
{

    public partial class PWinForm : Form
    {
        SoundPlayer speakerVictory = new SoundPlayer("victorySound.wav");
        public PWinForm()
        {
            InitializeComponent();
        }
        //Show starting form on close
        private void PWinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            speakerVictory.Stop();
            this.Hide();
            Form1 newGame = new Form1();
            newGame.ShowDialog();
            this.Close();
        }
        //Set ESC as close button
        private void PWinForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        //Play victorySound on form load
        private void PWinForm_Load(object sender, EventArgs e)
        {
            speakerVictory.Play();
        }
    }
}
