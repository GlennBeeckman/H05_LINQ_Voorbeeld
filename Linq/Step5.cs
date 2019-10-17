using Linq.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class Step5
    {
        public void Execute()
        {
            Console.WriteLine("\nStep 5 : Nog meer handige LINQ operatoren\n");

            IEnumerable<Location> placesVisited = TravelOrganizer.PlacesVisited;

            // FirstOrDefault: vind de verste stad
            Location furthest = placesVisited.OrderByDescending(c => c.Distance).FirstOrDefault();
            Console.WriteLine($"Verste stad: {furthest}");
            Console.WriteLine();

            // Skip n Take: cities 2 - 5
            IEnumerable<Location> locations = placesVisited.Skip(1).Take(5);
            Step4.PrintCollection("Cities skip 1 take 5", locations);
            Console.WriteLine();

            // Any/All:
            //any returnt true als er 1 inzit did voldoet aan de conditie bij all moeten ze er allemaal aan voldoen
            Console.WriteLine($"Is er een stad op meer dan 5000 miles afstand? {placesVisited.Any(c => c.Distance > 5000)}");
            Console.WriteLine($"Liggen alle steden op zijn minst 2000 miles ver? {placesVisited.All(c => c.Distance >= 2000)}");
            Console.WriteLine();

            // SelectMany: flat list of countries and cities with use of collection initializer
            var flatListOfNames = placesVisited.SelectMany(c => new List<string> { c.City, c.Country });
            Console.WriteLine("Alle steden en landen in 1 lijst:");
            foreach (var n in flatListOfNames)
                Console.WriteLine($"- {n} -");
            Console.WriteLine();

            // Groeperen van gegevens: per land, de steden die behoren tot het land...
            var overzicht = placesVisited.GroupBy(l => l.Country, l => l.City);
            foreach (var overzichtsGroep in overzicht)
            {
                Console.WriteLine(overzichtsGroep.Key);
                foreach (string city in overzichtsGroep)
                    Console.WriteLine($"  - {city}");
            }
            Console.WriteLine();

            Console.WriteLine("Druk op enter om verder te gaan...");
            Console.ReadLine();
        }
    }
}
