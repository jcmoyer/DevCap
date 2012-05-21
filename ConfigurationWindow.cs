using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevCap {
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
