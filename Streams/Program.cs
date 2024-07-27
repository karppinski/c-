namespace Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllBytes("myFile.bin", new byte[3000]);

            using FileStream fs = File.OpenRead("myFile.bin");

            using BufferedStream bs = new BufferedStream(fs, 2000);

            bs.ReadByte();
            Console.WriteLine(fs.Position);


        }

    }
}
