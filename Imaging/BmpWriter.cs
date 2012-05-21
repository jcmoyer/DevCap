using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace DevCap.Imaging {
    class BmpWriter : IImageWriter {
        public void Write(Image img, Stream output) {
            img.Save(output, ImageFormat.Bmp);
        }

        public string Extension {
            get { return "bmp"; }
        }
    }
}