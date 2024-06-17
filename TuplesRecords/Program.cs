namespace TuplesRecords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bob = ("Bob", 23);

            var joe = bob;
            joe.Item1 = "Joe";

            Console.WriteLine(bob);
            Console.WriteLine(joe);
            Console.ReadKey();

            (string, int) john = ("John", 20);

            (string, int) person = GetPerson();
            Console.WriteLine(person.Item1);
            Console.WriteLine(person.Item2);

            (string, int) GetPerson() => ("Bob", 23);

            // deconstructing

            var rob = ("Rob", 50);

            //string name = rob.Item1;
            //int age = rob.Item2;

            (string name, int age) = bob;
            (string name, int age) bobo= bob;

            Console.WriteLine(name);
            Console.WriteLine(age);

            Console.ReadKey();


            var tuple1 = ("one", 1);
            var tuple2 = ("one", 1);

            Console.WriteLine(tuple1.Equals(tuple2));
            Console.WriteLine(tuple1 == tuple2);

            Console.ReadKey();

            Console.WriteLine(tuple1.GetHashCode());
            Console.WriteLine(tuple2.GetHashCode());

            Console.ReadKey();

            Point p1 = new Point(2, 3);
            Point p2 = p1 with { A = 10 }; // nondestructive mutatiuon, 

            Poooint p3 = new Poooint(2, 3);
            Poooint p4 = p3 with { C = double.NaN };
        }

        record struct Pooint
        {

        }

        record Point 
        {
            public Point(int a, int b) => (A, B) = (a, b);

            public int A { get; init; }
            public int B { get; init; }
        }

        record Poooint
        {
            public Poooint(double c, double d) => (C, D) = (c, d);

            double _x;
            public double C
            {
                get => _x;
                init
                {
                    if (double.IsNaN(value))
                    {
                        throw new ArgumentException("X Cannot be NaN");
                    }
                    _x = value;
                }
            }

            public double D { get; init; }
        }

        record Student ( string ID, string LastName, string GivenName)
        {
            public string Id { get; } = ID;

            readonly int _enrollmentYear = int.Parse(ID.Substring(0, 4));
        }

        
    }
}
