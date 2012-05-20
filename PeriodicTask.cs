using System;
using System.Threading;

namespace DevCap {
    /// <summary>
    /// Base class for tasks that run periodically.
    /// </summary>
    internal abstract class PeriodicTask : IDisposable {
        private readonly Timer _timer;
        private bool _disposed;
        private TimeSpan _interval;
        private bool _running;

        protected PeriodicTask() {
            _timer = new Timer((state) => this.Run());
            _interval = Duration.Infinite;
        }

        ~PeriodicTask() {
            this.Dispose(false);
        }

        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
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

        public TimeSpan Interval {
            get { return _interval; }
            set {
                _interval = value;
                if (_running) {
                    this.Start();
                }
            }
        }

        public bool Running {
            get { return _running; }
        }
    }
}