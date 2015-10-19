using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustraCS.Stone
{
    public class StonePicture : PictureBox
    {
        private int x;
        private int y;

        public StonePicture(Stone stone)
        {
            AllowDrop = true;
            MouseDown += new MouseEventHandler(MouseDowned);
            MouseUp += new MouseEventHandler(MouseUped);
            x = stone.X;
            y = stone.Y;
            Size = new Size(stone.Size, stone.Size);
            Location = new Point(y * stone.Size, x * stone.Size);
            Image = Picture(stone.Color);
        }

        public Bitmap Picture(Brush color)
        {
            Bitmap canvas = new Bitmap(Size.Width, Size.Height);
            Graphics g = Graphics.FromImage(canvas);
            g.FillRectangle(color, 0, 0, Size.Width, Size.Height);
            g.Dispose();
            return canvas;
        }

        private void MouseDowned(object sender, MouseEventArgs e)
        {
            MouseMove += new MouseEventHandler(StoneMove);
        }

        private void MouseUped(object sender, MouseEventArgs e)
        { 
            MouseMove -= new MouseEventHandler(StoneMove);
            x = Top / Size.Height;
            y = Left / Size.Width;
            x = (Top >= x * Size.Height + Size.Height / 2) ? x + 1 : x;
            y = (Left >= y * Size.Width + Size.Width / 2) ? y + 1 : y;
            Top = x * Size.Height;
            Left = y * Size.Width;
        }

        private void StoneMove(object sender, MouseEventArgs e)
        {
            Left = Cursor.Position.X - Size.Width / 2;
            Top = Cursor.Position.Y - Size.Height;
        }
    }
}
