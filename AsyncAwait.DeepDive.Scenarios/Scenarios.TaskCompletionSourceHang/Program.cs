using Scenarios.TaskCompletionSourceHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCompletionSource2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AsyncQueue<int> asyncQueue = new AsyncQueue<int>();
            _ = Task.Run(() =>
            {
                Thread.Sleep(2000);
                asyncQueue.Enqueue(5);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"BackgroundThread: {i}");
                    Thread.Sleep(800);
                }
            });

            await asyncQueue.Dequeue();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ForegroundThread: {i}");
                Thread.Sleep(800);
            }

            Console.WriteLine("Finished!");
            Console.ReadLine();
        }
    }
}
