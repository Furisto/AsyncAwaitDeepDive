using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Internals.MessageLoop
{
    public class MessageLoopSyncContext : SynchronizationContext
    {
        private MessageLoop myWorker;

        public MessageLoopSyncContext(MessageLoop worker)
        {
            myWorker = worker;
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            myWorker.Enqueue(() => d(state));
        }
    }
}
