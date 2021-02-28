using NUnit.Framework;
using SimpleBank.Application;

namespace SimpleBank.Tests
{
    [SetUpFixture]
    public class TestsSetUp
    {
        [OneTimeSetUp]
        public void FixtureSetup()
        {
            ValidatorFactory.Init();
            RequestsFactory.Init();
        }
    }
}
