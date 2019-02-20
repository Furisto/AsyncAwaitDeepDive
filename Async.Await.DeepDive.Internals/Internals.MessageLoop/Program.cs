using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Internals.MessageLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageLoop messageLoop = new MessageLoop("UI_Thread");
            messageLoop.Enqueue(() =>
            {
                SynchronizationContext context = SynchronizationContext.Current;

                AsyncOperationSyncContext(5000).Wait();
                Console.WriteLine("Hello Await!");
            });
        }

        public static async Task<int> AsyncOperationSyncContext(int waitTime)
        {
            await Task.Delay(waitTime);
            return 41;
        }
    }
}
