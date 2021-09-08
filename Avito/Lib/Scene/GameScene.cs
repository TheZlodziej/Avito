using Avito.Lib.GameObjects.Characters;
using Avito.Lib.GameObjects.UI;
using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.Scene
{
    class GameScene : IScene
    {
        readonly Button btn = new("test btn");
        Player player = new();
        public void Draw(RenderWindow window)
        {
            btn.Draw(window);
            player.Draw(window);
        }

        public void Update(Time deltaTime, RenderWindow? window = null)
        {
            btn.Update(deltaTime, window);
            player.Update(deltaTime, window);
        }
    }
}
