using System;
using System.Collections.Generic;

namespace Extentions
{
    public static class EnumerableExtentions
    {
        public static T ElementAtt<T>(this IEnumerable<T> collection, int index)
        {
            var currentIndex = 0;
            var moveResult = false;
            var enumerator = collection.GetEnumerator();

            while (currentIndex < index)
            {
                currentIndex++;
                moveResult = enumerator.MoveNext();
            }

            return enumerator.Current;
        }
        
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> toFilter, Func<T, bool> filter)
        {
            if (filter == null) throw new ArgumentNullException("filter");
            var list = new List<T>();
            foreach (var item in toFilter)
            {
                if (filter(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}