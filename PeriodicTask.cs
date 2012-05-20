/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */ 
using System;
using System.Threading;

namespace DevCap {
    /// <summary>
    /// Base class for tasks that run periodically.
    /// </summary>
    abstract class PeriodicTask : IDisposable {
        private readonly Timer _timer;
        private bool _disposed;
        private TimeSpan _interval;
        private bool _running;

        protected PeriodicTask() {
            _timer = new Timer(state => Run());
            _interval = Duration.Infinite;
        }

        public TimeSpan Interval {
            get { return _interval; }
            set {
                _interval = value;
                if (_running) {
                    Start();
                }
            }
        }

        public bool Running {
            get { return _running; }
        }

        #region IDisposable Members

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        ~PeriodicTask() {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing) {
            if (_disposed) {
                return;
            }

            _timer.Dispose();

            _disposed = true;
        }

        public void Start() {
            OnStart();
            _timer.Change(_interval, _interval);
            _running = true;
        }

        public void Stop() {
            OnStop();
            _timer.Change(Duration.Infinite, Duration.Infinite);
            _running = false;
        }

        protected virtual void OnStart() {
        }

        protected virtual void OnStop() {
        }

        protected abstract void Run();
    }
}