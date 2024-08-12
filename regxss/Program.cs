using System.Text.RegularExpressions;

namespace regxss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Match m = Regex.Match("any colour you like", @"colou?r");

            Console.WriteLine(m.Success);
            Console.WriteLine(m.Index);
            Console.WriteLine(m.Length);
            Console.WriteLine(m.Value);
            Console.WriteLine(m.ToString());


            Match m1 = Regex.Match("One colo? There are two colours in my head!",
                @"colou?rs?");

            Match m2 = m1.NextMatch();
            Console.WriteLine(m1);
            Console.WriteLine(m2);

            Console.WriteLine(Regex.IsMatch("Jenny", "Jen(ny|nifer)?"));

            Console.WriteLine(Regex.Match("a", "A", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant));

            Console.WriteLine(Regex.Match("a",@"(?i)A"));

            Console.WriteLine(Regex.Match("AAAa", @"(?i)a(?=i)a"));

            Console.WriteLine(Regex.Matches("That is that.", "[Tt]hat").Count);

            Console.WriteLine(Regex.Match("quiz qwerty", "q[^aeiou]").Index);

            Console.WriteLine(Regex.Match("cv15.docx", @"cv\d*\.docx").Success);

            Console.WriteLine(Regex.Match("cvjoint.docx", @"cv.*\.docx").Success);

            Console.WriteLine(Regex.Matches("slow! yeah slooow!", "slo+w").Count);
            

        }
    }
}
