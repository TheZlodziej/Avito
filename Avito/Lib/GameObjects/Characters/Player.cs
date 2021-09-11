using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Avito.Lib.GameObjects.Characters
{
    public class Player : Character
    {
        public Player() : base(Assets.PlayerTexture) 
        {
            Hp = Settings.Player.DefaultHp;
            Mass = Settings.Player.Mass;
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
            // draw inventory <- in base class
            // draw hud
        }

        public override void Update(Time deltaTime, RenderWindow window)
        {
            base.Update(deltaTime, window);
            Movement(deltaTime);
            LookAt(Utils.CursorCoords(window));
            //Console.WriteLine(Physics.Velocity);
            //Console.WriteLine(Physics.Acceleration);

            // update hud
            // update inventory <- in base class
        }

        private void Movement(Time deltaTime)
        {
            Vector2f dir = new(0,0);

            if (Keyboard.IsKeyPressed(Settings.Controls.MoveRight))
                dir.X += 1;

            if (Keyboard.IsKeyPressed(Settings.Controls.MoveLeft))
                dir.X -= 1;

            if (Keyboard.IsKeyPressed(Settings.Controls.MoveUp))
                dir.Y -= 1;

            if (Keyboard.IsKeyPressed(Settings.Controls.MoveDown))
                dir.Y += 1;

            dir = Utils.NormalizeVec2(dir);
            Physics.AddForce(Settings.Physics.MoveForce * dir);
        }
    }
}
