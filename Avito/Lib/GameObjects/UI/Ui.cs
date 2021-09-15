using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Avito.Lib.GameObjects.UI
{
    public abstract class Ui : MouseEvents, IGameObject
    {
        public abstract void Draw(RenderWindow window);
        public abstract void Update(Time deltaTime, RenderWindow window);
    }
}
