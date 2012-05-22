/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System;
using System.IO;
using LmzaEncoder = DevCap.SevenZip.Compress.LZMA.Encoder;
using LmzaDecoder = DevCap.SevenZip.Compress.LZMA.Decoder;

namespace DevCap.Utilities {
    static class Lzma {
        public static void WriteHeader(LmzaEncoder encoder, Stream input, Stream output) {
            encoder.WriteCoderProperties(output);
            output.Write(BitConverter.GetBytes(input.Length), 0, sizeof(Int64));
        }

        public static long PrepareDecoder(LmzaDecoder decoder, Stream source) {
            byte[] properties = new byte[5];
            source.Read(properties, 0, 5);
            decoder.SetDecoderProperties(properties);

            byte[] uncompressedSize = new byte[sizeof(Int64)];
            source.Read(uncompressedSize, 0, sizeof(Int64));
            return BitConverter.ToInt64(uncompressedSize, 0);
        }
    }
}
