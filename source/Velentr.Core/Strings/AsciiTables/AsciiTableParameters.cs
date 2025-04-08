namespace Velentr.Core.Strings.AsciiTables;

/// <summary>
///     Represents the parameters for configuring an ASCII table.
/// </summary>
public record AsciiTableParameters
{
    /// <summary>
    ///     Gets or sets the averages row data.
    /// </summary>
    public Dictionary<string, object?>? AveragesRow = null;

    /// <summary>
    ///     Gets or sets a value indicating whether the averages row should appear before the totals row.
    /// </summary>
    public bool AveragesRowBeforeTotalsRow = true;

    /// <summary>
    ///     The display string for the averages row.
    /// </summary>
    public string AveragesRowDisplayString = "AVERAGES";

    /// <summary>
    ///     The column key for the averages row display string.
    /// </summary>
    public string ColumnKeyForAveragesRowDisplayString = string.Empty;

    /// <summary>
    ///     The column key for the totals row display string.
    /// </summary>
    public string ColumnKeyForTotalsRowDisplayString = string.Empty;

    /// <summary>
    ///     Gets or sets the extra rows data.
    /// </summary>
    public Dictionary<string, Dictionary<string, object>>? ExtraRows = null;

    /// <summary>
    ///     Gets or sets the order of the extra rows.
    /// </summary>
    public List<string>? ExtraRowsOrder = null;

    /// <summary>
    ///     Gets or sets a value indicating whether to include an averages row in the table.
    /// </summary>
    public bool IncludeAveragesRow = true;

    /// <summary>
    ///     Gets or sets a value indicating whether to include a column separator after each row.
    /// </summary>
    public bool IncludeColumnSeperatorAfterRow = true;

    /// <summary>
    ///     Gets or sets a value indicating whether to include a column separator before each row.
    /// </summary>
    public bool IncludeColumnSeperatorBeforeRow = true;

    /// <summary>
    ///     Gets or sets a value indicating whether to include headers in the table.
    /// </summary>
    public bool IncludeHeaders = true;

    /// <summary>
    ///     Gets or sets a value indicating whether to include a separator row after the headers.
    /// </summary>
    public bool IncludeSeperatorRowAfterHeaders = true;

    /// <summary>
    ///     Gets or sets a value indicating whether to include a separator row before the extra rows.
    /// </summary>
    public bool IncludeSeperatorRowBeforeExtrasRow = true;

    /// <summary>
    ///     Gets or sets a value indicating whether to include a separator row before the totals and averages row.
    /// </summary>
    public bool IncludeSeperatorRowBeforeTotalsAngAveragesRow = true;

    /// <summary>
    ///     Gets or sets a value indicating whether to include a totals row in the table.
    /// </summary>
    public bool IncludeTotalsRow = true;

    /// <summary>
    ///     Gets or sets the rows of the table.
    /// </summary>
    public required List<Dictionary<string, object?>> Rows;

    /// <summary>
    ///     Gets or sets the totals row data.
    /// </summary>
    public Dictionary<string, object?>? TotalsRow = null;

    /// <summary>
    ///     The display string for the totals row.
    /// </summary>
    public string TotalsRowDisplayString = "TOTALS";

    /// <summary>
    ///     Validates the parameters to ensure they are correctly set.
    /// </summary>
    /// <param name="columns">The columns of the table.</param>
    /// <exception cref="ArgumentException">Thrown when the parameters are invalid.</exception>
    public void ValidateParameters(List<AsciiTableColumn> columns)
    {
        // validate we have rows and columns
        if (this.Rows == null)
        {
            throw new ArgumentException("Rows cannot be null.");
        }

        if (columns == null || columns.Count == 0)
        {
            throw new ArgumentException("Columns cannot be null or empty.");
        }

        // validate we have aggregate functions for the columns we need to aggregate
        if (this.IncludeTotalsRow)
        {
            if (this.TotalsRow == null)
            {
                foreach (AsciiTableColumn column in columns)
                {
                    if (column.TotalsAggregateFunction == null && column.IsAggregatable)
                    {
                        throw new ArgumentException($"Column {column.Key} does not have a TotalsAggregateFunction.");
                    }
                }
            }
        }

        if (this.IncludeAveragesRow)
        {
            if (this.AveragesRow == null)
            {
                foreach (AsciiTableColumn column in columns)
                {
                    if (column.AverageAggregateFunction == null && column.IsAggregatable)
                    {
                        throw new ArgumentException($"Column {column.Key} does not have an AverageAggregateFunction.");
                    }
                }
            }
        }

        // extra rows order if extra rows
        if (this.ExtraRows != null &&
            (this.ExtraRowsOrder == null || this.ExtraRowsOrder.Count != this.ExtraRows.Count))
        {
            throw new ArgumentException("ExtraRowsOrder must be the same size as ExtraRows.");
        }
    }
}
