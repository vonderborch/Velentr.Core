using System.Numerics;

namespace Velentr.Core.Validation;

/// <summary>
/// Provides various validation methods.
/// </summary>
public static class Validations
{
    /// <summary>
    /// Checks if the specified string is not null.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <exception cref="ArgumentNullException">Thrown when the string is null.</exception>
    public static void NotNullCheck(string value, string parameterName)
    {
        if (value is null)
        {
            throw new ArgumentNullException(parameterName);
        }
    }
    
    /// <summary>
    /// Checks if the specified string is not null or empty.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <exception cref="ArgumentException">Thrown when the string is null or empty.</exception>
    public static void NotNullOrEmptyCheck(string value, string parameterName)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"{parameterName} can not be null or empty.");
        }
    }
        
    /// <summary>
    /// Checks if the specified string is not null, empty, or contains only white space.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <exception cref="ArgumentException">Thrown when the string is null, empty, or contains only white space.</exception>
    public static void NotNullOrWhiteSpaceCheck(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} can not be null, empty, or contain only white space.");
        }
    }
        
    /// <summary>
    /// Validates that the specified value is within the given range.
    /// </summary>
    /// <typeparam name="T">The numeric type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="parameterName">The name of the parameter being checked.</param>
    /// <param name="maxValue">The maximum allowed value.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is outside the specified range.</exception>
    public static void ValidateRange<T>(T value, string parameterName, T minValue, T maxValue) where T : INumber<T>
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentOutOfRangeException(parameterName, $"The parameter [{parameterName}] is out of the range (min: {minValue}, max:{maxValue})!");
        }
    }
}