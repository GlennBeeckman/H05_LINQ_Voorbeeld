using System;
using System.Collections.Generic;
using Linq.Models;

namespace Extensions
{
    public static class StringExtension
    {
        // voorbeeld: extension method gedefinieerd op string
        public static string RepeatText(this string s, int aantal) 
        {
            string resultaat = string.Empty;
            for (int i = 0; i < aantal; i++)
                resultaat += s;
            return resultaat;
        }

        // voorbeeld: extension method gedefinieerd op IEnumerable<Location>
        public static IEnumerable<Location> CheckIfTrue(this IEnumerable<Location> locations, Func<Location, bool> method)
        {
            IList<Location> list = new List<Location>();
            foreach (Location l in locations)
                if (method(l))
                    list.Add(l);
            return list;
        }
    }
    public static class IntExtension
    {
        // voorbeeld: extension method gedefinieerd op Int32
        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

        // voorbeeld: extension method gedefinieerd op IEnumerable<int>
        public static int CalculateSum(this IEnumerable<int> numbers)
        {
            if (numbers == null)
                throw new ArgumentException();
            int aux = 0;
            foreach (int i in numbers)
                aux += i;
            return aux;
        }

        // maak van IsdivisibleBy een extension method gedefinieerd op een geheel getal
        // de extension method retourneert true wanneer het getal 
        // deelbaar is door een ander geheel getal (parameter!)
        public static bool IsDivisibleBy(this int i, int by)
        {
            return i % by == 0;
        }
    }
}
