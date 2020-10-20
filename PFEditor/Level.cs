﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PFEditor
{
    class Level
    {
        private Texture2D[] tiles;
        private int[,] data;

        public Level(Texture2D[] tiles)
        {
            this.tiles = tiles;

            this.data = new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };
        }

        public static Point ScreenToGrid(float screenX, float screenY)
        {
            int gridX = (int)(screenX / 32);
            int gridY = (int)(screenY / 32);

            return new Point(gridX, gridY);
        }

        public static Point ScreenToGrid(Vector2 screenPos)
        {
            return ScreenToGrid(screenPos.X, screenPos.Y);
        }

        public static Vector2 GridToScreen(int gridX, int gridY)
        {
            float screenX = gridX * 32;
            float screenY = gridY * 32;

            return new Vector2(screenX, screenY);
        }

        public static Vector2 ScreenToGrid(Point gridPos)
        {
            return GridToScreen(gridPos.X, gridPos.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Vector2 pos = GridToScreen(j, i);
                    int tile = this.data[i, j];

                    if (tile != 0)
                    {
                        var tex = this.tiles[tile - 1]; // `tiles` array start at 0
                        spriteBatch.Draw(tex, pos, Color.White);
                    }
                }
            }
        }
    }
}
