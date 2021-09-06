using Avito.Lib.GameObjects;
using Avito.Lib.GameObjects.Shapes;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using AvText = Avito.Lib.GameObjects.UI.Text;

namespace Avito.Lib.Scene
{
    class GameScene : IScene
    {
        private Textured test = new(Assets.TestTexture);
        private Rectangle rect = new(300, 400);
        private AvText text = new("test test test");

        public GameScene():base()
        {
            rect.Renderable.FillColor = Color.Cyan;
        }

        public void Draw(RenderWindow window)
        {
            test.Components.GetComponent<Components.Transform>().Position = (Vector2f)Mouse.GetPosition(window);
            test.Draw(window);
            rect.Draw(window);
            text.Draw(window);
        }
        public void Update(Time deltaTime)
        {
            test.Update(deltaTime);
            rect.Update(deltaTime);
            text.Update(deltaTime);
        }
    }
}
