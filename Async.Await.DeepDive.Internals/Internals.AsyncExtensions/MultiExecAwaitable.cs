using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Internals.AsyncExtensions
{
    class MultiExecAwaitable
    {
        private SynchronizationContext mySynchronizationContext;

        public MultiExecAwaitable(SynchronizationContext synchronizationContext)
        {
            mySynchronizationContext = synchronizationContext;
        }

        public MultiExecAwaiter GetAwaiter()
        {
            return new MultiExecAwaiter(mySynchronizationContext);
        }
    }
}
