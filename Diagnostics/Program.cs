#define TESTMODE
#define PLAYMODE
using System.Diagnostics;

namespace Diagnostics
{
    internal class Program
    {

        static internal bool TestMode = true; // with this it is harder to lookup for things from other assembly
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

#if TESTOMDE && !PLAYMODE
                Console.WriteLine("in tst mode!");
#endif

#if !NET6_0_OR_GREATER
global::System.Console.WriteLine("dotnet problem");
#endif

            if (TestMode)
            {
                Console.WriteLine("In test mode");

            }


            ////clear the default listener
            //Trace.Listeners.Clear();

            //// Add a writer that appends to the trace.txt file:
            //Trace.Listeners.Add(new TextWriterTraceListener("trace.txt"));

            ////|Obtain the Console's output stream, then add that as a listener:
            //System.IO.TextWriter tw = Console.Out;
            //Trace.Listeners.Add(new TextWriterTraceListener(tw));

            ////set up a Windows event log source and then create/add listener.
            ////CreateEventSource requires administrative elevation, so this would typicallly be done in application setup.
            //if(!eventLog.SourceExists("DemoApp"))
            //    EventLog.CreateEventSource  idk not working


            foreach( Process p in Process.GetProcesses())

                using (p)
                {
                    Console.WriteLine(p.ProcessName);
                    Console.WriteLine("   PID:     " + p.Id);
                    Console.WriteLine("   Memory:  " + p.WorkingSet64);
                    Console.WriteLine("   Threads: " + p.Threads.Count);
                }

            


        }
        public void EnumerateThreads (Process p)
        {
            foreach(ProcessThread pt in p.Threads)
            {
                Console.WriteLine(pt.Id);
                Console.WriteLine("   State:     " + pt.ThreadState);
                Console.WriteLine("   Priority:  " + pt.PriorityLevel);
                Console.WriteLine("   Started:   " + pt.StartTime);
                Console.WriteLine("   CPU Time:  " + pt.TotalProcessorTime);
            }
        }
    }
}
