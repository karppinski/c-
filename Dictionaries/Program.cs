namespace Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // my own abstraction dictionaries are just proxy to let you deal with hashtables(that are hella efficient) easier


            var d = new Dictionary<string, int>();


            d.Add("One", 1);
            d["Two"] = 2; // implicit add
            d["Two"] = 22; // implicit override

            d["Three"] = 3;

            Console.WriteLine(d["Two"]);
            Console.WriteLine(d.ContainsKey("One")); // fast operation
            Console.WriteLine(d.ContainsValue(3)); // slow operation idk why


            // its because looking up for hashed key is O(1) and do not need to check for whole dictionary..
            




            Console.WriteLine("Hello, World!");
        }
    }
}
