/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
using System;
using System.Drawing;

namespace DevCap.Imaging {
    class ScreenCapturerParameters {
        private readonly string _directory;
        private readonly string _formatString;
        private readonly Rectangle _bounds;
        private readonly IImageWriter _writer;
        private readonly bool _compress;

        public ScreenCapturerParameters(string directory, string formatString, Rectangle bounds, IImageWriter writer)
            : this(directory, formatString, bounds, writer, false) {
        }

        public ScreenCapturerParameters(string directory, string formatString, Rectangle bounds, IImageWriter writer, bool compress) {
            _directory = directory;
            _formatString = formatString;
            _bounds = bounds;
            _writer = writer;
            _compress = compress;

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

        public bool Compress {
            get { return _compress; }
        }
    }
}