using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CustomLib;
using System.Diagnostics;

namespace PFEditor
{
    public class Player
    {
        private static float SPEED = 200.0f;

        private Vector2 pos;
        private Vector2 velocity;
        private Texture2D tex;

        public Player(ContentManager content)
        {
            this.velocity = Vector2.Zero;
            this.tex = content.Load<Texture2D>("player");
        }

        public Player(ContentManager content, Vector2 screenPos)
            : this(content)
        {
            this.pos = screenPos;
        }

        public Player(ContentManager content, Point gridPos)
            : this(content, Level.GridToScreen(gridPos))
        {
        }

        public bool CollideSingleAxis(Level level, float vx, float vy)
        {
            int leftGridX = Level.ScreenToGrid(this.pos.X);
            int upGridY = Level.ScreenToGrid(this.pos.Y);

            int rightGridX = Level.ScreenToGrid(this.pos.X + (32 - 1));
            int downGridY = Level.ScreenToGrid(this.pos.Y + (32 - 1));

            // Left
            if (vx < 0)
            {
                return level.IsWall(leftGridX, upGridY)
                       || level.IsWall(leftGridX, downGridY);
            }
            // Right
            else if (vx > 0)
            {
                return level.IsWall(rightGridX, upGridY)
                       || level.IsWall(rightGridX, downGridY);
            }
            // Up
            else if (vy < 0)
            {
                return level.IsWall(leftGridX, upGridY)
                       || level.IsWall(rightGridX, upGridY);
            }
            // Down
            else if (vy > 0)
            {
                return level.IsWall(leftGridX, downGridY)
                       || level.IsWall(rightGridX, downGridY);
            }

            return false;
        }

        public bool CollideSingleAxis(Level level, Vector2 velocity)
        {
            return this.CollideSingleAxis(level, velocity.X, velocity.Y);
        }

        public void Move(Vector2 velocity) 
        {
            this.velocity = velocity;
        }

        public void Move(float vx, float vy)
        {
            this.Move(new Vector2(vx, vy));
        }

        public void Update(GameTime gameTime, Input input, Level level)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.pos += this.velocity * dt;

            if (input.KeyDown(Keys.Left))
            {
                this.Move(-SPEED, 0);
                Debug.WriteLine(this.CollideSingleAxis(level, this.velocity));
            }
            else if (input.KeyDown(Keys.Right))
            {
                this.Move(SPEED, 0);
                Debug.WriteLine(this.CollideSingleAxis(level, this.velocity));
            }
            else
            {
                this.Move(0, 0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.tex, this.pos, Color.White);
        }
    }
}
