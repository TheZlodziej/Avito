using Avito.Lib.GameObjects.Characters;
using SFML.System;

namespace Avito.Lib.Components
{
    public class Physics
    {
        public Vector2f Acceleration { get; set; } = new();
        public Vector2f Velocity { get; set; } = new();
        public Vector2f Friction { get; set; } = Settings.Physics.Friction;
        public float Mass { get; set; }

        private readonly Character _owner;
        public Physics(Character owner)
        {
            _owner = owner;
            Mass = _owner.Mass;
        }

        public void Update(Time deltaTime)
        {
            // TODO: ZBYCHU
            ////clamp acceleration and velocity

            //// update acceleration
            //Acceleration -= Friction * deltaTime.AsSeconds();

            //// update velocity
            //Velocity = Acceleration * deltaTime.AsSeconds();

            //// move owner
            //_owner.Position += Velocity * deltaTime.AsSeconds();
        }

        public void AddForce(Vector2f force)
        {
            Acceleration += force;
        }
    }
}
