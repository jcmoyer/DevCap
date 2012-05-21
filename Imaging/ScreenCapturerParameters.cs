using System;
using System.Drawing;

namespace DevCap.Imaging {
    class ScreenCapturerParameters {
        private readonly string _directory;
        private readonly string _formatString;
        private readonly Rectangle _bounds;
        private readonly IImageWriter _writer;

        public ScreenCapturerParameters(string directory, string formatString, Rectangle bounds, IImageWriter writer) {
            _directory = directory;
            _formatString = formatString;
            _bounds = bounds;
            _writer = writer;

            if (String.IsNullOrWhiteSpace(_formatString)) {
                _formatString = ScreenCapturer.DefaultFormatString;
            }
        }

        public string Directory {
            get { return _directory; }
        }

        public string FormatString {
            get { return _formatString; }
        }

        public Rectangle Bounds {
            get { return _bounds; }
        }

        public IImageWriter Writer {
            get { return _writer; }
        }
    }
}