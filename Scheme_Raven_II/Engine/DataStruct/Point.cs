using System.Runtime.InteropServices;
namespace Raven.Engine.DataStruct
{
    /// <summary>
    /// 描述(U,V)坐标
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y) : this()
        {
            X = x;
            Y = y;
        }
    }

}
