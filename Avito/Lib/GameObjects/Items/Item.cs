using Avito.Lib.GameObjects.Characters;
using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.GameObjects.Items
{
    abstract class Item : Sprite, IGameObject
    {
        public Character? Owner { get; set; }
        public Item(Texture texture) : base(texture) { }
        public abstract void Use();
        public virtual void Draw(RenderWindow window)
        {
            window.Draw(this);
        }

        // if Owner is null it means the item is on the ground
        // else it's been collected and should be updated differently
        public abstract void Update(Time deltaTime, RenderWindow window);
    }
}
