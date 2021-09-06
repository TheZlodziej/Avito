using Avito.Lib.Components;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Avito.Lib.GameObjects.UI
{
    class Button : IUi
    {
        private readonly RectangleShape _rect;
        private readonly Text _text;

        public Button(string text) : this(text, Assets.DefaultFont, 20u) { }

        public Button(string text, Font font, uint characterSize):base()
        {
            _text = new(text, font, characterSize);

            var textBounds = _text.GetGlobalBounds();
            _rect = new(new Vector2f(textBounds.Width + 20, _text.CharacterSize + 14));
        }

        public void Click()
        {
            return;
        }

        public void Hover()
        {
            return;
        }

        public void Draw(RenderWindow window)
        {
            return;
        }

        public virtual void Update(Time deltaTime, RenderWindow? window = null)
        {
            if (window == null)
                return;

            if (MouseIsOver(window))
            {
                Hover();

                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    Click();
                }
            }
        }

        public bool MouseIsOver(RenderWindow relativeWindow)
        {
            var mousePos = (Vector2f)Mouse.GetPosition(relativeWindow);
            return _rect.GetGlobalBounds().Contains(mousePos.X, mousePos.Y);
        }
    }
}
