using Velentr.Core.Strings.AsciiTables;

namespace Velentr.Core.Test.Strings.AsciiTables;

[TestFixture]
public class AsciiTableParametersTests
{
    [Test]
    public void ValidateParameters_ShouldThrowException_WhenRowsAreNull()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = null!,
            IncludeTotalsRow = false,
            IncludeAveragesRow = false
        };

        List<AsciiTableColumn> columns = new();

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenRowsAreEmpty()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>>(),
            IncludeTotalsRow = false,
            IncludeAveragesRow = false
        };

        List<AsciiTableColumn> columns = new();

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenColumnsAreNull()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>> { new() },
            IncludeTotalsRow = false,
            IncludeAveragesRow = false
        };

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(null!));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenColumnsAreEmpty()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>> { new() },
            IncludeTotalsRow = false,
            IncludeAveragesRow = false
        };

        List<AsciiTableColumn> columns = new();

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenTotalsAggregateFunctionIsMissing()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>> { new() },
            IncludeTotalsRow = true,
            IncludeAveragesRow = false
        };

        List<AsciiTableColumn> columns = new()
        {
            new AsciiTableColumn
            {
                Key = "Column1", DisplayName = "Column 1", DefaultValue = 0, TotalsAggregateFunction = null,
                IsAggregatable = true
            }
        };

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenAverageAggregateFunctionIsMissing()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>> { new() },
            IncludeTotalsRow = false,
            IncludeAveragesRow = true
        };

        List<AsciiTableColumn> columns = new()
        {
            new AsciiTableColumn
            {
                Key = "Column1", DisplayName = "Column 1", DefaultValue = 0, AverageAggregateFunction = null,
                IsAggregatable = true
            }
        };

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenExtraRowsOrderIsInvalid()
    {
        AsciiTableParameters? parameters = new()
        {
            Rows = new List<Dictionary<string, object>> { new() },
            ExtraRows = new Dictionary<string, Dictionary<string, object>>
                { { "ExtraRow1", new Dictionary<string, object>() } },
            ExtraRowsOrder = new List<string>()
        };

        List<AsciiTableColumn> columns = new()
        {
            new AsciiTableColumn { Key = "Column1", DefaultValue = 0, DisplayName = "Column 1" }
        };

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }
}
