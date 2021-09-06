using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.Scene
{
    public interface IScene
    {
        public void Update(Time deltaTime, RenderWindow? window = null);
        public void Draw(RenderWindow window);
    }
}
