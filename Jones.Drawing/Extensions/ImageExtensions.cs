using System.Drawing;
using System.IO;

namespace Jones.Drawing.Extensions
{
    public static class ImageExtensions
    {
        public static bool IsImage(this Stream stream)
        {
            try {
                var image = Image.FromStream(stream);
                return !image.Size.IsEmpty;
            } catch {
                return false;
            }
        }
    }
}