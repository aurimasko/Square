using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square.Extensions
{
    public static class ListsExtensions
    {
        public static IEnumerable<T[]> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            List<T[]> result = new List<T[]>();

            if (k == 0)
            {
                result.Add(new T[0]);
            }
            else
            {
                int current = 1;
                foreach (T element in elements)
                {
                    result.AddRange(elements
                        .Skip(current++)
                        .Combinations(k - 1)
                        .Select(combination => (new T[] { element }).Concat(combination).ToArray())
                        );
                }
            }

            return result;
        }
    }
}
