using System.Reflection;

namespace Assemblies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly a = typeof(Program).Assembly;

            Console.WriteLine(a.GetName());
            Console.WriteLine(a.FullName);


            var executingAssembly = Assembly.GetExecutingAssembly();
            
            Console.WriteLine(executingAssembly);


        }
    }
}
