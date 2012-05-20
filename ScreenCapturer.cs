/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */ 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
// Because of conflict with property name.
using DirectoryClass = System.IO.Directory;

namespace DevCap {
    class ScreenCapturer : PeriodicTask {
        public const string DefaultFormatString = "$YEAR$MONTH$DAY_$HOUR$MINUTE$SECOND";

        private readonly string _directory;
        private readonly string _formatString;
        private readonly ImageFormat _format;
        private Rectangle _bounds;
        private long _number;

        public ScreenCapturer(string directory, string formatString, ImageFormat saveFormat) {
            _directory = directory;
            _formatString = formatString;
            _format = saveFormat;
            _bounds = Screen.PrimaryScreen.Bounds;

            if (String.IsNullOrWhiteSpace(formatString)) {
                _formatString = DefaultFormatString;
            }
        }

        protected override void OnStart() {
            if (!DirectoryClass.Exists(_directory)) {
                DirectoryClass.CreateDirectory(_directory);
            }

            _number = 0;
        }

        private void SaveFrame() {
            Bitmap buffer = new Bitmap(_bounds.Width, _bounds.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(buffer)) {
                g.CopyFromScreen(_bounds.Location, new Point(), _bounds.Size);

                Rectangle cursorBounds = new Rectangle(Point.Subtract(Cursor.Position, _bounds.Size), Cursor.Current.Size);
                Cursors.Default.Draw(g, cursorBounds);
            }

            buffer.Save(Path.Combine(_directory, CreateFilename()), _format);
        }

        private string CreateFilename() {
            var now = DateTime.Now;
            return _formatString
                .Replace("$YEAR", now.Year.ToString("D4"))
                .Replace("$MONTH", now.Month.ToString("D2"))
                .Replace("$DAY", now.Day.ToString("D2"))
                .Replace("$HOUR", now.Hour.ToString("D2"))
                .Replace("$MINUTE", now.Minute.ToString("D2"))
                .Replace("$SECOND", now.Second.ToString("D2"))
                .Replace("$NUMBER", Interlocked.Increment(ref _number).ToString("D8")) + "." + _format;
        }

        protected override void Run() {
            SaveFrame();
        }

        public string Directory {
            get { return _directory; }
        }

        public ImageFormat Format {
            get { return _format; }
        }

        public Rectangle Bounds {
            get { return _bounds; }
            set {
                if (base.Running) {
                    throw new Exception("Cannot change the bounds while a capture is in progress.");
                }
                _bounds = value;
            }
        }
    }
}
