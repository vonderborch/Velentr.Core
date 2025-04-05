using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace Velentr.Core.Mathematics.FixedPoint;

/// <summary>
///     Represents a fixed-point number with 2 decimal places of precision.
/// </summary>
public struct FixedPointPrecision2I : IFixedPoint<FixedPointPrecision2I>, IBaseFixedPoint<int>
{
    /// <summary>
    ///     Gets the precision of the fixed-point number.
    /// </summary>
    public static ushort Precision => 2;
    
    /// <summary>
    ///     Gets the shift value used for fixed-point calculations.
    /// </summary>
    public static ushort Shift => 7;
    
    /// <summary>
    ///     Gets the format string used for converting the fixed-point number to a string.
    /// </summary>
    public static string StringFormat => $"{{0:F{Precision}}}";
    
    /// <summary>
    ///     Gets the base value representing one in the fixed-point format.
    /// </summary>
    public static int BaseOne { get; } = 1 << Shift;
    
    /// <summary>
    /// Represents the maximum value of the fixed-point number.
    /// </summary>
    public static FixedPointPrecision2I MaxValue { get; } = new() { RawValue = int.MaxValue };
    
    /// <summary>
    /// Represents the minimum value of the fixed-point number.
    /// </summary>
    public static FixedPointPrecision2I MinValue { get; } = new() { RawValue = int.MinValue };
    
    /// <summary>
    ///     Represents the fixed-point number zero.
    /// </summary>
    public static FixedPointPrecision2I Zero { get; } = new() { RawValue = 0 };
    
    /// <summary>
    ///     Represents the fixed-point number one.
    /// </summary>
    public static FixedPointPrecision2I One { get; } = new() { RawValue = 1 << Shift };
    
    /// <summary>
    ///     Gets the additive identity for the fixed-point number.
    /// </summary>
    public static FixedPointPrecision2I AdditiveIdentity => Zero;
    
    /// <summary>
    ///     Gets the multiplicative identity for the fixed-point number.
    /// </summary>
    public static FixedPointPrecision2I MultiplicativeIdentity => One;
    
    /// <summary>
    ///     Gets the radix (base) of the fixed-point number.
    /// </summary>
    public static int Radix => 2;

    /// <summary>
    ///     Gets or sets the raw value of the fixed-point number.
    /// </summary>
    public int RawValue { get; set; }

    private FixedPointPrecision2I(int rawValue)
    {
        this.RawValue = rawValue;
    }
    
    /// <summary>
    ///     Creates a fixed-point number from a double value.
    /// </summary>
    /// <param name="value">The double value to convert.</param>
    /// <returns>A fixed-point number representing the double value.</returns>
    public static FixedPointPrecision2I CreateFromDouble(double value)
    {
        return new FixedPointPrecision2I { RawValue = (int)Math.Round(value * BaseOne) };
    }

    /// <summary>
    ///     Creates a fixed-point number from a float value.
    /// </summary>
    /// <param name="value">The float value to convert.</param>
    /// <returns>A fixed-point number representing the float value.</returns>
    public static FixedPointPrecision2I CreateFromFloat(float value)
    {
        return new FixedPointPrecision2I { RawValue = (int)(value * BaseOne) };
    }

    /// <summary>
    ///     Converts the fixed-point number to a double.
    /// </summary>
    /// <returns>The double representation of the fixed-point number.</returns>
    public double ToDouble()
    {
        return (double)this.RawValue / BaseOne;
    }

    /// <summary>
    ///     Converts the fixed-point number to a float.
    /// </summary>
    /// <returns>The float representation of the fixed-point number.</returns>
    public float ToFloat()
    {
        return (float)this.RawValue / BaseOne;
    }

    // Comparison methods
    public int CompareTo(object? obj)
    {
        if (obj is FixedPointPrecision2I other)
        {
            return CompareTo(other);
        }

        throw new ArgumentException("Object is not an FPL4");
    }

    public int CompareTo(FixedPointPrecision2I other)
    {
        return this.RawValue.CompareTo(other.RawValue);
    }

    public bool Equals(FixedPointPrecision2I other)
    {
        return this.RawValue == other.RawValue;
    }

    public override bool Equals(object? obj)
    {
        return obj is FixedPointPrecision2I other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(nameof(FixedPointPrecision2I), this.RawValue);
    }

    // Formatting
    public override string ToString()
    {
        return string.Format(StringFormat, ToDouble());
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return string.Format(formatProvider, format ?? StringFormat, ToDouble());
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format,
        IFormatProvider? provider)
    {
        var formattedValue = ToString(format.ToString(), provider);
        if (formattedValue.Length > destination.Length)
        {
            charsWritten = 0;
            return false;
        }

        formattedValue.AsSpan().CopyTo(destination);
        charsWritten = formattedValue.Length;
        return true;
    }
    
    public static FixedPointPrecision2I Parse(string s, IFormatProvider? provider)
    {
        return (FixedPointPrecision2I)CreateFromDouble(double.Parse(s, provider));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out FixedPointPrecision2I result)
    {
        if (double.TryParse(s, provider, out var value))
        {
            result = (FixedPointPrecision2I)CreateFromDouble(value);
            return true;
        }

        result = default;
        return false;
    }

    public static FixedPointPrecision2I Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        return (FixedPointPrecision2I)CreateFromDouble(double.Parse(s, provider));
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out FixedPointPrecision2I result)
    {
        if (double.TryParse(s, provider, out var value))
        {
            result = (FixedPointPrecision2I)CreateFromDouble(value);
            return true;
        }

        result = default;
        return false;
    }

    public static FixedPointPrecision2I Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        return (FixedPointPrecision2I)CreateFromDouble(double.Parse(s, style, provider));
    }

    public static FixedPointPrecision2I Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        return (FixedPointPrecision2I)CreateFromDouble(double.Parse(s, style, provider));
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out FixedPointPrecision2I result)
    {
        if (double.TryParse(s, style, provider, out var value))
        {
            result = (FixedPointPrecision2I)CreateFromDouble(value);
            return true;
        }

        result = default;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider,
        out FixedPointPrecision2I result)
    {
        if (double.TryParse(s, style, provider, out var value))
        {
            result = (FixedPointPrecision2I)CreateFromDouble(value);
            return true;
        }

        result = default;
        return false;
    }
    
    /// <summary>
    ///     Adds two fixed-point numbers.
    /// </summary>
    public static FixedPointPrecision2I operator +(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        return new FixedPointPrecision2I { RawValue = left.RawValue + right.RawValue };
    }

    /// <summary>
    ///     Subtracts the second fixed-point number from the first.
    /// </summary>
    public static FixedPointPrecision2I operator -(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        return new FixedPointPrecision2I { RawValue = left.RawValue - right.RawValue };
    }

    /// <summary>
    ///     Multiplies two fixed-point numbers.
    /// </summary>
    public static FixedPointPrecision2I operator *(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        // Multiply and then divide by BaseOne (shift right by Shift)
        return new FixedPointPrecision2I { RawValue = (left.RawValue * right.RawValue) >> Shift };
    }

    /// <summary>
    ///     Divides the first fixed-point number by the second.
    /// </summary>
    public static FixedPointPrecision2I operator /(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        // Shift left first to maintain precision, then divide
        return new FixedPointPrecision2I { RawValue = (left.RawValue << Shift) / right.RawValue };
    }

    /// <summary>
    ///     Returns the remainder after dividing the first fixed-point number by the second.
    /// </summary>
    public static FixedPointPrecision2I operator %(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        return new FixedPointPrecision2I { RawValue = left.RawValue % right.RawValue };
    }

    /// <summary>
    ///     Returns the negation of the fixed-point number.
    /// </summary>
    public static FixedPointPrecision2I operator -(FixedPointPrecision2I value)
    {
        return new FixedPointPrecision2I { RawValue = -value.RawValue };
    }

    /// <summary>
    ///     Returns the fixed-point number unchanged (unary plus).
    /// </summary>
    public static FixedPointPrecision2I operator +(FixedPointPrecision2I value)
    {
        return value;
    }

    /// <summary>
    ///     Increments the fixed-point number by one.
    /// </summary>
    public static FixedPointPrecision2I operator ++(FixedPointPrecision2I value)
    {
        return new FixedPointPrecision2I { RawValue = value.RawValue + BaseOne };
    }

    /// <summary>
    ///     Decrements the fixed-point number by one.
    /// </summary>
    public static FixedPointPrecision2I operator --(FixedPointPrecision2I value)
    {
        return new FixedPointPrecision2I { RawValue = value.RawValue - BaseOne };
    }
    
    public static bool operator ==(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        return left.RawValue == right.RawValue;
    }

    public static bool operator !=(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        return left.RawValue != right.RawValue;
    }

    public static bool operator >(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        return left.RawValue > right.RawValue;
    }

    public static bool operator >=(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        return left.RawValue >= right.RawValue;
    }

    public static bool operator <(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        return left.RawValue < right.RawValue;
    }

    public static bool operator <=(FixedPointPrecision2I left, FixedPointPrecision2I right)
    {
        return left.RawValue <= right.RawValue;
    }
    
    /// <summary>
    ///     Returns the absolute value of a fixed-point number.
    /// </summary>
    /// <param name="value">The fixed-point number.</param>
    /// <returns>The absolute value of the fixed-point number.</returns>
    public static FixedPointPrecision2I Abs(FixedPointPrecision2I value)
    {
        return new FixedPointPrecision2I { RawValue = Math.Abs(value.RawValue) };
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is in its canonical form.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always true for this implementation.</returns>
    public static bool IsCanonical(FixedPointPrecision2I value)
    {
        return true; // All values are canonical in this implementation
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents a complex number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsComplexNumber(FixedPointPrecision2I value)
    {
        return false; // Fixed-point numbers are not complex
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents an even integer.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is an even integer; otherwise, false.</returns>
    public static bool IsEvenInteger(FixedPointPrecision2I value)
    {
        // Check if it's an integer and if it's even
        if (value.RawValue % BaseOne != 0)
        {
            return false;
        }

        return value.RawValue / BaseOne % 2 == 0;
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is a finite number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always true for this implementation.</returns>
    public static bool IsFinite(FixedPointPrecision2I value)
    {
        return true; // Fixed-point numbers are always finite
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents an imaginary number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsImaginaryNumber(FixedPointPrecision2I value)
    {
        return false; // Fixed-point numbers are not imaginary
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents infinity.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsInfinity(FixedPointPrecision2I value)
    {
        return false; // Fixed-point numbers cannot be infinite
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents an integer.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is an integer; otherwise, false.</returns>
    public static bool IsInteger(FixedPointPrecision2I value)
    {
        // Check if there's any fractional part
        return value.RawValue % BaseOne == 0;
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is not a number (NaN).
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsNaN(FixedPointPrecision2I value)
    {
        return false; // Fixed-point numbers cannot be NaN
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is negative.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is negative; otherwise, false.</returns>
    public static bool IsNegative(FixedPointPrecision2I value)
    {
        return value.RawValue < 0;
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents negative infinity.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsNegativeInfinity(FixedPointPrecision2I value)
    {
        return false; // Fixed-point numbers cannot be infinite
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is a normal number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is not zero; otherwise, false.</returns>
    public static bool IsNormal(FixedPointPrecision2I value)
    {
        return value.RawValue != 0; // All non-zero values are normal
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents an odd integer.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is an odd integer; otherwise, false.</returns>
    public static bool IsOddInteger(FixedPointPrecision2I value)
    {
        // Check if it's an integer and if it's odd
        if (value.RawValue % BaseOne != 0)
        {
            return false;
        }

        return value.RawValue / BaseOne % 2 != 0;
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is positive.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is positive; otherwise, false.</returns>
    public static bool IsPositive(FixedPointPrecision2I value)
    {
        return value.RawValue > 0;
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents positive infinity.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsPositiveInfinity(FixedPointPrecision2I value)
    {
        return false; // Fixed-point numbers cannot be infinite
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents a real number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always true for this implementation.</returns>
    public static bool IsRealNumber(FixedPointPrecision2I value)
    {
        return true; // All fixed-point numbers are real
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is a subnormal number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsSubnormal(FixedPointPrecision2I value)
    {
        return false; // Fixed-point numbers don't have subnormal representation
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is zero.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is zero; otherwise, false.</returns>
    public static bool IsZero(FixedPointPrecision2I value)
    {
        return value.RawValue == 0;
    }

    /// <summary>
    ///     Compares two fixed-point numbers and returns the larger magnitude.
    /// </summary>
    /// <param name="x">The first fixed-point number.</param>
    /// <param name="y">The second fixed-point number.</param>
    /// <returns>The fixed-point number with the larger magnitude.</returns>
    public static FixedPointPrecision2I MaxMagnitude(FixedPointPrecision2I x, FixedPointPrecision2I y)
    {
        var absX = Math.Abs(x.RawValue);
        var absY = Math.Abs(y.RawValue);
        return absX >= absY ? x : y;
    }

    /// <summary>
    ///     Compares two fixed-point numbers and returns the larger magnitude number.
    /// </summary>
    /// <param name="x">The first fixed-point number.</param>
    /// <param name="y">The second fixed-point number.</param>
    /// <returns>The fixed-point number with the larger magnitude.</returns>
    public static FixedPointPrecision2I MaxMagnitudeNumber(FixedPointPrecision2I x, FixedPointPrecision2I y)
    {
        return MaxMagnitude(x, y);
    }

    /// <summary>
    ///     Compares two fixed-point numbers and returns the smaller magnitude.
    /// </summary>
    /// <param name="x">The first fixed-point number.</param>
    /// <param name="y">The second fixed-point number.</param>
    /// <returns>The fixed-point number with the smaller magnitude.</returns>
    public static FixedPointPrecision2I MinMagnitude(FixedPointPrecision2I x, FixedPointPrecision2I y)
    {
        var absX = Math.Abs(x.RawValue);
        var absY = Math.Abs(y.RawValue);
        return absX <= absY ? x : y;
    }

    /// <summary>
    ///     Compares two fixed-point numbers and returns the smaller magnitude number.
    /// </summary>
    /// <param name="x">The first fixed-point number.</param>
    /// <param name="y">The second fixed-point number.</param>
    /// <returns>The fixed-point number with the smaller magnitude.</returns>
    public static FixedPointPrecision2I MinMagnitudeNumber(FixedPointPrecision2I x, FixedPointPrecision2I y)
    {
        return MinMagnitude(x, y);
    }

    // Conversion methods
    public static bool TryConvertFromChecked<TOther>(TOther value, out FixedPointPrecision2I result) where TOther : INumberBase<TOther>
    {
        result = default;

        if (typeof(TOther) == typeof(double))
        {
            var doubleValue = (double)(object)value;
            result = (FixedPointPrecision2I)CreateFromDouble(doubleValue);
            return true;
        }

        if (typeof(TOther) == typeof(float))
        {
            var floatValue = (float)(object)value;
            result = (FixedPointPrecision2I)CreateFromFloat(floatValue);
            return true;
        }

        if (typeof(TOther) == typeof(decimal))
        {
            var decimalValue = (decimal)(object)value;
            result = (FixedPointPrecision2I)CreateFromDouble((double)decimalValue);
            return true;
        }

        if (typeof(TOther) == typeof(int))
        {
            var intValue = (int)(object)value;
            result = new FixedPointPrecision2I(intValue);
            return true;
        }

        if (typeof(TOther) == typeof(long))
        {
            var longValue = (long)(object)value;
            result = new FixedPointPrecision2I((int)longValue);
            return true;
        }

        return false;
    }

    public static bool TryConvertFromSaturating<TOther>(TOther value, out FixedPointPrecision2I result)
        where TOther : INumberBase<TOther>
    {
        // For simplicity, using the same implementation as checked conversion
        return TryConvertFromChecked(value, out result);
    }

    public static bool TryConvertFromTruncating<TOther>(TOther value, out FixedPointPrecision2I result)
        where TOther : INumberBase<TOther>
    {
        // For simplicity, using the same implementation as checked conversion
        return TryConvertFromChecked(value, out result);
    }

    public static bool TryConvertToChecked<TOther>(FixedPointPrecision2I value, [MaybeNullWhen(false)] out TOther result)
        where TOther : INumberBase<TOther>
    {
        result = default;

        if (typeof(TOther) == typeof(double))
        {
            var doubleValue = value.ToDouble();
            result = (TOther)(object)doubleValue;
            return true;
        }

        if (typeof(TOther) == typeof(float))
        {
            var floatValue = value.ToFloat();
            result = (TOther)(object)floatValue;
            return true;
        }

        if (typeof(TOther) == typeof(decimal))
        {
            var decimalValue = (decimal)value.ToDouble();
            result = (TOther)(object)decimalValue;
            return true;
        }

        if (typeof(TOther) == typeof(int))
        {
            var intValue = (int)(value.RawValue / BaseOne);
            result = (TOther)(object)intValue;
            return true;
        }

        if (typeof(TOther) == typeof(long))
        {
            var longValue = value.RawValue / BaseOne;
            result = (TOther)(object)longValue;
            return true;
        }

        return false;
    }

    public static bool TryConvertToSaturating<TOther>(FixedPointPrecision2I value, [MaybeNullWhen(false)] out TOther result)
        where TOther : INumberBase<TOther>
    {
        // For simplicity, using the same implementation as checked conversion
        return TryConvertToChecked(value, out result);
    }

    public static bool TryConvertToTruncating<TOther>(FixedPointPrecision2I value, [MaybeNullWhen(false)] out TOther result)
        where TOther : INumberBase<TOther>
    {
        // For simplicity, using the same implementation as checked conversion
        return TryConvertToChecked(value, out result);
    }

    /// <summary>
    ///     Converts an integer to a fixed-point number.
    /// </summary>
    public static implicit operator FixedPointPrecision2I(int value)
    {
        return new FixedPointPrecision2I { RawValue = value * BaseOne };
    }
    
    /// <summary>
    ///     Converts a short to a fixed-point number.
    /// </summary>
    public static implicit operator FixedPointPrecision2I(short value)
    {
        return new FixedPointPrecision2I(value);
    }
    
    /// <summary>
    ///     Converts a long to a fixed-point number.
    /// </summary>
    public static implicit operator FixedPointPrecision2I(long value)
    {
        return new FixedPointPrecision2I { RawValue = (int)value * BaseOne };
    }
    
    /// <summary>
    ///     Converts a decimal to a fixed-point number.
    /// </summary>
    public static implicit operator FixedPointPrecision2I(decimal value)
    {
        return (FixedPointPrecision2I)CreateFromDouble((double)value);
    }
    
    /// <summary>
    ///     Converts a double to a fixed-point number.
    /// </summary>
    public static implicit operator FixedPointPrecision2I(double value)
    {
        return (FixedPointPrecision2I)CreateFromDouble(value);
    }
    
    /// <summary>
    ///     Converts a float to a fixed-point number.
    /// </summary>
    public static implicit operator FixedPointPrecision2I(float value)
    {
        return (FixedPointPrecision2I)CreateFromFloat(value);
    }

    /// <summary>
    ///     Converts a fixed-point number to a double.
    /// </summary>
    public static explicit operator double(FixedPointPrecision2I value)
    {
        return value.ToDouble();
    }

    /// <summary>
    ///     Converts a fixed-point number to a float.
    /// </summary>
    public static explicit operator float(FixedPointPrecision2I value)
    {
        return value.ToFloat();
    }

    /// <summary>
    ///     Converts a fixed-point number to an integer by truncating its fractional part.
    /// </summary>
    public static explicit operator int(FixedPointPrecision2I value)
    {
        return (int)(value.RawValue / BaseOne);
    }
}
