using BustraCS.Stone;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustraCS
{
    public class Board
    {
        private Collection<StonePictureList> pictureBoxes;
        #region public int Height { get; }
        private readonly int _height = 5;
        public int Height
        {
            get { return _height; }
        }
        #endregion
        #region public int Width { get; }
        private readonly int _width = 6;
        public int Width
        {
            get { return _width; }
        }
        #endregion
        #region public bool isMoveing { set; get; }
        private bool _isMoveing = false;
        public bool IsMooving
        {
            get { return _isMoveing; }
            set { _isMoveing = value; }
        }
        #endregion

        public Board(BustraWindow form)
        {
            pictureBoxes = new Collection<StonePictureList>();
            for (int i = 0; i < Height; i++)
            {
                StonePictureList line = new StonePictureList();
                for (int j = 0; j < Width; j++)
                {
                    StonePicture pb = new StonePicture(i, j);
                    pb.Parent = form;
                    line.Add(pb);
                }
                pictureBoxes.Add(line);
            }
        }
    }
}
