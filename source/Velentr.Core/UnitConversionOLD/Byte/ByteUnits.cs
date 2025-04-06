namespace Velentr.Core.UnitConversion.Byte;

public struct ByteUnits(string name, string abbreviation, int power) : IUnit, IEquatable<ByteUnits>
{
    public static readonly ByteUnits Byte = new("Byte", "B", 1);
    public static readonly ByteUnits KB = new("Kilobyte", "KB", 2);
    public static readonly ByteUnits MB = new("Megabyte", "MB", 3);
    public static readonly ByteUnits GB = new("Gigabyte", "GB", 4);
    public static readonly ByteUnits TB = new("Terabyte", "TB", 5);
    public static readonly ByteUnits PB = new("Petabyte", "PB", 6);
    public static readonly ByteUnits EB = new("Exabyte", "EB", 7);
    public static readonly ByteUnits ZB = new("Zettabyte", "ZB", 8);
    public static readonly ByteUnits YB = new("Yottabyte", "YB", 9);
    
    public int Power { get; } = power;

    public string Name { get; } = name;

    public string Abbreviation { get; } = abbreviation;

    public bool Equals(ByteUnits other)
    {
        return this.Power == other.Power;
    }

    public bool Equals(IUnit? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other is ByteUnits otherByteUnit)
        {
            return Equals(otherByteUnit);
        }

        return false;
    }
    
    public static bool operator ==(ByteUnits a, ByteUnits b)
    {
        return a.Equals(b);
    }
    
    public static bool operator !=(ByteUnits a, ByteUnits b)
    {
        return !a.Equals(b);
    }
    
    public static int operator -(ByteUnits a, ByteUnits b)
    {
        return a.Power - b.Power;
    }

    public override bool Equals(object? obj)
    {
        return obj is ByteUnits other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Power, this.Name, this.Abbreviation);
    }
    
    public override string ToString()
    {
        return this.Abbreviation;
    }
}
