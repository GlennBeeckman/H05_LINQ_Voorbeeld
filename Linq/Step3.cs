using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Models;

namespace Linq
{
    public class Step3
    {
        public void Execute()
        {
            Console.WriteLine("\nStep 3: Where en lambda expressies\n");

            IEnumerable<Location> placesVisited = TravelOrganizer.PlacesVisited;
            int sumDistances = placesVisited.Sum(l => l.Distance); //hij herkent de de l omdat placesVisited een IEnumerable is
            Console.WriteLine($"De som van alle afstanden is {sumDistances} miles");

            int[] results = { 12, 15, 7, 9, 10, 5, 0, 20 };
            // bereken hieronder het aantal results hoger of gelijk aan 10
            int nrOfPasses = results.Count(r => r>= 10);
            Console.WriteLine($"De resultaten bevatten {nrOfPasses} cijfers boven de helft");
            Console.WriteLine();

            string[] cities = {
                                  "London", "Amsterdam", "San Francisco", "Las Vegas", "Boston", "Raleigh", "Chicago",
                                  "Charlestown", "Helsinki", "Nice", "Dublin"
                              };

            // filter: steden waarvan de naam langer dan 5 posities
            IEnumerable<string> citiesWithlongNames = cities.Where(c => c.Length > 5);

            // onderstaande uit commentaar halen: demo deferred execution
            //cities[0] = "Oostende";

            Console.WriteLine("Steden met namen langer dan 5 karakters:");
            foreach (var city in citiesWithlongNames)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();

            // steden waarvan de naam langer dan 5 posities, gesorteerd op naam
            IEnumerable<string> orderedPlaces = cities.Where(c => c.Length > 5).OrderBy(c => c).ToList(); //de ToList zorgt ervoor dat de methode meteen uigevoerd wordt
           // De deferred execution -> de methode wordt pas uitgevoerd op de moment dat je het oproept
           //ZEER BELANGRIJK!!!!!!!
            // cities[0] = "Oostende";
            Console.WriteLine("Gesorteerde lijst van steden met namen langer dan 5 karakters:");
            foreach (var city in orderedPlaces)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();

            // steden waarvan de naam langer is dan 5 posities en starten met de letter 'S'
            // gesorteerd dalend op lengte van de naam, en dan op de naam zelf
            string[] cities2 = {
                                  "London", "Amsterdam", "San Francisco", "Las Vegas", "Boston", "Raleigh", "Chicago",
                                  "Charlestown", "Helsinki", "Nice", "Dublin", "San Anselmo", "San Diego", "San Mateo"
                              };
            // vul selectedCities adhv een gepaste Linq expressie
            IEnumerable<string> selectedCities = cities2
                                                    .Where(c => c.Length > 5 && c.StartsWith("S"))
                                                    .OrderByDescending(c => c.Length)
                                                    .ThenBy(c => c);

            Console.WriteLine("Steden met namen langer dan 5 karakters, en beginnend met 'S', dalend gesorteerd op lengte van de naam, dan op naam:");
            // schrijf hier de steden uit adhv een for each
            foreach(string city in selectedCities)
            {
                Console.WriteLine(city);
            }
            //Console.WriteLine();
            Console.WriteLine("Druk op enter om verder te gaan...");
            Console.ReadLine();
        }
    }
}
