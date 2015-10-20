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
            return this.Left - 10 < MovingStonePicture.Left && MovingStonePicture.Left < this.Left + 10
                    && this.Top - 10 < MovingStonePicture.Top && MovingStonePicture.Top < this.Top + 10;
        }
        private bool isOverlay
        {
            get { return judgeOverlay(); }
        }
        #endregion
        #region public bool IsMoving { get; }
        private bool _isMoving = false;
        public bool IsMoving
        {
            get { return _isMoving; }
        }
        #endregion
        public static StonePicture MovingStonePicture;
        public static StonePicture EmptyStonePicture;

        /// <summary>
        /// 石を落とすイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDowned(object sender, MouseEventArgs e)
        {
            MouseMove += new MouseEventHandler(StoneMoved);
            this.Image = Border(stone.Color);
            StonePicture.MovingStonePicture = this;
            StonePicture.EmptyStonePicture = StonePicture.Clone(this);
            this._isMoving = true;
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
            this.Image = Picture(stone.Color);
            StonePicture.MovingStonePicture = null;
            StonePicture.EmptyStonePicture = null;
            this._isMoving = false;
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

        private void MoveTo(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
            stone.X = _x;
            stone.Y = _y;
            this.Location = new Point(y * defaultSize, x * defaultSize);
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
                                StonePicture temp = StonePicture.Clone(this);
                                this.x = EmptyStonePicture.x;
                                this.y = EmptyStonePicture.y;
                                // TODO: bugってる
                                try
                                {
                                    this.Location =  new Point(y * defaultSize, x * defaultSize);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.ToString());
                                }
                                EmptyStonePicture = temp;
                            }
                        });
                    System.Threading.Timer timer = new System.Threading.Timer(timerDelegate, null, 0, 1000);
                });
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler AsyncOverlayStone;
    }
}
