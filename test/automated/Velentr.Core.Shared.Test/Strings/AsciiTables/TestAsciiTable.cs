using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Velentr.Core.Strings.AsciiTables;

namespace Velentr.Core.Test.Strings.AsciiTables;

[TestFixture]
public class TestAsciiTable
{
    private List<AsciiTableColumn> columns;
    private List<AsciiTableColumn> aggregatableColumns;
    private List<AsciiTableColumn> mixedColumns;

    [SetUp]
    public void SetUp()
    {
        this.columns = new List<AsciiTableColumn>
        {
            new AsciiTableColumn { Key = "Column1", DisplayName = "Column 1", DefaultValue = "", HeaderJustification = AsciiTableJustification.Left },
            new AsciiTableColumn { Key = "Column2", DisplayName = "Column 2", DefaultValue = "", HeaderJustification = AsciiTableJustification.Left }
        };

        this.aggregatableColumns = new List<AsciiTableColumn>
        {
            new AsciiTableColumn { Key = "Column1", DisplayName = "Column 1", DefaultValue = "", TotalsRowJustification = AsciiTableJustification.Center, AveragesRowJustification = AsciiTableJustification.Right, IsAggregatable = true, TotalsAggregateFunction = x => x.Select(y => double.Parse(y.ToString())).Sum(), AverageAggregateFunction = x => x.Select(y => double.Parse(y.ToString())).Average() },
            new AsciiTableColumn { Key = "Column2", DisplayName = "Column 2", DefaultValue = "", TotalsRowJustification = AsciiTableJustification.Right, AveragesRowJustification = AsciiTableJustification.Center, IsAggregatable = true, TotalsAggregateFunction = x => x.Select(y => double.Parse(y.ToString())).Sum(), AverageAggregateFunction = x => x.Select(y => double.Parse(y.ToString())).Average() }
        };

        this.mixedColumns = new List<AsciiTableColumn>
        {
            new AsciiTableColumn { Key = "Column1", DisplayName = "Column 1", DefaultValue = "", HeaderJustification = AsciiTableJustification.Left },
            new AsciiTableColumn { Key = "Column2", DisplayName = "Column 2", DefaultValue = 0, SerializationMode = AsciiColumnSerializationMode.Formatted, ValueDisplayFormat = "{value:F2}", ValueJustification = AsciiTableJustification.Right, TotalsRowJustification = AsciiTableJustification.Center, AveragesRowJustification = AsciiTableJustification.Right, IsAggregatable = true, TotalsAggregateFunction = x => x.Select(y => double.Parse(y?.ToString() ?? "0")).Sum(), AverageAggregateFunction = x => x.Select(y => double.Parse(y?.ToString() ?? "0")).Average() },
            new AsciiTableColumn { Key = "Column3", DisplayName = "Column 3", DefaultValue = 0, SerializationMode = AsciiColumnSerializationMode.Formatted, ValueDisplayFormat = "{value:F4}", TotalsRowJustification = AsciiTableJustification.Right, AveragesRowJustification = AsciiTableJustification.Center, IsAggregatable = true, TotalsAggregateFunction = x => x.Select(y => double.Parse(y?.ToString() ?? "0")).Sum(), AverageAggregateFunction = x => x.Select(y => double.Parse(y?.ToString() ?? "0")).Average() }
        };
    }

    [Test]
    public void GetAsciiTableRows_ShouldReturnCorrectRows()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Column1", "Value1" }, { "Column2", "Value2" } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeAveragesRow = false,
            IncludeTotalsRow = false
        };

        var table = new AsciiTable(this.columns);
        var rows = table.GetAsciiTableRows(parameters);

        Assert.That(rows.Count, Is.EqualTo(3));
        Assert.That(rows[0], Is.EqualTo("| Column 1 | Column 2 |"));
        Assert.That(rows[1], Is.EqualTo("| -------- | -------- |"));
        Assert.That(rows[2], Is.EqualTo("| Value1   | Value2   |"));
    }

    [Test]
    public void GetAsciiTableString_ShouldReturnCorrectString()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Column1", "Value1" }, { "Column2", "Value2" } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeColumnSeperatorAfterRow = false,
            IncludeColumnSeperatorBeforeRow = false,
            IncludeAveragesRow = false,
            IncludeTotalsRow = false
        };

        var table = new AsciiTable(this.columns);
        var tableString = table.GetAsciiTableString(parameters);

        var expectedString = "Column 1 | Column 2" + Environment.NewLine +
                             "-------- | --------" + Environment.NewLine +
                             "Value1   | Value2  ";

        Assert.That(tableString, Is.EqualTo(expectedString));
    }

    [Test]
    public void GetAsciiTableStringBuilder_ShouldReturnCorrectStringBuilder()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Column1", "Value1" }, { "Column2", "Value2" } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            ColumnKeyForTotalsRowDisplayString = "Column1",
            ColumnKeyForAveragesRowDisplayString = "Column1"
        };

        var table = new AsciiTable(this.columns);
        var tableStringBuilder = table.GetAsciiTableStringBuilder(parameters);

        var expectedStringBuilder = new StringBuilder();
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
        var parameters = new AsciiTableParameters
        {
            Rows = null!,
            IncludeHeaders = true
        };

        var table = new AsciiTable(this.columns);

        Assert.Throws<ArgumentException>(() => table.GetAsciiTableRows(parameters));
    }

    [Test]
    public void GetAsciiTableRows_ShouldHandleEmptyRows()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>>(),
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeTotalsRow = false,
            IncludeAveragesRow = false,
            IncludeColumnSeperatorBeforeRow = false,
            IncludeColumnSeperatorAfterRow = false
        };

        var table = new AsciiTable(this.columns);
        var rows = table.GetAsciiTableRows(parameters);

        Assert.That(rows.Count, Is.EqualTo(2));
        Assert.That(rows[0], Is.EqualTo("Column 1 | Column 2"));
        Assert.That(rows[1], Is.EqualTo("-------- | --------"));
    }

    [Test]
    public void GetAsciiTableString_ShouldHandleNoHeaders()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Column1", "Value1" }, { "Column2", "Value2" } }
            },
            IncludeHeaders = false,
            IncludeColumnSeperatorAfterRow = false,
            IncludeColumnSeperatorBeforeRow = false,
            IncludeTotalsRow = false,
            IncludeAveragesRow = false
        };

        var table = new AsciiTable(this.columns);
        var tableString = table.GetAsciiTableString(parameters);

        var expectedString = "Value1 | Value2";

        Assert.That(tableString, Is.EqualTo(expectedString));
    }

    [Test]
    public void GetAsciiTableString_ShouldHandleCustomSeparator()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Column1", "Value1" }, { "Column2", "Value2" } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeTotalsRow = false,
            IncludeAveragesRow = false,
            IncludeColumnSeperatorBeforeRow = false
        };

        var table = new AsciiTable(this.columns, columnSeperator: " || ");
        var tableString = table.GetAsciiTableString(parameters);

        var expectedString = "Column 1 || Column 2 ||" + Environment.NewLine +
                             "-------- || -------- ||" + Environment.NewLine +
                             "Value1   || Value2   ||";

        Assert.That(tableString, Is.EqualTo(expectedString));
    }

    [Test]
    public void GetAsciiTableString_ShouldIncludeTotalsRow()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Column1", 1 }, { "Column2", 2 } },
                new Dictionary<string, object> { { "Column1", 3 }, { "Column2", 4 } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeTotalsRow = true,
            IncludeAveragesRow = false
        };

        var table = new AsciiTable(this.aggregatableColumns);
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
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Column1", 1 }, { "Column2", 2 } },
                new Dictionary<string, object> { { "Column1", 3 }, { "Column2", 4 } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            IncludeAveragesRow = true,
            IncludeTotalsRow = false,
            IncludeColumnSeperatorAfterRow = false,
            IncludeColumnSeperatorBeforeRow = false
        };

        var table = new AsciiTable(this.aggregatableColumns);
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
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object?>>
            {
                new Dictionary<string, object?> { { "Column1", "Cell1A" }, { "Column2", 1 }, { "Column3", 2 } },
                new Dictionary<string, object?> { { "Column1", "Cell1B" }, { "Column2", 3 }, { "Column3", null } },
                new Dictionary<string, object?> { { "Column1", "Cell1C" }, { "Column2", 12 }, { "Column3", 0 } },
                new Dictionary<string, object?> { { "Column1", "Cell1D" }, { "Column2", 1122 }, { "Column3", 0 } }
            },
            IncludeHeaders = true,
            IncludeSeperatorRowAfterHeaders = true,
            ColumnKeyForAveragesRowDisplayString = "Column1",
            ColumnKeyForTotalsRowDisplayString = "Column1"
        };

        var table = new AsciiTable(this.mixedColumns);
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