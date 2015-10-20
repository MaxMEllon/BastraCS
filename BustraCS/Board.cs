using BustraCS.Stone;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        public Board(BustraForm form)
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
            SetStonePictureOverlayEvent();
        }

        /// <summary>
        /// 現在石が動いているかどうかを調べる
        /// </summary>
        /// <returns>今石が動いてるかどうか</returns>
        private bool nowMovingStone()
        {
            bool flag = false;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    flag = pictureBoxes[i][j].IsMoving;
                }
            }
            return flag;
        }

        /// <summary>
        /// StonePictureが重なった時のイベントを登録
        /// </summary>
        private void SetStonePictureOverlayEvent()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    pictureBoxes[i][j].AsyncOverlayStone += new EventHandler(SwapStone);
                }
            }
        }

        private void SwapStone(object sender, EventArgs e)
        {
            Console.WriteLine("swap!");
        }
    }
}
