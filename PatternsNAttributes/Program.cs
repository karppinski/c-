using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace PatternsNAttributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool IsJanetOrJohn(string name) =>
                name.ToUpper() is var upper && (upper == "JANNET" || upper == "JOHN");

            string GetWeightCategory(decimal bmi) => bmi switch
            {
                < 18.5m => "underweight",
                < 25m => "normal",
                < 30m => "overwieght",
                _ => "obese"
            };

            bool IsVowel(char c) => c is 'a' or 'e' or 'i' or 'o' or 'u';

            bool Bettween1And9(int n) => n is >= 1 and <= 9;

            bool IsLetter(char c) => c is >= 'a' and <= 'z'
                                       or >= 'A' and <= 'Z';


            bool ShouldAllow(Uri uri) => uri switch
            {
                { Scheme: "http", Port: 80 } => true,
                { Scheme.Length : 4, Port: 80 } => true,
                { Host.Length : < 1000, Port: >0 } => true,

                { Scheme: "https", Port: 443 } => true,
                { Scheme: "ftp", Port: 21 } => true,
                { IsLoopback: true } => true,
                _ => false
            };

            foo();

            Console.ReadKey();
    }

        static void foo(        
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath =null,
            [CallerLineNumber] int lineNumber= 0)
        {
            Console.WriteLine(memberName);
            Console.WriteLine(filePath);
            Console.WriteLine(lineNumber);
        }

        
        [XmlType ("Customer", Namespace = "http://oreilly.com")]
        [assembly: AssemblyFileVersion("1.2.3.4")]
        public class CustomerEntity
        {
            [field: NotNull]
            public int MyProperty { get; set; }

            //Action<int> a = [Description("Method")]
            //[return: Description("return value")] chuj nie działa trzeba by było atrybyuty chyba dodać konkretnie do return typu a nie do metody
            //([Description("Parameter")] int x) => Console.Write(x);

        }
            [XmlSerializerAssembly, Obsolete, CLSCompliant(false)]
            public class klas
        {

        }
            [XmlSerializerAssembly] [Obsolete] [CLSCompliant(false)]
            public class klas1
        {

        }

            [XmlSerializerAssembly, Obsolete] 
            [CLSCompliant(false)]
            public class klas2
        {

        }

    }
}
