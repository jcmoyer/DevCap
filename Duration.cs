using System;

namespace DevCap {
    internal static class Duration {
        private static readonly TimeSpan InfiniteDur = new TimeSpan(0, 0, 0, 0, -1);

        public static TimeSpan Infinite {
            get { return InfiniteDur; }
        }
    }
}