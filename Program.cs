/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
using System;
using System.IO;
using System.Windows.Forms;
using DevCap.Properties;
using DevCap.UI;
using DevCap.Utilities;
using LzmaDecoder = DevCap.SevenZip.Compress.LZMA.Decoder;

namespace DevCap {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            if (ProcessArguments(args)) {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (MainWindow window = new MainWindow()) {
                Application.Run(window);
                Settings.Default.Save();
            }
        }

        private static bool ProcessArguments(string[] args) {
            bool any = false;
            for (var i = 0; i < args.Length; i++) {
                Switch o;
                if (TryGetSwitch(args, i, out o)) {
                    any = true;

                    switch (o.Name) {
                        case "x":
                            if (Directory.Exists(o.Value)) ProcessDirectory(o.Value);
                            break;
                        default:
                            break;
                    }

                    i++;
                }
            }
            return any;
        }

        private static bool TryGetSwitch(string[] args, int at, out Switch o) {
            if (at < args.Length &&args[at].StartsWith("/")) {
                string name = args[at].TrimStart('/');
                if (at + 1 < args.Length) {
                    string value = args[at + 1];
                    o = new Switch(name, value);
                    return true;
                }
            }
            o = null;
            return false;
        }

        private static void ProcessDirectory(string directory) {
            LzmaDecoder decoder = new LzmaDecoder();
            foreach (var f in Directory.GetFiles(directory, "*.lzma")) {
                ExtractFile(f, decoder);
            }
        }

        private static void ExtractFile(string f, LzmaDecoder decoder) {
            using (var input = File.OpenRead(f)) {
                long uncompressedLength = Lzma.PrepareDecoder(decoder, input);
                using (var output = File.OpenWrite(f.Remove(f.Length - 5)))
                    decoder.Code(input, output, input.Length, uncompressedLength, null);
            }
        }
    }
}
