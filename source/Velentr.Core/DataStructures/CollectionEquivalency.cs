namespace Velentr.Core.DataStructures;

/// <summary>
///     Provides methods for checking the equivalency of collections.
/// </summary>
public static class CollectionEquivalency
{
    /// <summary>
    ///     Determines whether two collections are equivalent.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collections.</typeparam>
    /// <param name="a">The first collection to compare.</param>
    /// <param name="b">The second collection to compare.</param>
    /// <returns><c>true</c> if the collections are equivalent; otherwise, <c>false</c>.</returns>
    public static bool CollectionsEquivalent<T>(ICollection<T> a, ICollection<T> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }

        using var enumeratorA = a.GetEnumerator();
        using var enumeratorB = b.GetEnumerator();

        while (enumeratorA.MoveNext() && enumeratorB.MoveNext())
        {
            if (!enumeratorA.Current!.Equals(enumeratorB.Current))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///     Determines whether two collections are equivalent.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collections.</typeparam>
    /// <param name="a">The first collection to compare.</param>
    /// <param name="b">The second collection to compare.</param>
    /// <returns><c>true</c> if the collections are equivalent; otherwise, <c>false</c>.</returns>
    public static bool IsEquivalent<T>(this ICollection<T> a, ICollection<T> b)
    {
        return CollectionsEquivalent(a, b);
    }
}
