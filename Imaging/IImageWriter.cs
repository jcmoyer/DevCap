using System.Drawing;
using System.IO;

namespace DevCap.Imaging {
    interface IImageWriter {
        void Write(Image img, Stream output);
        string Extension { get; }
    }
}