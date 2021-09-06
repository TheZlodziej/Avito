using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.GameObjects.Shapes
{
    public class Rectangle : Drawable<RectangleShape>
    {
        public override Vector2f Size => Renderable.Size;
        public Rectangle(float width, float height) : base(new(new Vector2f(width, height))) {}
    }
}
