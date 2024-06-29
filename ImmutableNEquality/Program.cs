using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace ImmutableNEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new[] { 1, 2, 3, }.ToImmutableList();


            var oldList = ImmutableList.Create<int>(1, 2, 3);

            ImmutableList<int> newList = oldList.Add(4);

            Console.WriteLine(oldList.Count);
            Console.WriteLine(newList.Count);

            var anotherList = oldList.AddRange(new[] { 4, 5, 6 });

            
            Console.WriteLine(anotherList.Count);


            ImmutableArray<int>.Builder builder = ImmutableArray.CreateBuilder<int>();
            builder.Add(1);

            builder.Add(2);

            builder.Add(3);

            builder.RemoveAt(0);
            ImmutableArray<int> myImmutable = builder.ToImmutable();


            Customer c1 = new Customer("Bloggs", "Joe");
            Customer c2 = new Customer("Bloggs", "Joe");

            Console.WriteLine(c1 == c2);
            Console.WriteLine(c1.Equals(c2));

            //var d = new Dictionary<Customer, string>();

            //d[c1] = "Joe";
            //Console.WriteLine(d.ContainsKey(c2));

            var eqComparer = new LastfirstEqComparer();
            
            var d = new Dictionary<Customer, string>(eqComparer);

            d[c1] = "Joe";
            Console.WriteLine(d.ContainsKey(c2));

            var dic = new SortedDictionary<string, string>(new SurnameComparer());
            dic.Add("MacPhail", "second!");
            dic.Add("MacWilliam", "third!");
            dic.Add("McDonald", "first!");

            foreach(string s in dic.Values)
                Console.Write(s + " ");

            var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            string[] names = { "Tom", "HARRY", "sheila" };
            CultureInfo ci = new CultureInfo("en-AU");
            Array.Sort<string>(names, StringComparer.Create(ci, false));

            foreach(string name in names)
                Console.WriteLine(name);




        }
    }
    public class Customer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Customer(string last, string first)
        {
            LastName = last;
            FirstName = first;
        }
    }
    public class LastfirstEqComparer : EqualityComparer<Customer>
    {
        public override bool Equals(Customer? x, Customer? y)
        {
            return x.LastName == y.LastName && x.FirstName == y.FirstName;
        }

        public override int GetHashCode(Customer obj)
            => (obj.LastName + ";" + obj.FirstName).GetHashCode();
       
    }

    public class SurnameComparer : Comparer<string>
    {
        string Normalize(string s)
        {
            s = s.Trim().ToUpper();
            if (s.StartsWith("MC")) s = "MAC" + s.Substring(2);
            return s;
        }

        public override int Compare(string? x, string? y)
        {
            return Normalize(x).CompareTo(Normalize(y));

        }
    }

}
