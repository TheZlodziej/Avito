using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Avito.Lib.GameObjects.UI
{
    class Cursor : Sprite, IGameObject
    {
        public Cursor() : base(Assets.CursorTexture)
        {
            Origin = Utils.SpriteSize(this) / 2f;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(this);
        }

        public void Update(Time deltaTime, RenderWindow? window = null)
        {
            if (window == null)
                return;

            Position = (Vector2f)Mouse.GetPosition(window);
        }
    }
}
