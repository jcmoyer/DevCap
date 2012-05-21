/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
// Because of conflict with property name.

namespace DevCap.Imaging {
    class ScreenCapturer : PeriodicTask {
        public const string DefaultFormatString = "$YEAR$MONTH$DAY_$HOUR$MINUTE$SECOND";

        private readonly ScreenCapturerParameters _params;

        private long _number;

        public ScreenCapturer(ScreenCapturerParameters param) {
            _params = param;
        }

        protected override void OnStart() {
            if (!Directory.Exists(_params.Directory)) {
                Directory.CreateDirectory(_params.Directory);
            }
            Interlocked.Exchange(ref _number, 0);
        }

        public static Image Capture(Rectangle bounds) {
            Bitmap buffer = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(buffer)) {
                g.CopyFromScreen(bounds.Location, new Point(), bounds.Size);
                if (Cursor.Current != null) {
                    Point cursorDest = Cursor.Position;
                    cursorDest.X -= Cursor.Current.HotSpot.X;
                    cursorDest.Y -= Cursor.Current.HotSpot.Y;
                    Cursors.Default.Draw(g, new Rectangle(cursorDest, Cursor.Current.Size));
                }
            }
            return buffer;
        }

        private string CreateFilename() {
            var now = DateTime.Now;
            return _params.FormatString
                .Replace("$YEAR", now.Year.ToString("D4"))
                .Replace("$MONTH", now.Month.ToString("D2"))
                .Replace("$DAY", now.Day.ToString("D2"))
                .Replace("$HOUR", now.Hour.ToString("D2"))
                .Replace("$MINUTE", now.Minute.ToString("D2"))
                .Replace("$SECOND", now.Second.ToString("D2"))
                .Replace("$NUMBER", Interlocked.Increment(ref _number).ToString("D8")) + "." + _params.Writer.Extension;
        }

        protected override void Run() {
            Image screen = Capture(_params.Bounds);
            string fn = Path.Combine(_params.Directory, CreateFilename());
            using (var stream = File.OpenWrite(fn)) {
                _params.Writer.Write(screen, stream);
            }
        }
    }
}
