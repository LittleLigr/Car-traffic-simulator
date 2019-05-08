using System;
using System.Windows.Forms;
using CarTrafficSimulator.Kernel.Utils;
namespace CarTrafficSimulator.Kernel.Game
{
    class TrafficController
    {
        Timer timerTop = new Timer();
        Timer timerRight = new Timer();
        Timer timerBottom = new Timer();
        Timer timerLeft = new Timer();
        Timer timerCarPosition = new Timer();
        Timer trafficLightTimer = new Timer();
        Car lastTop, lastRight, lastBottom, lastLeft;

        TrafficLight topLight, rightLight, bottomLight, leftLight;
        bool t = false, r = false, l = false, b = false;

        public static bool horizont = true;

        CarFabric fabric;
        Car c;
        Random random = new Random();

        public TrafficController()
        {
            fabric = new CarFabric();
            trafficLightTimer.Tick += trafficTimer;
            timerTop.Tick += timerTopTick;
            timerRight.Tick += timerRightTick;
            timerBottom.Tick += timerBottomTick;
            timerLeft.Tick += timerLeftTick;
            timerCarPosition.Tick += timerCarPositionTick;
            timerCarPosition.Interval = 1;

            topLight = new TrafficLight();
            topLight.position = new Vector2f(460, 320);
            topLight.rotate = -90;

            rightLight = new TrafficLight();
            rightLight.position = new Vector2f(470, 450);

            bottomLight = new TrafficLight();
            bottomLight.position = new Vector2f(335, 460);
            bottomLight.rotate = 90;

            leftLight = new TrafficLight();
            leftLight.position = new Vector2f(330, 330);
            leftLight.rotate = 180;


            trafficLightTimer.Interval = 6000;
            timerTop.Interval = 1;
            timerRight.Interval = 1;
            timerBottom.Interval = 1;
            timerLeft.Interval = 1;

            lastTop = fabric.createRandomColor();
            lastTop.position = new Vector2f(425, 0);
            lastTop.scale = new Vector2f(0.2f, 0.2f);
            lastTop.rotate = 90;
            lastTop.speed.y = 1;
            lastTop.maxSpeed = new Vector2f(0, 2);
            lastTop.acceleration = new Vector2f(0, 0.1f);

            lastRight = fabric.createRandomColor();
            lastRight.position = new Vector2f(800, 410);
            lastRight.scale = new Vector2f(0.2f, 0.2f);
            lastRight.rotate = 180;
            lastRight.speed.x = -1;
            lastRight.maxSpeed = new Vector2f(-2, 0);
            lastRight.acceleration = new Vector2f(-0.1f, 0);

            lastBottom = fabric.createRandomColor();
            lastBottom.position = new Vector2f(375, 800);
            lastBottom.scale = new Vector2f(0.2f, 0.2f);
            lastBottom.speed.y = -1;
            lastBottom.rotate = -90;
            lastBottom.maxSpeed = new Vector2f(0, -2);
            lastBottom.acceleration = new Vector2f(0, -0.1f);

            lastLeft = fabric.createRandomColor();
            lastLeft.position = new Vector2f(0, 370);
            lastLeft.scale = new Vector2f(0.2f, 0.2f);
            lastLeft.speed.x = 1;
            lastLeft.maxSpeed = new Vector2f(2,0);
            lastLeft.acceleration = new Vector2f(0.1f, 0);

            trafficLightTimer.Start();
            timerTop.Start();
            timerRight.Start();
            timerBottom.Start();
            timerLeft.Start();
            timerCarPosition.Start();
        }

        public void trafficTimer(object sendler, EventArgs e)
        {
            if(horizont && Physics.Physics.horizont)
            {
                Physics.Physics.horizont = false;
                Physics.Physics.vertical = false;
                trafficLightTimer.Interval = 2000;
                rightLight.mode = TrafficLight.YELLOW_MODE;
                leftLight.mode = TrafficLight.YELLOW_MODE;
                topLight.mode = TrafficLight.YELLOW_MODE;
                bottomLight.mode = TrafficLight.YELLOW_MODE;
            }
            else if(!horizont && Physics.Physics.vertical)
            {
                Physics.Physics.horizont = false;
                Physics.Physics.vertical = false;
                trafficLightTimer.Interval = 2000;
                rightLight.mode = TrafficLight.YELLOW_MODE;
                leftLight.mode = TrafficLight.YELLOW_MODE;
                topLight.mode = TrafficLight.YELLOW_MODE;
                bottomLight.mode = TrafficLight.YELLOW_MODE;
            }
            else if (horizont && !Physics.Physics.horizont)
            {
                Physics.Physics.horizont = false;
                Physics.Physics.vertical = true;
                horizont = false;
                trafficLightTimer.Interval = 6000;

                rightLight.mode = TrafficLight.RED_MODE;
                leftLight.mode = TrafficLight.RED_MODE;
                topLight.mode = TrafficLight.GREEN_MODE;
                bottomLight.mode = TrafficLight.GREEN_MODE;
            }
            else if(!horizont && !Physics.Physics.vertical)
            {
                Physics.Physics.horizont = true;
                Physics.Physics.vertical = false;
                horizont = true;
                trafficLightTimer.Interval = 6000;

                rightLight.mode = TrafficLight.GREEN_MODE;
                leftLight.mode = TrafficLight.GREEN_MODE;
                topLight.mode = TrafficLight.RED_MODE;
                bottomLight.mode = TrafficLight.RED_MODE;
            }
        }

        public void timerCarPositionTick(object sendler, EventArgs e)
        {
            
            /*for(int i = 0; i < fabric.car_list.Count; i++)
            {
                Car c = fabric.car_list[i];
                if (c.position.x < 0 || c.position.x > 800 || c.position.y < 0 || c.position.y > 800)
                    fabric.car_list.Remove(c);
            }*/
            if (!t && lastTop.position.y > 50)
                t = true;
            if (!r && lastRight.position.x < 750)
                r = true;
            if (!b && lastBottom.position.y < 750)
                b = true;
            if (!l && lastLeft.position.x > 50) 
                l = true;


        }

        public void timerTopTick(object sendler, EventArgs e)
        {
            if(t)
            {
                lastTop = fabric.createRandomColor();
                lastTop.position = new Vector2f(425, 0);
                lastTop.scale = new Vector2f(0.2f, 0.2f);
                lastTop.rotate = 90;
                lastTop.speed.y = 1;
                lastTop.maxSpeed = new Vector2f(0, 2);
                lastTop.acceleration = new Vector2f(0, 0.1f);
                t = false;
            }
           
            
        }

        public void timerRightTick(object sendler, EventArgs e)
        {
            if(r)
            {
                lastRight = fabric.createRandomColor();
                lastRight.position = new Vector2f(800, 410);
                lastRight.scale = new Vector2f(0.2f, 0.2f);
                lastRight.rotate = 180;
                lastRight.speed.x = -1;
                lastRight.maxSpeed = new Vector2f(-2, 0);
                lastRight.acceleration = new Vector2f(-0.1f, 0);
                r = false;
            }
     
        }

        public void timerBottomTick(object sendler, EventArgs e)
        {
            if(b)
            {
                lastBottom = fabric.createRandomColor();
                lastBottom.position = new Vector2f(375, 800);
                lastBottom.scale = new Vector2f(0.2f, 0.2f);
                lastBottom.speed.y = -1;
                lastBottom.rotate = -90;
                lastBottom.maxSpeed = new Vector2f(0, -2);
                lastBottom.acceleration = new Vector2f(0, -0.1f);
                b = false;
            }
          
        }

        public void timerLeftTick(object sendler, EventArgs e)
        {
            if(l)
            {
                lastLeft = fabric.createRandomColor();
                lastLeft.position = new Vector2f(0, 370);
                lastLeft.scale = new Vector2f(0.2f, 0.2f);
                lastLeft.speed.x = 1;
                lastLeft.maxSpeed = new Vector2f(2, 0);
                lastLeft.acceleration = new Vector2f(0.1f, 0);
                l = false;
            }
           
        }

    }
}
