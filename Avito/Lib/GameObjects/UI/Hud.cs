using Avito.Lib.GameObjects.Characters;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avito.Lib.GameObjects.UI
{
    public class Hud
    {
        public Character Owner { get; set; }
        private readonly RectangleShape _background = new(Settings.Hud.ItemsBackgroundSize);

        public Hud(Character owner): base()
        {
            Owner = owner;
            SetupBackground();
        }

        private void SetupBackground()
        {
            _background.FillColor = Settings.Hud.ItemsBackroundColor;
            _background.Position = Settings.Hud.ItemsBackgroundPosition;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(_background);
        }

        public void UpdateBackground(RenderWindow window)
        {
            View view = window.GetView();
            _background.Position = view.Center - view.Size / 2f + Settings.Hud.ItemsBackgroundPosition;
        }

        public void Update(RenderWindow window)
        {
            UpdateBackground(window);
        }
    }
}
