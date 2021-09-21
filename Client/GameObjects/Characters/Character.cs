using Avito.Client.Components;
using Avito.Client.GameObjects.Items;
using Avito.Lib;
using SFML.Graphics;
using SFML.System;
using System;

namespace Avito.Client.GameObjects.Characters
{
    public abstract class Character : Sprite, IGameObject
    {
        public Inventory Inventory { get; set; } = new();
        public Physics Physics { get; set; }
        public int Hp { get; set; }
        public float Mass { get; set; }

        public Character(Texture texture) : base(texture)
        {
            Origin = Utils.GetSpriteSize(this) / 2f;
            Physics = new(this);
        }

        public virtual void Draw(RenderWindow window)
        {
            window.Draw(this);
            Inventory.Draw(window);
        }

        public virtual void Update(Time deltaTime, RenderWindow window)
        {
            Physics.Update(deltaTime);
            Inventory.Update(deltaTime, window);
        }

        public virtual void LookAt(Vector2f position)
        {
            Vector2f dPos = position - Position;
            float angleDeg = Utils.RadToDeg(MathF.Atan2(dPos.Y, dPos.X));
            Rotation = angleDeg + 90f;
        }

        public new virtual void Dispose()
        {
            Inventory.Dispose();
            base.Dispose();
        }
    }
}
