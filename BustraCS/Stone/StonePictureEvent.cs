using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustraCS.Stone
{
    /// <summary>
    /// StonePictureのcommand
    /// </summary>
    public partial class StonePicture : PictureBox
    {
        /// <summary>
        /// 石を落とすイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDowned(object sender, MouseEventArgs e)
        {
            MouseMove += new MouseEventHandler(StoneMove);
        }

        /// <summary>
        /// 石を持ち上げるイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseUped(object sender, MouseEventArgs e)
        { 
            MouseMove -= new MouseEventHandler(StoneMove);
            this.Move();
        }

        /// <summary>
        /// 石を動かすイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoneMove(object sender, MouseEventArgs e)
        {
            Left = Cursor.Position.X - Size.Width / 2;
            Top = Cursor.Position.Y - Size.Height;
        }

        /// <summary>
        /// StonePictureを動かす
        /// </summary>
        private void Move()
        {
            int _x = Top / Size.Height;
            int _y = Left / Size.Width;
            x = (Top >= _x * Size.Height + Size.Height / 2) ? _x + 1 : _x;
            y = (Left >= _y * Size.Width + Size.Width / 2) ? _y + 1 : _y;
            Top = x * Size.Height;
            Left = y * Size.Width;
        }
    }
}
