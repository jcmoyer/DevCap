/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */ 
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
            stopToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Enabled = false;
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

        private void MainWindowFormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }

        private void NotifyIcoDoubleClick(object sender, EventArgs e) {
            Show();
        }
    }
}
