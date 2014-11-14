using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace Scheme_Raven_II.Game
{
    
    /// <summary>
    /// 获取每一帧之间的时间的类
    /// </summary>
    class PreciseTimer
    {
        /// <summary>
        /// 返回硬件支持的高精度计数器的频率
        /// </summary>
        /// <param name="PerformanceFrequency">频率</param>
        /// <returns>读取成功或失败</returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceFrequency(ref long PerformanceFrequency);

        /// <summary>
        /// 得到高精度计时器的值
        /// </summary>
        /// <param name="PerformanceCount">计时器的值</param>
        /// <returns>读取成功或失败</returns>
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32")]
        private static extern bool QueryPerformanceCounter(ref long PerformanceCount);

        private long _ticksPerSecond = 0;           // 时钟频率
        private long _previousElapsedTime = 0;      // 上次调用的时间

        public PreciseTimer()
        {
            QueryPerformanceFrequency(ref _ticksPerSecond);
            GetElapsedTime();
        }

        // 返回两次调用的时间差
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
