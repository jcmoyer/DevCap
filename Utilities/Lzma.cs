using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
