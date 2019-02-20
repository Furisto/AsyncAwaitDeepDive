using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Internals.StateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = FooAsync_();
            Console.WriteLine(task.Result);
            Console.ReadLine();
        }

        static async Task<int> FooAsync()
        {
            Console.WriteLine("Before Await");
            int asyncResult = await AsyncOperation(5000);
            return asyncResult + 1;
        }

        static Task<int> FooAsync_()
        {
            FooStateMachine stateMachine = new FooStateMachine();

            stateMachine.methodBuilder = AsyncTaskMethodBuilder<int>.Create();
            stateMachine.methodBuilder.Start(ref stateMachine);

            return stateMachine.methodBuilder.Task;
        }

        static Task<int> AsyncOperation(int waitTime)
        {
            return Task.Run(() =>
            {
                Task.Delay(waitTime).Wait();
                return 41;
            });
        }

        struct FooStateMachine : IAsyncStateMachine
        {
            public AsyncTaskMethodBuilder<int> methodBuilder;

            private int state;

            private TaskAwaiter<int> awaiter;

            public void MoveNext()
            {
                try
                {
                    if (state == 0)
                    {
                        Console.WriteLine("Before Await");
                        awaiter = AsyncOperation(5000).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            state = 1;
                        }
                        else
                        {
                            state = 1;
                            methodBuilder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                            return;
                        }
                    }

                    if (state == 1)
                    {
                        int result = awaiter.GetResult();
                        methodBuilder.SetResult(result + 1);
                    }
                }
                catch (Exception ex)
                {
                    methodBuilder.SetException(ex);
                }
            }

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                methodBuilder.SetStateMachine(stateMachine);
            }
        }
    }
}
