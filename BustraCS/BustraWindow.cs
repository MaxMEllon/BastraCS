using BustraCS.Stone;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustraCS
{
    public partial class BustraWindow : Form
    {
        private Board board;
        private Collection<StonePictureList> pictureBoxes;

        public BustraWindow()
        {
            board = new Board(this);
            board.Draw();
            InitializeComponent();
        }
    }
}
