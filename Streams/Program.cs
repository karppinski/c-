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
            

            using(FileStream fss = File.Create("test.txt"))
            using (TextWriter writer = new StreamWriter(fss))
            {
                writer.WriteLine("Line1");
                writer.WriteLine("Line2");
            }

            using (TextWriter writer = File.AppendText("test.txt"))
                writer.WriteLine("Line3");


            //using (FileStream fss = File.OpenRead("test.txt"))
            //using (TextReader reader = new StreamReader(fss))
            //{
            //    //Console.WriteLine(reader.ReadLine());
            //    //Console.WriteLine(reader.ReadLine());


            //}

            using (TextReader reader = File.OpenText("test.txt"))
            {
                while(reader.Peek() > -1)
                    Console.WriteLine(reader.ReadLine());
            }

        }

    }
}
