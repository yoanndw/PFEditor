using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using CustomLib;

using PFEditor.Scene;

namespace PFEditor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public GraphicsDeviceManager GraphicsDeviceManager { get => this.graphics; }

        SpriteBatch spriteBatch;
        ShapesDrawingManager sh;

        BaseScene currScn;
        Input input;

        Random rng;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.Window.Title = "City Cameras (Not a Gamejam Release)";
        }

        public void ChangeScene(SceneTrans next)
        {
            this.ChangeScene(next, new Dictionary<string, string>());
        }

        public void ChangeScene(SceneTrans next, Dictionary<string, string> properties)
        {
            switch (next)
            {
                case SceneTrans.Title:
                    this.currScn = new TitleScene(this, properties);
                    break;

                case SceneTrans.Game:
                    this.currScn = new GameScene(this, properties, this.rng);
                    break;

                case SceneTrans.End:
                    this.currScn = new EndScene(this, properties);
                    break;
            }
        }

        protected override void Initialize()
        {
            this.input = new Input();

            this.rng = new Random();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.sh = new ShapesDrawingManager(graphics.GraphicsDevice, spriteBatch);

            this.ChangeScene(SceneTrans.Game);
        }

        protected override void UnloadContent()
        {
            sh.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            this.input.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.currScn.Update(gameTime, this.input);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            this.currScn.Draw(spriteBatch, this.sh);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
