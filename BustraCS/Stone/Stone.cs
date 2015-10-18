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
        private Brush _color;
        public Brush Color
        {
            get { return _color; }
        }
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
            _color = StoneColor.random();
            _x = x;
            _y = y;
        }

    }
}
