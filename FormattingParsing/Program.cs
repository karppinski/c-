using System.Globalization;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace FormattingParsing
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = true.ToString();
            bool b = bool.Parse(s);
            Console.WriteLine(s + " | " + b);


            bool failure = int.TryParse("qwerty", out int i1);
            bool success = int.TryParse("123", out int i2);

            Console.WriteLine(success);
            Console.WriteLine(i2);

            string x = 1.234.ToString(CultureInfo.InvariantCulture);
            Console.WriteLine( x);

            Console.ReadKey();
            NumberFormatInfo f = new NumberFormatInfo();
            f.NumberGroupSeparator = " ";
            Console.WriteLine(12345.6789.ToString("N3", f));


            
            int minusTwo = int.Parse("(2)", NumberStyles.Integer | NumberStyles.AllowParentheses);
            decimal fivePointTwo = decimal.Parse("$5.20", NumberStyles.Currency , CultureInfo.GetCultureInfo("en-US"));

            try
            {
                int error = int.Parse("(2)");
                Console.WriteLine(error);

            }
            catch(Exception ex)
            {
                Console.WriteLine("exception" + ex);
            }
            finally
            {
                Console.WriteLine( minusTwo + fivePointTwo);
            }


            double d = 3.9;
            int i = Convert.ToInt32(d);
            Console.WriteLine( i);

            int thirty = Convert.ToInt32("1E", 16);
            uint five = Convert.ToUInt32("101", 2);

            Console.WriteLine(thirty + " | |" + five);


            foreach(byte by in BitConverter.GetBytes(3.5))
            {
                Console.WriteLine(by + " ");
            }

            Console.WriteLine(CultureInfo.GetCultures);

            BigInteger twentyFive = 25;

            BigInteger googol = BigInteger.Pow(10, 100);

            BigInteger googolString = BigInteger.Parse("1".PadRight(101, '0'));

            Console.WriteLine(googol.ToString()) ;

            double g2 = (double)googol;

            BigInteger g3 = (BigInteger)g2;

            Console.WriteLine(g3); // loss of precision







        }
    }
}
