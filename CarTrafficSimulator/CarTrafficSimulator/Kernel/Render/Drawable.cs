using System.Drawing;
using CarTrafficSimulator.Kernel.Utils;
namespace CarTrafficSimulator.Kernel.Render
{
    interface Drawable
    {
        void draw(Graphics g, Vector2f parentPosition, Vector2f parentScale, float parentRotate);
    }
}
