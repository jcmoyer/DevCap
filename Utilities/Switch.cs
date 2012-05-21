using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
