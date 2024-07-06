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

            int secondNumber = numbers.ElementAt(1);
            int secondLowest = numbers.OrderBy(n => n).Skip(1).First();


            IEnumerable<string> sortedByLength, sortedAlphabetically;
            sortedByLength = namez.OrderBy(n => n.Length);// int key
            sortedAlphabetically = namez.OrderBy(n => n); //string key 


            int[] seq1 = { 1, 2, 3 };
            int[] seq2 = { 3, 4, 5 };


            IEnumerable<int> concat = seq1.Concat(seq2);
            IEnumerable<int> union = seq1.Union(seq2);

            foreach(int i in concat) Console.WriteLine(i + ", concat");
            foreach(int i in union) Console.WriteLine(i + ", union");



            int matches = (from n in namez where n.Contains("a") select n).Count();
            int matches1 = namez.Where(n => n.Contains("a")).Count();
            Console.WriteLine("matches: " + matches +" "+  matches1);

            string first = (from n in namez orderby n select n).First();
            string first1 = namez.OrderBy(n => n).First();
            Console.WriteLine("first: " + first + " " + first1);


            var numbersX = new List<int> { 1 };

            IEnumerable<int> query5 = numbersX.Select(n => n * 10); // build query

            numbersX.Add(2);

            foreach(int n in query5) // executed only when enumerated !!!
                Console.Write(n + " | ");

            Console.WriteLine();
            var numbers5 = new List<int> { 1, 2 };

            IEnumerable<int> query66 = numbers5.Select(n => n * 10);

            foreach (int n in query66) Console.Write(n + " | ");

            numbers5.Clear();
            Console.WriteLine();


            foreach (int n in query66) Console.Write(n + " | "); // nothing happend !!!!
            Console.WriteLine(  );

            var numbers6 = new List<int> { 1, 2 };

            IEnumerable<int> query67 = numbers6.Select(n => n * 10).ToList(); /// need to assign it to list to copy values !!

            foreach (int n in query67) Console.Write(n + " | ");
            Console.WriteLine();
            numbers6.Clear();

            Console.WriteLine();
            foreach (int n in query67) Console.Write(n + " | ");




        }
    }
}
