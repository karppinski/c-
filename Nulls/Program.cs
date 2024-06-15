namespace Nulls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int? x = 5;
            int y = (int)x;

            object o = "string";
            int? z = o as int?;
            Console.WriteLine(z.HasValue);
            Console.ReadKey();

            int? a = 5;
            int? b = 10;
            bool c = a < b;

            bool cIsThis = (a.HasValue && b.HasValue) ? (a.Value < b.Value) : false;

            int? t = null;

            string? empty = null;

            object emptyO = null;
            Console.WriteLine(t);
            Console.WriteLine(empty);
            Console.WriteLine(emptyO);
            Console.ReadKey();
        }



    }
    
    
}
//public struct Nullable<T> where T : struct
//{
//    public T Value { get; }
//    public bool HasValue { get; }
//    public T GetValueOrDefault();
//    public T GetValueOrDefault(T defaultValue);;



//}
