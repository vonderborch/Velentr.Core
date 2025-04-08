using System.Text;
using Velentr.Core.Strings.AsciiTables;

namespace Velentr.Core.Test.Strings.AsciiTables;

[TestFixture]
public class TestAsciiTable
{
    [SetUp]
    public void SetUp()
    {
        this.columns = new List<AsciiTableColumn>
        {
            new()
            {
                Key = "Column1", DisplayName = "Column 1", DefaultValue = "",
                HeaderJustification = AsciiTableJustification.Left
            },
            new()
            {
                Key = "Column2", DisplayName = "Column 2", DefaultValue = "",
                HeaderJustification = AsciiTableJustification.Left
            }
        };

        this.aggregatableColumns = new List<AsciiTableColumn>
        {
            new()
            {
                Key = "Column1", DisplayName = "Column 1", DefaultValue = "",
                TotalsRowJustification = AsciiTableJustification.Center,
                AveragesRowJustification = AsciiTableJustification.Right, IsAggregatable = true,
                TotalsAggregateFunction = x => x.Select(y => double.Parse(y.ToString())).Sum(),
                AverageAggregateFunction = x => x.Select(y => double.Parse(y.ToString())).Average()
            },
            new()
            {
                Key = "Column2", DisplayName = "Column 2", DefaultValue = "",
                TotalsRowJustification = AsciiTableJustification.Right,
                AveragesRowJustification = AsciiTableJustification.Center, IsAggregatable = true,
                TotalsAggregateFunction = x => x.Select(y => double.Parse(y.ToString())).Sum(),
                AverageAggregateFunction = x => x.Select(y => double.Parse(y.ToString())).Average()
            }
        };

        this.mixedColumns = new List<AsciiTableColumn>
        {
            new()
            {
                Key = "Column1", DisplayName = "Column 1", DefaultValue = "",
                HeaderJustification = AsciiTableJustification.Left
            },
            new()
            {
                Key = "Column2", DisplayName = "Column 2", DefaultValue = 0,
                SerializationMode = AsciiColumnSerializationMode.Formatted, ValueDisplayFormat = "{value:F2}",
                ValueJustification = AsciiTableJustification.Right,
                TotalsRowJustification = AsciiTableJustification.Center,
                AveragesRowJustification = AsciiTableJustification.Right, IsAggregatable = true,
                TotalsAggregateFunction = x => x.Select(y => double.Parse(y?.ToString() ?? "0")).Sum(),
                AverageAggregateFunction = x => x.Select(y => double.Parse(y?.ToString() ?? "0")).Average()
            },
            new()
            {
                Key = "Column3", DisplayName = "Column 3", DefaultValue = 0,
                SerializationMode = AsciiColumnSerializationMode.Formatted, ValueDisplayFormat = "{value:F4}",
                TotalsRowJustification = AsciiTableJustification.Right,
                AveragesRowJustification = AsciiTableJustification.Center, IsAggregatable = true,
                TotalsAggregateFunction = x => x.Select(y => double.Parse(y?.ToString() ?? "0")).Sum(),
                AverageAggregateFunction = x => x.Select(y => double.Parse(y?.ToString() ?? "0")).Average()
            }
        };
    }

    private List<AsciiTableColumn> columns;
    private List<AsciiTableColumn> aggregatableColumns;
    private List<AsciiTableColumn> mixedColumns;

    [Test]
    public void GetAsciiTableRows_ShouldReturnCorrectRows()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>>
            {
                new() { { "Column1", "Value1" }, { "Column2", "Value2" } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeAveragesRow = false,
            IncludeTotalsRow = false
        };

        AsciiTable table = new(this.columns);
        List<string> rows = table.GetAsciiTableRows(parameters);

        Assert.That(rows.Count, Is.EqualTo(3));
        Assert.That(rows[0], Is.EqualTo("| Column 1 | Column 2 |"));
        Assert.That(rows[1], Is.EqualTo("| -------- | -------- |"));
        Assert.That(rows[2], Is.EqualTo("| Value1   | Value2   |"));
    }

    [Test]
    public void GetAsciiTableString_ShouldReturnCorrectString()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>>
            {
                new() { { "Column1", "Value1" }, { "Column2", "Value2" } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeColumnSeperatorAfterRow = false,
            IncludeColumnSeperatorBeforeRow = false,
            IncludeAveragesRow = false,
            IncludeTotalsRow = false
        };

        AsciiTable table = new(this.columns);
        var tableString = table.GetAsciiTableString(parameters);

        var expectedString = "Column 1 | Column 2" + Environment.NewLine +
                             "-------- | --------" + Environment.NewLine +
                             "Value1   | Value2  ";

        Assert.That(tableString, Is.EqualTo(expectedString));
    }

    [Test]
    public void GetAsciiTableStringBuilder_ShouldReturnCorrectStringBuilder()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>>
            {
                new() { { "Column1", "Value1" }, { "Column2", "Value2" } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            ColumnKeyForTotalsRowDisplayString = "Column1",
            ColumnKeyForAveragesRowDisplayString = "Column1"
        };

        AsciiTable table = new(this.columns);
        StringBuilder tableStringBuilder = table.GetAsciiTableStringBuilder(parameters);

        StringBuilder expectedStringBuilder = new();
        expectedStringBuilder.AppendLine("| Column 1 | Column 2 |");
        expectedStringBuilder.AppendLine("| -------- | -------- |");
        expectedStringBuilder.AppendLine("| Value1   | Value2   |");
        expectedStringBuilder.AppendLine("| -------- | -------- |");
        expectedStringBuilder.AppendLine("| AVERAGES |          |");
        expectedStringBuilder.AppendLine("| TOTALS   |          |");

        Assert.That(tableStringBuilder.ToString(), Is.EqualTo(expectedStringBuilder.ToString()));
    }

    [Test]
    public void GetAsciiTableRows_ShouldThrowException_WhenParametersAreInvalid()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = null!,
            IncludeHeaders = true
        };

        AsciiTable table = new(this.columns);

        Assert.Throws<ArgumentException>(() => table.GetAsciiTableRows(parameters));
    }

    [Test]
    public void GetAsciiTableRows_ShouldHandleEmptyRows()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>>(),
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeTotalsRow = false,
            IncludeAveragesRow = false,
            IncludeColumnSeperatorBeforeRow = false,
            IncludeColumnSeperatorAfterRow = false
        };

        AsciiTable table = new(this.columns);
        List<string> rows = table.GetAsciiTableRows(parameters);

        Assert.That(rows.Count, Is.EqualTo(2));
        Assert.That(rows[0], Is.EqualTo("Column 1 | Column 2"));
        Assert.That(rows[1], Is.EqualTo("-------- | --------"));
    }

    [Test]
    public void GetAsciiTableString_ShouldHandleNoHeaders()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>>
            {
                new() { { "Column1", "Value1" }, { "Column2", "Value2" } }
            },
            IncludeHeaders = false,
            IncludeColumnSeperatorAfterRow = false,
            IncludeColumnSeperatorBeforeRow = false,
            IncludeTotalsRow = false,
            IncludeAveragesRow = false
        };

        AsciiTable table = new(this.columns);
        var tableString = table.GetAsciiTableString(parameters);

        var expectedString = "Value1 | Value2";

        Assert.That(tableString, Is.EqualTo(expectedString));
    }

    [Test]
    public void GetAsciiTableString_ShouldHandleCustomSeparator()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>>
            {
                new() { { "Column1", "Value1" }, { "Column2", "Value2" } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeTotalsRow = false,
            IncludeAveragesRow = false,
            IncludeColumnSeperatorBeforeRow = false
        };

        AsciiTable table = new(this.columns, " || ");
        var tableString = table.GetAsciiTableString(parameters);

        var expectedString = "Column 1 || Column 2 ||" + Environment.NewLine +
                             "-------- || -------- ||" + Environment.NewLine +
                             "Value1   || Value2   ||";

        Assert.That(tableString, Is.EqualTo(expectedString));
    }

    [Test]
    public void GetAsciiTableString_ShouldIncludeTotalsRow()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>>
            {
                new() { { "Column1", 1 }, { "Column2", 2 } },
                new() { { "Column1", 3 }, { "Column2", 4 } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeTotalsRow = true,
            IncludeAveragesRow = false
        };

        AsciiTable table = new(this.aggregatableColumns);
        var tableString = table.GetAsciiTableString(parameters);

        var expectedString = "| Column 1 | Column 2 |" + Environment.NewLine +
                             "| -------- | -------- |" + Environment.NewLine +
                             "| 1        | 2        |" + Environment.NewLine +
                             "| 3        | 4        |" + Environment.NewLine +
                             "| -------- | -------- |" + Environment.NewLine +
                             "|    4     |        6 |";

        Assert.That(tableString, Is.EqualTo(expectedString));
    }

    [Test]
    public void GetAsciiTableString_ShouldIncludeAveragesRow()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>>
            {
                new() { { "Column1", 1 }, { "Column2", 2 } },
                new() { { "Column1", 3 }, { "Column2", 4 } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeAveragesRow = true,
            IncludeTotalsRow = false,
            IncludeColumnSeperatorAfterRow = false,
            IncludeColumnSeperatorBeforeRow = false
        };

        AsciiTable table = new(this.aggregatableColumns);
        var tableString = table.GetAsciiTableString(parameters);

        var expectedString = "Column 1 | Column 2" + Environment.NewLine +
                             "-------- | --------" + Environment.NewLine +
                             "1        | 2       " + Environment.NewLine +
                             "3        | 4       " + Environment.NewLine +
                             "-------- | --------" + Environment.NewLine +
                             "       2 |    3    ";

        Assert.That(tableString, Is.EqualTo(expectedString));
    }

    [Test]
    public void GetAsciiTableString_ShouldIncludeTotalsAndAveragesNames()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object?>>
            {
                new() { { "Column1", "Cell1A" }, { "Column2", 1 }, { "Column3", 2 } },
                new() { { "Column1", "Cell1B" }, { "Column2", 3 }, { "Column3", null } },
                new() { { "Column1", "Cell1C" }, { "Column2", 12 }, { "Column3", 0 } },
                new() { { "Column1", "Cell1D" }, { "Column2", 1122 }, { "Column3", 0 } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            ColumnKeyForAveragesRowDisplayString = "Column1",
            ColumnKeyForTotalsRowDisplayString = "Column1"
        };

        AsciiTable table = new(this.mixedColumns);
        var tableString = table.GetAsciiTableString(parameters);

        var expectedString = "| Column 1 | Column 2 | Column 3 |" + Environment.NewLine +
                             "| -------- | -------- | -------- |" + Environment.NewLine +
                             "| Cell1A   |     1.00 | 2.0000   |" + Environment.NewLine +
                             "| Cell1B   |     3.00 |          |" + Environment.NewLine +
                             "| Cell1C   |    12.00 | 0.0000   |" + Environment.NewLine +
                             "| Cell1D   |  1122.00 | 0.0000   |" + Environment.NewLine +
                             "| -------- | -------- | -------- |" + Environment.NewLine +
                             "| AVERAGES |   284.50 |  0.5000  |" + Environment.NewLine +
                             "| TOTALS   | 1138.00  |   2.0000 |";

        Assert.That(tableString, Is.EqualTo(expectedString));
    }
}
