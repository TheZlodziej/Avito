using Avito.Lib.Components;
using SFML.Graphics;
using SFML.System;
using System;

namespace Avito.Lib.GameObjects.Player
{
    public abstract class Player : Sprite, IGameObject
    {
        public ComponenetManager Components { get; set; }

        public Player(Texture texture) : base(texture)
        {
            Components = new(this);
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(this);
        }

        public void Update(Time deltaTime, RenderWindow? window = null)
        {
            //Components.Update();
        }
    }
}
