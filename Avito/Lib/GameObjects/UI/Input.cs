using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avito.Lib.GameObjects.UI
{
    class Input : Ui
    {
        public string Value { get; set; } = "";
        public bool Active { get; set; } = false;

        private RectangleShape _background = new(new Vector2f(200,50));
        private Text _text = new("", Assets.Fonts.Default, Assets.Fonts.Size);
        private readonly Dictionary<Keyboard.Key, bool> _keyStates = new(); // true => available (released)

        public Input() : base()
        {
            _background.FillColor = Settings.Input.BackgroundColor;
            _text.FillColor = Settings.Input.TextColor;
            _keyStates.Add(Settings.Input.RemoveLetterKey, true);
            foreach (var key in Settings.Input.AvailableKeys)
                _keyStates.Add(key.Key, true);
        }

        protected override void OnClick()
        {
            Active = true;
        }

        public override void Draw(RenderWindow window)
        {
            window.Draw(_background);
            window.Draw(_text);
        }

        protected override void MouseEnter()
        {
            // TODO: change background
        }

        protected override bool MouseIsOver(RenderWindow relativeWindow)
        {
            var cursorPos = Utils.CursorCoords(relativeWindow);
            return _background.GetGlobalBounds().Contains(cursorPos.X, cursorPos.Y);
        }

        protected override void MouseLeft()
        {
            if (Mouse.IsButtonPressed(Settings.Controls.Mouse.Confirm))
            {
                Active = false;
            }
        }

        private void HandleLetterRemoval()
        {
            var removeKey = Settings.Input.RemoveLetterKey;
            if (Keyboard.IsKeyPressed(removeKey))
            {
                if (_keyStates[removeKey])
                {
                    _keyStates[removeKey] = false;
                    Value = Value.Remove(Value.Length - 1);
                }
            }
            else
            {
                _keyStates[removeKey] = true;
            }
        }

        private void HandleLetterInput()
        {
            foreach (var key in Settings.Input.AvailableKeys)
            {
                if (Keyboard.IsKeyPressed(key.Key))
                {
                    if (_keyStates[key.Key])
                    {
                        _keyStates[key.Key] = false;

                        if (Keyboard.IsKeyPressed(Settings.Input.CapitalizeKey))
                        {
                            Value += key.Value.ToUpper();
                        }

                        else
                        {
                            Value += key.Value;
                        }
                    }
                }
                else
                {
                    _keyStates[key.Key] = true;
                }
            }
        }

        private void TextInput()
        {
            if (!Active)
                return;

            HandleLetterRemoval();
            HandleLetterInput();
            _text.DisplayedString = Value;
        }

        public override void Update(Time deltaTime, RenderWindow window)
        {
            MouseEventsHandler(window);
            TextInput();
        }
    }
}
