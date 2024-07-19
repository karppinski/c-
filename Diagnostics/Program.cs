#define TESTMODE
#define PLAYMODE
using System.Diagnostics;
using System.Threading;
using System.Diagnostics.Tracing;

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


            foreach ( Process p in Process.GetProcesses())

                using (p)
                {
                    Console.WriteLine(p.ProcessName);
                    Console.WriteLine("   PID:     " + p.Id);
                    Console.WriteLine("   Memory:  " + p.WorkingSet64);
                    Console.WriteLine("   Threads: " + p.Threads.Count);
                }

            A();

            bool enumerateOverAllCounters = false;


            if (enumerateOverAllCounters)
            {
                PerformanceCounterCategory[] cats =
                    PerformanceCounterCategory.GetCategories();

                foreach (PerformanceCounterCategory cat in cats) // over 10k lines
                {
                    Console.WriteLine("Category: " + cat.CategoryName);

                    string[] instances = cat.GetInstanceNames();
                    if (instances.Length == 0)
                    {
                        foreach (PerformanceCounter ctr in cat.GetCounters())
                            Console.WriteLine("   Counter:   " + ctr.CounterName);
                    }

                    else
                    {
                        foreach (string instance in instances)
                        {
                            Console.WriteLine("   Instance:   " + instance);
                            if (cat.InstanceExists(instance))
                            {
                                foreach (PerformanceCounter ctr in cat.GetCounters(instance))
                                {
                                    Console.WriteLine("   Counter:   " + ctr.CounterName);
                                }
                            }
                        }
                    }
                }
            }
            string procName = Process.GetCurrentProcess().ProcessName;

            using PerformanceCounter pc = new PerformanceCounter("Process", "Private Bytes", procName);
            Console.WriteLine(pc.NextValue());


            string category = "Nutshell Monitoring";

            string eatenPerMin = " Macadamias easten so far";
            string tooHard = "Macadamias deemed too hard";

            if (!PerformanceCounterCategory.Exists(category))
            {
                CounterCreationDataCollection cd = new CounterCreationDataCollection();

                cd.Add(new CounterCreationData(eatenPerMin,
                    "Number of macadamias consumed, including shelling time",
                    PerformanceCounterType.NumberOfItems32));

                cd.Add(new CounterCreationData(tooHard,
                    "Number of macadamias that will not crack, despite much effort",
                    PerformanceCounterType.NumberOfItems32));

                PerformanceCounterCategory.Create(category, "Test category",
                    PerformanceCounterCategoryType.SingleInstance, cd);
            }

            Stopwatch s = Stopwatch.StartNew();
            File.WriteAllText("test.txt", new string('*', 30000000));
            Console.WriteLine(s.Elapsed);


        }

        static void A() { B(); }
        static void B() { C(); }
        static void C()
        {
            StackTrace s = new StackTrace(true);

            Console.WriteLine("Total frames:    " + s.FrameCount);
            Console.WriteLine("Current method:  " + s.GetFrame(0).GetMethod().Name);
            Console.WriteLine("Calling method:  " + s.GetFrame(1).GetMethod().Name);
            Console.WriteLine("Entry method:    " + s.GetFrame(s.FrameCount-1).GetMethod().Name);

            Console.WriteLine("Call Stack:");
            foreach(StackFrame f in s.GetFrames())
            {
                Console.WriteLine(
                    "    File:   " + f.GetFileName() +
                    "    Line:   " + f.GetFileLineNumber() + 
                    "    Col:    " + f.GetFileColumnNumber() +
                    "    Offset: " + f.GetILOffset() +
                    "    Method: " + f.GetMethod().Name);
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
