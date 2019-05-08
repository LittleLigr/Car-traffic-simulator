using System;
using System.Drawing;
using CarTrafficSimulator.Kernel.Render;
using CarTrafficSimulator.Kernel.Utils;


namespace CarTrafficSimulator.Kernel.Game
{
    class TrafficLight : Drawable
    {
        public static PointF[] trafficLightBody = new PointF[4] { new PointF(-17, -10), new PointF(17, -10), new PointF(17, 10), new PointF(-17, 10) };

        public const byte RED_MODE = 0;
        public const byte YELLOW_MODE = 1;
        public const byte GREEN_MODE = 2;

        public Vector2f position = new Vector2f();
        public Vector2f scale = new Vector2f(1, 1);
        public float rotate = 0;

        Vector2f redLightPosition = new Vector2f(-10, 0);
        Vector2f yellowLightPosition = new Vector2f(0, 0);
        Vector2f greenLightPosition = new Vector2f(10, 0);

        public byte mode = 0;

        public TrafficLight()
        {
            Render.Render.add(this);
        }

        public void draw(Graphics g, Vector2f parentPosition, Vector2f parentScale, float parentRotate)
        {
            float sin = (float)Math.Cos(rotate * Math.PI / 180f);
            float cos = (float)Math.Cos(rotate*Math.PI/180f);
            PointF[] buffer = GameMath.rotate(trafficLightBody, rotate);
            Vector2f redBuffer = GameMath.rotate(redLightPosition, rotate);
            Vector2f yellowBuffer = GameMath.rotate(yellowLightPosition, rotate);
            Vector2f greenBuffer = GameMath.rotate(greenLightPosition, rotate);

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i].X = buffer[i].X + position.x;
                buffer[i].Y = buffer[i].Y + position.y;
            }

            g.FillPolygon(Brushes.Black, buffer);

            if (mode == RED_MODE)
            {
                g.FillEllipse(Brushes.Red, position.x + redBuffer.x-4 , position.y+ redBuffer.y-4, 8, 8);
            }
            else
            {
                g.FillEllipse(Brushes.DarkRed, position.x+ redBuffer.x-4, position.y+ redBuffer.y-4, 8, 8);
            }

            if (mode == YELLOW_MODE)
            {
                g.FillEllipse(Brushes.Yellow, position.x+yellowBuffer.x-4, position.y + yellowBuffer.y-4, 8, 8);
            }
            else
            {
                g.FillEllipse(Brushes.DarkOrange, position.x + yellowBuffer.x-4, position.y + yellowBuffer.y-4, 8, 8);
            }

            if (mode == GREEN_MODE)
            {
                g.FillEllipse(Brushes.LightGreen, position.x + greenBuffer.x - 4, position.y+greenBuffer.y - 4, 8, 8);
            }
            else
            {
                g.FillEllipse(Brushes.DarkGreen, position.x + greenBuffer.x - 4, position.y+greenBuffer.y - 4, 8, 8);
            }



          
        }
    }
}
