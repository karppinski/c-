using System;

namespace Collections
{
    public class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Person> pipul = new List<Person>();

            Person Bob = new Person("Bob");
            pipul.Add(Bob);
            Person Rob = new Person("Rob");

            pipul.Add(Rob);
            Person Kob = new Person("Kob");

            pipul.Add(Kob);
            Person Sob = new Person("Sob");

            pipul.Add(Sob);

            Console.WriteLine(pipul.Count);

            foreach (Person p in pipul)
            {
                Console.WriteLine(p.Name);
            }


            var pipArr = new Person[4];
            for(int i =  0; i < 4; i++)
                {
                    pipArr[i] = pipul[i];
                }
          
            foreach(Person p in pipArr)
            {
                
                Console.WriteLine(p.Name + " in arr");
            }


            Array a = Array.CreateInstance(typeof(string), 2);
            a.SetValue("hi", 0);
            a.SetValue("there", 1);

            string s = (string)a.GetValue(0);

            string[] cSharpArray = (string[])a;

            string s2 = cSharpArray[0];


            object copierd = pipArr.Clone();

            object copierdAr;


            


        }
    }
}
