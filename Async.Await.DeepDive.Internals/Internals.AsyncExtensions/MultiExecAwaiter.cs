using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Internals.AsyncExtensions
{
    class MultiExecAwaiter: ICriticalNotifyCompletion
    {
        private SynchronizationContext mySynchronizationContext;

        public bool IsCompleted
        {
            get { return false; }
        }

        public MultiExecAwaiter(SynchronizationContext synchronizationContext)
        {
            mySynchronizationContext = synchronizationContext;
        }

        public void OnCompleted(Action continuation)
        {
            mySynchronizationContext.Post(state => continuation(), null);
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            mySynchronizationContext.Post(state => continuation(), null);
        }

        public void GetResult()
        {
            //
        }
    }
}
