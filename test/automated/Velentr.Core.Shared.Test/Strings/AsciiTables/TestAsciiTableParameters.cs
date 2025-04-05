using System;
using System.Collections.Generic;
using NUnit.Framework;
using Velentr.Core.Strings.AsciiTables;

namespace Velentr.Core.Test.Strings.AsciiTables;

[TestFixture]
public class AsciiTableParametersTests
{
    [Test]
    public void ValidateParameters_ShouldThrowException_WhenRowsAreNull()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = null!,
            IncludeTotalsRow = false,
            IncludeAveragesRow = false
        };

        var columns = new List<AsciiTableColumn>();

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenRowsAreEmpty()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>>(),
            IncludeTotalsRow = false,
            IncludeAveragesRow = false
        };

        var columns = new List<AsciiTableColumn>();

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenColumnsAreNull()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>> { new Dictionary<string, object>() },
            IncludeTotalsRow = false,
            IncludeAveragesRow = false
        };

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(null!));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenColumnsAreEmpty()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>> { new Dictionary<string, object>() },
            IncludeTotalsRow = false,
            IncludeAveragesRow = false
        };

        var columns = new List<AsciiTableColumn>();

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenTotalsAggregateFunctionIsMissing()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>> { new Dictionary<string, object>() },
            IncludeTotalsRow = true,
            IncludeAveragesRow = false
        };

        var columns = new List<AsciiTableColumn>
        {
            new AsciiTableColumn { Key = "Column1", DisplayName = "Column 1", DefaultValue = 0, TotalsAggregateFunction = null, IsAggregatable = true }
        };

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenAverageAggregateFunctionIsMissing()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>> { new Dictionary<string, object>() },
            IncludeTotalsRow = false,
            IncludeAveragesRow = true
        };

        var columns = new List<AsciiTableColumn>
        {
            new AsciiTableColumn { Key = "Column1", DisplayName = "Column 1", DefaultValue = 0, AverageAggregateFunction = null, IsAggregatable = true }
        };

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }

    [Test]
    public void ValidateParameters_ShouldThrowException_WhenExtraRowsOrderIsInvalid()
    {
        var parameters = new AsciiTableParameters
        {
            Rows = new List<Dictionary<string, object>> { new Dictionary<string, object>() },
            ExtraRows = new Dictionary<string, Dictionary<string, object>> { { "ExtraRow1", new Dictionary<string, object>() } },
            ExtraRowsOrder = new List<string>()
        };

        var columns = new List<AsciiTableColumn>
        {
            new AsciiTableColumn { Key = "Column1", DefaultValue = 0, DisplayName = "Column 1" }
        };

        Assert.Throws<ArgumentException>(() => parameters.ValidateParameters(columns));
    }
}