using System;
using System.Runtime.InteropServices;

namespace Raven.Engine.DataStruct
{
    /// <summary>
    /// 三维向量类
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector
    {
        public static readonly Vector Zero = new Vector(0, 0, 0);
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// 向量长度
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        /// <summary>
        /// 长度的平方
        /// </summary>
        /// <returns></returns>
        public double LengthSquared()
        {
            return (X * X + Y * Y + Z * Z);
        }
        
        /// <summary>
        /// 向量相加
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Vector Add(Vector r)
        {
            return new Vector(X + r.X, Y + r.Y, Z + r.Z);
        }

        /// <summary>
        /// 向量相减
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Vector Subtract(Vector r)
        {
            return new Vector(X - r.X, Y - r.Y, Z - r.Z);
        }

        /// <summary>
        /// 向量相等
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool Equals(Vector v)
        {
            return (X == v.X) && (Y == v.Y) && (Z == v.Z);
        }

        /// <summary>
        /// 取得向量hash值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)X ^ (int)Y ^ (int)Z;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            // If they're the same object or both null, return.
            if (System.Object.ReferenceEquals(v1, v2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (v1 == null || v2 == null)
            {
                return false;
            }

            return v1.Equals(v2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                return Equals((Vector)obj);
            }
            return base.Equals(obj);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !v1.Equals(v2);
        }

        /// <summary>
        /// 向量放缩
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Vector Multiply(double v)
        {
            return new Vector(X * v, Y * v, Z * v);
        }

        public static Vector operator *(Vector v, double s)
        {
            return v.Multiply(s);
        }

        /// <summary>
        /// 叉乘
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Vector CrossProduct(Vector v)
        {
            double nx = Y * v.Z - Z * v.Y;
            double ny = Z * v.X - X * v.Z;
            double nz = X * v.Y - Y * v.X;
            return new Vector(nx, ny, nz);
        }

        /// <summary>
        /// 点乘
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double DotProduct(Vector v)
        {
            return (v.X * X) + (Y * v.Y) + (Z * v.Z);
        }

        public static double operator *(Vector v1, Vector v2)
        {
            return v1.DotProduct(v2);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return v1.Add(v2);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1.Subtract(v2);
        }

        /// <summary>
        /// 取得方向向量
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Vector Normalise(Vector v)
        {
            double r = v.Length();
            if (r != 0.0)				// guard against divide by zero
            {
                return new Vector(v.X / r, v.Y / r, v.Z / r);	// normalise and return
            }
            else
            {
                return new Vector(0, 0, 0);
            }
        }

        /// <summary>
        /// 取得向量的字符串表示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", X, Y, Z);
        }

    }

}
