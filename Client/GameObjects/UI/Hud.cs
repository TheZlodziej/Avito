using Avito.Client.GameObjects.Characters;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Avito.Client.GameObjects.UI
{
    public sealed class Hud
    {
        public Character Owner { get; set; }

        private RectangleShape _background = new(Settings.Hud.ItemsBackgroundSize);
        private RectangleShape _hpBar = new(new Vector2f(Settings.Hud.HpBarSize.X * Settings.Player.DefaultHp, Settings.Hud.HpBarSize.Y));
        private RectangleShape _hpBarBackground = new(new Vector2f(Settings.Hud.HpBarSize.X * Settings.Player.DefaultHp, Settings.Hud.HpBarSize.Y));
        
        public Hud(Character owner) : base()
        {
            Owner = owner;
            SetupBackground();
            SetupHpBar();
        }

        private void SetupHpBar()
        {
            _hpBar.FillColor = Settings.Hud.HpBarColor;
            _hpBar.Position = Settings.Hud.HpBarPosition;

            _hpBarBackground.FillColor = Settings.Hud.HpBarBackgroundColor;
            _hpBarBackground.Position = _hpBar.Position;
        }

        private void SetupBackground()
        {
            _background.FillColor = Settings.Hud.ItemsBackroundColor;
            _background.Position = Settings.Hud.ItemsBackgroundPosition;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(_background);
            window.Draw(_hpBarBackground);
            window.Draw(_hpBar);
        }

        private void UpdateHpBar(View view)
        {
            _hpBar.Position = view.Center - view.Size / 2f + Settings.Hud.HpBarPosition;
            _hpBar.Size = new(Settings.Hud.HpBarSize.X * Owner.Hp, Settings.Hud.HpBarSize.Y);

            _hpBarBackground.Position = _hpBar.Position;
        }

        public void UpdateBackground(View view)
        {
            _background.Position = new(
                view.Center.X - _background.Size.X / 2f,
                view.Center.Y + view.Size.Y / 2f - _background.Size.Y
            );
        }

        public void Update(RenderWindow window)
        {
            var view = window.GetView();
            // test
            // TODO: remove this test
            if (Keyboard.IsKeyPressed(Keyboard.Key.F1))
            {
                Owner.Hp -= 1;
            }
            //
            UpdateBackground(view);
            UpdateHpBar(view);
        }
    }
}
