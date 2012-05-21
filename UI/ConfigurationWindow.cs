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
