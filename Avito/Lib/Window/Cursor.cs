using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Avito.Lib.Window
{
    class Cursor : Sprite
    {
        public Cursor() : base(Assets.CursorTexture)
        {
            Origin = Utils.SpriteSize(this) / 2f;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(this);
        }

        public void Update(RenderWindow window)
        { 
            Position = window.MapPixelToCoords(Mouse.GetPosition(window));
        }
    }
}
