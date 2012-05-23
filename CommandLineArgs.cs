/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using DevCap.Utilities;

namespace DevCap {
    class CommandLineArgs : CommandLine {
        public string Operation { get; set; }
        public string Directory { get; set; }
        public string File { get; set; }
    }
}