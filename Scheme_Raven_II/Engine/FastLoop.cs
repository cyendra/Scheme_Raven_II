using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Raven.Engine
{
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

    /// <summary>
    /// 游戏循环的类
    /// </summary>
    public class GameLoop
    {
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(
            out Message msg,
            IntPtr hWnd,
            uint messageFilterMin,
            uint messageFilterMax,
            uint flags);

        private PreciseTimer _timer = new PreciseTimer();
        public delegate void LoopCallback(double elapsedTime);
        private LoopCallback _callback;

        public GameLoop(LoopCallback callback)
        {
            _callback = callback;
            Application.Idle += new EventHandler(OnApplicationEnterIdle);
        }

        private void OnApplicationEnterIdle(object sender, EventArgs e)
        {
            while (IsAppStillIdle())
            {
                _callback(_timer.GetElapsedTime());
            }
        }

        private bool IsAppStillIdle()
        {
            Message msg;
            return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
        }

    }

}
