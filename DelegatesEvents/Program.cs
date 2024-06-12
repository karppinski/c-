
using System.Security.Cryptography.X509Certificates;

namespace DelegatesEvents
{
    internal class Program
    {
        delegate int square(int x);
        delegate int Transformer(int x);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int sqrae(int x) { return x * x; }

            square s = sqrae;

            int info = s.Invoke(3);

            Console.WriteLine(info);

            Console.ReadKey();


            int[] values = { 1, 2, 3 };

            //           Transform(values, Squart);
            Transform(values, Cube);

            foreach (int i in values)
                Console.WriteLine(i + " ");



            int Squart(int x) => x * x;
            int Cube(int x) => x * x * x;

            Console.ReadKey();


            Transformer t = Test.Square;
            Console.WriteLine("Single static method: " + t(10));

            Transformer multicast = Test.Square;
            Console.WriteLine("before cubing :" + multicast(5));
            multicast += Test.Cube;

            Console.WriteLine("multicast with square'n cube is another instance! : " + multicast(5));

            ITrnasformer squarer = new Squarer();
            int[] values2 = { 1, 2, 3 };
            Utill.TransformAll(values2, squarer);
            foreach (int i in values2)
                Console.WriteLine(i + " ");






        }
        static void Transform(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t(values[i]);
        }


        class Test
        {
            public static int Square(int x) => x * x;
            public static int Cube(int x) => x * x * x;
        }

        public interface ITrnasformer
        {
            int Transform(int x);
        }

        public class Utill
        {
            public static void TransformAll(int[] values, ITrnasformer t)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = t.Transform(values[i]);
                }
            }
        }

        public class Squarer : ITrnasformer
        {
            public int Transform(int x) => x * x;
        }









    }
}

