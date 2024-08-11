using System.Net;

namespace ParallelPrograming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Enumerable.Range(3, 100000 - 3);

            var parallelQurey =
                from n in numbers.AsParallel()
                where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                select n;

            int[] primes = parallelQurey.ToArray();

            foreach(int i in primes)
            {
                Console.Write(i + " ");
            }

            IEnumerable<int> milion = Enumerable.Range(3, 1000000);

            var cancelSource = new CancellationTokenSource();

            var primeNumberQuery =
                from n in milion.AsParallel().WithCancellation(cancelSource.Token)
                where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                select n;

            new Thread(() =>
                {
                    Thread.Sleep(100);
                    cancelSource.Cancel();
                }
             ).Start();

            try
            {
                //satrt query
                int[] primes1 = primeNumberQuery.ToArray();
                // we will never get here4 because the other thread will cancel us.
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Query canceled! ");
            }

            Parallel.ForEach("Hello, world", (c, loopState) =>
           {
               if (c == ',')
                   loopState.Break();
               else
                   Console.WriteLine(c);
           });

            Task parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("I am a parent");

                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("I am detached");
                });

                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine(" I am a child");
                }, TaskCreationOptions.AttachedToParent);
            });

            var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            cts.CancelAfter(500);

            Task task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                token.ThrowIfCancellationRequested();
            }, token);

            try { task.Wait(); }
            catch (AggregateException ex)
            {
                Console.WriteLine( ex.InnerException is TaskCanceledException);
                Console.WriteLine(task.IsCanceled);
                Console.WriteLine(task.Status);
            }
                

            //Parallel.Invoke(
            //    () => new WebClient().DownloadFile("http://linqpad.net", "lp/html"),
            //    () => new WebClient().DownloadFile("mocrosoft.com", "ms.html"));
        }

    }
    
}
