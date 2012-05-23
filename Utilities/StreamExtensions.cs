/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System;
using System.Collections.Generic;
using System.IO;

namespace DevCap.Utilities {
    static class StreamExtensions {
        private const int BufferSize = 4096;

        public static void Pipe(this Stream input, Stream output) {
            byte[] buffer = new byte[BufferSize];
            while (input.Position < input.Length) {
                int read = input.Read(buffer, 0, BufferSize);
                output.Write(buffer, 0, read);
            }
        }

        public static void Pipe(this Stream input, Stream output, long count) {
            byte[] buffer = new byte[BufferSize];
            long start = input.Position;
            while (input.Position < start + count) {
                // OK since BufferSize is well within the range of an int.
                int read = input.Read(buffer, 0, (int)Math.Min(BufferSize, start + count - input.Position));
                output.Write(buffer, 0, read);
            }
        }

        public static void Pack(this IEnumerable<Stream> uncompressed, Stream output) {
            foreach (var s in uncompressed) {
                s.Pipe(output);
            }
        }
    }
}
