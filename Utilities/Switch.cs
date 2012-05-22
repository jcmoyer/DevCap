/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

namespace DevCap.Utilities {
    class Switch {
        private readonly string _name;
        private readonly string _value;

        public Switch(string name, string value) {
            _name = name;
            _value = value;
        }

        public string Name { get { return _name; } }
        public string Value { get { return _value; } }
    }
}
