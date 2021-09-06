using SFML.Graphics;
using SFML.System;
using SfText = SFML.Graphics.Text;
using GameAssets = Avito.Assets;

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

        public Text(string text = "", uint characterSize = 16u) : 
            this(text, GameAssets.DefaultFont, characterSize) { }
        public Text(string text, Font font, uint characterSize) : 
            base(new SfText(text, font, characterSize))
        { 
            
        }
    }
}
