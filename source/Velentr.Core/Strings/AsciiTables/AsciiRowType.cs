namespace Velentr.Core.Strings.AsciiTables;

/// <summary>
///     Represents the different types of rows that can be present in an ASCII table.
/// </summary>
public enum AsciiRowType
{
    /// <summary>
    ///     Represents the header row of the table.
    /// </summary>
    Header = 1,

    /// <summary>
    ///     Represents a data row in the table.
    /// </summary>
    Data = 2,

    /// <summary>
    ///     Represents an extra row in the table.
    /// </summary>
    ExtraRow = 3,

    /// <summary>
    ///     Represents the totals row in the table.
    /// </summary>
    Totals = 4,

    /// <summary>
    ///     Represents the averages row in the table.
    /// </summary>
    Averages = 5
}
