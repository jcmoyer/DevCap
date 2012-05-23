/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System;
using System.Windows.Forms;

namespace DevCap.Utilities {
    static class Report {
        public static void Error(string text) {
            Message(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Info(string text) {
            Message(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Message(string text, string category, MessageBoxButtons buttons, MessageBoxIcon icon) {
            MessageBox.Show(text, String.Format("{0} - {1}", Application.ProductName, category), buttons, icon);
        }
    }
}
