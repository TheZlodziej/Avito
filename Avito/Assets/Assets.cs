using SFML.Graphics;
using System.IO;

namespace Avito
{
    public static partial class Assets
    {
        // DIRECTORY PATH
        public static string AssetsDirectory { get; set; } = Path.Join(Settings.RootDirectory, "Assets");

        // FONTS
        public static Font DefaultFont { get; set; } = new(Path.Join(AssetsDirectory, "Fonts\\default_font.ttf"));

        // TEXTURES
        public static Texture PlayerTexture { get; set; } = new(Path.Join(AssetsDirectory, "Images\\test.png"));
        public static Texture CursorTexture { get; set; } = new(Path.Join(AssetsDirectory, "Images\\cursor.png"));

        // TEST
        public static Texture TestTexture { get; set; } = new(Path.Join(AssetsDirectory, "Images\\test.png"));
    }
}
