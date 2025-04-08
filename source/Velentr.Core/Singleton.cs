namespace Velentr.Core;

public interface ISingleton<TSelf> where TSelf : ISingleton<TSelf>
{
    TSelf SingletonInstance { get; }
}

public abstract class Singleton<TSelf> where TSelf : Singleton<TSelf>
{
    private static readonly Lazy<TSelf> Lazy = new(() => (Activator.CreateInstance(typeof(TSelf), true) as TSelf)!);

    public static TSelf Instance => Lazy.Value;
}
