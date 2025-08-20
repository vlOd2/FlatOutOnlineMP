using System;
using System.Collections;
using System.Collections.Generic;

namespace FlatOutOnlineMP
{
    public class SynchronizedQueue<T> : ICollection, IEnumerable<T>
    {
        private readonly Queue<T> queue;
        public int Count => queue.Count;
        public object SyncRoot => ((ICollection)queue).SyncRoot;
        public bool IsSynchronized => true;

        public SynchronizedQueue()
        {
            queue = new Queue<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (SyncRoot)
            {
                foreach (T item in queue)
                    yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void CopyTo(Array array, int index)
        {
            lock (SyncRoot)
                ((ICollection)queue).CopyTo(array, index);
        }

        public void Enqueue(T item)
        {
            lock (SyncRoot)
                queue.Enqueue(item);
        }

        public T Dequeue()
        {
            lock (SyncRoot)
                return queue.Dequeue();
        }

        public T Peek()
        {
            lock (SyncRoot)
                return queue.Peek();
        }

        public void Clear()
        {
            lock (SyncRoot)
                queue.Clear();
        }
    }
}
