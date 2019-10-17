using System;
using System.Collections.Generic;
using Extensions;

namespace Linq
{
    public class Step1
    {
        public void Execute()
        {
            Console.WriteLine("\nStep 1. Extension methods.\n");

            // voorbeeld: extension methods gedefinieerd op Int32
            Console.WriteLine($"Is 6 even? {6.IsEven()}");
            Console.WriteLine($"Is 7 even? {7.IsEven()}");
            for (int i = 0; i < 10; i++)
            {
                string even = i.IsEven() ? "even" : "odd";
                Console.WriteLine($"{i} is {even}");
            }

            // voorbeeld: extension methods gedefinieerd op string
            string hello = "Hello!";
            Console.WriteLine($"6 times {hello}, that's {hello.RepeatText(6)}");

            string myText = "Please repeat me...";
            Console.WriteLine(myText.RepeatText(2));

            // voorbeeld: extension method op IEnumerable<int>
            IList<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine($"De som is {numbers.CalculateSum()}");

            // extension method IsDivisibleBy geeft aan of 
            // een geheel getal deelbaar is door een ander geheel getal
            // vervolledig de extension method in de klasse Extension, en vervolledig onderstaande for-loop
            // zodat enkel getallen die deelbaar zijn door 3 worden getoond, maak gebruik van de extension method
            Console.WriteLine("Getallen tussen 1 en 20 deelbaar door 3:");
            for (int i = 1; i <= 20; i++)
            {
                if (i.IsDivisibleBy(3))
                {
                    Console.WriteLine(i);
                }
            }                       

            Console.WriteLine("Druk op enter om verder te gaan...");
            Console.ReadLine();
        }
    }
}
