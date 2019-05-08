using System.Drawing;
using System;

namespace CarTrafficSimulator.Kernel.Utils
{
    abstract class GameMath
    {
        public static PointF[] rotate(PointF[] vertexes, float angle)
        {
            float cos = (float)Math.Cos(angle * Math.PI / 180f);
            float sin = (float)Math.Sin(angle * Math.PI / 180f);
          

            PointF[] result = new PointF[vertexes.Length];

            for(int i = 0; i < vertexes.Length; i++)
                result[i] = new PointF(vertexes[i].X * cos - sin*vertexes[i].Y, vertexes[i].X*sin + vertexes[i].Y*cos);

            return result;
        }

        public static Vector2f rotate(Vector2f vertex, float angle)
        {
            Vector2f res = new Vector2f();
            float cos = (float)Math.Cos(angle * Math.PI / 180f);
            float sin = (float)Math.Sin(angle * Math.PI / 180f);

            res.x = vertex.x * cos - sin * vertex.y;
            res.y = vertex.x * sin + vertex.y * cos;

            return res;
        }

        public static void rotateThis(Vector2f vertex, float angle)
        {
            float x = vertex.x;
            float cos = (float)Math.Cos(angle * Math.PI / 180f);
            float sin = (float)Math.Sin(angle * Math.PI / 180f);

            vertex.x = vertex.x * cos - sin * vertex.y;
            vertex.y = x * sin + vertex.y * cos;
        }

        public static PointF[] copyPointArray(PointF [] a)
        {
            PointF[] res = new PointF[a.Length];
            for (int i = 0; i < a.Length; i++)
                res[i] = new PointF(a[i].X, a[i].Y);

            return res;
        }

        public static void rotate(PointF vertex, float angle)
        {
            float x = vertex.X;
            float cos = (float)Math.Cos(angle * Math.PI / 180f);
            float sin = (float)Math.Sin(angle * Math.PI / 180f);

            vertex.X = vertex.X * cos - sin * vertex.Y;
            vertex.Y = x * sin + vertex.Y * cos;
        }
    }
}
