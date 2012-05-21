using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DevCap.Imaging {
    class PngWriter : IImageWriter {
        public void Write(Image img, Stream output) {
            img.Save(output, ImageFormat.Png);
        }

        public string Extension {
            get { return "png"; }
        }
    }
}