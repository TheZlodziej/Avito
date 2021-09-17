using SFML.Graphics;
using System.IO;
using SfFont = SFML.Graphics.Font;
namespace Avito
{
    public static partial class Assets
    {
        // DIRECTORY PATH
        public static string AssetsDirectory { get; } = Path.Join(Settings.RootDirectory, "Assets");

        // FONTS
        public static class Fonts
        {
            public static SfFont Default { get; } = new(Path.Join(AssetsDirectory, "Fonts\\default_font.ttf"));
            public static uint Size { get; } = 20u;
        }

        // TEXTURES
        public static Texture PlayerTexture { get; } = new(Path.Join(AssetsDirectory, "Images\\test.png"));
        public static Texture CursorTexture { get; } = new(Path.Join(AssetsDirectory, "Images\\cursor.png"));

        // TEST
        public static Texture TestTexture { get; } = new(Path.Join(AssetsDirectory, "Images\\test.png"));
    }
}
