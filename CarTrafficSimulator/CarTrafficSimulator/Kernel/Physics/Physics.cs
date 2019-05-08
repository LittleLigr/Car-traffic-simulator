using CarTrafficSimulator.Kernel.Game;
using System.Collections.Generic;
using System;
using CarTrafficSimulator.Kernel.Utils;
using System.Drawing;
using System.Threading;

namespace CarTrafficSimulator.Kernel.Physics
{
    class Physics
    {
        public const byte CAR_COLLIDE = 0;
        public const byte TRAFFIC_LIGHT_COLLIDE = 0;
        public static bool horizont = true;
        public static bool vertical = false;

        static List<Car> list = new List<Car>();

        PointF[] trafficLightZone = new PointF[4] { new PointF(340, 340), new PointF(340, 445), new PointF(445, 445), new PointF(445, 340) };

        Thread thread;
        public bool enable = true;
        public Physics()
        {
            thread = new Thread(new ThreadStart(tick));
            thread.Start();
        }

        public static void add(Car c)
        {
            list.Add(c);
        }

        public void dispose()
        {
            enable = false;
        }


        public void tick()
        {
            while(enable)
            {
                bool intersect_x_r = false, intersect_x_l = false, intersect_y_t = false, intersect_y_b = false;
               
                for (int i = 0; i < list.Count - 1; i++)
                {
                    Car car1 = list[i];
            
                    PointF[] colliderBuffer = GameMath.copyPointArray(car1.collider);
                    for (int x = 0; x < colliderBuffer.Length; x++)
                    {
                        colliderBuffer[x].X = colliderBuffer[x].X * car1.scale.x;
                        colliderBuffer[x].Y = colliderBuffer[x].Y * car1.scale.y;
                    }

                    for (int j = i + 1; j < list.Count; j++)
                    {
                        Car car2 = list[j];
                        PointF[] colliderBuffer2 = GameMath.rotate(car2.collider, car2.rotate - car1.rotate);
                        Vector2f r = GameMath.rotate(car2.position - car1.position, -car1.rotate);
                        for (int x = 0; x < colliderBuffer2.Length; x++)
                        {
                            colliderBuffer2[x].X = (colliderBuffer2[x].X) * car2.scale.x + r.x;
                            colliderBuffer2[x].Y = (colliderBuffer2[x].Y) * car2.scale.y + r.y;
                        }

                        intersect_x_r = false; intersect_x_l = false; intersect_y_t = false; intersect_y_b = false;

                        for (int c1 = 0; c1 < colliderBuffer.Length; c1++)
                            for (int c2 = 0; c2 < colliderBuffer2.Length; c2++)
                            {
                                if (colliderBuffer[c1].X >= colliderBuffer2[c2].X)
                                    intersect_x_l = true;
                                else if (colliderBuffer[c1].X <= colliderBuffer2[c2].X)
                                    intersect_x_r = true;

                                if (colliderBuffer[c1].Y >= colliderBuffer2[c2].Y)
                                    intersect_y_b = true;
                                else if (colliderBuffer[c1].Y <= colliderBuffer2[c2].Y)
                                    intersect_y_t = true;

                                if (intersect_x_r && intersect_x_l && intersect_y_b && intersect_y_t)
                                {
                                    c1 = colliderBuffer.Length;
                                    break;
                                }
                            }

                        if (intersect_x_r && intersect_x_l && intersect_y_b && intersect_y_t)
                        {
 
                            if (car1.acceleration.x > 0)
                            {
                                if (car1.position.x > car2.position.x)
                                    car2.collide(CAR_COLLIDE);
                                else car1.collide(CAR_COLLIDE);
                            }
                            else if (car1.acceleration.x < 0)
                            {
                                if (car1.position.x < car2.position.x)
                                    car2.collide(CAR_COLLIDE);
                                else car1.collide(CAR_COLLIDE);
                            }
                            else if (car1.acceleration.y > 0)
                            {
                                if (car1.position.y > car2.position.y)
                                    car2.collide(CAR_COLLIDE);
                                else car1.collide(CAR_COLLIDE);
                                //
                            }
                            else if (car1.acceleration.y < 0)
                            {
                                if (car1.position.y < car2.position.y)
                                    car2.collide(CAR_COLLIDE);
                                else car1.collide(CAR_COLLIDE);
                            }
                        }
                       

                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    Car car = list[i];
                    PointF[] colliderBuffer = GameMath.rotate(car.collider, car.rotate);
                    for (int x = 0; x < colliderBuffer.Length; x++)
                    {
                        colliderBuffer[x].X = colliderBuffer[x].X * car.scale.x + car.position.x;
                        colliderBuffer[x].Y = colliderBuffer[x].Y * car.scale.y + car.position.y;
                    }

                    intersect_x_r = false; intersect_x_l = false; intersect_y_t = false; intersect_y_b = false;

                    for (int c1 = 0; c1 < colliderBuffer.Length; c1++)
                        for (int c2 = 0; c2 < trafficLightZone.Length; c2++)
                        {
                            if (colliderBuffer[c1].X >= trafficLightZone[c2].X)
                                intersect_x_l = true;
                            else if (colliderBuffer[c1].X <= trafficLightZone[c2].X)
                                intersect_x_r = true;

                            if (colliderBuffer[c1].Y >= trafficLightZone[c2].Y)
                                intersect_y_b = true;
                            else if (colliderBuffer[c1].Y <= trafficLightZone[c2].Y)
                                intersect_y_t = true;

                            if (intersect_x_r && intersect_x_l && intersect_y_b && intersect_y_t)
                            {
                                c1 = colliderBuffer.Length;
                                break;
                            }
                        }

                    if (intersect_x_r && intersect_x_l && intersect_y_b && intersect_y_t)
                    {
                        if (car.maxSpeed.x != 0 && horizont == false && !car.collideTrafficZone)
                            car.collide(TRAFFIC_LIGHT_COLLIDE);
                        else if (car.maxSpeed.y != 0 && vertical == false && !car.collideTrafficZone)
                            car.collide(TRAFFIC_LIGHT_COLLIDE);
                        else
                        {
                            car.collideTrafficZone = true;
                        }

                    }
                    else if (car.collideTrafficZone)
                        car.collideTrafficZone = false;
                }


            }
        }
    }
}
