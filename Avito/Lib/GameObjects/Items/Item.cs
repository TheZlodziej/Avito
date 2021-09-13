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
        public abstract void Draw(RenderWindow window);
        public abstract void Update(Time deltaTime, RenderWindow window);
    }
}
