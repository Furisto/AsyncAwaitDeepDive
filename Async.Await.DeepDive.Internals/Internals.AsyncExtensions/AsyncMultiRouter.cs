using Internals.MessageLoop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internals.AsyncExtensions
{
    class AsyncMultiRouter
    {
        private SynchronizationContext myPoolSyncContext;

        private WindowsFormsSynchronizationContext myUISyncContext;

        private MessageLoopSyncContext myMessageLoopSyncContext;

        public AsyncMultiRouter()
        {
            myPoolSyncContext = new SynchronizationContext();
            myUISyncContext = new WindowsFormsSynchronizationContext();
            myMessageLoopSyncContext = new MessageLoopSyncContext(new MessageLoop.MessageLoop("MessageLoop"));
        }

        public MultiExecAwaitable SwitchToUIThread()
        {
            return new MultiExecAwaitable(myUISyncContext);
        }

        public MultiExecAwaitable SwitchToThreadPoolThread()
        {
            return new MultiExecAwaitable(myPoolSyncContext);
        }

        public MultiExecAwaitable SwitchToMessageLoopThread()
        {
            return new MultiExecAwaitable(myMessageLoopSyncContext);
        }
    }
}
