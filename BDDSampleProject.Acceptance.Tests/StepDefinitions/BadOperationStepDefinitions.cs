using System;
using Reqnroll;

namespace BDDSampleProject.Acceptance.Tests.StepDefinitions
{
    [Binding]
    public class BadOperationStepDefinitions
    {
        private readonly ScenarioContext _context;

        public BadOperationStepDefinitions(ScenarioContext context)
        {
            _context = context;
        }

        [Then("The exception should be {string}")]
        public void ThenTheExceptionShouldBe(string expectedExceptionMessage)
        {
            if (_context.TryGetValue("Exception", out Exception exception))
            {
                Assert.Equal(expectedExceptionMessage, exception.Message);
                return;
            }
            Assert.Fail();
        }
    }
}
