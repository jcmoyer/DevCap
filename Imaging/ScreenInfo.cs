/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System.Drawing;
using System.Windows.Forms;

namespace DevCap.Imaging {
    class ScreenInfo {
        private readonly Rectangle _bounds;
        private readonly string _name;
        private readonly Rectangle _workingArea;

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
