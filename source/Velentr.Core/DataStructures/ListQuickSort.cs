namespace Velentr.Core.DataStructures;

/// <summary>
///     Provides sorting methods for lists.
/// </summary>
public static class ListQuickSort
{
    /// <summary>
    ///     Recursively sorts the specified range of the list using the provided comparison method.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to sort.</param>
    /// <param name="low">The starting index of the range to sort.</param>
    /// <param name="high">The ending index of the range to sort.</param>
    /// <param name="compareMethod">The comparison method to use for sorting.</param>
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
    ///     Partitions the specified range of the list using the provided comparison method.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to partition.</param>
    /// <param name="low">The starting index of the range to partition.</param>
    /// <param name="high">The ending index of the range to partition.</param>
    /// <param name="compareMethod">The comparison method to use for partitioning.</param>
    /// <returns>The index of the pivot element after partitioning.</returns>
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

    /// <summary>
    ///     Sorts the specified list using the provided comparison method.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to sort.</param>
    /// <param name="compareMethod">The comparison method to use for sorting.</param>
    /// <param name="low">The starting index of the range to sort (optional).</param>
    /// <param name="high">The ending index of the range to sort (optional).</param>
    public static void QuickSort<T>(this List<T> list, Func<T, T, int> compareMethod, int? low = null, int? high = null)
    {
        InternalSort(list, low ?? 0, high ?? list.Count() - 1, compareMethod);
    }

    /// <summary>
    ///     Sorts the specified list using the provided comparison method.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to sort.</param>
    /// <param name="compareMethod">The comparison method to use for sorting.</param>
    /// <param name="low">The starting index of the range to sort (optional).</param>
    /// <param name="high">The ending index of the range to sort (optional).</param>
    public static void Sort<T>(List<T> list, Func<T, T, int> compareMethod, int? low = null, int? high = null)
    {
        InternalSort(list, low ?? 0, high ?? list.Count() - 1, compareMethod);
    }
}
