using System.Collections.ObjectModel;
using System.Reflection;

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



            var sorted = new SortedList<string, MethodInfo>();

            foreach (MethodInfo m in typeof(object).GetMethods())
                sorted[m.Name] = m;

            foreach(string name in sorted.Keys)
                Console.WriteLine(name);

            foreach(MethodInfo m in sorted.Values)
                Console.WriteLine(m.Name + " returns a " + m.ReturnType);


            Console.WriteLine("Hello, World!");


            Test t = new Test();
            Console.WriteLine(t.Namez.Count);
            t.AddInternally();

            Console.WriteLine(t.Namez.Count);

            //  t.Namez.Add("test");  compiler error

            ((IList<string>)t.Namez).Add("test");

Console.WriteLine(t.Namez.Count);

        }
    }


    public class Test
    {
        List<string> namez = new List<string>();
        public IReadOnlyList<string> Namez => namez;

        public void AddInternally() => namez.Add("test");

    }

}
