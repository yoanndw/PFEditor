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
       
        public GameScene(Game1 game, Dictionary<string, string> properties, Random rng)
            : base(game, properties)
        {
            
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);
        }

       
        public override void Draw(SpriteBatch spriteBatch, ShapesDrawingManager sh)
        {
            base.Draw(spriteBatch, sh);
        }
    }
}
