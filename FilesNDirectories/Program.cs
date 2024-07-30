using System.Runtime.InteropServices;

namespace FilesNDirectories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(@"c:\test"))
            {
                Directory.CreateDirectory(@"c:\test");
                Console.WriteLine("Directory created");
            }
            else Console.WriteLine("Directory exists!");

            Directory.CreateDirectory(TestDirectory);

            FileInfo fi = new FileInfo(Path.Combine(TestDirectory, "FileInfo.txt"));

            Console.WriteLine(fi.Exists);

            using (TextWriter w = fi.CreateText())
                w.Write("Some text");

            Console.WriteLine(fi.Exists);

            fi.Refresh();

            Console.WriteLine(fi.Exists);

            Console.WriteLine(fi.Name);
            Console.WriteLine(fi.FullName);

            Console.WriteLine(fi.DirectoryName);
            Console.WriteLine(fi.Directory.Name);
            Console.WriteLine(fi.Extension);
            Console.WriteLine(fi.Length);

            try
            {
                fi.Encrypt();
                Console.WriteLine("File encrypted successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Encryption failed: {ex.Message}");
            }

            fi.Attributes ^= FileAttributes.Hidden;
            fi.IsReadOnly = true;

            Console.WriteLine(fi.Attributes);
            Console.WriteLine(fi.CreationTime);

            if (!File.Exists(@"c:\Temp\FileInfoX.txt"))
            {
                fi.MoveTo(Path.Combine(TestDirectory, "FileInfoX.txt"));
            }

            DirectoryInfo di = fi.Directory;
            Console.WriteLine(di.Name);
            Console.WriteLine(di.FullName);
            Console.WriteLine(di.Parent.FullName);
            di.CreateSubdirectory("SubFFolder");

            bool enumerate = false;

            DirectoryInfo dii = new DirectoryInfo(@"e:\photos");

            if (enumerate)
            {
                foreach(FileInfo fii in dii.GetFiles("*.jpg"))
                {
                    Console.WriteLine(fii.Name);
                }

                foreach(DirectoryInfo subDir in di.GetDirectories())
                {
                    Console.WriteLine(subDir.Name);
                }
            }

            DriveInfo c = new DriveInfo("C");

            long totalSize = c.TotalSize;
            long freeBytes = c.TotalFreeSpace;
            long freeToMe = c.AvailableFreeSpace;

            foreach(DriveInfo d in DriveInfo.GetDrives())
            {
                Console.WriteLine(d.Name);
                Console.WriteLine(d.DriveType);
                Console.WriteLine(d.RootDirectory);

                if (d.IsReady)
                {
                    Console.WriteLine(d.VolumeLabel);
                    Console.WriteLine(d.DriveFormat);
                }
            }

            Directory.Delete(@"c:\Temp", true);



        }

        static string TestDirectory =>
    RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
    ? @"C:\Temp"
    : "/tmp";





    }
}
