using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TryCatchExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> Prices = new Dictionary<string, int>();
            try 
            {
                for (int i = 0; i < 2; i++)
                {
                    argument(); 
                }

                //var pricesarr = Prices.ToArray();
                //var outOfRange = pricesarr[pricesarr.Length];

                string notExistingKey = null;
                int value = Prices[notExistingKey];

             //   ReadOnlyCollection<string, int> readonlyPrices = new ReadOnlyCollection<string, int>(Prices);



            }
            //catch (IndexOutOfRangeException)
            //{
            //    Console.WriteLine("Argument out of range exception here");
            //}
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument null exception here");
            } 

            catch (ArgumentException)
            {
                Console.WriteLine("Argument exception here");
            }
            
            


            void argument()
            {
                string itemName = Console.ReadLine();
                
                
                
                
             
                int price = int.Parse(Console.ReadLine());

                addItem(itemName, price); 

                void addItem(string itemName, int price)
                {

                    Prices.Add(itemName, price);
                }
            }
        }
    }
}