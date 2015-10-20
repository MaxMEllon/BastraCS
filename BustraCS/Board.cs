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

        private async void SwapStone(object sender, EventArgs e)
        {
            await Task.Run(
                () => {
                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            int x = i;
                            int y = j;
                            if (pictureBoxes[i][j].IsEmpty)
                            {
                                StonePicture temp = ((StonePicture)sender);
                                Thread t = new Thread(new ThreadStart(
                                    ()=> {
                                        temp.worker(
                                            () => {
                                                temp._x = x;
                                                temp._y = y;
                                                temp.Top = x * 50;
                                                temp.Left = y * 50;
                                                temp.IsEmpty = true;
                                            });
                                    }));
                                t.Start();
                                pictureBoxes[i][j].IsEmpty = false;
                            }
                        }
                    }
                });
        }
    }

}
