using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

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

}
