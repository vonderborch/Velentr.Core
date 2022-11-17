namespace Velentr.Core
{
    /// <summary>
    ///     Interface for objects that need a Load and Unload method.
    /// </summary>
    public interface ILoadable
    {
        /// <summary>
        ///     Loads this object.
        /// </summary>
        void Load();

        /// <summary>
        ///     Unloads this object.
        /// </summary>
        void Unload();
    }
}
