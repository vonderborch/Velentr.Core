using Velentr.Core.TestApp;
#if FNA
FnaDependencyHelper.HandleDependencies();

#endif

using TestGame game = new();
game.Run();
