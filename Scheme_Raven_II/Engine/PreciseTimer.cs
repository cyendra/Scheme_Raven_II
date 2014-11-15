using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Engine
{
    /// <summary>
    /// 获取每一帧之间的时间的类
    /// </summary>
    public class PreciseTimer
    {
        // 返回硬件支持的高精度计数器的频率
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceFrequency(ref long PerformanceFrequency);

        // 得到高精度计时器的值
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceCounter(ref long PerformanceCount);

        private long _ticksPerSecond = 0;           // 时钟频率
        private long _previousElapsedTime = 0;      // 上次调用的时间

        public PreciseTimer()
        {
            QueryPerformanceFrequency(ref _ticksPerSecond);
            GetElapsedTime(); // Get rid of first rubbish result
        }

        /// <summary>
        /// 返回两次调用经过的时间
        /// </summary>
        /// <returns>经过的时间</returns>
        public double GetElapsedTime()
        {
            long time = 0;
            QueryPerformanceCounter(ref time);

            double elapsedTime = (double)(time - _previousElapsedTime) / (double)_ticksPerSecond;
            _previousElapsedTime = time;

            return elapsedTime;
        }
    }
}
