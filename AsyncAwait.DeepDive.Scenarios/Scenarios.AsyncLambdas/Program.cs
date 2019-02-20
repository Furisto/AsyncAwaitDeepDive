using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLambdas
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task<Task> task = Task.Factory.StartNew(async() =>
            {
                Console.WriteLine("Before await");
                await Task.Delay(5000);
                Console.WriteLine("After await");
            });

            await task;
            Console.WriteLine("Task has been finished");
            Console.Read();
        }
    }
}
