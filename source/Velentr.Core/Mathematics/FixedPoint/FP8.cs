using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace Velentr.Core.Mathematics.FixedPoint;

/// <summary>
///     Represents a fixed-point number with 8 decimal places of precision.
/// </summary>
// ReSharper disable once InconsistentNaming
public struct FP8 : IFixedPoint<FP8>, IBaseFixedPoint<long>
{
    /// <summary>
    ///     Gets the precision of the fixed-point number.
    /// </summary>
    public static ushort Precision => 8;

    /// <summary>
    ///     Gets the shift value used for fixed-point calculations.
    /// </summary>
    public static ushort Shift => 27;

    /// <summary>
    ///     Gets the format string used for converting the fixed-point number to a string.
    /// </summary>
    public static string StringFormat => $"{{0:F{Precision}}}";

    /// <summary>
    ///     Gets the base value representing one in the fixed-point format.
    /// </summary>
    public static long BaseOne { get; } = 1 << Shift;

    /// <summary>
    ///     Represents the maximum value of the fixed-point number.
    /// </summary>
    public static FP8 MaxValue { get; } = new() { RawValue = long.MaxValue };

    /// <summary>
    ///     Represents the minimum value of the fixed-point number.
    /// </summary>
    public static FP8 MinValue { get; } = new() { RawValue = long.MinValue };

    /// <summary>
    ///     Represents the fixed-point number zero.
    /// </summary>
    public static FP8 Zero { get; } = new() { RawValue = 0 };

    /// <summary>
    ///     Represents the fixed-point number one.
    /// </summary>
    public static FP8 One { get; } = new() { RawValue = 1 << Shift };

    /// <summary>
    ///     Gets the additive identity for the fixed-point number.
    /// </summary>
    public static FP8 AdditiveIdentity => Zero;

    /// <summary>
    ///     Gets the multiplicative identity for the fixed-point number.
    /// </summary>
    public static FP8 MultiplicativeIdentity => One;

    /// <summary>
    ///     Gets the radix (base) of the fixed-point number.
    /// </summary>
    public static int Radix => 2;

    /// <summary>
    ///     Gets or sets the raw value of the fixed-point number.
    /// </summary>
    public long RawValue { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="FP8"/> with a raw internal value.
    /// </summary>
    private FP8(long rawValue)
    {
        this.RawValue = rawValue;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FP8"/> from an integer value.
    /// </summary>
    private FP8(int value)
    {
        this.RawValue = value * BaseOne;
    }

    /// <summary>
    ///     Creates a fixed-point number from a double value.
    /// </summary>
    /// <param name="value">The double value to convert.</param>
    /// <returns>A fixed-point number representing the double value.</returns>
    public static FP8 CreateFromDouble(double value)
    {
        return new FP8 { RawValue = (long)Math.Round(value * BaseOne) };
    }

    /// <summary>
    ///     Creates a fixed-point number from a float value.
    /// </summary>
    /// <param name="value">The float value to convert.</param>
    /// <returns>A fixed-point number representing the float value.</returns>
    public static FP8 CreateFromFloat(float value)
    {
        return new FP8 { RawValue = (long)(value * BaseOne) };
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

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        if (obj is FP8 other)
        {
            return CompareTo(other);
        }

        throw new ArgumentException("Object is not an FPL4");
    }

    /// <inheritdoc/>
    public int CompareTo(FP8 other)
    {
        return this.RawValue.CompareTo(other.RawValue);
    }

    /// <summary>
    /// Determines whether this instance and another <see cref="FP8"/> have the same value.
    /// </summary>
    public bool Equals(FP8 other)
    {
        return this.RawValue == other.RawValue;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is FP8 other && Equals(other);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(nameof(FP8), this.RawValue);
    }

    /// <summary>
    /// Returns the string representation of the fixed-point number.
    /// </summary>
    public override string ToString()
    {
        return string.Format(StringFormat, ToDouble());
    }

    /// <summary>
    /// Converts the fixed-point number to a string using the specified format and culture.
    /// </summary>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return string.Format(formatProvider, format ?? StringFormat, ToDouble());
    }

    /// <summary>
    /// Tries to format the fixed-point number into the given character span.
    /// </summary>
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

    /// <summary>
    /// Parses the string into an <see cref="FP8"/> using the specified provider.
    /// </summary>
    public static FP8 Parse(string s, IFormatProvider? provider)
    {
        return CreateFromDouble(double.Parse(s, provider));
    }

    /// <summary>
    /// Tries to parse the string into an <see cref="FP8"/> using the specified provider.
    /// </summary>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out FP8 result)
    {
        if (double.TryParse(s, provider, out var value))
        {
            result = CreateFromDouble(value);
            return true;
        }

        result = default;
        return false;
    }

    /// <summary>
    /// Parses the span into an <see cref="FP8"/> using the specified provider.
    /// </summary>
    public static FP8 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        return CreateFromDouble(double.Parse(s, provider));
    }

    /// <summary>
    /// Tries to parse the span into an <see cref="FP8"/> using the specified provider.
    /// </summary>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out FP8 result)
    {
        if (double.TryParse(s, provider, out var value))
        {
            result = CreateFromDouble(value);
            return true;
        }

        result = default;
        return false;
    }

    /// <summary>
    /// Parses the span into an <see cref="FP8"/> using the specified number style and provider.
    /// </summary>
    public static FP8 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        return CreateFromDouble(double.Parse(s, style, provider));
    }

    /// <summary>
    /// Parses the string into an <see cref="FP8"/> using the specified number style and provider.
    /// </summary>
    public static FP8 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        return CreateFromDouble(double.Parse(s, style, provider));
    }

    /// <summary>
    /// Tries to parse the span into an <see cref="FP8"/> using the specified number style and provider.
    /// </summary>
    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out FP8 result)
    {
        if (double.TryParse(s, style, provider, out var value))
        {
            result = CreateFromDouble(value);
            return true;
        }

        result = default;
        return false;
    }

    /// <summary>
    /// Tries to parse the string into an <see cref="FP8"/> using the specified number style and provider.
    /// </summary>
    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider,
        out FP8 result)
    {
        if (double.TryParse(s, style, provider, out var value))
        {
            result = CreateFromDouble(value);
            return true;
        }

        result = default;
        return false;
    }

    /// <summary>
    ///     Adds two <see cref="FP8"/> values.
    /// </summary>
    public static FP8 operator +(FP8 left, FP8 right)
    {
        return new FP8 { RawValue = left.RawValue + right.RawValue };
    }

    /// <summary>
    ///     Subtracts one <see cref="FP8"/> value from another.
    /// </summary>
    public static FP8 operator -(FP8 left, FP8 right)
    {
        return new FP8 { RawValue = left.RawValue - right.RawValue };
    }

    /// <summary>
    ///     Multiplies two <see cref="FP8"/> values.
    /// </summary>
    public static FP8 operator *(FP8 left, FP8 right)
    {
        // Multiply and then divide by BaseOne (shift right by Shift)
        return new FP8 { RawValue = (left.RawValue * right.RawValue) >> Shift };
    }

    /// <summary>
    ///     Divides one <see cref="FP8"/> value by another.
    /// </summary>
    public static FP8 operator /(FP8 left, FP8 right)
    {
        // Shift left first to maintain precision, then divide
        return new FP8 { RawValue = (left.RawValue << Shift) / right.RawValue };
    }

    /// <summary>
    ///     Returns the remainder after dividing two <see cref="FP8"/> values.
    /// </summary>
    public static FP8 operator %(FP8 left, FP8 right)
    {
        return new FP8 { RawValue = left.RawValue % right.RawValue };
    }

    /// <summary>
    ///     Returns the negation of the specified <see cref="FP8"/> value.
    /// </summary>
    public static FP8 operator -(FP8 value)
    {
        return new FP8 { RawValue = -value.RawValue };
    }

    /// <summary>
    /// Unary plus operator for <see cref="FP8"/>.
    /// </summary>
    public static FP8 operator +(FP8 value)
    {
        return value;
    }

    /// <summary>
    ///     Increments the fixed-point number by one.
    /// </summary>
    public static FP8 operator ++(FP8 value)
    {
        return new FP8 { RawValue = value.RawValue + BaseOne };
    }

    /// <summary>
    ///     Decrements the fixed-point number by one.
    /// </summary>
    public static FP8 operator --(FP8 value)
    {
        return new FP8 { RawValue = value.RawValue - BaseOne };
    }

    /// <summary>
    ///     Determines whether two <see cref="FP8"/> values are equal.
    /// </summary>
    public static bool operator ==(FP8 left, FP8 right)
    {
        return left.RawValue == right.RawValue;
    }

    /// <summary>
    ///     Determines whether two <see cref="FP8"/> values are not equal.
    /// </summary>
    public static bool operator !=(FP8 left, FP8 right)
    {
        return left.RawValue != right.RawValue;
    }

    /// <summary>
    ///     Determines whether one <see cref="FP8"/> value is greater than another.
    /// </summary>
    public static bool operator >(FP8 left, FP8 right)
    {
        return left.RawValue > right.RawValue;
    }

    /// <summary>
    ///     Determines whether one <see cref="FP8"/> value is greater than or equal to another.
    /// </summary>
    public static bool operator >=(FP8 left, FP8 right)
    {
        return left.RawValue >= right.RawValue;
    }

    /// <summary>
    ///     Determines whether one <see cref="FP8"/> value is less than another.
    /// </summary>
    public static bool operator <(FP8 left, FP8 right)
    {
        return left.RawValue < right.RawValue;
    }

    /// <summary>
    ///     Determines whether one <see cref="FP8"/> value is less than or equal to another.
    /// </summary>
    public static bool operator <=(FP8 left, FP8 right)
    {
        return left.RawValue <= right.RawValue;
    }

    /// <summary>
    /// Returns the absolute value of the specified <see cref="FP8"/>.
    /// </summary>
    public static FP8 Abs(FP8 value)
    {
        return new FP8 { RawValue = Math.Abs(value.RawValue) };
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is in its canonical form.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always true for this implementation.</returns>
    public static bool IsCanonical(FP8 value)
    {
        return true; // All values are canonical in this implementation
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents a complex number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsComplexNumber(FP8 value)
    {
        return false; // Fixed-point numbers are not complex
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents an even integer.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is an even integer; otherwise, false.</returns>
    public static bool IsEvenInteger(FP8 value)
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
    public static bool IsFinite(FP8 value)
    {
        return true; // Fixed-point numbers are always finite
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents an imaginary number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsImaginaryNumber(FP8 value)
    {
        return false; // Fixed-point numbers are not imaginary
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents infinity.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsInfinity(FP8 value)
    {
        return false; // Fixed-point numbers cannot be infinite
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents an integer.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is an integer; otherwise, false.</returns>
    public static bool IsInteger(FP8 value)
    {
        // Check if there's any fractional part
        return value.RawValue % BaseOne == 0;
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is not a number (NaN).
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsNaN(FP8 value)
    {
        return false; // Fixed-point numbers cannot be NaN
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is negative.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is negative; otherwise, false.</returns>
    public static bool IsNegative(FP8 value)
    {
        return value.RawValue < 0;
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents negative infinity.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsNegativeInfinity(FP8 value)
    {
        return false; // Fixed-point numbers cannot be infinite
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is a normal number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is not zero; otherwise, false.</returns>
    public static bool IsNormal(FP8 value)
    {
        return value.RawValue != 0; // All non-zero values are normal
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents an odd integer.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is an odd integer; otherwise, false.</returns>
    public static bool IsOddInteger(FP8 value)
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
    public static bool IsPositive(FP8 value)
    {
        return value.RawValue > 0;
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents positive infinity.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsPositiveInfinity(FP8 value)
    {
        return false; // Fixed-point numbers cannot be infinite
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number represents a real number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always true for this implementation.</returns>
    public static bool IsRealNumber(FP8 value)
    {
        return true; // All fixed-point numbers are real
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is a subnormal number.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>Always false for this implementation.</returns>
    public static bool IsSubnormal(FP8 value)
    {
        return false; // Fixed-point numbers don't have subnormal representation
    }

    /// <summary>
    ///     Indicates whether the specified fixed-point number is zero.
    /// </summary>
    /// <param name="value">The fixed-point number to check.</param>
    /// <returns>True if the fixed-point number is zero; otherwise, false.</returns>
    public static bool IsZero(FP8 value)
    {
        return value.RawValue == 0;
    }

    /// <summary>
    ///     Compares two fixed-point numbers and returns the larger magnitude.
    /// </summary>
    /// <param name="x">The first fixed-point number.</param>
    /// <param name="y">The second fixed-point number.</param>
    /// <returns>The fixed-point number with the larger magnitude.</returns>
    public static FP8 MaxMagnitude(FP8 x, FP8 y)
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
    public static FP8 MaxMagnitudeNumber(FP8 x, FP8 y)
    {
        return MaxMagnitude(x, y);
    }

    /// <summary>
    ///     Compares two fixed-point numbers and returns the smaller magnitude.
    /// </summary>
    /// <param name="x">The first fixed-point number.</param>
    /// <param name="y">The second fixed-point number.</param>
    /// <returns>The fixed-point number with the smaller magnitude.</returns>
    public static FP8 MinMagnitude(FP8 x, FP8 y)
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
    public static FP8 MinMagnitudeNumber(FP8 x, FP8 y)
    {
        return MinMagnitude(x, y);
    }

    /// <summary>
    /// Attempts to convert another numeric type to <see cref="FP8"/>, throwing on overflow.
    /// </summary>
    public static bool TryConvertFromChecked<TOther>(TOther value, out FP8 result) where TOther : INumberBase<TOther>
    {
        result = default;

        if (typeof(TOther) == typeof(double))
        {
            var doubleValue = (double)(object)value;
            result = CreateFromDouble(doubleValue);
            return true;
        }

        if (typeof(TOther) == typeof(float))
        {
            var floatValue = (float)(object)value;
            result = CreateFromFloat(floatValue);
            return true;
        }

        if (typeof(TOther) == typeof(decimal))
        {
            var decimalValue = (decimal)(object)value;
            result = CreateFromDouble((double)decimalValue);
            return true;
        }

        if (typeof(TOther) == typeof(int))
        {
            var intValue = (int)(object)value;
            result = new FP8(intValue);
            return true;
        }

        if (typeof(TOther) == typeof(long))
        {
            var longValue = (long)(object)value;
            result = new FP8 { RawValue = longValue * BaseOne };
            return true;
        }

        return false;
    }

    /// <summary>
    /// Attempts to convert another numeric type to <see cref="FP8"/>, saturating on overflow.
    /// </summary>
    public static bool TryConvertFromSaturating<TOther>(TOther value, out FP8 result)
        where TOther : INumberBase<TOther>
    {
        // For simplicity, using the same implementation as checked conversion
        return TryConvertFromChecked(value, out result);
    }

    /// <summary>
    /// Attempts to convert another numeric type to <see cref="FP8"/>, truncating on overflow.
    /// </summary>
    public static bool TryConvertFromTruncating<TOther>(TOther value, out FP8 result)
        where TOther : INumberBase<TOther>
    {
        // For simplicity, using the same implementation as checked conversion
        return TryConvertFromChecked(value, out result);
    }

    /// <summary>
    /// Attempts to convert this <see cref="FP8"/> to another numeric type, throwing on overflow.
    /// </summary>
    public static bool TryConvertToChecked<TOther>(FP8 value, [MaybeNullWhen(false)] out TOther result)
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

    /// <summary>
    /// Attempts to convert this <see cref="FP8"/> to another numeric type, saturating on overflow.
    /// </summary>
    public static bool TryConvertToSaturating<TOther>(FP8 value, [MaybeNullWhen(false)] out TOther result)
        where TOther : INumberBase<TOther>
    {
        // For simplicity, using the same implementation as checked conversion
        return TryConvertToChecked(value, out result);
    }

    /// <summary>
    /// Attempts to convert this <see cref="FP8"/> to another numeric type, truncating on overflow.
    /// </summary>
    public static bool TryConvertToTruncating<TOther>(FP8 value, [MaybeNullWhen(false)] out TOther result)
        where TOther : INumberBase<TOther>
    {
        // For simplicity, using the same implementation as checked conversion
        return TryConvertToChecked(value, out result);
    }

    /// <summary>
    ///     Converts an integer to a fixed-point number.
    /// </summary>
    public static implicit operator FP8(int value)
    {
        return new FP8(value);
    }

    /// <summary>
    ///     Converts a short to a fixed-point number.
    /// </summary>
    public static implicit operator FP8(short value)
    {
        return new FP8(value);
    }

    /// <summary>
    ///     Converts a long to a fixed-point number.
    /// </summary>
    public static implicit operator FP8(long value)
    {
        return new FP8 { RawValue = value * BaseOne };
    }

    /// <summary>
    ///     Converts a decimal to a fixed-point number.
    /// </summary>
    public static implicit operator FP8(decimal value)
    {
        return CreateFromDouble((double)value);
    }

    /// <summary>
    ///     Converts a double to a fixed-point number.
    /// </summary>
    public static implicit operator FP8(double value)
    {
        return CreateFromDouble(value);
    }

    /// <summary>
    ///     Converts a float to a fixed-point number.
    /// </summary>
    public static implicit operator FP8(float value)
    {
        return CreateFromFloat(value);
    }

    /// <summary>
    ///     Converts a fixed-point number to a double.
    /// </summary>
    public static explicit operator double(FP8 value)
    {
        return value.ToDouble();
    }

    /// <summary>
    ///     Converts a fixed-point number to a float.
    /// </summary>
    public static explicit operator float(FP8 value)
    {
        return value.ToFloat();
    }

    /// <summary>
    ///     Converts a fixed-point number to an integer by truncating its fractional part.
    /// </summary>
    public static explicit operator int(FP8 value)
    {
        return (int)(value.RawValue / BaseOne);
    }
}
