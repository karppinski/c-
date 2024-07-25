using System.Threading;

namespace StreamsNIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Stream s = new FileStream("test.txt", FileMode.Create))
            {
                Console.WriteLine(s.CanRead);
                Console.WriteLine(s.CanSeek);
                Console.WriteLine(s.CanWrite);

                s.WriteByte(101);
                s.WriteByte(102);
                byte[] block = { 1, 2, 3, 4, 5 };
                s.Write(block, 0, block.Length);

                Console.WriteLine(s.Length);
                Console.WriteLine(s.Position);
                s.Position = 0;

                Console.WriteLine(s.ReadByte());
                Console.WriteLine(s.ReadByte());

                Console.WriteLine(s.Read(block, 0, block.Length));

                Console.WriteLine(s.Read(block, 0, block.Length));

            }

            FileStream f1 = File.OpenRead("readme.bin"); // read only
            FileStream f2 = File.OpenWrite("writeme.tmp"); // write only
            FileStream f3 = File.Create("readWrite.tmp"); // read and write 

        }

        async static void AsyncDemo()
        {
            using (Stream s = new FileStream("test.txt", FileMode.Create))
            {
                
                byte[] block = { 1, 2, 3, 4, 5 };

                await s.WriteAsync(block, 0, block.Length);

                s.Position = 0;

                Console.WriteLine( await s.ReadAsync(block, 0, block.Length));
            }
        }
    }
}
