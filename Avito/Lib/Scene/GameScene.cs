using Avito.Lib.GameObjects.Characters;
using Avito.Lib.GameObjects.UI;
using Avito.Lib.Window;
using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.Scene
{
    class GameScene : Scene
    {
        readonly Button btn = new("test btn");
        readonly Player player = new();

        public GameScene() : base()
        {
            Camera.Pin = player;
        }

        public override void Draw(RenderWindow window)
        {
            btn.Draw(window);
            player.Draw(window);
        }

        public override void Update(Time deltaTime, RenderWindow window)
        {
            base.Update(deltaTime, window);

            btn.Update(deltaTime, window);
            player.Update(deltaTime, window);
        }
    }
}
