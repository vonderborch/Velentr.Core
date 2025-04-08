namespace Velentr.Core.Mathematics.Bound;

/// <summary>
///     Defines various default Bounds instances.
/// </summary>
public class DefaultBounds
{
    /// <summary>
    ///     A Bounds representing the full Bounds of a double.
    /// </summary>
    public static readonly Bounds<double> FullDoubleBounds = new(double.MinValue, double.MaxValue);

    /// <summary>
    ///     A Bounds representing a percentage (0/0% -> 1/100%).
    /// </summary>
    public static readonly Bounds<double> DoublePercentageBounds = new(0, 1);

    /// <summary>
    ///     A Bounds representing the valid numbers for a neural network.
    /// </summary>
    public static readonly Bounds<double> NeuralNetworkBounds = new(-1, 1);

    /// <summary>
    ///     A Bounds representing the full Bounds of a byte.
    /// </summary>
    public static readonly Bounds<byte> FullByteBounds = new(byte.MinValue, byte.MaxValue);

    /// <summary>
    ///     The default Bounds we use for Alpha in random colours.
    /// </summary>
    public static readonly Bounds<byte> RandomDefaultAlphaBounds = new(255, 255);

    /// <summary>
    ///     A Bounds representing the default Bounds we generally want for random colours.
    /// </summary>
    public static readonly Bounds<byte> RandomDefaultRgbColourBounds = new(100, 255);

    /// <summary>
    ///     A Bounds representing the degrees in a circle.
    /// </summary>
    public static readonly Bounds<int> DegreeBounds = new(0, 360);
}
