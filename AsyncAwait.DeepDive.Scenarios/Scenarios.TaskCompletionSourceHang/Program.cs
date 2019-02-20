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
            TaskCompletionSource<bool> setupFinished = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            Task producerTask = Task.Run(async () =>
            {
                await Task.Delay(500);
                setupFinished.SetResult(true);

                foreach (int number in Enumerable.Range(1, 8))
                {
                    await Task.Delay(600);
                    Console.WriteLine(number);
                }
            });

            await setupFinished.Task;
            Console.WriteLine("Values are now produced");
            producerTask.Wait();

            Console.WriteLine("Finished!");
            Console.ReadLine();
        }
    }
}
