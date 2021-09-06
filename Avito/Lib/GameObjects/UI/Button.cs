using Avito.Lib.GameObjects.Shapes;
using SFML.Graphics;
using SFML.System;
using AvTransform = Avito.Lib.Components.Transform;

namespace Avito.Lib.GameObjects.UI
{
    class Button : Rectangle, UiComponent
    {
        public Vector2f Padding { get; } = new(13, 7);// padding left top (right bottom assumed the same)

        public Text Text { get; set; }

        public Button(string text = "", uint characterSize = 20u) :
            this(text, Assets.DefaultFont, characterSize)
        { }

        public Button(string text, Font font, uint characterSize) :
            this(text, font, characterSize, 0f, 0f)
        {  
            Renderable.Size = Text.Size + 2 * Padding;
        }

        public Button(string text, Font font, uint characterSize, float width, float height) : 
            base(width, height)
        {
            Text = new Text(text, font, characterSize);
            
            var rectTransform = Components.GetComponent<AvTransform>();
            var textTransform = Text.Components.GetComponent<AvTransform>();
            
            textTransform.Position = Size / 2f + Padding;
            textTransform.RelativeTo = rectTransform;
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
            Text.Draw(window);
        }
    }
}
