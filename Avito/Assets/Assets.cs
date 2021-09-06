using System.IO;
using SfFont = SFML.Graphics.Font;

namespace Avito
{
    public static partial class Assets
    {
        // DIRECTORY PATH
        public static string AssetsDirectory { get; set; } = Path.Join(Directory.GetCurrentDirectory(), "Assets");

        // WINDOW
        public static string WindowTitle { get; set; } = "Avito";
        public static uint WindowWidth { get; set; } = 720u;
        public static uint WindowHeight { get; set; } = 520u;

        // FONTS
        public static SfFont DefaultFont { get; set; } = new(Path.Join(AssetsDirectory, "Fonts\\default_font.ttf"));
    }
}
