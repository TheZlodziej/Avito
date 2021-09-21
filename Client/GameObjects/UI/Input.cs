using Avito.Lib;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Avito.Client.GameObjects.UI
{
    public sealed class Input : Ui
    {
        public string Value { get; set; } = "";
        public bool Active { get; set; } = false;
        public override Vector2f Position
        {
            get => _background.Position;
            set
            {
                _background.Position = value;
                _text.Position = value + new Vector2f(5, 0); // adding (5,0) padding
            }
        }

        private RectangleShape _background = new(new Vector2f(200, Assets.Fonts.Size * 1.5f));
        private Text _text = new("Click to enter value", Assets.Fonts.Default, Assets.Fonts.Size);
        private readonly Dictionary<Keyboard.Key, bool> _keyStates = new(); // true => available (released)

        public Input() : base()
        {
            SetupInputShapes();
            SetupKeyStates();
        }

        private void SetupInputShapes()
        {
            _background.FillColor = Settings.Input.BackgroundColor;
            _background.Origin = _background.Size / 2f;

            _text.FillColor = Settings.Input.TextColor;
            _text.Origin = new(_background.Size.X / 2, Utils.GetTextSize(_text).Y / 2f);
        }

        private void SetupKeyStates()
        {
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
            _background.FillColor = Settings.Input.ActiveBackgroundColor;
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
            _background.FillColor = Settings.Input.BackgroundColor;
        }

        private void HandleLetterRemoval()
        {
            var removeKey = Settings.Input.RemoveLetterKey;
            if (Keyboard.IsKeyPressed(removeKey))
            {
                if (_keyStates[removeKey])
                {
                    _keyStates[removeKey] = false;
                    if (Value.Length > 0)
                    {
                        Value = Value.Remove(Value.Length - 1);
                    }
                }
            }
            else
            {
                _keyStates[removeKey] = true;
            }
        }

        private void HandleLetterInput()
        {
            // TODO: limit input value to N letters
            if (Value.Length > Settings.Input.MaxSize)
                return;

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
            else
                _background.FillColor = Settings.Input.ActiveBackgroundColor;

            HandleLetterRemoval();
            HandleLetterInput();
            _text.DisplayedString = Value;
        }

        public override void Update(Time deltaTime, RenderWindow window)
        {
            MouseEventsHandler(window);
            TextInput();

            if (Keyboard.IsKeyPressed(Settings.Input.Exit))
                Active = false;
        }
    }
}
