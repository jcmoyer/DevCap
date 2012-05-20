using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
// Because of conflict with property name.
using DirectoryClass = System.IO.Directory;

namespace DevCap {
    class ScreenCapturer : PeriodicTask {
        private readonly string _directory;
        private readonly ImageFormat _format;
        private Rectangle _bounds;
        private long _number;

        public ScreenCapturer(string directory, ImageFormat saveFormat) {
            _directory = directory;
            _format = saveFormat;
            _bounds = Screen.PrimaryScreen.Bounds;
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

            long thisNumber = Interlocked.Increment(ref _number);

            string filename = String.Format("{0:00000000}.{1}", thisNumber, _format.ToString());

            buffer.Save(Path.Combine(_directory, filename), _format);
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
