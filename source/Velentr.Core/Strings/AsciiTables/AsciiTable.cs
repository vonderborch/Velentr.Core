using System.Text;
using System.Text.Json;
using Velentr.Core.Json;

namespace Velentr.Core.Strings.AsciiTables;

/// <summary>
///     Represents an ASCII table with customizable columns, rows, and formatting options.
/// </summary>
public class AsciiTable
{
    private readonly List<AsciiTableColumn> columns;
    private readonly string columnSeperator;
    private readonly char rowSeperator;

    /// <summary>
    ///     Initializes a new instance of the AsciiTable class.
    /// </summary>
    /// <param name="columns">The columns of the ASCII table.</param>
    /// <param name="columnSeperator">The separator between columns.</param>
    /// <param name="rowSeperator">The separator between rows.</param>
    /// <param name="options">Optional JSON serializer options.</param>
    public AsciiTable(List<AsciiTableColumn> columns, string columnSeperator = " | ", char rowSeperator = '-',
        JsonSerializerOptions? options = null)
    {
        this.columns = columns;
        this.columnSeperator = columnSeperator;
        this.rowSeperator = rowSeperator;
    }

    /// <summary>
    ///     Adds totals and averages rows to the ASCII table.
    /// </summary>
    private void AddTotalsAndAveragesRows(AsciiTableParameters parameters, List<string> asciiTableRows,
        Dictionary<string, string>? totalsRow, Dictionary<string, string>? averagesRow,
        Dictionary<string, int> maxColumnSizes)
    {
        StringBuilder totalsRowBuilder = new();
        StringBuilder averagesRowBuilder = new();

        if (totalsRow != null)
        {
            totalsRowBuilder.Append(BuildDataRow(parameters, totalsRow, maxColumnSizes, AsciiRowType.Totals));
        }

        if (averagesRow != null)
        {
            averagesRowBuilder.Append(BuildDataRow(parameters, averagesRow, maxColumnSizes, AsciiRowType.Averages));
        }

        if (totalsRow != null && averagesRow == null)
        {
            asciiTableRows.Add(totalsRowBuilder.ToString());
        }
        else if (totalsRow == null && averagesRow != null)
        {
            asciiTableRows.Add(averagesRowBuilder.ToString());
        }
        else if (totalsRow != null && averagesRow != null)
        {
            if (parameters.AveragesRowBeforeTotalsRow)
            {
                asciiTableRows.Add(averagesRowBuilder.ToString());
                asciiTableRows.Add(totalsRowBuilder.ToString());
            }
            else
            {
                asciiTableRows.Add(totalsRowBuilder.ToString());
                asciiTableRows.Add(averagesRowBuilder.ToString());
            }
        }
    }

    /// <summary>
    ///     Builds a data row.
    /// </summary>
    private string BuildDataRow(AsciiTableParameters parameters, Dictionary<string, string> row,
        Dictionary<string, int> maxColumnSizes, AsciiRowType rowType, string? extraRowKey = null)
    {
        StringBuilder rowBuilder = new();
        if (parameters.IncludeColumnSeperatorBeforeRow)
        {
            rowBuilder.Append(this.columnSeperator.TrimStart());
        }

        foreach (AsciiTableColumn? column in this.columns)
        {
            AsciiTableJustification justification = rowType switch
            {
                AsciiRowType.Header => column.HeaderJustification,
                AsciiRowType.Data => column.ValueJustification,
                AsciiRowType.Totals => column.TotalsRowJustification,
                AsciiRowType.Averages => column.AveragesRowJustification,
                AsciiRowType.ExtraRow => column.ExtraRowJustifications[extraRowKey!],
                _ => throw new ArgumentOutOfRangeException()
            };
            var paddedValue = GetPaddedValue(row[column.Key], maxColumnSizes[column.Key], justification);
            rowBuilder.Append(paddedValue).Append(this.columnSeperator);
        }

        string output;
        if (!parameters.IncludeColumnSeperatorAfterRow)
        {
            rowBuilder.Remove(rowBuilder.Length - this.columnSeperator.Length, this.columnSeperator.Length);
            output = rowBuilder.ToString();
        }
        else
        {
            output = rowBuilder.ToString().TrimEnd();
        }

        return output;
    }

    /// <summary>
    ///     Builds the header row.
    /// </summary>
    private string BuildHeaderRow(AsciiTableParameters parameters, Dictionary<string, int> maxColumnSizes)
    {
        StringBuilder headerRow = new();
        if (parameters.IncludeColumnSeperatorBeforeRow)
        {
            headerRow.Append(this.columnSeperator.TrimStart());
        }

        foreach (AsciiTableColumn column in this.columns)
        {
            var paddedValue =
                GetPaddedValue(column.DisplayName, maxColumnSizes[column.Key], column.HeaderJustification);
            headerRow.Append(paddedValue).Append(this.columnSeperator);
        }

        string output;
        if (!parameters.IncludeColumnSeperatorAfterRow)
        {
            headerRow.Remove(headerRow.Length - this.columnSeperator.Length, this.columnSeperator.Length);
            output = headerRow.ToString();
        }
        else
        {
            output = headerRow.ToString().TrimEnd();
        }

        return output;
    }

    /// <summary>
    ///     Builds the separator row.
    /// </summary>
    private string BuildSeparatorRow(AsciiTableParameters parameters, Dictionary<string, int> maxColumnSizes)
    {
        StringBuilder seperatorRowBuilder = new();
        if (parameters.IncludeColumnSeperatorBeforeRow)
        {
            seperatorRowBuilder.Append(this.columnSeperator.TrimStart());
        }

        foreach (AsciiTableColumn column in this.columns)
        {
            var columnSize = maxColumnSizes[column.Key];
            seperatorRowBuilder.Append(new string(this.rowSeperator, columnSize)).Append(this.columnSeperator);
        }

        string output;
        if (!parameters.IncludeColumnSeperatorAfterRow)
        {
            seperatorRowBuilder.Remove(seperatorRowBuilder.Length - this.columnSeperator.Length,
                this.columnSeperator.Length);
            output = seperatorRowBuilder.ToString();
        }
        else
        {
            output = seperatorRowBuilder.ToString().TrimEnd();
        }

        return output;
    }

    /// <summary>
    ///     Calculates the totals and averages rows.
    /// </summary>
    private (Dictionary<string, int> maxColumnSizes, Dictionary<string, string>? totalsRow, Dictionary<string, string>?
        averagesRow) CalculateTotalsAndAveragesRow(AsciiTableParameters parameters,
            Dictionary<string, List<object>> columnValues, Dictionary<string, int> currentColumnMaxSizes)
    {
        Dictionary<string, string> totalsRow = new();
        Dictionary<string, string> averagesRow = new();

        foreach (AsciiTableColumn column in this.columns)
        {
            List<object> columnValueList = columnValues[column.Key];
            if (parameters.IncludeTotalsRow)
            {
                var replaceValue = parameters.ColumnKeyForTotalsRowDisplayString == column.Key
                    ? parameters.TotalsRowDisplayString
                    : null;
                UpdateRowWithAggregateValue(column, columnValueList, totalsRow, currentColumnMaxSizes,
                    column.TotalsAggregateFunction, replaceValue);
            }

            if (parameters.IncludeAveragesRow)
            {
                var replaceValue = parameters.ColumnKeyForAveragesRowDisplayString == column.Key
                    ? parameters.AveragesRowDisplayString
                    : null;
                UpdateRowWithAggregateValue(column, columnValueList, averagesRow, currentColumnMaxSizes,
                    column.AverageAggregateFunction, replaceValue);
            }
        }

        return (currentColumnMaxSizes, parameters.IncludeTotalsRow ? totalsRow : null,
            parameters.IncludeAveragesRow ? averagesRow : null);
    }

    /// <summary>
    ///     Generates the rows of the ASCII table based on the provided parameters.
    /// </summary>
    /// <param name="parameters">The parameters for generating the ASCII table.</param>
    /// <returns>A list of strings representing the rows of the ASCII table.</returns>
    public List<string> GetAsciiTableRows(AsciiTableParameters parameters)
    {
        parameters.ValidateParameters(this.columns);
        List<string> asciiTableRows = new();

        // Serialize rows and calculate max column sizes
        (Dictionary<string, int> maxColumnSizes, List<Dictionary<string, string>> rows,
            Dictionary<string, string>? totalsRow, Dictionary<string, string>? averagesRow,
            Dictionary<string, Dictionary<string, string>>? extraRows) = SerializeRows(parameters);

        // Build the separator row
        var seperatorRow = BuildSeparatorRow(parameters, maxColumnSizes);

        // Add header row if needed
        if (parameters.IncludeHeaders)
        {
            asciiTableRows.Add(BuildHeaderRow(parameters, maxColumnSizes));

            // Add separator row after headers if needed
            if (parameters.IncludeSeperatorRowAfterHeaders)
            {
                asciiTableRows.Add(seperatorRow);
            }
        }

        // Add data rows
        foreach (Dictionary<string, string> row in rows)
        {
            asciiTableRows.Add(BuildDataRow(parameters, row, maxColumnSizes, AsciiRowType.Data));
        }

        // Add extra rows if any
        if (extraRows != null)
        {
            if (parameters.IncludeSeperatorRowBeforeExtrasRow)
            {
                asciiTableRows.Add(seperatorRow);
            }

            foreach (var extraRowKey in parameters.ExtraRowsOrder)
            {
                asciiTableRows.Add(BuildDataRow(parameters, extraRows[extraRowKey], maxColumnSizes,
                    AsciiRowType.ExtraRow, extraRowKey));
            }
        }

        // Add totals and averages rows if needed
        if ((parameters.IncludeTotalsRow && totalsRow != null) ||
            (parameters.IncludeAveragesRow && averagesRow != null))
        {
            if (parameters.IncludeSeperatorRowBeforeTotalsAngAveragesRow)
            {
                asciiTableRows.Add(seperatorRow);
            }

            AddTotalsAndAveragesRows(parameters, asciiTableRows, totalsRow, averagesRow, maxColumnSizes);
        }

        return asciiTableRows;
    }

    /// <summary>
    ///     Generates the ASCII table as a single string.
    /// </summary>
    public string GetAsciiTableString(AsciiTableParameters parameters)
    {
        List<string> asciiTableRows = GetAsciiTableRows(parameters);
        return string.Join(Environment.NewLine, asciiTableRows);
    }

    /// <summary>
    ///     Generates the ASCII table as a StringBuilder.
    /// </summary>
    public StringBuilder GetAsciiTableStringBuilder(AsciiTableParameters parameters)
    {
        List<string> asciiTableRows = GetAsciiTableRows(parameters);
        StringBuilder sb = new();
        foreach (var row in asciiTableRows)
        {
            sb.AppendLine(row);
        }

        return sb;
    }

    /// <summary>
    ///     Pads the value based on the justification.
    /// </summary>
    private string GetPaddedValue(string value, int maxPadding, AsciiTableJustification justification)
    {
        var padding = maxPadding - value.Length;
        if (padding <= 0)
        {
            return value;
        }

        StringBuilder output = new(maxPadding);
        switch (justification)
        {
            case AsciiTableJustification.Left:
                output.Append(value).Append(' ', padding);
                break;
            case AsciiTableJustification.Right:
                output.Append(' ', padding).Append(value);
                break;
            case AsciiTableJustification.Center:
                var leftPadding = padding / 2;
                var rightPadding = padding - leftPadding;
                output.Append(' ', leftPadding).Append(value).Append(' ', rightPadding);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return output.ToString();
    }

    /// <summary>
    ///     Initializes the column values.
    /// </summary>
    private Dictionary<string, List<object>> InitializeColumnValues()
    {
        Dictionary<string, List<object>> columnValues = new();
        foreach (AsciiTableColumn column in this.columns)
        {
            columnValues[column.Key] = new List<object>();
        }

        return columnValues;
    }

    /// <summary>
    ///     Initializes the max column sizes.
    /// </summary>
    private Dictionary<string, int> InitializeMaxColumnSizes(bool includeHeaders)
    {
        Dictionary<string, int> maxColumnSizes = new();
        foreach (AsciiTableColumn column in this.columns)
        {
            maxColumnSizes[column.Key] = includeHeaders ? column.DisplayName.Length : 0;
        }

        return maxColumnSizes;
    }

    /// <summary>
    ///     Serializes the extra rows.
    /// </summary>
    private Dictionary<string, Dictionary<string, string>>? SerializeExtraRows(
        Dictionary<string, Dictionary<string, object>>? extraRows, Dictionary<string, int> maxColumnSizes)
    {
        if (extraRows is null || extraRows.Count == 0)
        {
            return null;
        }

        Dictionary<string, Dictionary<string, string>> serializedExtraRows = new();
        foreach ((var rowKey, Dictionary<string, object> extraRow) in extraRows)
        {
            Dictionary<string, string> serializedExtraRow = new();
            foreach (AsciiTableColumn column in this.columns)
            {
                var value = extraRow.TryGetValue(column.Key, out var val) ? val : column.DefaultValue;
                var serializedValue = SerializeValue(value, column);
                if (serializedValue.Length > maxColumnSizes[column.Key])
                {
                    maxColumnSizes[column.Key] = serializedValue.Length;
                }

                serializedExtraRow[column.Key] = serializedValue;
            }

            serializedExtraRows[rowKey] = serializedExtraRow;
        }

        return serializedExtraRows;
    }

    /// <summary>
    ///     Serializes the rows and calculates the max column sizes.
    /// </summary>
    private (Dictionary<string, int> maxColumnSizes, List<Dictionary<string, string>> rows, Dictionary<string, string>?
        totalsRow, Dictionary<string, string>? averagesRow, Dictionary<string, Dictionary<string, string>>? extraRows)
        SerializeRows(AsciiTableParameters parameters)
    {
        Dictionary<string, int> maxColumnSizes = InitializeMaxColumnSizes(parameters.IncludeHeaders);
        Dictionary<string, List<object>> columnValues = InitializeColumnValues();

        List<Dictionary<string, string>> serializedRows =
            SerializeTableRows(parameters.Rows, columnValues, maxColumnSizes);

        Dictionary<string, string>? totalsRow = null;
        Dictionary<string, string>? averagesRow = null;
        if (parameters.IncludeTotalsRow || parameters.IncludeAveragesRow)
        {
            (maxColumnSizes, totalsRow, averagesRow) =
                CalculateTotalsAndAveragesRow(parameters, columnValues, maxColumnSizes);
        }

        Dictionary<string, Dictionary<string, string>>? extraRows =
            SerializeExtraRows(parameters.ExtraRows, maxColumnSizes);

        return (maxColumnSizes, serializedRows, totalsRow, averagesRow, extraRows);
    }

    /// <summary>
    ///     Serializes the table rows.
    /// </summary>
    private List<Dictionary<string, string>> SerializeTableRows(List<Dictionary<string, object?>> rows,
        Dictionary<string, List<object>> columnValues, Dictionary<string, int> maxColumnSizes)
    {
        List<Dictionary<string, string>> serializedRows = new();
        foreach (Dictionary<string, object?> row in rows)
        {
            Dictionary<string, string> serializedRow = new();
            foreach (AsciiTableColumn column in this.columns)
            {
                var value = row.TryGetValue(column.Key, out var val) ? val : column.DefaultValue;
                columnValues[column.Key].Add(value);

                var serializedValue = SerializeValue(value, column);
                if (serializedValue.Length > maxColumnSizes[column.Key])
                {
                    maxColumnSizes[column.Key] = serializedValue.Length;
                }

                serializedRow[column.Key] = serializedValue;
            }

            serializedRows.Add(serializedRow);
        }

        return serializedRows;
    }

    /// <summary>
    ///     Serializes the value based on the column's serialization mode.
    /// </summary>
    private string SerializeValue(object? value, AsciiTableColumn column)
    {
        string serializedValue;
        if (value == column.DefaultValue || value is null)
        {
            serializedValue = column.DefaultSerializedValue;
        }
        else
        {
            switch (column.SerializationMode)
            {
                case AsciiColumnSerializationMode.ToString:
                    serializedValue = value.ToString() ?? column.DefaultSerializedValue;
                    break;
                case AsciiColumnSerializationMode.Serialize:
                    serializedValue = JsonHelpers.SerializeToString(value, column.JsonSerializationOptions);
                    break;
                case AsciiColumnSerializationMode.Formatted:
                    serializedValue = column.ValueDisplayFormat.TemplateFormat(new { value });
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return serializedValue;
    }

    /// <summary>
    ///     Updates the row with the aggregate value.
    /// </summary>
    private void UpdateRowWithAggregateValue(AsciiTableColumn column, List<object> columnValueList,
        Dictionary<string, string> row, Dictionary<string, int> currentColumnMaxSizes,
        Func<List<object>, object>? aggregateFunction, string? replaceValue = null)
    {
        string serializedValue;
        if (replaceValue == null)
        {
            var aggregateValue = aggregateFunction?.Invoke(columnValueList) ?? column.DefaultValue;
            serializedValue = SerializeValue(aggregateValue, column);
        }
        else
        {
            serializedValue = replaceValue;
        }

        row[column.Key] = serializedValue;
        if (serializedValue.Length > currentColumnMaxSizes[column.Key])
        {
            currentColumnMaxSizes[column.Key] = serializedValue.Length;
        }
    }
}
