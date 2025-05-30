using System.Diagnostics;

namespace Velentr.Core.Threading;

/// <summary>
///     A thread-safe boolean guard/flag.
/// </summary>
[DebuggerDisplay("State = {Check}")]
public struct Guard : IEquatable<Guard>
{
    /// <summary>
    /// Determines whether the specified <see cref="Guard"/> instance is equal to this instance.
    /// </summary>
    /// <param name="other">The <see cref="Guard"/> instance to compare with this instance.</param>
    /// <returns>True if the state of the specified <see cref="Guard"/> instance matches the state of this instance; otherwise, false.</returns>
    public bool Equals(Guard other)
    {
        return this.state == other.state;
    }

    /// <summary>
    /// Determines whether the specified <see cref="Guard"/> instance is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="Guard"/> instance to compare with this instance.</param>
    /// <returns>True if the state of the specified <see cref="Guard"/> instance matches the state of this instance; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Guard other && Equals(other);
    }

    /// <summary>
    /// Gets a hash code for this instance of the <see cref="Guard"/> struct.
    /// </summary>
    /// <returns>
    /// An integer representing the current state of the guard. The value is 0 if the state is false, or 1 if the state is true.
    /// </returns>
    public override int GetHashCode()
    {
        return this.state;
    }

    /// <summary>
    ///     The value for false.
    /// </summary>
    private const int False = 0;

    /// <summary>
    ///     The value for true.
    /// </summary>
    private const int True = 1;

    /// <summary>
    ///     The current state.
    /// </summary>
    private int state = False;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Guard" /> struct.
    /// </summary>
    public Guard()
    {
    }

    /// <summary>
    ///     Gets a value indicating whether this <see cref="Guard" /> is set to True. NOTE: Will *not*
    ///     set it to true if it is currently set to False!
    /// </summary>
    public bool Check => this.state == True;

    /// <summary>
    ///     Gets a value whether this <see cref="Guard" /> is set to True. Will set it to True if it is currently set to
    ///     False.
    /// </summary>
    public bool CheckSet => Interlocked.Exchange(ref this.state, True) == False;

    /// <summary>
    ///     Compares the specified Guard instance to a boolean value.
    /// </summary>
    /// <param name="left">The Guard instance to compare.</param>
    /// <param name="right">The boolean value to compare against.</param>
    /// <returns>True if the Guard's state matches the boolean value; otherwise, false.</returns>
    public static bool operator ==(Guard left, bool right)
    {
        return left.Check == right;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Guard" /> struct.
    /// </summary>
    /// <param name="left">The Guard instance to compare.</param>
    /// <param name="right">The boolean value to compare against.</param>
    /// <returns>True if the Guard's state matches the boolean value; otherwise, false.</returns>
    public static bool operator ==(bool left, Guard right)
    {
        return left == right.Check;
    }

    /// <summary>
    ///     Compares the specified Guard instance to a boolean value.
    /// </summary>
    /// <param name="left">The Guard instance to compare.</param>
    /// <param name="right">The boolean value to compare against.</param>
    /// <returns>True if the Guard's Check is not equal to the boolean value; otherwise, false.</returns>
    public static bool operator !=(Guard left, bool right)
    {
        return left.Check != right;
    }

    /// <summary>
    ///     Compares the specified Guard instance to a boolean value.
    /// </summary>
    /// <param name="left">The Guard instance to compare.</param>
    /// <param name="right">The boolean value to compare against.</param>
    /// <returns>True if the Guard's Check is not equal to the boolean value; otherwise, false.</returns>
    public static bool operator !=(bool left, Guard right)
    {
        return left != right.Check;
    }

    /// <summary>
    ///     Mark the <see cref="Guard" /> as being checked.
    /// </summary>
    public void MarkChecked()
    {
        Interlocked.Exchange(ref this.state, True);
    }

    /// <summary>
    ///     Reset the <see cref="Guard" /> to False.
    /// </summary>
    public void Reset()
    {
        Interlocked.Exchange(ref this.state, False);
    }
}
