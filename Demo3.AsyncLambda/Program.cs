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
                Foo(() => { throw new NotImplementedException(); });
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occured: " + e.Message);
            }
            Console.WriteLine("Finished");

            await Task.Delay(1000);
        }

        #region
        private static void Foo(Action action)
        {
            action();
        }
        #endregion
    }
}
