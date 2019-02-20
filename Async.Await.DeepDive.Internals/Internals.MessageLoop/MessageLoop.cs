using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Internals.MessageLoop
{
    public class MessageLoop
    {
        private BlockingCollection<Action> myQueue = new BlockingCollection<Action>();

        private Thread myWorkerThread;

        public MessageLoop(string name_in)
        {
            myWorkerThread = new Thread(RunLoop);
            myWorkerThread.SetApartmentState(ApartmentState.STA);
            myWorkerThread.Name = name_in;

            myWorkerThread.Start();
        }

        public void Enqueue(Action action_in)
        {
            myQueue.Add(action_in);
        }

        private void RunLoop()
        {
            SynchronizationContext.SetSynchronizationContext(new MessageLoopSyncContext(this));

            while (!myQueue.IsCompleted)
            {
                Action action;
                if (myQueue.TryTake(out action, -1))
                {
                    action();
                }
            }
        }
    }
}
