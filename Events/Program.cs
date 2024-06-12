namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int factor = 2;
            Func<int, int> multiplier = n => n * factor;
            Console.WriteLine(multiplier(3));
            Console.ReadKey();    
            
            Func<int, int> multiplier2 = n => n * factor;
            factor = 10;
            Console.WriteLine(multiplier2(3));
            Console.ReadKey();

            int seed = 0;
            Func<int> natural = () => seed++;
            Console.WriteLine(natural());
            Console.WriteLine(natural());
            Console.WriteLine(seed);
            Console.ReadKey();

            Func<int, int> staticMultiplier = static n => n * 2;

            Console.WriteLine("static mutlipier: " + staticMultiplier.Target.ToString()) ;
            Console.ReadKey();


            Action[] actions = new Action[3];

            for(int i = 0; i <3; i++)
            {
                actions[i] = () => Console.Write(i); 
            }

            foreach (Action a in actions) a();
            Console.ReadKey();

        }
    }
}
