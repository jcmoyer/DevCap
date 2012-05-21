namespace DevCap {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this._notifyIco = new System.Windows.Forms.NotifyIcon(this.components);
            this._trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._dirTxt = new System.Windows.Forms.TextBox();
            this._browseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._stypeGroup = new System.Windows.Forms.GroupBox();
            this._bmpRad = new System.Windows.Forms.RadioButton();
            this._pngRad = new System.Windows.Forms.RadioButton();
            this._jpgRad = new System.Windows.Forms.RadioButton();
            this._intervalNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this._startBtn = new System.Windows.Forms.Button();
            this._stopBtn = new System.Windows.Forms.Button();
            this._fmtTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._fmtHelpBtn = new System.Windows.Forms.Button();
            this._folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this._exitBtn = new System.Windows.Forms.Button();
            this._capAreaGrp = new System.Windows.Forms.GroupBox();
            this._capXTxt = new System.Windows.Forms.TextBox();
            this._includeTaskbarChk = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this._capHTxt = new System.Windows.Forms.TextBox();
            this._capWTxt = new System.Windows.Forms.TextBox();
            this._capYTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._screensBox = new System.Windows.Forms.ComboBox();
            this._trayMenu.SuspendLayout();
            this._stypeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._intervalNum)).BeginInit();
            this._capAreaGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _notifyIco
            // 
            this._notifyIco.ContextMenuStrip = this._trayMenu;
            this._notifyIco.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIco.Icon")));
            this._notifyIco.Visible = true;
            this._notifyIco.DoubleClick += new System.EventHandler(this.NotifyIcoDoubleClick);
            // 
            // _trayMenu
            // 
            this._trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripMenuItem1,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this._trayMenu.Name = "_trayMenu";
            this._trayMenu.Size = new System.Drawing.Size(101, 104);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 6);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItemClick);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItemClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(97, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // _dirTxt
            // 
            this._dirTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dirTxt.Location = new System.Drawing.Point(127, 12);
            this._dirTxt.Name = "_dirTxt";
            this._dirTxt.Size = new System.Drawing.Size(300, 20);
            this._dirTxt.TabIndex = 1;
            // 
            // _browseBtn
            // 
            this._browseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._browseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._browseBtn.Location = new System.Drawing.Point(433, 12);
            this._browseBtn.Name = "_browseBtn";
            this._browseBtn.Size = new System.Drawing.Size(25, 20);
            this._browseBtn.TabIndex = 2;
            this._browseBtn.Text = "...";
            this._browseBtn.UseVisualStyleBackColor = true;
            this._browseBtn.Click += new System.EventHandler(this.BrowseBtnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Screenshot directory:";
            // 
            // _stypeGroup
            // 
            this._stypeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._stypeGroup.Controls.Add(this._bmpRad);
            this._stypeGroup.Controls.Add(this._pngRad);
            this._stypeGroup.Controls.Add(this._jpgRad);
            this._stypeGroup.Location = new System.Drawing.Point(15, 38);
            this._stypeGroup.Name = "_stypeGroup";
            this._stypeGroup.Size = new System.Drawing.Size(106, 95);
            this._stypeGroup.TabIndex = 3;
            this._stypeGroup.TabStop = false;
            this._stypeGroup.Text = "Screenshot Type";
            // 
            // _bmpRad
            // 
            this._bmpRad.AutoSize = true;
            this._bmpRad.Location = new System.Drawing.Point(6, 65);
            this._bmpRad.Name = "_bmpRad";
            this._bmpRad.Size = new System.Drawing.Size(48, 17);
            this._bmpRad.TabIndex = 2;
            this._bmpRad.Text = "BMP";
            this._bmpRad.UseVisualStyleBackColor = true;
            // 
            // _pngRad
            // 
            this._pngRad.AutoSize = true;
            this._pngRad.Location = new System.Drawing.Point(6, 42);
            this._pngRad.Name = "_pngRad";
            this._pngRad.Size = new System.Drawing.Size(48, 17);
            this._pngRad.TabIndex = 1;
            this._pngRad.Text = "PNG";
            this._pngRad.UseVisualStyleBackColor = true;
            // 
            // _jpgRad
            // 
            this._jpgRad.AutoSize = true;
            this._jpgRad.Checked = true;
            this._jpgRad.Location = new System.Drawing.Point(6, 19);
            this._jpgRad.Name = "_jpgRad";
            this._jpgRad.Size = new System.Drawing.Size(45, 17);
            this._jpgRad.TabIndex = 0;
            this._jpgRad.TabStop = true;
            this._jpgRad.Tag = "";
            this._jpgRad.Text = "JPG";
            this._jpgRad.UseVisualStyleBackColor = true;
            // 
            // _intervalNum
            // 
            this._intervalNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._intervalNum.Location = new System.Drawing.Point(127, 139);
            this._intervalNum.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this._intervalNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._intervalNum.Name = "_intervalNum";
            this._intervalNum.Size = new System.Drawing.Size(300, 20);
            this._intervalNum.TabIndex = 6;
            this._intervalNum.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Interval (seconds):";
            // 
            // _startBtn
            // 
            this._startBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._startBtn.Location = new System.Drawing.Point(271, 203);
            this._startBtn.Name = "_startBtn";
            this._startBtn.Size = new System.Drawing.Size(75, 23);
            this._startBtn.TabIndex = 11;
            this._startBtn.Text = "Start";
            this._startBtn.UseVisualStyleBackColor = true;
            this._startBtn.Click += new System.EventHandler(this.StartBtnClick);
            // 
            // _stopBtn
            // 
            this._stopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._stopBtn.Enabled = false;
            this._stopBtn.Location = new System.Drawing.Point(352, 203);
            this._stopBtn.Name = "_stopBtn";
            this._stopBtn.Size = new System.Drawing.Size(75, 23);
            this._stopBtn.TabIndex = 12;
            this._stopBtn.Text = "Stop";
            this._stopBtn.UseVisualStyleBackColor = true;
            this._stopBtn.Click += new System.EventHandler(this.StopBtnClick);
            // 
            // _fmtTxt
            // 
            this._fmtTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._fmtTxt.Location = new System.Drawing.Point(127, 165);
            this._fmtTxt.Name = "_fmtTxt";
            this._fmtTxt.Size = new System.Drawing.Size(300, 20);
            this._fmtTxt.TabIndex = 8;
            this._fmtTxt.Text = "$YEAR$MONTH$DAY_$HOUR$MINUTE$SECOND";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filename format:";
            // 
            // _fmtHelpBtn
            // 
            this._fmtHelpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._fmtHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._fmtHelpBtn.Location = new System.Drawing.Point(433, 165);
            this._fmtHelpBtn.Name = "_fmtHelpBtn";
            this._fmtHelpBtn.Size = new System.Drawing.Size(25, 20);
            this._fmtHelpBtn.TabIndex = 9;
            this._fmtHelpBtn.Text = "?";
            this._fmtHelpBtn.UseVisualStyleBackColor = true;
            this._fmtHelpBtn.Click += new System.EventHandler(this.FmtHelpBtnClick);
            // 
            // _exitBtn
            // 
            this._exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._exitBtn.Location = new System.Drawing.Point(12, 203);
            this._exitBtn.Name = "_exitBtn";
            this._exitBtn.Size = new System.Drawing.Size(75, 23);
            this._exitBtn.TabIndex = 10;
            this._exitBtn.Text = "Exit";
            this._exitBtn.UseVisualStyleBackColor = true;
            this._exitBtn.Click += new System.EventHandler(this.ExitBtnClick);
            // 
            // _capAreaGrp
            // 
            this._capAreaGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._capAreaGrp.Controls.Add(this._capXTxt);
            this._capAreaGrp.Controls.Add(this._includeTaskbarChk);
            this._capAreaGrp.Controls.Add(this.label5);
            this._capAreaGrp.Controls.Add(this._capHTxt);
            this._capAreaGrp.Controls.Add(this._capWTxt);
            this._capAreaGrp.Controls.Add(this._capYTxt);
            this._capAreaGrp.Controls.Add(this.label4);
            this._capAreaGrp.Controls.Add(this._screensBox);
            this._capAreaGrp.Location = new System.Drawing.Point(127, 38);
            this._capAreaGrp.Name = "_capAreaGrp";
            this._capAreaGrp.Size = new System.Drawing.Size(300, 95);
            this._capAreaGrp.TabIndex = 4;
            this._capAreaGrp.TabStop = false;
            this._capAreaGrp.Text = "Capture Area";
            // 
            // _capXTxt
            // 
            this._capXTxt.Location = new System.Drawing.Point(56, 46);
            this._capXTxt.Name = "_capXTxt";
            this._capXTxt.Size = new System.Drawing.Size(55, 20);
            this._capXTxt.TabIndex = 3;
            // 
            // _includeTaskbarChk
            // 
            this._includeTaskbarChk.AutoSize = true;
            this._includeTaskbarChk.Location = new System.Drawing.Point(56, 72);
            this._includeTaskbarChk.Name = "_includeTaskbarChk";
            this._includeTaskbarChk.Size = new System.Drawing.Size(99, 17);
            this._includeTaskbarChk.TabIndex = 7;
            this._includeTaskbarChk.Text = "Include taskbar";
            this._includeTaskbarChk.UseVisualStyleBackColor = true;
            this._includeTaskbarChk.CheckedChanged += new System.EventHandler(this.IncludeTaskbarChkCheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "XYWH:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _capHTxt
            // 
            this._capHTxt.Location = new System.Drawing.Point(239, 46);
            this._capHTxt.Name = "_capHTxt";
            this._capHTxt.Size = new System.Drawing.Size(55, 20);
            this._capHTxt.TabIndex = 6;
            // 
            // _capWTxt
            // 
            this._capWTxt.Location = new System.Drawing.Point(178, 46);
            this._capWTxt.Name = "_capWTxt";
            this._capWTxt.Size = new System.Drawing.Size(55, 20);
            this._capWTxt.TabIndex = 5;
            // 
            // _capYTxt
            // 
            this._capYTxt.Location = new System.Drawing.Point(117, 46);
            this._capYTxt.Name = "_capYTxt";
            this._capYTxt.Size = new System.Drawing.Size(55, 20);
            this._capYTxt.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Screen:";
            // 
            // _screensBox
            // 
            this._screensBox.FormattingEnabled = true;
            this._screensBox.Location = new System.Drawing.Point(56, 19);
            this._screensBox.Name = "_screensBox";
            this._screensBox.Size = new System.Drawing.Size(238, 21);
            this._screensBox.TabIndex = 1;
            this._screensBox.SelectedValueChanged += new System.EventHandler(this.ScreensBoxSelectedValueChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 238);
            this.Controls.Add(this._capAreaGrp);
            this.Controls.Add(this._exitBtn);
            this.Controls.Add(this._fmtHelpBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._fmtTxt);
            this.Controls.Add(this._stopBtn);
            this.Controls.Add(this._startBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._intervalNum);
            this.Controls.Add(this._stypeGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._browseBtn);
            this.Controls.Add(this._dirTxt);
            this.MinimumSize = new System.Drawing.Size(478, 265);
            this.Name = "MainWindow";
            this.Text = "DevCap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindowFormClosing);
            this._trayMenu.ResumeLayout(false);
            this._stypeGroup.ResumeLayout(false);
            this._stypeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._intervalNum)).EndInit();
            this._capAreaGrp.ResumeLayout(false);
            this._capAreaGrp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon _notifyIco;
        private System.Windows.Forms.TextBox _dirTxt;
        private System.Windows.Forms.Button _browseBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox _stypeGroup;
        private System.Windows.Forms.RadioButton _bmpRad;
        private System.Windows.Forms.RadioButton _pngRad;
        private System.Windows.Forms.RadioButton _jpgRad;
        private System.Windows.Forms.NumericUpDown _intervalNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _startBtn;
        private System.Windows.Forms.Button _stopBtn;
        private System.Windows.Forms.TextBox _fmtTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _fmtHelpBtn;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowser;
        private System.Windows.Forms.ContextMenuStrip _trayMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button _exitBtn;
        private System.Windows.Forms.GroupBox _capAreaGrp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _screensBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _capHTxt;
        private System.Windows.Forms.TextBox _capWTxt;
        private System.Windows.Forms.TextBox _capYTxt;
        private System.Windows.Forms.CheckBox _includeTaskbarChk;
        private System.Windows.Forms.TextBox _capXTxt;
    }
}

