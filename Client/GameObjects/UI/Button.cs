using Avito.Lib;
using SFML.Graphics;
using SFML.System;

namespace Avito.Client.GameObjects.UI
{
    public sealed class Button : Ui
    {
        private RectangleShape _rect;
        private Text _text;

        public override Vector2f Position
        {
            get => _rect.Position;
            set
            {
                _rect.Position = value;
                _text.Position = value;
            }
        }

        public Button(string text) : this(text, Assets.Fonts.Default, Assets.Fonts.Size) { }

        public Button(string text, Font font, uint characterSize) : base()
        {
            _text = new(text, font, characterSize);
            var textSize = Utils.GetTextSize(_text);
            _text.Origin = textSize / 2f;

            _rect = new(new Vector2f(textSize.X + 20, textSize.Y + 14));
            _rect.Origin = _rect.Size / 2f;
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

        public override void Dispose()
        {
            _rect?.Dispose();
            _rect = null!;

            _text?.Dispose();
            _text = null!;

            base.Dispose();
        }
    }
}
