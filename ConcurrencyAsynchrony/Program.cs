namespace ConcurrencyAsynchrony

{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Thread t = new Thread(WriteY);
            //t.Start();

            //for (int i = 0; i < 1000; i++) Console.Write("x");

            //void WriteY()
            //{
            //    for (int i = 0; i < 1000; i++) Console.Write("y");
            //}
            //try
            //{
            //    new Thread(Go).Start();
            //}
            //catch (Exception ex)
            //{
            //    //program will never go here!
            //    Console.WriteLine("Exception");
            //}

            //void Go() { throw null; }

            //new Thread(Goo).Start();

            //void Goo()
            //{
            //    try
            //    {
            //        //code
            //        //code
            //        throw null;
            //    }
            //    catch(Exception ex)
            //    {
            //        throw null;
            //    }
            //}

            //var signal = new ManualResetEvent(false);
            //new Thread(() =>
            //{
            //    Console.WriteLine("Waiting for signal...");
            //    signal.WaitOne();
            //    signal.Dispose();
            //    Console.WriteLine("Got signal!");
            //}).Start();

            //Thread.Sleep(2000);
            //signal.Set();

            //Task task = Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Foo");
            //});
            //Console.WriteLine(task.IsCompleted);
            //task.Wait();

            Task<int> primeNumberTask = Task.Run(() =>
                Enumerable.Range(2, 3000000).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));

            //  Console.WriteLine("Task is running");
            //    Console.WriteLine("The answer is" + primeNumberTask.Result);

            var awaiter = primeNumberTask.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine(result);
            });




        } 

    }
}
