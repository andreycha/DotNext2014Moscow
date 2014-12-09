using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo3.AsyncLambda
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
            Console.WriteLine("Started");
            try
            {
                // by making this lambda async we will get unhandled exception
                ExecuteAction(() => { throw new NotImplementedException(); });
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occured: " + e.Message);
            }
            Console.WriteLine("Finished");

            // waiting for exception to be thrown
            await Task.Delay(1000);
        }

        #region
        private static void ExecuteAction(Action action)
        {
            action();
        }
        #endregion
    }
}
