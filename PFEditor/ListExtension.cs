using System;
using System.Collections.Generic;

namespace CustomLib
{
    public static class ListExtension
    {
        public static void Shuffle<T>(this IList<T> lst, Random rng)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                int newIndex = rng.Next(lst.Count);

                // Swap [i] and [newIndex]
                T tmp = lst[i];
                lst[i] = lst[newIndex];
                lst[newIndex] = tmp;
            }
        }
    }
}
