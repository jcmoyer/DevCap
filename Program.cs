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
using LzmaDecoder = DevCap.SevenZip.Compress.LZMA.Decoder;

namespace DevCap {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            if (args.Length > 0 && Directory.Exists(args[0])) {
                LzmaDecoder decoder = new LzmaDecoder();
                foreach (var f in Directory.GetFiles(args[0], "*.lzma")) {
                    Console.WriteLine("Decoding {0}...", f);
                    using (var input = File.OpenRead(f)) {
                        byte[] props = new byte[5];
                        input.Read(props, 0, 5);
                        decoder.SetDecoderProperties(props);
                        byte[] fileLengthBytes = new byte[8];
                        input.Read(fileLengthBytes, 0, 8);
                        long fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

                        using (var output = File.OpenWrite(f.Replace(".lzma", String.Empty)))
                            decoder.Code(input, output, input.Length, fileLength, null);
                    }
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
    }
}
