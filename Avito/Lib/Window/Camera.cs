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
            window.SetView(this);
            var winSize = (Vector2f)window.Size;
            // TODO: [?] set scale of the view so it shows only original

            Size = winSize;
            if (Pin == null)
                Center = winSize / 2f;

            else
                Center = Pin.Position;
        }
    }
}
