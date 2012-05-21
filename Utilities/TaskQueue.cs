using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevCap.Utilities {
    abstract class TaskQueue<T> where T : class {
        private readonly object _locker = new object();
        private readonly Thread _thread;
        private readonly Queue<T> _queue = new Queue<T>();

        protected TaskQueue() {
            _thread = new Thread(Consume);
        }

        public void Enqueue(T item) {
            lock (_locker) {
                _queue.Enqueue(item);
                Monitor.Pulse(_locker);
            }
        }

        public void Start() {
            _thread.Start();
        }
        public void Stop(bool wait) {
            Enqueue(null);
            if (wait) {
                _thread.Join();
            }
        }

        private void Consume() {
            while (true) {
                T item;
                lock (_locker) {
                    while (_queue.Count == 0) Monitor.Wait(_locker);
                    item = _queue.Dequeue();
                }
                if (item == null) return;
                Work(item);
            }
        }

        protected abstract void Work(T task);
    }
}
