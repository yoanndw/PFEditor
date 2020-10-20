using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using CustomLib;

using PFEditor;

namespace PFEditor.Scene
{
    public class GameScene : BaseScene
    {
        private Level level;
        private Player player;
       
        public GameScene(Game1 game, Dictionary<string, string> properties, Random rng)
            : base(game, properties)
        {
            Texture2D[] tiles =
            {
                game.Content.Load<Texture2D>("block"),
            };

            this.level = new Level(tiles);
            this.player = new Player(content, new Point(1, 8));
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
        }

       
        public override void Draw(SpriteBatch spriteBatch, ShapesDrawingManager sh)
        {
            base.Draw(spriteBatch, sh);

            this.level.Draw(spriteBatch);
            this.player.Draw(spriteBatch);
        }
    }
}
