using System;
using System.Drawing;
using CarTrafficSimulator.Kernel.Render;
using CarTrafficSimulator.Kernel.Utils;

namespace CarTrafficSimulator.Kernel.Game
{
    class Car : Drawable
    {
        public PolyMesh mesh;

        public Vector2f position = new Vector2f(200, 200);
        public Vector2f scale = new Vector2f(1, 1);
        public float rotate = 0;
        public Vector2f speed = new Vector2f(0f, 0f);
        public Vector2f acceleration = new Vector2f(0f, 0f);
        public Vector2f maxSpeed = new Vector2f(0f, 0f);

        public Point destination = MapPoints.top_turn_right;

        public bool collideCar = false; 
        public bool collideTrafficZone = false;

        public PointF[] collider = new PointF[4] { new PointF(-150, -30), new PointF(-150, 30), new PointF(150, 30), new PointF(150, -30) };

        public Car()
        {
            Render.Render.add(this);
            Physics.Physics.add(this);
        }

        public Car(PolyMesh m)
        {
            mesh = m;
            Render.Render.add(this);
            Physics.Physics.add(this);
        }

        public void draw(Graphics g, Vector2f parentPosition, Vector2f parentScale, float parentRotate)
        {
            if (Math.Abs(speed.x) < Math.Abs(maxSpeed.x) || Math.Abs(speed.y) < Math.Abs(maxSpeed.y))
                speed += acceleration;
            position += speed;

            Console.WriteLine(speed);
            /*PointF[] colliderBuffer = GameMath.rotate(collider, rotate+parentRotate);
            for (int i = 0; i < colliderBuffer.Length; i++)
            {
                colliderBuffer[i].X = colliderBuffer[i].X * scale.x * parentScale.x + position.x + parentPosition.x;
                colliderBuffer[i].Y = colliderBuffer[i].Y * scale.y * parentScale.y + position.y + parentPosition.y;
            }

            g.DrawLine(Pens.White, axisVector.x +100 , axisVector.y +100, 2*axisVector.x+100, 2*axisVector.y+100 );

            g.DrawPolygon(Pens.Violet, colliderBuffer);*/


            //rotate++;
            mesh.draw(g, position+parentPosition, scale* parentScale, rotate+parentRotate);
        }

        public void collide(byte col)
        {
            speed = -acceleration;
            
            /*if (obj == Physics.Physics.TRAFFIC_LIGHT_COLLIDE)
                speed -= acceleration;
            else if(speed.x!=0 || speed.y != 0)
            {
                speed -= acceleration ;
            }*/



        }
    }
}
