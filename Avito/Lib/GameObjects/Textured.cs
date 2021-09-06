using AvTransform = Avito.Lib.Components.Transform;
using SfSprite = SFML.Graphics.Sprite;
using SFML.System;
using SFML.Graphics;

namespace Avito.Lib.GameObjects
{
    class Textured : Drawable<SfSprite>
    {
        public override Vector2f Size
        {
            get
            {
                var bounds = Renderable.GetGlobalBounds();
                return new(bounds.Width, bounds.Height);
            }
        }

        public Textured(Texture texture) : base(new SfSprite(texture))
        {
            Components.GetComponent<AvTransform>().Origin = Size / 2f;
        }
    }
}
