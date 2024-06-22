using System.ComponentModel.DataAnnotations;

namespace BitOperationsEnums
{
    internal class Program
    {

        static int GetIntegralValue (Enum anyEnum)
        {
            return (int)(object)anyEnum;
        }

        static decimal GetAnyIntegralValue(Enum anyEnum)
        {
            return Convert.ToDecimal(anyEnum);
        }

        [Flags]
        public enum BorderSides { Left =1,Right =2,Top=4, Bottom =8}
        enum Nut { Walnut, Hazelnut, Macadamia }
        enum Size { Small, Medium, Large }
        static void Main(string[] args)
        {
            Display(Nut.Macadamia);
            Display(Size.Large);

            void Display(Enum value)
            {
                Console.WriteLine(value.GetType().Name + "." + value.ToString());
            }

            int i = (int)BorderSides.Top;
            BorderSides side = (BorderSides)i;

            Console.WriteLine( side.ToString());

            object bs = Enum.ToObject(typeof(BorderSides), 3);
            Console.WriteLine( bs);


        }
    }
}
