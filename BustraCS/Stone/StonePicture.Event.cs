using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustraCS.Stone
{
    /// <summary>
    /// StonePictureのcommand
    /// </summary>
    public partial class StonePicture : PictureBox
    {
        #region private bool isOverlay { get; }
        private bool judgeOverlay()
        {
            if (MovingStonePicture == null) { return false; }
            return this.Left - 15 < MovingStonePicture.Left && MovingStonePicture.Left < this.Left + 15 
                 && this.Top - 15 < MovingStonePicture.Top && MovingStonePicture.Top < this.Top + 15;
        }
        private bool isOverlay
        {
            get { return judgeOverlay(); }
        }
        #endregion
        private bool _isEnpty = false;
        public bool IsEmpty
        {
            get { return _isEnpty; }
            set { _isEnpty = value; }
        }
        public static StonePicture MovingStonePicture;

        /// <summary>
        /// 石を落とすイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDowned(object sender, MouseEventArgs e)
        {
            MouseMove += new MouseEventHandler(StoneMoved);
            //this.Image = Border(stone.Color);
            StonePicture.MovingStonePicture = this;
            this._isEnpty = true;
            BringToFront();
        }

        /// <summary>
        /// 石を持ち上げるイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseUped(object sender, MouseEventArgs e)
        { 
            MouseMove -= new MouseEventHandler(StoneMoved);
            this.CorrectStoneLocation();
            //this.Image = Picture(stone.Color);
            StonePicture.MovingStonePicture = null;
            this._isEnpty = false;
            SendToBack();
        }
        
        /// <summary>
        /// 石を動かすイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoneMoved(object sender, MouseEventArgs e)
        {
            Left = Cursor.Position.X - Size.Width / 2;
            Top = Cursor.Position.Y - Size.Height;
        }

        /// <summary>
        /// 石の場所を補正する
        /// </summary>
        private void CorrectStoneLocation()
        {
            int _x = Top / Size.Height;
            int _y = Left / Size.Width;
            _x = (Top >= _x * Size.Height + Size.Height / 2) ? _x + 1 : _x;
            _y = (Left >= _y * Size.Width + Size.Width / 2) ? _y + 1 : _y;
            this.MoveTo(_x, _y);
        }

        /// <summary>
        /// 指定の場所に移動
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        private void MoveTo(int _x, int _y)
        {
            this._x = _x;
            this._y = _y;
            stone.X = _x;
            stone.Y = _y;
            this.Location = new Point(_y * defaultSize, _x * defaultSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected async virtual void OnAsyncOverlayStone(EventArgs e)
        {
            await Task.Run(()=>
                {
                    TimerCallback timerDelegate = new TimerCallback(
                        (_) =>
                        {
                            EventHandler handler = AsyncOverlayStone;
                            if (handler != null && this.isOverlay)
                            {
                                handler(this, e);
                            }
                        });
                    System.Threading.Timer timer = new System.Threading.Timer(timerDelegate, null, 0, 600);
                });
        }

        /// <summary>
        /// 
        /// </summary>

        public void worker(Action callBack)
        {
            Invoke(new SetFocusDelegate( () => callBack() ));
        }

        public event EventHandler AsyncOverlayStone;
        public delegate void SetFocusDelegate();
    }
}
