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
        public int _x;
        public int _y;
        private Stone stone;
        private static readonly int defaultSize = 50;

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
            OnAsyncOverlayStone(EventArgs.Empty);
            Image = Picture(stone.Color);
        }

        /// <summary>
        /// 石の画像
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private Bitmap Picture(Brush color)
        {
            Bitmap canvas = new Bitmap(defaultSize, defaultSize);
            Graphics g = Graphics.FromImage(canvas);
            g.FillRectangle(color, 0, 0, defaultSize, defaultSize);
            g.Dispose();
            return canvas;
        }

        /// <summary>
        /// 仮のborder
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private Bitmap Border(Brush color)
        {
            Bitmap canvas = new Bitmap(defaultSize, defaultSize);
            Graphics g = Graphics.FromImage(canvas);
            g.FillRectangle(Brushes.Aqua, 0, 0, Size.Width, Size.Height);
            g.FillRectangle(color, 2, 2, Size.Width-4, Size.Height-4);
            g.Dispose();
            this.Size = new Size(defaultSize, defaultSize);
            return canvas;
        }
    }
}
