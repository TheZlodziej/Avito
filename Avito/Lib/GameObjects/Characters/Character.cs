using Avito.Lib.Components;
using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.GameObjects.Characters
{
    public abstract class Character : Sprite, IGameObject
    {
        public Physics Physics { get; set; }
        public int Hp { get; set; }
        public float Mass { get; set; }

        public Character(Texture texture) : base(texture)
        {
            Physics = new(this);
        }

        public virtual void Draw(RenderWindow window)
        {
            window.Draw(this);
        }

        public virtual void Update(Time deltaTime, RenderWindow? window = null)
        {
            Physics.Update(deltaTime);
        }
    }
}
