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

        private void MouseEntered(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(this, DragDropEffects.Move);
            }
        }

        private void DragEntered(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void DragLeaved(object sender, EventArgs e)
        {
        }

        public StonePicture(Stone stone)
        {
            AllowDrop = true;
            MouseDown += new MouseEventHandler(this.MouseEntered);
            DragEnter += new DragEventHandler(this.DragEntered);
            DragLeave += new EventHandler(this.DragLeaved);
            this.x = stone.X;
            this.y = stone.Y;
            this.Size = new Size(stone.Size, stone.Size);
            this.Top  = x * stone.Size;
            this.Left = y * stone.Size;
            this.Image = Picture(stone.Color);
        }

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
