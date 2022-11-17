namespace Velentr.Core
{
    /// <summary>
    ///     Interface for objects that need an Initialize method.
    /// </summary>
    public interface IInitializable
    {
        /// <summary>
        ///     Initializes this object.
        /// </summary>
        void Initialize();
    }
}
