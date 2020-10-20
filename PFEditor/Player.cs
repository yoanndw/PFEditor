using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CustomLib;

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

        public void Move(Vector2 velocity) 
        {
            this.velocity = velocity;
        }

        public void Move(float vx, float vy)
        {
            this.Move(new Vector2(vx, vy));
        }

        public void Update(GameTime gameTime, Input input)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.pos += this.velocity * dt;

            if (input.KeyDown(Keys.Left))
            {
                this.Move(-SPEED, 0);
            }
            else if (input.KeyDown(Keys.Right))
            {
                this.Move(SPEED, 0);
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
