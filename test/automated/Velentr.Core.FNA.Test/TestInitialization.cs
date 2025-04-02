namespace Velentr.Core.Test;

[SetUpFixture]
public class TestInitialization
{
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        FnaDependencyHelper.HandleDependencies();
    }

    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
    }
}
