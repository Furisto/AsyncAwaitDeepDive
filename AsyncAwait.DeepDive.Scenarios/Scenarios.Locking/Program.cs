using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locking
{
    class Program
    {
        private object myLock = new object();

        private SemaphoreSlim myAsyncLock = new SemaphoreSlim(1, 1);

        static void Main(string[] args)
        {
            new Program().AsyncLocking().GetAwaiter().GetResult();
        }

        public async Task SyncLocking()
        {
            lock (myLock)
            {
                //await Task.Delay(1000);
            }
        }

        public async Task AsyncLocking()
        {
            await myAsyncLock.WaitAsync();
            try
            {
                await Task.Delay(1000).ConfigureAwait(false);
            }
            finally
            {
                myAsyncLock.Release();
            }
        }
    }
}
