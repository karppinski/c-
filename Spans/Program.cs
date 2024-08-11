using System;

namespace Spans
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Sum(ReadOnlySpan<int> numbers)
            {
                int total = 0;
                foreach (int i in numbers) total += i;
                return total;
            }

            var numbers = new int[1000];
            for (int i = 0; i < numbers.Length; i++) numbers[i] = i;

            int total = Sum(numbers);

            var span = numbers.AsSpan();

            int total1 = Sum(numbers.AsSpan(250, 500));

            Span<int> span1 = numbers;

            int total2 = Sum(span1.Slice(250, 500));

            Console.WriteLine(span[^1]);
            Console.WriteLine(Sum(span[..10]));
            Console.WriteLine(Sum(span[100..]));
            Console.WriteLine(Sum(span[^5..]));

            unsafe int Sum1(int* numbers, int length)
            {
                int total = 0;
                for (int i = 0; i < length; i++) total += numbers[i];
                return total;
            }
            unsafe
            {
                int* numbers1 = stackalloc int[1000];
                int total3 = Sum1(numbers1, 1000);
            }

            unsafe
            {
                int* numbers2 = stackalloc int[1000];
                var span3 = new Span<int>(numbers2, 1000);r
            }
        }
    }
}
