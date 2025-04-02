#if FNA
Velentr.Core.TestApp.FnaDependencyHelper.HandleDependencies();

#endif

using Velentr.Core.TestApp.TestGame game = new();
game.Run();
