using System.Text;

namespace Dynamic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (EncodingInfo info in Encoding.GetEncodings())
            {
                Console.WriteLine(info.Name);
            
            }



            byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes("0123456789");
            byte[] utf16Bytes = System.Text.Encoding.Unicode.GetBytes("0123456789");
            byte[] utf32Bytes = System.Text.Encoding.UTF32.GetBytes("0123456789");

            Console.WriteLine(utf8Bytes.Length);
            Console.WriteLine(utf16Bytes.Length);
            Console.WriteLine(utf32Bytes.Length);

            string oryginal1 = System.Text.Encoding.UTF8.GetString(utf8Bytes);
            string oryginal2 = System.Text.Encoding.Unicode.GetString(utf16Bytes);
            string oryginal3 = System.Text.Encoding.UTF32.GetString(utf32Bytes);

            Console.WriteLine(oryginal1);
            Console.WriteLine(oryginal2);
            Console.WriteLine(oryginal3);
        }
    }
}                                   
