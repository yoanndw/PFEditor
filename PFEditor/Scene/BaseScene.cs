using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using CustomLib;

namespace PFEditor.Scene
{
    public enum SceneTrans
    {
        Title, Game, End
    }

    public class BaseScene
    {
        protected Game1 game;
        protected ContentManager content;
        protected Dictionary<string, string> properties;

        public BaseScene(Game1 game, Dictionary<string, string> properties)
        {
            this.game = game;
            this.content = this.game.Content;
            this.properties = properties;
        }

        public BaseScene(Game1 game) 
            : this(game, new Dictionary<string, string>())
        {
        }

        public void ChangeScene(SceneTrans next)
        {
            this.game.ChangeScene(next);
        }

        public void ChangeScene(SceneTrans next, Dictionary<string, string> properties)
        {
            this.game.ChangeScene(next, properties);
        }

        public virtual void Update(GameTime gameTime, Input input)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, ShapesDrawingManager sh)
        {
        }
    }
}
