using System.Text.Json;
using System.Text.Json.Serialization;

namespace Velentr.Core.Strings.AsciiTables;

/// <summary>
///     Represents a column in an ASCII table.
/// </summary>
public record AsciiTableColumn
{
    /// <summary>
    ///     The default JSON serializer options used for serialization.
    /// </summary>
    public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new()
        { Converters = { new JsonStringEnumConverter() }, IncludeFields = true };

    /// <summary>
    ///     Gets or sets the average aggregate function for the column, used for calculating the Averages row.
    /// </summary>
    public Func<List<object>, object>? AverageAggregateFunction = null;

    /// <summary>
    ///     Gets or sets the justification format for the column averages.
    /// </summary>
    public AsciiTableJustification AveragesRowJustification = AsciiTableJustification.Left;

    /// <summary>
    ///     Gets or sets the default serialized value of the column.
    /// </summary>
    public string DefaultSerializedValue = string.Empty;

    /// <summary>
    ///     Gets or sets the default value of the column.
    /// </summary>
    public required object DefaultValue;

    /// <summary>
    ///     Gets or sets the display name of the column.
    /// </summary>
    public required string DisplayName;

    /// <summary>
    ///     Gets or sets the justification format for the column extra rows.
    /// </summary>
    public Dictionary<string, AsciiTableJustification> ExtraRowJustifications = new();

    /// <summary>
    ///     Gets or sets the justification format for the column header.
    /// </summary>
    public AsciiTableJustification HeaderJustification = AsciiTableJustification.Left;

    /// <summary>
    ///     Gets or sets whether the column is aggregatable.
    /// </summary>
    public bool IsAggregatable = false;

    /// <summary>
    ///     The serializer options used for JSON serialization for this column.
    /// </summary>
    public JsonSerializerOptions JsonSerializationOptions = DefaultJsonSerializerOptions;

    /// <summary>
    ///     Gets or sets the key of the column.
    /// </summary>
    public required string Key;

    /// <summary>
    ///     Gets or sets the serialization mode for the column.
    /// </summary>
    public AsciiColumnSerializationMode SerializationMode = AsciiColumnSerializationMode.ToString;

    /// <summary>
    ///     Gets or sets the totals aggregate function for the column, used for calculating the Totals row.
    /// </summary>
    public Func<List<object>, object>? TotalsAggregateFunction = null;

    /// <summary>
    ///     Gets or sets the justification format for the column totals.
    /// </summary>
    public AsciiTableJustification TotalsRowJustification = AsciiTableJustification.Left;

    /// <summary>
    ///     Gets or sets the display format for the column values.
    /// </summary>
    public string ValueDisplayFormat = "{value}";

    /// <summary>
    ///     Gets or sets the justification format for the column values.
    /// </summary>
    public AsciiTableJustification ValueJustification = AsciiTableJustification.Left;
}
