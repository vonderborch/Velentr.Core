using System;
using System.Collections.Generic;

namespace Velentr.Core.Helpers.Extensions
{
    /// <summary>
    ///     Extensions for lists.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        ///     A List&lt;T&gt; extension method that performs a QuickSort against the list.
        /// </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="list">             The list to act on. </param>
        /// <param name="compareMethod">
        ///     Used when deciding whether an item needs to be sorted. Must
        ///     take the form of a method returning an int, where the first
        ///     parameter is the item we are looking at and the second is the
        ///     pivot item. For more details on what this means, look at how a
        ///     QuickSort algorithm is implemented.
        /// </param>
        public static void QuickSort<T>(this List<T> list, Func<T, T, int> compareMethod)
        {
            DataStructures.QuickSort.Sort(list, compareMethod, 0, list.Count);
        }
    }
}
