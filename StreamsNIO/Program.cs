using System.IO.Pipes;
using System.Threading;
using System.Xml.Schema;

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

            using var ps = new NamedPipeServerStream("pipedream");
            
                ps.WaitForConnection();
                ps.WriteByte(100);
            Console.WriteLine(ps.ReadByte());


            using var sp= new NamedPipeClientStream("pipedream");
            sp.Connect();
            Console.WriteLine(sp.ReadByte());
            sp.WriteByte(200);


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

        static void AnnonymousPipeClient(string rxID, string txID)
        {
            using (var rx = new AnonymousPipeClientStream(PipeDirection.In, rxID)) ;
            {
                using (var tx = new AnonymousPipeClientStream(PipeDirection.Out, txID)) ;
                {
                    Console.WriteLine("Client received: " + 
                } }

        }
    }
}
