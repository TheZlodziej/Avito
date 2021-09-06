using SFML.Graphics;
using SfDrawable = SFML.Graphics.Drawable;
using AvTransform = Avito.Lib.Components.Transform;
using SFML.System;

namespace Avito.Lib.GameObjects
{
    public abstract class Drawable<T> : GameObject where T : SfDrawable
    {
        public T Renderable { get; set; }

        public abstract Vector2f Size { get; }

        public Drawable(T renderable) : base()
        {
            Renderable = renderable;
            Components.Add<AvTransform>();
        }

        public override void Update(Time deltaTime)
        {
            base.Update(deltaTime);
        }

        public virtual void Draw(RenderWindow window)
        {
            RenderStates states = RenderStates.Default;
            states.Transform = Components.GetComponent<AvTransform>().Transform;

            Draw(window, states);
        }

        public virtual void Draw(RenderWindow window, RenderStates states)
        {
            Renderable.Draw(window, states);
        }
    }
}
