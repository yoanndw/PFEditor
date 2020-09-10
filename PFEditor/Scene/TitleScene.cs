using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CustomLib;

using PFEditor;

namespace PFEditor.Scene
{
    public class TitleScene : BaseScene
    {
        public TitleScene(Game1 game, Dictionary<string, string> properties)
            : base(game, properties)
        {
        }

        public override void Update(GameTime gameTime, Input input)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, ShapesDrawingManager sh)
        {
            base.Draw(spriteBatch, sh);
            sh.DrawRectangle(0, 0, 32, 32, Color.White);
        }
    }
}
