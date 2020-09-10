using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CustomLib
{
    public class Input
    {
        //FIELDS
        private KeyboardState oldKbState, currentKbState;
        private MouseState oldMouseState, currentMouseState;

        //PROPERTIES
        public MouseState Mouse
        {
            get { return this.currentMouseState; }
        }

        public Vector2 MousePos
        {
            get
            {
                return new Vector2(this.currentMouseState.X, this.currentMouseState.Y);
            }
        }

        //CONSTRUCTOR
        public Input()
        {
            this.currentKbState = Keyboard.GetState();
            this.oldKbState = this.currentKbState;

            this.currentMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            this.oldMouseState = this.currentMouseState;
        }

        //UPDATE
        public void Update() // at the beginning of Update() function
        {
            this.oldKbState = this.currentKbState;
            this.currentKbState = Keyboard.GetState();

            this.oldMouseState = this.currentMouseState;
            this.currentMouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }

        //METHODS
        #region Keyboard
        public bool KeyDown(Keys key)
        {
            return this.currentKbState.IsKeyDown(key);
        }

        public bool KeyUp(Keys key)
        {
            return this.currentKbState.IsKeyUp(key);
        }

        public bool KeyPressed(Keys key)
        {
            return this.oldKbState.IsKeyUp(key) && this.currentKbState.IsKeyDown(key); // old frame: up AND current frame: down
        }

        public bool KeyReleased(Keys key)
        {
            return this.oldKbState.IsKeyDown(key) && this.currentKbState.IsKeyUp(key); // old frame: down AND current frame: up
        }
        #endregion

        #region Mouse
        public bool MouseCompareWithState(ButtonState button, ButtonState state)
        {
            return button == state;
        }

        public bool MouseButtonDown(ButtonState button)
        {    
            return button == ButtonState.Pressed;
        }

        public bool MouseButtonUp(ButtonState button)
        {
            return button == ButtonState.Released;
        }
        
        // Left button
        public bool LeftButtonPressed()
        {
            return this.MouseButtonUp(this.oldMouseState.LeftButton) &&
                   this.MouseButtonDown(this.currentMouseState.LeftButton); 
        }

        public bool LeftButtonReleased()
        {
            return this.MouseButtonDown(this.oldMouseState.LeftButton) &&
                   this.MouseButtonUp(this.currentMouseState.LeftButton); 
        }

        // Right button
        public bool RightButtonPressed()
        {
            return this.MouseButtonUp(this.oldMouseState.RightButton) &&
                   this.MouseButtonDown(this.currentMouseState.RightButton); 
        }

        public bool RightButtonReleased()
        {
            return this.MouseButtonDown(this.oldMouseState.RightButton) &&
                   this.MouseButtonUp(this.currentMouseState.RightButton); 
        }
        #endregion
    }
}