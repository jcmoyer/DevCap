/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System.Windows.Forms;

namespace DevCap.Utilities {
    static class Report {
        public static void Error(string text) {
            MessageBox.Show(text, Application.ProductName + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
