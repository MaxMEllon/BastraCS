using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BustraCS.Stone
{
    /// <summary>
    /// 石のmodel
    /// </summary>
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
            set { _x = value; }
        }
        private int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private int _size = 50;
        public int Size
        {
            get { return _size; }
        }

        public Stone(int x, int y)
        {
            _color = StoneColor.Random();
            _x = x;
            _y = y;
        }

    }
}
