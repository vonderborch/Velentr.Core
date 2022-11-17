using System;
using System.Collections.Generic;
using System.Linq;

namespace Velentr.Core.Helpers.DataStructures
{
    /// <summary>
    ///     A quick sort implementation.
    /// </summary>
    public static class QuickSort
    {
        /// <summary>
        ///     Sorts according to the QuickSort algorithm. https://en.wikipedia.org/wiki/Quicksort.
        /// </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="list">             The list. </param>
        /// <param name="compareMethod">
        ///     Used when deciding whether an item needs to be sorted. Must
        ///     take the form of a method returning an int, where the first
        ///     parameter is the item we are looking at and the second is the
        ///     pivot item. For more details on what this means, look at how a
        ///     QuickSort algorithm is implemented.
        /// </param>
        /// <param name="low">              (Optional) The low. </param>
        /// <param name="high">             (Optional) The high. </param>
        public static void Sort<T>(List<T> list, Func<T, T, int> compareMethod, int? low = null, int? high = null)
        {
            InternalSort(list, low ?? 0, high ?? list.Count() - 1, compareMethod);
        }

        /// <summary>
        ///     Internal sort.
        /// </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="list">             The list. </param>
        /// <param name="low">              The low. </param>
        /// <param name="high">             The high. </param>
        /// <param name="compareMethod">    The compare method. </param>
        private static void InternalSort<T>(List<T> list, int low, int high, Func<T, T, int> compareMethod)
        {
            if (low < high)
            {
                var index = Partition(list, low, high, compareMethod);
                InternalSort(list, low, index - 1, compareMethod);
                InternalSort(list, index + 1, high, compareMethod);
            }
        }

        /// <summary>
        ///     Partitions.
        /// </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="list">             The list. </param>
        /// <param name="low">              The low. </param>
        /// <param name="high">             The high. </param>
        /// <param name="compareMethod">    The compare method. </param>
        /// <returns>
        ///     An int.
        /// </returns>
        private static int Partition<T>(List<T> list, int low, int high, Func<T, T, int> compareMethod)
        {
            var pivot = list[high];
            var index = low - 1;
            T temp;

            for (var i = low; i < high; i++)
            {
                if (compareMethod(list[i], pivot) < 1)
                {
                    index++;
                    temp = list[index];
                    list[index] = list[i];
                    list[i] = temp;
                }
            }

            temp = list[index + 1];
            list[index + 1] = list[high];
            list[high] = temp;

            return index + 1;
        }
    }
}
