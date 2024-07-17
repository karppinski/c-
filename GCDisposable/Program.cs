using System.Collections.Concurrent;

namespace GCDisposable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //intentional objectdisposed exceptions
            //var stream = new MemoryStream();
            //stream.Dispose();

            //int data = stream.ReadByte();

            try
            {
                List<byte[]> memoryKiller = new List<byte[]>();
                int counter = 0;


                while (true)
                {
                    memoryKiller.Add(new byte[1024 * 1024]);
                    Console.WriteLine("Allocated 1 MB");

                    counter++;

                    if (counter % 10 == 0)
                    {
                        for (int i = 0; i <5 && memoryKiller.Count >0; i++)
                        {
                            memoryKiller.RemoveAt(0);
                            Console.WriteLine("Removed 1 MB");
                            if(i == 4)
                            {
                                long memoryUsed = GC.GetTotalMemory(true);
                                Console.WriteLine("Memory used: " + memoryUsed);
                            }
                        }

                    }
                    Console.WriteLine("Memory before collection: " + GC.GetTotalMemory(true));
                    GC.Collect();

                    Console.WriteLine("Memory after collection: " + GC.GetTotalMemory(true));
                    Console.WriteLine("Memory collected");
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine("Out of memory exception caught: " + ex.Message);
            }

        }
    }

    public class TempFileRef  // when file is in use or already deleted or lack of permission, there will be exception while deleting
    {
        public readonly string FilePath;
        public TempFileRef(string filePath) { FilePath = filePath; }

        ~TempFileRef() { File.Delete(FilePath); }
    }

    public class TempFileRef1 // ressurection
    {
        static internal readonly ConcurrentQueue<TempFileRef1> FailedDeletions
               = new ConcurrentQueue<TempFileRef1>();

        public readonly string FilePath;
        public Exception DeletionError { get; private set; }
        public TempFileRef1(string filePath)
        {
            FilePath = filePath;
        }

        ~TempFileRef1()
        {
            try { File.Delete(FilePath); }
            catch(Exception ex)
            {
                DeletionError = ex;
                FailedDeletions.Enqueue(this); // when possible
            }
        }
    }

    public class TempFileRef2 // while dealing with ressurected objects u will need to call GC on ur own
    {
        public readonly string FilePath;
        int _deleteAttempt;

        public TempFileRef2(string filePath)
        {
            FilePath = filePath;
        }

        ~TempFileRef2()
        {
            try { File.Delete(FilePath); }
            catch
            {
                if (_deleteAttempt++ < 3) GC.ReRegisterForFinalize(this);  // after third try finalizer won't be called anymore 
            }
        }


    }


}         
