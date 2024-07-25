namespace awaits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            async Task PrintAnswer()
            {
                await Task.Delay(5000);
                int answer = 21 * 2;
                Console.Out.WriteLine(answer);
            }

             async Task Go()
            {
                await PrintAnswer();
                Console.WriteLine("Done");
            }

            Go();
        }



    }
}
