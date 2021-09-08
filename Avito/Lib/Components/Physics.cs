using Avito.Lib.GameObjects.Characters;
using SFML.System;
using System;

namespace Avito.Lib.Components
{
    public class Physics
    {
        public Vector2f Acceleration  = new();
        public Vector2f Velocity = new();
        public float Mass;

        private readonly Character _owner;
        public Physics(Character owner)
        {
            _owner = owner;
            Mass = _owner.Mass;
        }

        public void Update(Time deltaTime)
        {
            Velocity *= Settings.Physics.FrictionCoeff;
            
            if (Math.Abs(Velocity.X) < 0.01)
            {
                Velocity.X = 0f;
            }
            if (Math.Abs(Velocity.Y) < 0.01)
            {
                Velocity.Y = 0f;
            }
            _owner.Position += Velocity * deltaTime.AsSeconds();
        }

        public void AddForce(Vector2f force)
        {
            //Acceleration += force;
            Velocity = Utils.ClampVec2(Velocity + force, -100f, 100f);
        }
    }
}
