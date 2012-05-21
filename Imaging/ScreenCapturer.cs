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
using System.Threading;
using System.Windows.Forms;
using DevCap.SevenZip.Compress.LZMA;
using LzmaEncoder = DevCap.SevenZip.Compress.LZMA.Encoder;

namespace DevCap.Imaging {
    class ScreenshotWork {
        private readonly IImageWriter _writer;
        private readonly Image _toWrite;

        public ScreenshotWork(IImageWriter writer, Image toWrite) {
            _writer = writer;
            _toWrite = toWrite;
        }

        public IImageWriter Writer {
            get { return _writer; }
        }

        public Image ToWrite {
            get { return _toWrite; }
        }

        public void Write(Stream dest) {
            _writer.Write(_toWrite, dest);
        }
    }

    class ScreenshotWorker {
        private readonly object _locker = new object();
        private readonly Thread _thread;
        private readonly Queue<ScreenshotWork> _itemQ = new Queue<ScreenshotWork>();
        private readonly LzmaEncoder _encoder = new LzmaEncoder();
        private readonly string _filename;
        private FileStream _fs;

        public ScreenshotWorker(string filename) {
            _filename = filename;
            _thread = new Thread(Consume);
        }

        public void Enqueue(ScreenshotWork item) {
            lock (_locker) {
                _itemQ.Enqueue(item);
                Monitor.Pulse(_locker);
            }
        }

        public void Start() {
            if (_fs != null) {
                _fs.Close();
                _fs = null;
            }
            _fs = File.OpenWrite(_filename);

            _thread.Start();
        }

        public void Stop(bool wait) {
            Enqueue(null);
            if (wait) {
                _thread.Join();
            }
            if (_fs != null) {
                _fs.Close();
                _fs = null;
            }
        }

        private void Consume() {
            using (MemoryStream buffer = new MemoryStream()) {
                while (true) {
                    ScreenshotWork item;
                    lock (_locker) {
                        while (_itemQ.Count == 0) Monitor.Wait(_locker);
                        item = _itemQ.Dequeue();
                    }
                    if (item == null) return;

                    item.Write(buffer);
                    buffer.Seek(0, SeekOrigin.Begin);
                    long inSize;
                    long outSize;
                    bool finished = false;

                    BinaryWriter writer = new BinaryWriter(buffer);
                    writer.Write(0L);

                    while (!finished) {
                        _encoder.CodeOneBlock(out inSize, out outSize, out finished);
                    }

                    buffer.Seek(0, SeekOrigin.Begin);
                    buffer.SetLength(0);
                }
            }
        }
    }

    class ScreenCapturer : PeriodicTask {
        public const string DefaultFormatString = "$YEAR$MONTH$DAY_$HOUR$MINUTE$SECOND";

        private readonly ScreenCapturerParameters _params;
        private readonly ScreenshotWorker _worker;

        private readonly MemoryStream _compressionStream = new MemoryStream();
        private readonly LzmaEncoder _encoder = new LzmaEncoder();

        private long _number;

        public ScreenCapturer(ScreenCapturerParameters param) {
            _params = param;
            //_worker = new ScreenshotWorker(CreateFilename());
        }

        protected override void OnStart() {
            if (!Directory.Exists(_params.Directory)) {
                Directory.CreateDirectory(_params.Directory);
            }
            Interlocked.Exchange(ref _number, 0);

            //if (_params.Compress) _worker.Start();
        }

        protected override void OnStop() {
            //if (_params.Compress) _worker.Stop(true);
        }

        public static Image Capture(Rectangle bounds) {
            Bitmap buffer = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(buffer)) {
                g.CopyFromScreen(bounds.Location, new Point(), bounds.Size);
                if (Cursor.Current != null) {
                    Point cursorDest = Cursor.Position;
                    cursorDest.X -= Cursor.Current.HotSpot.X;
                    cursorDest.Y -= Cursor.Current.HotSpot.Y;
                    cursorDest.X -= bounds.X;
                    cursorDest.Y -= bounds.Y;
                    Cursors.Default.Draw(g, new Rectangle(cursorDest, Cursor.Current.Size));
                }
            }
            return buffer;
        }

        private string CreateFilename() {
            var now = DateTime.Now;
            string filename = _params.FormatString
                .Replace("$YEAR", now.Year.ToString("D4"))
                .Replace("$MONTH", now.Month.ToString("D2"))
                .Replace("$DAY", now.Day.ToString("D2"))
                .Replace("$HOUR", now.Hour.ToString("D2"))
                .Replace("$MINUTE", now.Minute.ToString("D2"))
                .Replace("$SECOND", now.Second.ToString("D2"))
                .Replace("$NUMBER", Interlocked.Increment(ref _number).ToString("D8"));

            if (_params.Compress) {
                filename += ".lzma";
            } else {
                filename += "." + _params.Writer.Extension;
            }

            return Path.Combine(_params.Directory, filename);
        }

        protected override void Run() {
            using (Image screen = Capture(_params.Bounds)) {
                if (_params.Compress) {
                    WriteCompressedFile(screen);
                } else {
                    WriteFile(screen);
                }   
            }
        }

        private void WriteFile(Image screenshot) {
            using (var stream = File.OpenWrite(CreateFilename())) {
                _params.Writer.Write(screenshot, stream);
            }
        }

        private void WriteCompressedFile(Image screenshot) {
            _params.Writer.Write(screenshot, _compressionStream);
            // Rewind stream
            _compressionStream.Seek(0, SeekOrigin.Begin);
            // LZMA encode from memory to file
            using (var stream = File.OpenWrite(CreateFilename())) {
                _encoder.Code(_compressionStream, stream, -1, -1, null);
            }
            // Flip stream
            _compressionStream.Seek(0, SeekOrigin.Begin);
            _compressionStream.SetLength(0);
        }
    }
}
