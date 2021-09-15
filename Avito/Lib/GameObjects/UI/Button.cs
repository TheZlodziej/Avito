using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.GameObjects.UI
{
    class Button : Ui
    {
        private readonly RectangleShape _rect;
        private readonly Text _text;

        public Button(string text) : this(text, Assets.Fonts.Default, Assets.Fonts.Size) { }

        public Button(string text, Font font, uint characterSize):base()
        {
            _text = new(text, font, characterSize);

            var textBounds = _text.GetGlobalBounds();
            _rect = new(new Vector2f(textBounds.Width + 20, _text.CharacterSize + 14));
        }

        protected override void OnClick()
        {
            _rect.FillColor = Color.Red;
        }

        protected override void MouseEnter()
        {
            _rect.FillColor = Color.Blue;
        }

        protected override void MouseLeft()
        {
            _rect.FillColor = Color.Green;
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(_rect);
            window.Draw(_text);
        }

        public override void Update(Time deltaTime, RenderWindow window)
        {
            MouseEventsHandler(window);
        }

        protected override bool MouseIsOver(RenderWindow relativeWindow)
        {
            var mousePos = Utils.CursorCoords(relativeWindow);
            return _rect.GetGlobalBounds().Contains(mousePos.X, mousePos.Y);
        }
    }
}
