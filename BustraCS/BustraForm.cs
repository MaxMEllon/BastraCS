using BustraCS.Stone;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BustraCS
{
    public partial class BustraForm : Form
    {
        private Board board;

        public BustraForm()
        {
            board = new Board(this);
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            DesktopLocation = new Point(0, 0);
            InitializeComponent();
        }

        [SecurityPermission(SecurityAction.Demand,
            Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const long SC_MOVE = 0xF010L;

            if (m.Msg == WM_SYSCOMMAND &&
                (m.WParam.ToInt64() & 0xFFF0L) == SC_MOVE)
            {
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
        }
    }
}
