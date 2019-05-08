using CarTrafficSimulator.Kernel.Render;
using System.Windows.Forms;
using System.Drawing;
using CarTrafficSimulator.Kernel.Game;
using CarTrafficSimulator.Kernel.Physics;
using System;
namespace CarTrafficSimulator
{
    public partial class Form1 : Form
    {
        Render render;
        Physics physics;
        TrafficController controller;


        public Form1()
        {
            InitializeComponent();
            render = new Render(this);
            physics = new Physics();
            controller = new TrafficController();
            MouseWheel += MouseScroll;

         


            render.clearColor = Color.Green;
            render.start();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            render.dispose();
            physics.dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //addCar(Brushes.Black);
            if(Physics.horizont == false)
            {
                Physics.horizont = true;
                Physics.vertical = false;
            }
            else
            {
                Physics.horizont = false;
                Physics.vertical = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void MouseScroll(object sender, MouseEventArgs e)
        {
            /*if(e.Delta>0)
            Render.cameraScale *= new Kernel.Utils.Vector2f(1.1f, 1.1f);
            else
                Render.cameraScale /= new Kernel.Utils.Vector2f(1.1f, 1.1f);*/
        }
    }

    abstract class MapPoints
    {
        public static Point top_turn_right = new Point(425, 200);
        public static Point top_turn_left = new Point(360, 200);

    }
}
