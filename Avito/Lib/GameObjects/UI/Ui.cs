using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.GameObjects.UI
{
    public abstract class Ui : MouseEvents, IGameObject
    {
        public abstract Vector2f Position { get; set; }
        public abstract void Draw(RenderWindow window);
        public abstract void Update(Time deltaTime, RenderWindow window);
    }
}
