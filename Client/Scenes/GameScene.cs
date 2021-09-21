using Avito.Client.GameObjects.Characters;
using Avito.Client.GameObjects.UI;
using Avito.Client.Window;
using SFML.Graphics;
using SFML.System;

namespace Avito.Client.Scenes
{
    public sealed class GameScene : Scene
    {
        Client client = new();
        readonly Button btn = new("test btn");
        readonly Player player = new();
        readonly Hud hud;
        readonly Input ipt = new();
        public GameScene() : base()
        {
            Camera.Pin = player;
            hud = new(player);
            ipt.Position = new(100, 100);
            btn.Position = new(-100, -100);
        }

        public override void Draw(RenderWindow window)
        {
            btn.Draw(window);
            player.Draw(window);
            ipt.Draw(window);
            hud.Draw(window);
        }

        public override void Update(Time deltaTime, RenderWindow window)
        {
            base.Update(deltaTime, window);
            btn.Update(deltaTime, window);
            ipt.Update(deltaTime, window);
            if (!ipt.Active)
                player.Update(deltaTime, window);
            hud.Update(window);
        }

        public override void Dispose()
        {
            //dispose game objects
            btn.Dispose();
            player.Dispose();
            hud.Dispose();
            ipt.Dispose();

            //dispose client
            client?.Dispose();
            client = null!;

            base.Dispose();
        }
    }
}
