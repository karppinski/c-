namespace ExtensionMethNAnnonymousTypes
{
    internal class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine(StringHelper.IsCapitalized("Perth"));
            Console.WriteLine(StringHelper.IsCapitalized("perth"));
            Console.ReadKey();

            string x = "sasuage".Pluralize().Capitalize();
            string y = StringHelper.Pluralize(StringHelper.Capitalize("sasuage"));


            var dudes = new[]
            {
                new { Name = "bob", Age = 10 },
                new { Name = "Rob", Age = 20 }


            };

            Console.WriteLine(dudes[0].GetType());
            Console.WriteLine(dudes[1].GetType());
            dudes[1].GetType();

            Console.ReadKey();

            var a1 = new { A = 1, B = 2, C = 3 };

            //Annonmous types are immutable ! 

            var a2 = a1 with { C = 10 }; // nondestruuctive mutation

            

            var Foo() => new { Name = "bobo", Age = 30 }; // illegal
 
            dynamic FooD() => new { Name = "bobo", Age = 30 };  // legal, no static type sfety 
            
        }
    }

    public static class StringHelper
    {
        public static bool IsCapitalized(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return char.IsUpper(s[0]);
        }

        public static string Pluralize(this string s) { return s; }
        public static string Capitalize(this string s) { return s; }

    }
}
