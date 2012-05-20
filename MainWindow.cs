using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevCap {
    public partial class MainWindow : Form {
        private ScreenCapturer _cap;

        public MainWindow() {
            InitializeComponent();
        }

        private void StartBtnClick(object sender, EventArgs e) {
            StopCapture();
            if (_cap == null) {
                _cap = new ScreenCapturer(_dirTxt.Text, SelectedFormat) {
                    Interval = TimeSpan.FromSeconds(Convert.ToDouble(_intervalNum.Value))
                };
            }
            _cap.Start();

            _startBtn.Enabled = false;
            _stopBtn.Enabled = true;
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
        }

        private ImageFormat SelectedFormat {
            get {
                if (_jpgRad.Checked) {
                    return ImageFormat.Jpeg;
                } else if (_pngRad.Checked) {
                    return ImageFormat.Png;
                } else if (_bmpRad.Checked) {
                    return ImageFormat.Bmp;
                } else {
                    return ImageFormat.Jpeg;
                }
            }
        }

        private void BrowseBtnClick(object sender, EventArgs e) {
            var dr = _folderBrowser.ShowDialog();
            if (dr == DialogResult.OK) {
                _dirTxt.Text = _folderBrowser.SelectedPath;
            }
        }
    }
}
