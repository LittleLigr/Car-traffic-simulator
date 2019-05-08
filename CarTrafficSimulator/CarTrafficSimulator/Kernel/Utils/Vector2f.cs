using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrafficSimulator.Kernel.Utils
{
    class Vector2f
    {
        public float x, y;
        public Vector2f(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2f()
        {

        }

        public override string ToString()
        {
            return "x: " + x + " y: " + y;
        }

        public static Vector2f operator /(Vector2f v1, Vector2f v2)
        {
            return new Vector2f(v1.x / v2.x, v1.y / v2.y);
        }

        public static Vector2f operator *(Vector2f v1, Vector2f v2)
        {
            return new Vector2f(v1.x * v2.x, v1.y * v2.y);
        }

        public static Vector2f operator *(Vector2f v1, float v2)
        {
            return new Vector2f(v1.x * v2, v1.y * v2);
        }


        public static Vector2f operator +(Vector2f v1, Vector2f v2)
        {
            return new Vector2f(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2f operator -(Vector2f v1)
        {
            return new Vector2f(-v1.x, -v1.y);
        }

        public static Vector2f operator -(Vector2f v1, Vector2f v2)
        {
            return new Vector2f(v1.x - v2.x, v1.y - v2.y);
        }

        public static bool operator !=(Vector2f v1, Vector2f v2)
        {
            return v1.x != v2.x && v1.y != v2.y;
        }

        public static bool operator ==(Vector2f v1, Vector2f v2)
        {
            return v1.x == v2.x && v1.y == v2.y;
        }
    }
}
