using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Scheme_Raven_II.Game
{
    class GameLoop
    {
        public delegate void LoopCallback();
        LoopCallback _callback;
        
        public GameLoop(LoopCallback callback)
        {
            _callback = callback;
            Application.Idle += new EventHandler(OnApplicationEnterIdle);
        }

        public void OnApplicationEnterIdle(object sender, EventArgs e)
        {
            while (IsAppStillIdle())
            {
                _callback();
            }
        }

        private bool IsAppStillIdle()
        {
            Message msg;
            return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Message
        {
            public IntPtr hWnd;
            public Int32 msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(
            out Message msg,
            IntPtr hWnd,
            uint messageFilterMin,
            uint messageFilterMax,
            uint flags);

    }
}
