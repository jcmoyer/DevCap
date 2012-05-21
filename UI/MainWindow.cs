/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using DevCap.Imaging;
using DevCap.Properties;

namespace DevCap.UI {
    public partial class MainWindow : Form {
        private ScreenCapturer _cap;
        private readonly List<RadioButton> _formatRads = new List<RadioButton>();

        public MainWindow() {
            InitializeComponent();

            _jpgRad.Tag = new JpegWriter();
            _pngRad.Tag = new PngWriter();
            _bmpRad.Tag = new BmpWriter();
            foreach (Control c in _stypeGroup.Controls) {
                if (c is RadioButton && c.Tag is IImageWriter) _formatRads.Add((RadioButton)c);
            }

            PopulateSettings();
        }

        private ImageFormat SelectedFormat {
            get {
                if (_jpgRad.Checked) {
                    return ImageFormat.Jpeg;
                }
                if (_pngRad.Checked) {
                    return ImageFormat.Png;
                }
                if (_bmpRad.Checked) {
                    return ImageFormat.Bmp;
                }
                // Default to jpeg
                return ImageFormat.Jpeg;
            }
        }

        private string Directory {
            get { return _dirTxt.Text; }
        }

        private double Interval {
            get { return (double)_intervalNum.Value; }
        }

        private string Format {
            get { return _fmtTxt.Text; }
        }

        private bool IsCaptureAreaValid {
            get {
                int r;
                if (!Int32.TryParse(_capXTxt.Text, out r)) {
                    return false;
                }
                if (!Int32.TryParse(_capYTxt.Text, out r)) {
                    return false;
                }
                if (!Int32.TryParse(_capWTxt.Text, out r)) {
                    return false;
                }
                if (!Int32.TryParse(_capHTxt.Text, out r)) {
                    return false;
                }
                return true;
            }
        }

        private Rectangle CaptureArea {
            get {
                return new Rectangle(
                    Int32.Parse(_capXTxt.Text),
                    Int32.Parse(_capYTxt.Text),
                    Int32.Parse(_capWTxt.Text),
                    Int32.Parse(_capHTxt.Text));
            }
            set {
                _capXTxt.Text = value.X.ToString(CultureInfo.InvariantCulture);
                _capYTxt.Text = value.Y.ToString(CultureInfo.InvariantCulture);
                _capWTxt.Text = value.Width.ToString(CultureInfo.InvariantCulture);
                _capHTxt.Text = value.Height.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void PopulateSettings() {
            if (String.IsNullOrWhiteSpace(Settings.Default.Directory)) {
                SetDefaultDirectory();
            } else {
                _dirTxt.Text = Settings.Default.Directory;
            }

            if (String.IsNullOrWhiteSpace(Settings.Default.Format)) {
                _fmtTxt.Text = ScreenCapturer.DefaultFormatString;
            } else {
                _fmtTxt.Text = Settings.Default.Format;
            }

            decimal interval = (decimal)Settings.Default.Interval;
            if (interval < _intervalNum.Minimum) {
                Settings.Default.Interval = (double)_intervalNum.Minimum;
            } else if (interval > _intervalNum.Maximum) {
                Settings.Default.Interval = (double)_intervalNum.Maximum;
            }
            _intervalNum.Value = (decimal)Settings.Default.Interval;

            foreach (RadioButton rad in _formatRads) {
                if (rad.Text.Equals(Settings.Default.ScreenshotType, StringComparison.OrdinalIgnoreCase)) {
                    rad.Checked = true;
                    break;
                }
            }

            PopulateScreens();

            // If a configured screen is provided, try to select it. SelectScreen will
            // not do anything if the screen does not exist.
            if (!String.IsNullOrWhiteSpace(Settings.Default.CaptureDevice)) {
                SelectScreen(Settings.Default.CaptureDevice);
            }

            _includeTaskbarChk.Checked = Settings.Default.IncludeTaskbar;

            if (Settings.Default.CaptureArea != Rectangle.Empty) {
                CaptureArea = Settings.Default.CaptureArea;
            }

            _compress.Checked = Settings.Default.Compress;
        }

        private void PopulateScreens() {
            // If the user has multiple monitors, add an option for their combined space.
            if (Screen.AllScreens.Length > 1) {
                _screensBox.Items.Add(new ScreenInfo("All Monitors", SystemInformation.VirtualScreen, SystemInformation.VirtualScreen));
            }
            
            foreach (var screen in Screen.AllScreens) {
                _screensBox.Items.Add(new ScreenInfo(screen));
            }
            _screensBox.SelectedIndex = 0;
        }

        private void SelectScreen(string name) {
            foreach (ScreenInfo si in _screensBox.Items) {
                if (si.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) {
                    _screensBox.SelectedItem = si;
                    break;
                }
            }
        }

        private void SetDefaultDirectory() {
            foreach (var di in DriveInfo.GetDrives()) {
                if (di.DriveType == DriveType.Fixed) {
                    _dirTxt.Text = Path.Combine(di.RootDirectory.FullName, "DevCap");
                    break;
                }
            }
        }

        private ScreenCapturerParameters CreateCaptureParams() {
            IImageWriter writer = null;

            foreach (RadioButton rad in _formatRads) {
                if (rad.Checked) writer = (IImageWriter)rad.Tag;
            }

            if (writer == null) {
                return null;
            }

            return new ScreenCapturerParameters(_dirTxt.Text, _fmtTxt.Text, CaptureArea, writer, _compress.Checked);
        }

        private void StartBtnClick(object sender, EventArgs e) {
            if (_cap == null) {
                if (!IsCaptureAreaValid) {
                    MessageBox.Show("The capture area is not valid.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ScreenCapturerParameters param = CreateCaptureParams();
                if (param != null) {
                    _cap = new ScreenCapturer(param) {
                        Interval = TimeSpan.FromSeconds(Convert.ToDouble(_intervalNum.Value))
                    };
                } else {
                    MessageBox.Show("You must select an image format.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            try {
                _cap.Start();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _startBtn.Enabled = false;
            _stopBtn.Enabled = true;
            stopToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Enabled = false;

            EnableSettings(false);
        }

        private void EnableSettings(bool state) {
            _dirTxt.Enabled = state;
            _browseBtn.Enabled = state;
            _stypeGroup.Enabled = state;
            _intervalNum.Enabled = state;
            _fmtTxt.Enabled = state;
            _capAreaGrp.Enabled = state;
        }

        private void StopBtnClick(object sender, EventArgs e) {
            StopCapture();
        }

        private void StopCapture() {
            if (_cap != null) {
                _cap.Stop();
                _cap = null;
            }
            _stopBtn.Enabled = false;
            _startBtn.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = true;
            EnableSettings(true);
        }

        private void BrowseBtnClick(object sender, EventArgs e) {
            var dr = _folderBrowser.ShowDialog();
            if (dr == DialogResult.OK) {
                _dirTxt.Text = _folderBrowser.SelectedPath;
            }
        }

        private void ShowToolStripMenuItemClick(object sender, EventArgs e) {
            Show();
        }

        private void StartToolStripMenuItemClick(object sender, EventArgs e) {
            StartBtnClick(sender, e);
        }

        private void StopToolStripMenuItemClick(object sender, EventArgs e) {
            StopBtnClick(sender, e);
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e) {
            Application.Exit();
        }

        private void ApplySettings() {
            Settings.Default.Directory = Directory;
            Settings.Default.Format = Format;
            Settings.Default.Interval = Interval;
            Settings.Default.ScreenshotType = SelectedFormat.ToString();
            Settings.Default.Compress = _compress.Checked;

            ScreenInfo si = _screensBox.SelectedItem as ScreenInfo;
            if (si != null) {
                Settings.Default.CaptureDevice = si.Name;
            }
            if (IsCaptureAreaValid) {
                Settings.Default.CaptureArea = CaptureArea;
            }
            Settings.Default.IncludeTaskbar = _includeTaskbarChk.Checked;
        }

        private void MainWindowFormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.ApplicationExitCall) {
                ApplySettings();
                return;
            }

            e.Cancel = true;
            Hide();

            if (!Settings.Default.NotifiedUser) {
                _notifyIco.ShowBalloonTip(5000, Application.ProductName, "DevCap will continue running in the tray here. Right click the icon for various commands.", ToolTipIcon.Info);
                Settings.Default.NotifiedUser = true;
            }
        }

        private void NotifyIcoDoubleClick(object sender, EventArgs e) {
            Show();
        }

        private void FmtHelpBtnClick(object sender, EventArgs e) {
            MessageBox.Show(
@"Format variables:

$YEAR
$MONTH
$DAY
$HOUR
$MINUTE
$SECOND
$NUMBER

If no format string is given, it will default to:
" + ScreenCapturer.DefaultFormatString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitBtnClick(object sender, EventArgs e) {
            Application.Exit();
        }

        private void ScreensBoxSelectedValueChanged(object sender, EventArgs e) {
            SetCaptureAreaValues();
        }

        private void IncludeTaskbarChkCheckedChanged(object sender, EventArgs e) {
            SetCaptureHeightValue();
        }

        private void SetCaptureHeightValue() {
            ScreenInfo info = (ScreenInfo)_screensBox.SelectedItem;
            if (_includeTaskbarChk.Checked) {
                _capHTxt.Text = info.Bounds.Height.ToString(CultureInfo.InvariantCulture);
            } else {
                _capHTxt.Text = info.WorkingArea.Height.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void SetCaptureAreaValues() {
            ScreenInfo info = (ScreenInfo)_screensBox.SelectedItem;
            if (_includeTaskbarChk.Checked) {
                _capXTxt.Text = info.Bounds.X.ToString(CultureInfo.InvariantCulture);
                _capYTxt.Text = info.Bounds.Y.ToString(CultureInfo.InvariantCulture);
                _capWTxt.Text = info.Bounds.Width.ToString(CultureInfo.InvariantCulture);
                _capHTxt.Text = info.Bounds.Height.ToString(CultureInfo.InvariantCulture);
            } else {
                _capXTxt.Text = info.WorkingArea.X.ToString(CultureInfo.InvariantCulture);
                _capYTxt.Text = info.WorkingArea.Y.ToString(CultureInfo.InvariantCulture);
                _capWTxt.Text = info.WorkingArea.Width.ToString(CultureInfo.InvariantCulture);
                _capHTxt.Text = info.WorkingArea.Height.ToString(CultureInfo.InvariantCulture);
            }
        }

        private IImageWriter SelectedWriter {
            get {
                foreach (var rad in _formatRads) {
                    if (rad.Checked) return (IImageWriter)rad.Tag;
                }
                return null;
            }
        }

        private void SettingsButtonClick(object sender, EventArgs e) {
            ConfigurationWindow config = new ConfigurationWindow();
            config.SelectedObject = SelectedWriter;
            config.ShowDialog();
        }

        private void TypeRadioCheckedChanged(object sender, EventArgs e) {
            RadioButton r = (RadioButton)sender;
            // Make settings button follow the selected radio button
            _settingsBtn.Location = new Point(_settingsBtn.Location.X, r.Location.Y - 3);
        }
    }
}
