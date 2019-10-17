using Linq.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class Step7
    {
        public void Execute()
        {
            Console.WriteLine("\nStep 6 : Exercises\n");
            IEnumerable<Location> placesVisited = TravelOrganizer.PlacesVisited;

            // De gemiddelde afstand van de steden
            Console.WriteLine($"Gemiddelde afstand van de steden is {placesVisited.Average(l => l.Distance)} miles");

            // De afstand van de verste stad
            Console.WriteLine($"De verste stad ligt op {placesVisited.Max(l => l.Distance)} miles");

            // De verste stad in de USA
            Console.WriteLine($"De verste stad in de USA is {placesVisited.OrderByDescending(l => l.Distance).FirstOrDefault(l => l.Country == "USA")}");

            // Geef de namen van de landen met steden die niet in de USA liggen en op minder dan 4600 miles afstand liggen
            IEnumerable<string> nearbyNonUSACities = null;
            Step4.PrintCollection("Dichte steden buiten de USA", nearbyNonUSACities);

            // Een gesorteerde lijst van alle landen (elk land komt slechts 1 keer voor in de lijst)
            Console.WriteLine("Alle landen in de lijst:");
            IEnumerable<string> countries = null;
            Step4.PrintCollection("Alle landen in de lijst:", countries);

            // Maak een lijst van anonieme objecten die de properties City en InUSA hebben.
            // InUSA staat op true voor een city binnen de USA, anders op false
            var cityInfo = null as string;
            Console.WriteLine("Welke steden liggen in de USA?");
            Step4.PrintCollection("Anonieme type voor landen:", cityInfo);

            // Maak een array van CityDistance objecten voor alle Locations die in de USA liggen
            CityDistance[] cityDistances = null;
            Step4.PrintCollection("CityDistances voor steden in USA:", cityDistances);

            Console.WriteLine("Druk op enter om verder te gaan...");
            Console.ReadLine();
        }
    }
}
