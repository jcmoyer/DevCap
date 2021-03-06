/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace DevCap.Imaging {
    class JpegWriter : IImageWriter {
        private const int DefaultQuality = 75;
        
        private int _quality;

        
        public int Quality {
            get { return _quality; }
            set {
                if (value > 100) value = 100;
                if (value < 0) value = 0;
                _params.Param[0] = new EncoderParameter(_encoder, value);
                _quality = value;
            }
        }

        private readonly ImageCodecInfo _codec = GetCodec();
        private readonly Encoder _encoder = Encoder.Quality;
        private readonly EncoderParameters _params = new EncoderParameters(1);

        public JpegWriter() {
            Quality = DefaultQuality;
        }

        public void Write(Image img, Stream output) {
            img.Save(output, _codec, _params);
        }

        private static ImageCodecInfo GetCodec() {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            return codecs.FirstOrDefault(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
        }

        public string Extension {
            get { return "jpg"; }
        }
    }
}