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

        }
    }
}
