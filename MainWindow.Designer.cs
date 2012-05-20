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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this._folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this._trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._stypeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._intervalNum)).BeginInit();
            this._trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _notifyIco
            // 
            this._notifyIco.ContextMenuStrip = this._trayMenu;
            this._notifyIco.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIco.Icon")));
            this._notifyIco.Visible = true;
            this._notifyIco.DoubleClick += new System.EventHandler(this.NotifyIcoDoubleClick);
            // 
            // _dirTxt
            // 
            this._dirTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dirTxt.Location = new System.Drawing.Point(127, 12);
            this._dirTxt.Name = "_dirTxt";
            this._dirTxt.Size = new System.Drawing.Size(300, 20);
            this._dirTxt.TabIndex = 0;
            // 
            // _browseBtn
            // 
            this._browseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._browseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._browseBtn.Location = new System.Drawing.Point(433, 12);
            this._browseBtn.Name = "_browseBtn";
            this._browseBtn.Size = new System.Drawing.Size(25, 20);
            this._browseBtn.TabIndex = 1;
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
            this.label1.TabIndex = 2;
            this.label1.Text = "Screenshot directory:";
            // 
            // _stypeGroup
            // 
            this._stypeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._stypeGroup.Controls.Add(this._bmpRad);
            this._stypeGroup.Controls.Add(this._pngRad);
            this._stypeGroup.Controls.Add(this._jpgRad);
            this._stypeGroup.Location = new System.Drawing.Point(15, 38);
            this._stypeGroup.Name = "_stypeGroup";
            this._stypeGroup.Size = new System.Drawing.Size(412, 88);
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
            this._bmpRad.TabStop = true;
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
            this._pngRad.TabStop = true;
            this._pngRad.Text = "PNG";
            this._pngRad.UseVisualStyleBackColor = true;
            // 
            // _jpgRad
            // 
            this._jpgRad.AutoSize = true;
            this._jpgRad.Location = new System.Drawing.Point(6, 19);
            this._jpgRad.Name = "_jpgRad";
            this._jpgRad.Size = new System.Drawing.Size(45, 17);
            this._jpgRad.TabIndex = 0;
            this._jpgRad.TabStop = true;
            this._jpgRad.Text = "JPG";
            this._jpgRad.UseVisualStyleBackColor = true;
            // 
            // _intervalNum
            // 
            this._intervalNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._intervalNum.Location = new System.Drawing.Point(127, 132);
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
            this._intervalNum.TabIndex = 4;
            this._intervalNum.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Interval (seconds):";
            // 
            // _startBtn
            // 
            this._startBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._startBtn.Location = new System.Drawing.Point(271, 238);
            this._startBtn.Name = "_startBtn";
            this._startBtn.Size = new System.Drawing.Size(75, 23);
            this._startBtn.TabIndex = 6;
            this._startBtn.Text = "Start";
            this._startBtn.UseVisualStyleBackColor = true;
            this._startBtn.Click += new System.EventHandler(this.StartBtnClick);
            // 
            // _stopBtn
            // 
            this._stopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._stopBtn.Enabled = false;
            this._stopBtn.Location = new System.Drawing.Point(352, 238);
            this._stopBtn.Name = "_stopBtn";
            this._stopBtn.Size = new System.Drawing.Size(75, 23);
            this._stopBtn.TabIndex = 7;
            this._stopBtn.Text = "Stop";
            this._stopBtn.UseVisualStyleBackColor = true;
            this._stopBtn.Click += new System.EventHandler(this.StopBtnClick);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(127, 158);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(300, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "{0}{1}{2}_{3}{4}{5}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Filename format:";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(433, 158);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 20);
            this.button4.TabIndex = 10;
            this.button4.Text = "?";
            this.button4.UseVisualStyleBackColor = true;
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 273);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this._stopBtn);
            this.Controls.Add(this._startBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._intervalNum);
            this.Controls.Add(this._stypeGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._browseBtn);
            this.Controls.Add(this._dirTxt);
            this.Name = "MainWindow";
            this.Text = "DevCap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindowFormClosing);
            this._stypeGroup.ResumeLayout(false);
            this._stypeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._intervalNum)).EndInit();
            this._trayMenu.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowser;
        private System.Windows.Forms.ContextMenuStrip _trayMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

