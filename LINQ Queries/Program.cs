namespace LINQ_Queries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry" };

            IEnumerable<string> filteredNames = System.Linq.Enumerable.Where
                                                (names, n => n.Length >= 4);

            foreach (string n in filteredNames)
                Console.WriteLine(n);

            IEnumerable<string> filteredNames1 = names.Where(n => n.Length >= 4);

            var filteredNames2 = names.Where(n => n.Length >= 4);

            IEnumerable<string> withA = names.Where(n => n.Contains("a"));

            
            foreach (string n in withA)
                Console.WriteLine(n);
            
            IEnumerable<string> withA1 = from n in names
                                         where n.Contains("a")
                                         select n;


            foreach (string n in withA1)
                Console.WriteLine(n);

            string[] namez = { "Tom", "Dick", "Hary", "Mary", "Jay" };

            IEnumerable<string> query = namez
                .Where(n => n.Contains("a"))
                .OrderBy(n => n.Length)
                .Select(n => n.ToUpper());

            foreach( string n in query ) Console.WriteLine(n);

            IEnumerable<string> query1 =
                Enumerable.Select(
                    Enumerable.OrderBy(
                        Enumerable.Where(
                            names, n => n.Contains("a")
                            ), n => n.Length)
                    , n => n.ToUpper()
                    );

            int[] numbers = { 10, 9, 8, 7, 6 };

            IEnumerable<int> firstThree = numbers.Take(3);

            IEnumerable<int> lastTwo = numbers.Skip(numbers.Length - 2);

            IEnumerable<int> reversed = numbers.Reverse();
        }
    }
}
