using Dictionaries;
using System.Reflection;
using System.Reflection.Emit;

namespace ReflectionNMetadata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type base1 = typeof(System.String).BaseType;
            Type base2 = typeof(System.IO.FileStream).BaseType;

            Console.WriteLine(base1.Name);
            Console.WriteLine(base2.Name);

            int i = (int)Activator.CreateInstance(typeof(int));

            Console.WriteLine(i);

            MemberInfo[] members = typeof(Walnut).GetMembers();

            foreach(MemberInfo m in members)
            {
                Console.WriteLine(m);
            }

            TypeAttributes ta = typeof(Console).Attributes;
            MethodAttributes ma = MethodInfo.GetCurrentMethod().Attributes;
            Console.WriteLine(ta + "\r\n" + ma);


            var dynMeth = new DynamicMethod("Foo", null, null, typeof(Test));
            ILGenerator gen = dynMeth.GetILGenerator();
            gen.EmitWriteLine("Hello World!");
            gen.Emit(OpCodes.Ret);
            dynMeth.Invoke(null, null);
        }


    }

    public class Walnut
    {
        private bool cracked;
        public void Crack() { cracked = true; }
    }
}
