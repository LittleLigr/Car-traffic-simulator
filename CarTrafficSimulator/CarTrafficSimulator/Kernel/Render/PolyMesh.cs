using System;
using System.Collections.Generic;
using System.Drawing;
using CarTrafficSimulator.Kernel.Utils;

namespace CarTrafficSimulator.Kernel.Render
{
    class PolyMesh:Drawable
    {
        List<Detail> details = new List<Detail>();

        public void add(Detail d)
        {
            details.Add(d);
        }

        public void draw(Graphics g, Vector2f parentPosition, Vector2f parentScale, float parentRotate)
        {
            for (int i = 0; i < details.Count; i++)
                details[i].draw(g, parentPosition, parentScale, parentRotate);
        }
    }
    class Detail : Drawable
    {
        Brush color;
        PointF[] vertexes;

        public Detail(PointF [] v, Brush c)
        {
            vertexes = v;
            color = c;
        }

        public void draw(Graphics g, Vector2f parentPosition, Vector2f parentScale, float parentRotate)
        {
            PointF[] buffer = GameMath.rotate(vertexes, parentRotate);
        
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i].X = buffer[i].X * parentScale.x + parentPosition.x;
                buffer[i].Y = buffer[i].Y * parentScale.y + parentPosition.y;
            }
            g.FillPolygon(color, buffer);
           // g.FillRectangle(color, 0, 0, 100, 100);
        }
    }
}
