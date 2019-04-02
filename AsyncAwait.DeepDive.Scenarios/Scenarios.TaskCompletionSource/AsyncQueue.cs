using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCompletionSource
{
    class AsyncQueue<T>
    {
        private Queue<T> myItems = new Queue<T>();

        private Queue<TaskCompletionSource<T>> myWaiters = new Queue<TaskCompletionSource<T>>();

        private object myLock = new object();

        public void Enqueue(T item)
        {
            lock (myLock)
            {
                if (myWaiters.Count > 0)
                {
                    TaskCompletionSource<T> response = myWaiters.Dequeue();
                    response.SetResult(item);
                }
                else
                {
                    myItems.Enqueue(item);
                }
            }
        }

        public Task<T> Dequeue()
        {
            lock (myLock)
            {
                TaskCompletionSource<T> response = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);

                if (myItems.Count > 0)
                {
                    response.SetResult(myItems.Dequeue());
                }
                else
                {
                    myWaiters.Enqueue(response);
                }

                return response.Task;
            }
        }
    }
}
