namespace EnumerationIterators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            foreach(int fib in Fibs(6))
            {
                Console.WriteLine(fib + " ");
            }
                

            foreach(int fib in EvenNumbersOnly(Fibs(6)))
            {
                Console.WriteLine(fib + " ");
            }

            IEnumerable<int> Fibs (int fibCount)
            {
                for (int i =0, prevFib =1, curFib =1; i < fibCount; i++)
                {
                    yield return prevFib;
                    int newFib = prevFib + curFib;
                    prevFib = curFib;
                    curFib = newFib;
                }
            }

            IEnumerable<int> EvenNumbersOnly(IEnumerable<int> sequence)
            {
                foreach(int x in sequence)
                {
                    if((x %2 )== 0)
                    {
                        yield return x;
                    }
                }
            }

            Console.ReadKey();
            
            foreach(string s in Foo())
            {
                Console.WriteLine(s);
            }

            IEnumerable<string> Foo()
            {
                yield return "One";
                yield return "Two";

                yield break;

                yield return "Three";
            }

            Console.ReadKey();
            
        }
    }
}
