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
        private Collection<StonePictureList> pictureBox;
        #region height
        private readonly int _height = 5;
        public int Height
        {
            get { return _height; }
        }
        #endregion
        #region width
        private int _width = 6;
        public int Width
        {
            get { return _width; }
        }
        #endregion
        #region Stones
        private Collection<StoneList> _stones = new Collection<StoneList>();
        /// <summary>
        /// Stones : 石の２次元リスト
        /// </summary>
        public Collection<StoneList> Stones
        {
            get { return _stones; }
        }
        #endregion
        #region isMoveing
        private bool _isMoveing = false;
        public bool IsMooving
        {
            get { return _isMoveing; }
            set { _isMoveing = value; }
        }
        #endregion

        public Board(BustraWindow form)
        {
            for (int i = 0; i < Height; i++)
            {
                StoneList line = new StoneList();
                for (int j = 0; j < Width; j++)
                {
                    line.Add(new BustraCS.Stone.Stone(i, j));
                }
                _stones.Add(line);
            }
            pictureBox = createPictureBoxes(form);
        }

        private Collection<StonePictureList> createPictureBoxes(BustraWindow form)
        {
            Collection<StonePictureList> boxes = new Collection<StonePictureList>();
            for (int i = 0; i < Height; i++)
            {
                StonePictureList line = new StonePictureList();
                for (int j = 0; j < Width; j++)
                {
                    StonePicture pb = new StonePicture(_stones[i][j]);
                    pb.Parent = form;
                    line.Add(pb);
                }
                boxes.Add(line);
            }
            return boxes;
        }
    }
}
