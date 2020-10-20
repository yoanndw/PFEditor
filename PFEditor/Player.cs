using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PFEditor
{
    public class Player
    {
        private Vector2 pos;
        private Texture2D tex;

        public Player(ContentManager content)
        {
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.tex, this.pos, Color.White);
        }
    }
}
