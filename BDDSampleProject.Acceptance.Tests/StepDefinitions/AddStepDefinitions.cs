using BDDSampleProject.Operations.Interfaces;

namespace BDDSampleProject.Acceptance.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Add")]
    public class AddStepDefinitions
    {
        private readonly IAddOperation _addOperation;
        private int _result = -1;
        private int _first;
        private int _second;

        public AddStepDefinitions(IAddOperation addOperation)
        {
            _addOperation = addOperation;
        }

        [Given("The first number is {int}")]
        public void GivenTheFirstNumberIs(int first)
        {
            _first = first;
        }

        [Given("The second number is {int}")]
        public void GivenTheSecondNumberIs(int second)
        {
            _second = second;
        }

        [When("I make the Add Operation")]
        public void WhenIMakeTheAddOperation()
        {
            _result = _addOperation.Do(_first, _second);
        }


        [Then("The result should be {int}")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.Equal(result, _result);
        }
    }
}
