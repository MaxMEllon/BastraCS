using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustraCS.Stone
{
    /// <summary>
    /// 石のViewModel
    /// </summary>
    public partial class StonePicture : PictureBox
    {
        private int x;
        private int y;
        private Stone stone;

        public StonePicture(int x, int y)
        {
            stone = new Stone(x, y);
            x = stone.X;
            y = stone.Y;
            AllowDrop = true;
            MouseDown += new MouseEventHandler(MouseDowned);
            MouseUp += new MouseEventHandler(MouseUped);
            Size = new Size(stone.Size, stone.Size);
            Location = new Point(y * stone.Size, x * stone.Size);
            Image = Picture(stone.Color);
        }

        /// <summary>
        /// 石の画像
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Bitmap Picture(Brush color)
        {
            Bitmap canvas = new Bitmap(Size.Width, Size.Height);
            Graphics g = Graphics.FromImage(canvas);
            g.FillRectangle(color, 0, 0, Size.Width, Size.Height);
            g.Dispose();
            return canvas;
        }

    }
}
