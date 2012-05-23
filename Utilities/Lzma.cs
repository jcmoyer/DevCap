/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System;
using System.Collections.Generic;
using System.IO;
using LzmaEncoder = DevCap.SevenZip.Compress.LZMA.Encoder;
using LzmaDecoder = DevCap.SevenZip.Compress.LZMA.Decoder;

namespace DevCap.Utilities {
    static class Lzma {
        public static void WriteHeader(LzmaEncoder encoder, Stream input, Stream output) {
            encoder.WriteCoderProperties(output);
            output.Write(BitConverter.GetBytes(input.Length), 0, sizeof(Int64));
        }

        public static long PrepareDecoder(LzmaDecoder decoder, Stream source) {
            byte[] properties = new byte[5];
            source.Read(properties, 0, 5);
            decoder.SetDecoderProperties(properties);

            byte[] uncompressedSize = new byte[sizeof(Int64)];
            source.Read(uncompressedSize, 0, sizeof(Int64));
            return BitConverter.ToInt64(uncompressedSize, 0);
        }

        public static void Pack(string directory, string filename) {
            List<FileInfo> infos = new List<FileInfo>();
            LzmaDecoder decoder = new LzmaDecoder();

            // Figure out the info for each file we need to compress.
            foreach (string fn in Directory.GetFiles(directory, "*.lzma")) {
                // Remove the extension.
                infos.Add(new FileInfo(fn));
            }

            string tempFilename = Path.GetTempFileName();
            using (var output = File.OpenWrite(filename)) {
                // First pass: write file table to output, and combine files.
                //
                // File table format:
                // <number entries>
                // file1: <name> <lzma size> <uncompressed size>
                // file2: <name> <lzma size> <uncompressed size>
                // ......
                // filen: <name> <lzma size> <uncompressed size>
                using (BinaryWriter writer = new BinaryWriter(output)) {
                    writer.Write(infos.Count);
                    using (var tempFile = File.OpenWrite(tempFilename))
                        foreach (FileInfo fi in infos) {
                            writer.Write(fi.Name);
                            writer.Write(fi.Length);
                            
                            // Decompress this file to the temp blob.
                            using (var thisFile = fi.OpenRead()) {
                                long uncompressedSize = PrepareDecoder(decoder, thisFile);
                                decoder.Code(thisFile, tempFile, thisFile.Length, uncompressedSize, null);

                                writer.Write(uncompressedSize);

                                thisFile.Pipe(tempFile);
                            }
                        }

                    // Second pass: write LZMA header to output, and compress the temp blob
                    // into the output file.
                    LzmaEncoder encoder = new LzmaEncoder();
                    using (var tempFile = File.OpenRead(tempFilename)) {
                        WriteHeader(encoder, tempFile, output);
                        encoder.Code(tempFile, output, -1, -1, null);
                    }
                }
            }
        }

        public static void Unpack(string filename, string directory) {
            List<ExtendedFileInfo> infos = new List<ExtendedFileInfo>();
            string tempFilename = Path.GetTempFileName();

            using (var archive = File.OpenRead(filename)) {
                using (BinaryReader reader = new BinaryReader(archive)) {
                    int count = reader.ReadInt32();
                    for (int i = 0; i < count; i++) {
                        string name = reader.ReadString();
                        long csize = reader.ReadInt64();
                        long ucsize = reader.ReadInt64();
                        infos.Add(new ExtendedFileInfo(new FileInfo(Path.Combine(directory,name)), csize, ucsize));
                    }

                    // Unpack the compressed blob.
                    using (var tempFile = File.Open(tempFilename, FileMode.Create, FileAccess.ReadWrite)) {
                        LzmaDecoder decoder = new LzmaDecoder();
                        long uncompressedSize = PrepareDecoder(decoder, archive);
                        decoder.Code(archive, tempFile, archive.Length - archive.Position, uncompressedSize, null);

                        // Return to the beginning of the file.
                        tempFile.Seek(0, SeekOrigin.Begin);
                        // Split the compressed blob into individual files.
                        foreach (var efi in infos) {
                            using (var output = File.OpenWrite(efi.FileInfo.FullName.Remove(efi.FileInfo.FullName.Length - 5))) {
                                tempFile.Pipe(output, efi.UncompressedSize);
                            }
                        }
                    }
                }
            }
        }

        class ExtendedFileInfo {
            private readonly FileInfo _wrappedInfo;
            private readonly long _compSize;
            private readonly long _ucompSize;

            public ExtendedFileInfo(FileInfo info, long compSize, long ucompSize) {
                _wrappedInfo = info;
                _compSize = compSize;
                _ucompSize = ucompSize;
            }

            public FileInfo FileInfo {
                get { return _wrappedInfo; }
            }

            public long CompressedSize {
                get { return _compSize; }
            }

            public long UncompressedSize {
                get { return _ucompSize; }
            }
        }
    }
}
