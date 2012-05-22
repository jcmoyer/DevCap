/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System.Windows.Forms;

namespace DevCap.UI {
    public partial class ConfigurationWindow : Form {
        public ConfigurationWindow() {
            InitializeComponent();
        }

        public object SelectedObject {
            get { return propertyGrid1.SelectedObject; }
            set { propertyGrid1.SelectedObject = value; }
        }
    }
}
