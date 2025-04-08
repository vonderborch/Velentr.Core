namespace Velentr.Core.Test;

[SetUpFixture]
public class TestInitialization
{
    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
    }

    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        FnaDependencyHelper.HandleDependencies();
    }
}
