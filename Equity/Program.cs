namespace Equity
{

    internal class Program
    {
        public static bool AreEqual(object obj1, object obj2)
                   => obj1 == null ? obj2 == null : obj1.Equals(obj2);
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

            Console.WriteLine(s1.Equals(s2));
            Console.WriteLine(object.ReferenceEquals(s1, s2) + "references");
            /* while interpolating strings if they are the same, they are stored in one place in memory thats 
             * why code above returns true */

            var s3 = new string("http://www.jan.com".ToCharArray());

            Console.WriteLine(object.ReferenceEquals(s1, s3) + " s1 to s3 references");
            Console.WriteLine(object.ReferenceEquals(s1, s3) + " s2 to s3 references");

            var s4 = new string(new char[] { 'j', 'a', 'n' });
            var s5 = new string(new char[] { 'j', 'a', 'n' });

            // its from string class not char array 
            Console.WriteLine(object.ReferenceEquals(s5, s4) + " char array references");

            string s6 = null;
            bool eq = s1 == s6;
            Console.WriteLine(eq +  "  this can take null but equals not ");

            //Console.WriteLine(s6.Equals(s1));

            Console.WriteLine(AreEqual(s1,s2));
            Console.WriteLine(AreEqual(s1,s6));

            Console.WriteLine(object.Equals(s1,s2));


            double x = double.NaN;
            Console.WriteLine("comparing double nan " + (x == x));
            Console.WriteLine(x.Equals(x));




        }
    }

    public class Foo
    {
        public int X;
    }



}
