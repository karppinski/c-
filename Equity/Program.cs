namespace Equity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dt1 = new DateTimeOffset(2010, 1, 1, 1, 1, 1, TimeSpan.FromHours(8));
            var dt2 = new DateTimeOffset(2010, 1, 1, 2, 1, 1, TimeSpan.FromHours(9));
            Console.WriteLine(dt1 == dt2);

            Foo f1 = new Foo { X = 5 };
            Foo f2 = new Foo { X = 5 };

            Console.WriteLine(f1 == f2);

            Foo f3 = f1;

            f3.X = 6;

            Console.WriteLine(f1.X.ToString());
            Console.WriteLine(f1 == f3);

            Uri uri1 = new Uri("http://www.jan.com");
            Uri uri2 = new Uri("http://www.jan.com");

            Console.WriteLine( uri1 == uri2);

            var s1 = "http://www.jan.com";
            var s2 = "http://" + "www.jan.com";

            Console.WriteLine(s1 == s2); //overloaded operators of uri and string lets them act as value types
        }
    }

    public class Foo
    {
        public int X;
    }
}
