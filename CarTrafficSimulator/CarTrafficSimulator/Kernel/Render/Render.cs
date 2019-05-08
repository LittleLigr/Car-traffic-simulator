using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using CarTrafficSimulator.Kernel.Utils;
using CarTrafficSimulator.Kernel.Render;

namespace CarTrafficSimulator.Kernel.Render
{
    class Render
    {
        private Thread renderThread;
        public static List<Drawable> objects;

        private static bool pause = false;
        private static bool enable = true;

        private Form onDrawingForm;
        private Graphics canvas;
        private Bitmap[] buffer;
        private Graphics[] bufferGraphics;
        private byte currentBuffer = 0;

        public Color clearColor = Color.Black;
        public bool resizeRender = true;

        public static Vector2f cameraPosition = new Vector2f(0, 0);
        public static Vector2f cameraScale = new Vector2f(1, 1);
        public static float cameraRotate = 0;


        public Render(Form onDrawForm)
        {
            onDrawingForm = onDrawForm;

            objects = new List<Drawable>();
            buffer = new Bitmap[2] { new Bitmap(onDrawForm.Width, onDrawingForm.Height), new Bitmap(onDrawForm.Width, onDrawingForm.Height) };
            bufferGraphics = new Graphics[2] { Graphics.FromImage(buffer[0]), Graphics.FromImage(buffer[1]) };
            canvas = onDrawForm.CreateGraphics();

            renderThread = new Thread(new ThreadStart(draw));
        }

        private void draw()
        {
            while(enable)
            {
                if (resizeRender)
                    renderSizeControl();

                if (!pause)
                {

                    canvas.DrawImage(buffer[currentBuffer], 0, 0);

                    if (currentBuffer == 0) currentBuffer++;
                    else currentBuffer--;

                    bufferGraphics[currentBuffer].Clear(clearColor);
                    preRender(bufferGraphics[currentBuffer]);
                    for (int i = 0; i < objects.Count; i++)
                        objects[i].draw(bufferGraphics[currentBuffer], cameraPosition, cameraScale, cameraRotate);
                }   
            }
        }

       

        void preRender(Graphics g)
        {
           
            g.FillRectangle(Brushes.Gray, 360, 0, 80, 800);

            g.FillRectangle(Brushes.Gray, 0, 350, 800, 80);

            for (int i = 0; i < 9; i += 1)
                g.FillRectangle(Brushes.White, 397, 800 / 20 * i, 6, 20);
            for (int i = 11; i < 20; i += 1)
                g.FillRectangle(Brushes.White, 397, 800 / 20 * i, 6, 20);

            for (int i = 0; i < 9; i += 1)
                g.FillRectangle(Brushes.White, 800 / 20 * i, 387, 20, 6);
            for (int i = 11; i < 20; i += 1)
                g.FillRectangle(Brushes.White, 800 / 20 * i + 10, 387, 20, 6);
        }

        private void renderSizeControl()
        {
            if (onDrawingForm.Width != buffer[0].Width || onDrawingForm.Height != buffer[0].Height)
            {
                buffer = new Bitmap[2] { new Bitmap(onDrawingForm.Width, onDrawingForm.Height), new Bitmap(onDrawingForm.Width, onDrawingForm.Height) };
                bufferGraphics = new Graphics[2] { Graphics.FromImage(buffer[0]), Graphics.FromImage(buffer[1]) };
            }
        }

        public static void add(Drawable g)
        {
            objects.Add(g);
        }

        public void start()
        {
            if (!renderThread.IsAlive)
                renderThread.Start();
            else pause = false;
        }

        public void dispose()
        {
            enable = false;
        }

        public void stop()
        {
            pause = true;
        }
    }
}
