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
using LzmaEncoder = DevCap.SevenZip.Compress.LZMA.Encoder;

namespace DevCap {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            var cl = CommandLine.Parse<CommandLineArgs>(args);

            if (cl.Operation != null) {
                try {
                    PerformOperation(cl);
                } catch (Exception ex) {
                    Report.Error(ex.Message);
                }
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (MainWindow window = new MainWindow()) {
                Application.Run(window);
                Settings.Default.Save();
            }
        }

        private static void PerformOperation(CommandLineArgs t) {
            switch (t.Operation.ToLowerInvariant()) {
                case "extract":
                    TryExtract(t.Directory);
                    break;
                case "optimize":
                    TryOptimize(t.Directory, t.File);
                    break;
                case "unpack":
                    TryUnpack(t.File, t.Directory);
                    break;
            }
        }

        private static void TryExtract(string directory) {
            if (Directory.Exists(directory)) {
                LzmaDecoder decoder = new LzmaDecoder();
                ProcessDirectory(directory, fn => ExtractFile(fn, decoder));
            }
        }

        private static void TryOptimize(string directory, string filename) {
            filename = filename ?? "optimized.lzmo";
            if (Directory.Exists(directory)) {
                Lzma.Pack(directory, Path.Combine(directory, filename));
            }
        }

        private static void TryUnpack(string filename, string directory) {
            if (File.Exists(filename)) {
                FileInfo fi = new FileInfo(filename);
                Lzma.Unpack(filename, fi.DirectoryName);
            }
        }

        private static void ProcessDirectory(string directory, Action<string> processor) {
            foreach (var f in Directory.GetFiles(directory, "*.lzma")) {
                processor(f);
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
