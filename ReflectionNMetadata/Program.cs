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



            var dynMeth2 = new DynamicMethod("Foo2", null, null, typeof(Program));
            ILGenerator gen2 = dynMeth2.GetILGenerator();
            MethodInfo writeLineInt = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) });         
            
            // 10 / 2 + 1
            gen2.Emit(OpCodes.Ldc_I4, 10);
            gen2.Emit(OpCodes.Ldc_I4, 2);
            gen2.Emit(OpCodes.Div);
            gen2.Emit(OpCodes.Ldc_I4, 1);
            gen2.Emit(OpCodes.Add);
            gen2.Emit(OpCodes.Call, writeLineInt);
            gen2.Emit(OpCodes.Ret);
            dynMeth2.Invoke(null, null);

            int x = 6;
            int y = 7;
            x *= y;
            Console.WriteLine(x);

            var dynMeth3 = new DynamicMethod("Test", null, null, typeof(void));
            ILGenerator gen3 = dynMeth3.GetILGenerator();

            LocalBuilder localX = gen3.DeclareLocal(typeof(int));
            LocalBuilder localY = gen3.DeclareLocal(typeof(int));

            gen3.Emit(OpCodes.Ldc_I4, 6);
            gen3.Emit(OpCodes.Stloc, localX);
            gen3.Emit(OpCodes.Ldc_I4, 7);
            gen3.Emit(OpCodes.Stloc, localY);

            gen3.Emit(OpCodes.Ldloc, localX);
            gen3.Emit(OpCodes.Ldloc, localY);
            gen3.Emit(OpCodes.Mul);
            gen3.Emit(OpCodes.Stloc, localX);

            gen3.EmitWriteLine(localX);
            gen3.Emit(OpCodes.Ret);

            dynMeth3.Invoke(null,null);

        }


    }

    public class Walnut
    {
        private bool cracked;
        public void Crack() { cracked = true; }
    }
}
