using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LinQuueries1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int>
                source = new int[] { 5, 12, 3 },
                filtered = source.Where(n => n < 10),
                sorted = filtered.OrderBy(n => n),
                query = sorted.Select(n => n * 10);


        foreach (int n in query) Console.WriteLine(n);

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };


            IEnumerable<string> querry =
                from n in names
                select n.Replace("a", "").Replace("e", "").Replace("i", "")
                        .Replace("o", "").Replace("u", "")
                into noVowel
                where noVowel.Length > 2
                orderby noVowel
                select noVowel;

            IEnumerable<string> querry1 =
         from n in names
         let vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                 .Replace("o", "").Replace("u", "")
         where vowelless.Length > 2
         orderby vowelless
         select n;



            Regex wordCounter = new Regex(@"\b(\w|[-'])+\b");


            using var dbContext = new NutshellContext();

            var query1 = 




        }
    }
    public class NutshellContext : DbContext
    {


    }


}

