using System.Diagnostics;

namespace Velentr.Core.Threading;

/// <summary>
///     A thread-safe boolean guard/flag.
/// </summary>
[DebuggerDisplay("State = {Check}")]
public struct Guard
{
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
