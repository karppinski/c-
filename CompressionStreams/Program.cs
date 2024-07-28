using System.IO.Compression;

namespace CompressionStreams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Stream s = File.Create("compressed.bin"))
            using (Stream ds = new DeflateStream(s, CompressionMode.Compress))
                for (byte i = 0; i < 100; i++)
                    ds.WriteByte(i);
            

            using(Stream s = File.OpenRead("compressed.bin"))
            using (Stream ds = new DeflateStream(s, CompressionMode.Decompress))
                for(byte i =0; i< 100; i++)
                    Console.WriteLine(ds.ReadByte());


            string[] words = "The quick brown fox jumps over the lazy dog".Split();
            Random rand = new Random(0);

            using (Stream ss = File.Create("compressed1.bin"))
            using (Stream dss = new BrotliStream(ss, CompressionMode.Compress))
            using (TextWriter w = new StreamWriter(dss))
                for (int i = 0; i < 1000; i++)
                    w.Write(words[rand.Next(words.Length)] + " ");

            Console.WriteLine(new FileInfo("compressed1.bin").Length);

            using (Stream ss = File.OpenRead("compressed1.bin"))
            using (Stream dss = new BrotliStream(ss, CompressionMode.Decompress))
            using (TextReader r = new StreamReader(dss))
                Console.Write(r.ReadToEnd());

        }

        async Task GZip(string sourceFile, bool deleteSource = true)
        {
            var gzipfile = $"{sourceFile}.gz";
            if (File.Exists(gzipfile))
                throw new Exception("Gzip file already exists! ");

            // Compress 
            using (FileStream inStream = File.Open(sourceFile, FileMode.Open))
            using (FileStream outStream = new FileStream(gzipfile, FileMode.CreateNew))
            using (GZipStream gZipStream =
            new GZipStream(outStream, CompressionMode.Compress))
                await inStream.CopyToAsync(gZipStream);

            if (deleteSource) File.Delete(sourceFile);
        }

        async Task GUnzip(string gzipfile, bool deleteGzip = true)
        {
            if (Path.GetExtension(gzipfile) != ".gz")
                throw new Exception("Not a gzip file");

            var uncompressedFile = gzipfile.Substring(0, gzipfile.Length - 3);
            if (File.Exists(uncompressedFile))
                throw new Exception("Destiation file already exists");

            // Uncompress

            using (FileStream uncompressToStream =
                File.Open(uncompressedFile, FileMode.Create))
            using (FileStream zipfileStream = File.Open(gzipfile, FileMode.Open))
            using (var unzipStream =
            new GZipStream(zipfileStream, CompressionMode.Decompress))
                await unzipStream.CopyToAsync(uncompressToStream);

            if (deleteGzip) File.Delete(gzipfile);

        }
    }
}
