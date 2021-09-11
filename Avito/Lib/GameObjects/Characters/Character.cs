using Avito.Lib.Components;
using SFML.Graphics;
using SFML.System;
using System;

namespace Avito.Lib.GameObjects.Characters
{
    public abstract class Character : Sprite, IGameObject
    {
        public Physics Physics { get; set; }
        public int Hp { get; set; }
        public float Mass { get; set; }

        public Character(Texture texture) : base(texture)
        {
            Origin = Utils.SpriteSize(this) /2f; 
            Physics = new(this);
        }

        public virtual void Draw(RenderWindow window)
        {
            window.Draw(this);
        }

        public virtual void Update(Time deltaTime, RenderWindow window)
        {
            Physics.Update(deltaTime);
        }

        public virtual void LookAt(Vector2f position)
        {
            Vector2f dPos = position - Position;
            float angleDeg = Utils.RadToDeg(MathF.Atan2(dPos.Y, dPos.X));
            Rotation = angleDeg + 90f;
        }
    }
}
