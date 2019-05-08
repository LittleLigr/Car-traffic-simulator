using CarTrafficSimulator.Kernel.Render;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace CarTrafficSimulator.Kernel.Game
{
    class CarFabric
    {
        PointF[] light_left = new PointF[4] { new PointF(41, -28), new PointF(58, -28), new PointF(58, -18), new PointF(41, -18) };
        PointF[] light_right = new PointF[4] { new PointF(41, 28), new PointF(58, 28), new PointF(58, 18), new PointF(41, 18) };
        PointF[] window_forward = new PointF[4] { new PointF(3, -22), new PointF(28, -26), new PointF(28, 26), new PointF(3, 22) };
        PointF[] window_back = new PointF[4] { new PointF(-30, -22), new PointF(-45, -26), new PointF(-45, 26), new PointF(-30, 22) };
        PointF[] body = new PointF[4] { new PointF(-60, -30), new PointF(60, -30), new PointF(60, 30), new PointF(-60, 30) };

        public static PolyMesh RED_CAR;
        public static PolyMesh BLUE_CAR;
        public static PolyMesh BROWN_CAR;
        public static PolyMesh BLACK_CAR;
        public static PolyMesh VIOLET_CAR;

        Random random = new Random();

        public List<Car> car_list = new List<Car>();

        public CarFabric()
        {
            RED_CAR = new PolyMesh();
            RED_CAR.add(new Detail(body, Brushes.Red));
            RED_CAR.add(new Detail(light_left, Brushes.Yellow));
            RED_CAR.add(new Detail(light_right, Brushes.Yellow));
            RED_CAR.add(new Detail(window_forward, Brushes.LightBlue));
            RED_CAR.add(new Detail(window_back, Brushes.LightBlue));

            BLUE_CAR = new PolyMesh();
            BLUE_CAR.add(new Detail(body, Brushes.Blue));
            BLUE_CAR.add(new Detail(light_left, Brushes.Yellow));
            BLUE_CAR.add(new Detail(light_right, Brushes.Yellow));
            BLUE_CAR.add(new Detail(window_forward, Brushes.LightBlue));
            BLUE_CAR.add(new Detail(window_back, Brushes.LightBlue));

            BROWN_CAR = new PolyMesh();
            BROWN_CAR.add(new Detail(body, Brushes.Brown));
            BROWN_CAR.add(new Detail(light_left, Brushes.Yellow));
            BROWN_CAR.add(new Detail(light_right, Brushes.Yellow));
            BROWN_CAR.add(new Detail(window_forward, Brushes.LightBlue));
            BROWN_CAR.add(new Detail(window_back, Brushes.LightBlue));

            BLACK_CAR = new PolyMesh();
            BLACK_CAR.add(new Detail(body, Brushes.Black));
            BLACK_CAR.add(new Detail(light_left, Brushes.Yellow));
            BLACK_CAR.add(new Detail(light_right, Brushes.Yellow));
            BLACK_CAR.add(new Detail(window_forward, Brushes.LightBlue));
            BLACK_CAR.add(new Detail(window_back, Brushes.LightBlue));

            VIOLET_CAR = new PolyMesh();
            VIOLET_CAR.add(new Detail(body, Brushes.Violet));
            VIOLET_CAR.add(new Detail(light_left, Brushes.Yellow));
            VIOLET_CAR.add(new Detail(light_right, Brushes.Yellow));
            VIOLET_CAR.add(new Detail(window_forward, Brushes.LightBlue));
            VIOLET_CAR.add(new Detail(window_back, Brushes.LightBlue));
        }

        public Car create(PolyMesh carMesh)
        {
            Car c = new Car();
            c.mesh = carMesh;
            car_list.Add(c);
            return c;
        }

        public Car createRandomColor()
        {
            int color = random.Next(0, 6);
            if (color == 1)
                return create(RED_CAR);
            else if (color == 2)
                return create(BLUE_CAR);
            else if (color == 3)
                return create(BROWN_CAR);
            else if (color == 4)
                return create(BLACK_CAR);
            else
                return create(VIOLET_CAR);
        }
    }
}
