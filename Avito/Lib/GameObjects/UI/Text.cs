using SFML.Graphics;
using SFML.System;
using SfText = SFML.Graphics.Text;

namespace Avito.Lib.GameObjects.UI
{
    public class Text : Drawable<SfText>, UiComponent
    {
        public override Vector2f Size 
        {
            get 
            {
                var bounds = Renderable.GetGlobalBounds();
                return new(bounds.Width, bounds.Height);
            }
        }

        public Text(string text = "", uint characterSize = 20u) : 
            this(text, Assets.DefaultFont, characterSize) { }
        public Text(string text, Font font, uint characterSize) : 
            base(new SfText(text, font, characterSize))
        {
            Renderable.FillColor = Color.Black;
        }
    }
}
