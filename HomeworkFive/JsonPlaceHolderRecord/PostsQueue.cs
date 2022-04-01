using System;
using System.Collections.Concurrent;

namespace JsonPlaceHolderRecord
{
    public interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
    }
    public class PostsQueue<T> : IQueue<T> where T : class
    {
        private readonly ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
        public T Dequeue()
        {
            var success = this.queue.TryDequeue(out T nextTtem);
            return success ? nextTtem : default(T);

        }

        public void Enqueue(T item)
        {
            if(item == null) throw new ArgumentNullException(nameof(item));
            this.queue.Enqueue(item);
        }
    }
}
