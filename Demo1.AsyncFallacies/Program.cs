using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo1.AsyncFallacies
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Main method is not allowed to be async
                MainAsync().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occured: " + e.ToString());
            }
        }

        private async static Task MainAsync()
        {
            Console.WriteLine("Before async op call, thread id: " + Thread.CurrentThread.ManagedThreadId);
            await DelayAsync();
        }

        private async static Task DelayAsync()
        {
            Console.WriteLine("Prologue of async op, thread id: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(100);
            ////this allows us to continue on the same thread
            //await Task.FromResult(1);
            Console.WriteLine("Continuation of async op, thread id: " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
