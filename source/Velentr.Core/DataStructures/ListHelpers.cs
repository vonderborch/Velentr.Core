namespace Velentr.Core.DataStructures;

/// <summary>
///     Provides helper methods for working with lists.
/// </summary>
public static class ListHelpers
{
    /// <summary>
    ///     Adds multiple items to the list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to add items to.</param>
    /// <param name="items">The items to add to the list.</param>
    public static void AddItems<T>(this List<T> list, params T[] items)
    {
        list.AddRange(items);
    }

    /// <summary>
    ///     Compiles a list from multiple lists and individual items.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="lists">The lists to compile.</param>
    /// <param name="individuals">The individual items to add to the list.</param>
    /// <returns>A compiled list containing all elements from the provided lists and individual items.</returns>
    public static List<T> CompileList<T>(IEnumerable<T>[]? lists, params T[] individuals)
    {
        List<T> toReturn = individuals.ToList();
        if (lists != null)
        {
            foreach (IEnumerable<T> list in lists)
            {
                toReturn.AddRange(list);
            }
        }

        return toReturn;
    }

    /// <summary>
    ///     Compiles a list from individual items.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="individuals">The individual items to add to the list.</param>
    /// <returns>A compiled list containing all individual items.</returns>
    public static List<T> CompileList<T>(params T[] individuals)
    {
        List<T> toReturn = individuals.ToList();
        return toReturn;
    }
}
