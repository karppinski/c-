namespace ConcurrencyAsynchrony

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(WriteY);
            t.Start();

            for (int i = 0; i < 1000; i++) Console.Write("x");

            void WriteY()
            {
                for (int i = 0; i < 1000; i++) Console.Write("y");
            }
            try
            {
                new Thread(Go).Start();
            }
            catch (Exception ex)
            {
                //program will never go here!
                Console.WriteLine("Exception");
            }

            void Go() { throw null; }

            new Thread(Goo).Start();

            void Goo()
            {
                try
                {
                    //code
                    //code
                    throw null;
                }
                catch(Exception ex)
                {
                    throw null;
                }
            }

            var signal = new ManualResetEvent(false);
            new Thread(() =>
            {
                Console.WriteLine("Waiting for signal...");
                signal.WaitOne();
                signal.Dispose();
                Console.WriteLine("Got signal!");
            }).Start();

            Thread.Sleep(2000);
            signal.Set();

            
        }
    }
}
