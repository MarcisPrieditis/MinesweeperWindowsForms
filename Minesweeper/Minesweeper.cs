﻿using Minesweeper.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        public Minesweeper()
        {
            InitializeComponent();
            var board = new Board(this, 8, 9, 9);
            board.SetupBoard();
        }

        private void Minesweeper_Load(object sender, EventArgs e)
        {

        }
    }
}