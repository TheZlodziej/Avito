using SFML.Graphics;
using System.IO;
using SfFont = SFML.Graphics.Font;

namespace Avito
{
    public static partial class Assets
    {
        // DIRECTORY PATH
        public static string AssetsDirectory { get; set; } = Path.Join(Settings.RootDirectory, "Assets");

        // FONTS
        public static SfFont DefaultFont { get; set; } = new(Path.Join(AssetsDirectory, "Fonts\\default_font.ttf"));

        // TEXTURES
        public static Texture PlayerTexture { get; set; } = new(Path.Join(AssetsDirectory, "Images\\test.png"));

        // TEST
        public static Texture TestTexture { get; set; } = new(Path.Join(AssetsDirectory, "Images\\test.png"));
    }
}
