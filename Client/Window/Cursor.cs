using Avito.Lib;
using SFML.Graphics;

namespace Avito.Client.Window
{
    public class Cursor : Sprite
    {
        public Cursor() : base(Assets.CursorTexture)
        {
            Origin = Utils.GetSpriteSize(this) / 2f;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(this);
        }

        public void Update(RenderWindow window)
        {
            Position = Utils.CursorCoords(window);
        }
    }
}
