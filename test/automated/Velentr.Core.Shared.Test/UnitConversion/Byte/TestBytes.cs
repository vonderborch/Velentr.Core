using NUnit.Framework;
using Velentr.Core.UnitConversion;
using Velentr.Core.UnitConversion.Byte;
using Velentr.Core.UnitConversions;
using Velentr.Core.UnitConversions.ComputerBits.Bytes;

namespace Velentr.Core.Test.UnitConversion.Byte;

[TestFixture]
public class BytesTests
{
    [Test]
    public void TestByte()
    {
        var measure = Measurements.GetMeasurementFromValue(1000, ByteScale.Byte);
        Assert.That(measure.Value, Is.EqualTo(1000));
    }
}
