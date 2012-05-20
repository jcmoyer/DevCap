using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevCap {
    class ScreenInfo {
        private readonly string _name;
        private readonly Rectangle _workingArea;
        private readonly Rectangle _bounds;

        public ScreenInfo(Screen source) {
            _name = source.DeviceName;
            _workingArea = source.WorkingArea;
            _bounds = source.Bounds;
        }

        public ScreenInfo(string name, Rectangle workingArea, Rectangle bounds) {
            _name = name;
            _workingArea = workingArea;
            _bounds = bounds;
        }

        public string Name {
            get { return _name; }
        }

        public Rectangle WorkingArea {
            get { return _workingArea; }
        }

        public Rectangle Bounds {
            get { return _bounds; }
        }

        public override string ToString() {
            return _name;
        }
    }
}
