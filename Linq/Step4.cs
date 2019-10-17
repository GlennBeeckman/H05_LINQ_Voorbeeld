using Linq.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class Step4
    {
        public void Execute()
        {
            Console.WriteLine("\nStep 4: Linq Select, var en anonieme types\n");

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<Location> placesVisited = TravelOrganizer.PlacesVisited;

            // simpele transformatie van collectie van int-s
            IEnumerable<int> newNumbers = numbers.Select(g => g + 1);
            PrintCollection("De gewijzigde lijst van getallen:", newNumbers);

            // De namen van de steden. Transformatie van Location-s naar string-s. 
            IEnumerable<string> cityNames = placesVisited.Select(c => c.City);
            PrintCollection("De namen van de steden:", cityNames);

            // Oefening: De namen van de steden in de USA, gesorteerd op naam. Transformatie van Location-s naar string-s. 
            IEnumerable<string> citiesInUSA = placesVisited
                                                .Where(l => l.Country == "USA")
                                                .Select(l => l.City)
                                                .OrderBy(c => c);
            PrintCollection("De namen van de steden in de USA:", citiesInUSA);

            // transformatie van Location-s naar CityDistance-s, object initializer
            IEnumerable<CityDistance> cityDistances = placesVisited
                                                        .Select(l => new CityDistance
                                                                        {
                                                                            Country = l.Country,
                                                                            Name = l.City,
                                                                            DistanceInKm = (int)(l.Distance*1.61)
                                                                        });
            PrintCollection("Afstanden in km:", cityDistances);
            Console.WriteLine();

            //voorbeeld met gebruik van var, IEnumerable<Location> wordt omgezet naar een type door de compiler bepaald...
            var cityList = placesVisited.Select(c => c.City);
            foreach (var city in cityList)
                Console.WriteLine(city);

            //transformatie naar een anoniem type met de props Name, Country en DistanceInKm
            var anonymousCities = placesVisited.Select(c => new
            {
                Name = c.City,
                c.Country,
                DistanceInKm = c.Distance * 1.61
            });
            PrintCollection("Anonieme types:", anonymousCities);
            Console.WriteLine();

            Console.WriteLine("Druk op enter om verder te gaan...");
            Console.ReadLine();
        }

        // generische methode PrintCities<T>
        public static void PrintCollection<T>(string title, IEnumerable<T> cities)
        {
            Console.WriteLine();
            Console.WriteLine($"----- {title} -----");
            if (cities == null || !cities.Any())
                Console.WriteLine("geen steden...");
            else
                foreach (var c in cities)
                    Console.WriteLine(c);
            Console.WriteLine();
        }
    }
}
