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
        private Size size;

        private event MouseEventHandler _OnMouseClick;
        public event MouseEventHandler OnMouseClick
        {
            add { _OnMouseClick += value; }
            remove { _OnMouseClick -= value; }
        }


        private void MouseEntered(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Clicks);
        }

        public StonePicture(Stone stone)
        {
            this.OnMouseClick += new MouseEventHandler(this.MouseEntered);
            this.x = stone.X;
            this.y = stone.Y;
            this.Size = new Size(stone.Size, stone.Size);
            this.Top  = x * stone.Size;
            this.Left = y * stone.Size;
        }
    }
}
