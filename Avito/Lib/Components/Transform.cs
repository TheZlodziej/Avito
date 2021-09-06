using SfTransformable = SFML.Graphics.Transformable;

namespace Avito.Lib.Components
{
    class Transform : SfTransformable, IComponent
    {
        private Transform? _relativeTo;
        public Transform? RelativeTo 
        { 
            get => _relativeTo;
            set 
            {
                _relativeTo = value;
                RelativeToChanged();
            } 
        }
        public Transform() : base() { }

        private void RelativeToChanged()
        {
            if (RelativeTo == null)
                return;

            Position += RelativeTo.Position;
        }
    }
}
