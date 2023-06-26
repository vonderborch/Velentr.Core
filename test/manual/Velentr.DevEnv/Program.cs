using Velentr.PerformanceMetrics;

namespace Velentr.DevEnv
{
    public static class Program
    {
        static void Main()
        {
            using var game = new GamePerformanceWrapper(new Game1(), "Velentr.Core_WITH_GENERIC");
            game.Run();
        }
    }
}
