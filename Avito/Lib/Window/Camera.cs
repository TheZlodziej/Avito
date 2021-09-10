using SFML.Graphics;
using SFML.System;

namespace Avito.Lib.Window
{
    public class Camera : View
    {
        // Transformable object that the camera is pinned to
        // if not set then the camera center is set to Window.Size/2f
        public Transformable? Pin { get; set; } 

        public void Update(RenderWindow window)
        {
            Size = (Vector2f)window.Size;

            if (Pin == null)
                Center = Size / 2f;

            else
                Center = Pin.Position;
            
            window.SetView(this);
        }
    }
}
