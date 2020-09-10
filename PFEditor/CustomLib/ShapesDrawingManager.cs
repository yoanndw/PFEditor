using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CustomLib
{
    public class ShapesDrawingManager
    {
        //FIELDS
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;

        private Texture2D pixel;

        //PROPERTIES
        public SpriteBatch SpriteBatch
        {
            get {return this.spriteBatch;}
        }

        public Texture2D Pixel
        {
            get {return this.pixel;}
        }

        //CONSTRUCTOR
        public ShapesDrawingManager(GraphicsDevice g, SpriteBatch spriteBatch)
        {
            this.graphicsDevice = g;
            this.spriteBatch = spriteBatch;

            this.pixel = new Texture2D(this.graphicsDevice, 1, 1); // create a texture of size: 1x1
            this.pixel.SetData(new Color[] {Color.White}); // fill this texture with 1 white pixel
        }

        //DRAWING METHODS
        #region Drawing pixel
        public void DrawPixel(Vector2 pos, Color color)
        {
            this.spriteBatch.Draw(this.pixel, pos, color);
        }

        public void DrawPixel(int x, int y, Color color)
        {
            this.spriteBatch.Draw(this.pixel, new Vector2(x, y), color);
        }
        #endregion

        #region Drawing rectangle
        public void DrawRectangle(int x, int y, int width, int height, Color color)
        {
            this.spriteBatch.Draw(this.pixel, new Rectangle(x, y, width, height), color);
        }

        public void DrawRectangle(Point pos, Point size, Color color)
        {
            this.spriteBatch.Draw(this.pixel, new Rectangle(pos, size), color);
        }

        public void DrawRectangle(Vector2 pos, Vector2 size, Color color)
        {
            this.DrawRectangle
            (
               (int)pos.X, (int)pos.Y, 
               (int)size.X, (int)size.Y, 
               color
            );
        }

        public void DrawRectangle(Rectangle rectangle, Color color)
        {
            this.spriteBatch.Draw(this.pixel, rectangle, color);
        }
        #endregion

        #region Drawing line
        public void DrawLine(Vector2 pos1, Vector2 pos2, Color color, float strokeWidth = 1)
        {
            float distX = pos2.X - pos1.X;
            float distY = pos2.Y - pos1.Y;

            double angle = Math.Atan2(distY, distX);
            float length = Vector2.Distance(pos1, pos2);

#pragma warning disable CS0618 // Type or member is obsolete
            this.spriteBatch.Draw(this.pixel,
                destinationRectangle: new Rectangle((int)pos1.X, (int)pos1.Y, (int)length, (int)strokeWidth),
                origin: Vector2.Zero,
                rotation: (float)angle,
                color: color);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public void DrawLine(float x1, float y1, float x2, float y2, Color color, float strokeWidth = 1)
        {
            this.DrawLine(new Vector2(x1, y1), new Vector2(x2, y2), color, strokeWidth);
        }
        #endregion

        #region Drawing circle
        private Texture2D CreateCircleTexture(int radius)
        {
            int diam = radius * 2 + 1; // radius = 5 => #####.##### => must have one pixel which represents the precise center

            Texture2D circle = new Texture2D(this.graphicsDevice, diam, diam);

            int centerX = radius;
            int centerY = radius;

            // Tab which will be 2D representation of circle in the image (pixels are represented by bool values)
            bool[,] repres_2d = new bool[diam, diam];

            // Test all pixels of image
            for (int y = 0; y < diam; y++)
            {
                for (int x = 0; x < diam; x++)
                {
                    if (Vector2.DistanceSquared(new Vector2(x, y), new Vector2(centerX, centerY)) <= radius * radius) // pixel is in the circle
                        repres_2d[y, x] = true;
                    else
                        repres_2d[y, x] = false;
                }
            }            

            // Copy content of 2D tab "repres_2d" in 1 dimension tab "data", replacing bool values by colors
            Color[] data = new Color[diam * diam];
            int i = 0;

            for (int y = 0; y < diam; y++)
            {
                for (int x = 0; x < diam; x++)
                {
                    if (repres_2d[y, x] == true)
                        data[i] = Color.White;
                    else
                        data[i] = Color.Transparent;

                    i++;
                }
            }

            circle.SetData(data); // fill "circle" texture with "data" data / values
            return circle;
        }

        public void DrawCircle(Vector2 centerPos, int radius, Color color)
        {
            Texture2D circleTexture = this.CreateCircleTexture(radius);

            Vector2 originPos = new Vector2(centerPos.X - radius, centerPos.Y - radius);

            this.spriteBatch.Draw(circleTexture, originPos, color);
        }

        public void DrawCircle(int x, int y, int radius, Color color)
        {
            this.DrawCircle(new Vector2(x, y), radius, color);
        }
        #endregion
    
        //UNLOADING
        public void Unload()
        {
            this.pixel.Dispose();
        }
    }
}