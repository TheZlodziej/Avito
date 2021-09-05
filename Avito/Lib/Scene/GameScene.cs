using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Avito.Lib.Scene
{
    class GameScene : Scene
    {
        private RectangleShape test = new(new Vector2f(100, 150));

        public GameScene()
        { 
            test.Origin = test.Size / 2f;
        }

        public override void Draw(RenderWindow window)
        {
            test.Position = (Vector2f)Mouse.GetPosition(window);
            window.Draw(test);
        }

        public override void Update(Time deltaTime)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                test.FillColor = new(255, 0, 0);
            else
                test.FillColor = new(0, 0, 0);
        }
    }
}
