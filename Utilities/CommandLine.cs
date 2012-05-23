/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace DevCap.Utilities {
    abstract class CommandLine {
        private enum ParseState {
            None,
            SwitchParam,
        }

        public string Rest { get; set; }

        public static T Parse<T>(string[] args) where T : CommandLine, new() {
            T output = new T();
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var mutator = CreateMutatorMap(props, output);
            string thisSwitch = String.Empty;
            ParseState state = ParseState.None;

            for (int i = 0; i < args.Length; i++) {
                string thisPiece = args[i];
                if (thisPiece.StartsWith("-") && args[i].Length > 1) {
                    thisSwitch = args[i].Substring(1);
                    state = ParseState.SwitchParam;
                } else if (thisSwitch != String.Empty && args[i].Length > 0 && state == ParseState.SwitchParam) {
                    if (mutator.ContainsKey(thisSwitch)) {
                        mutator[thisSwitch](args[i]);
                    }
                    thisSwitch = String.Empty;
                    state = ParseState.None;
                } else if (state == ParseState.None) {
                    if (output.Rest == null) {
                        output.Rest = thisPiece;
                    } else {
                        output.Rest += " " + thisPiece;
                    }
                }
            }

            return output;
        }

        private static Dictionary<string, Action<object>> CreateMutatorMap(PropertyInfo[] pi, object instance) {
            var mm = new Dictionary<string, Action<object>>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < pi.Length; i++) {
                PropertyInfo piInst = pi[i];
                mm[piInst.Name] = o => {
                    if (piInst.PropertyType.IsInstanceOfType(o)) {
                        piInst.SetValue(instance, o, null);
                    } else {
                        IConvertible c = o as IConvertible;
                        if (c != null) {
                            object value = c.ToType(piInst.PropertyType, CultureInfo.CurrentCulture);
                            piInst.SetValue(instance, value, null);
                        }
                    }
                };
            }
            return mm;
        }
    }
}
