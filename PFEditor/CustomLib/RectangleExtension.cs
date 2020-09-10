using Microsoft.Xna.Framework;

namespace CustomLib
{
    public static class RectangleExtension
    {
        public static void Draw(this Rectangle rectangle, ShapesDrawingManager sh, Color color)
        {
            sh.DrawRectangle(rectangle, color);
        }
    }
}