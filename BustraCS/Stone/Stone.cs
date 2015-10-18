using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BustraCS.Stone
{
    public class Stone
    {
        private Brush color;
        private int _x;
        public int X
        {
            get { return _x; }
        }
        private int _y;
        public int Y
        {
            get { return _y; }
        }

        private int _size = 48;
        public int Size
        {
            get { return _size; }
        }

        public Stone(int x, int y)
        {
            color = StoneColor.random();
            _x = x;
            _y = y;
        }

        public Bitmap Image()
        {
            Bitmap canvas = new Bitmap(_size, _size);
            Graphics g = Graphics.FromImage(canvas);
            g.FillRectangle(color, 0, 0, _size, _size);
            g.Dispose();
            return canvas;
        }
    }
}
