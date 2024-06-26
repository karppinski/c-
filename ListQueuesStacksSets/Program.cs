using System.Collections;
using System.Diagnostics;

namespace ListQueuesStacksSets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            al.AddRange(new[] { 1, 5, 9 });
            List<int> list = al.Cast <int>().ToList();



            var tune = new LinkedList<string>();
            tune.AddFirst("do");
            view(tune);
            tune.AddLast("so");
            
            view(tune);

            tune.AddAfter(tune.First, "re");
            view(tune);
            tune.AddAfter(tune.First.Next, "mi");
            view(tune);
            tune.AddBefore(tune.Last, "fa");

            view(tune);



            tune.Remove(tune.Find("mi"));

            view(tune);

            tune.AddFirst("mi");

            view(tune);


            var bits = new BitArray(2);
            bits[1] = true;

            bits.Xor(bits);

            Console.WriteLine(bits[1]);


        }
        static void view(LinkedList<string> list)
        {
            foreach (string e in list){
                Console.Write(e + " ");
            }
            Console.WriteLine();
        }
    }

    public class LinkedListNode<T>
    {
        public LinkedList<T> List { get;  }
        public LinkedListNode<T> Next { get;  }
        public LinkedListNode<T> Previous { get;  }
        public T Value { get;  }
        
    }
}
