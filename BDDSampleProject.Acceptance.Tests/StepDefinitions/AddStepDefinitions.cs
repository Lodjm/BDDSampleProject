using BDDSampleProject.Operations.Interfaces;

namespace BDDSampleProject.Acceptance.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Add")]
    public class AddStepDefinitions
    {
        private readonly IAddOperation _addOperation;
        private int _result = -1;
        private int _leftMember;
        private int _rightMember;

        public AddStepDefinitions(IAddOperation addOperation)
        {
            _addOperation = addOperation;
        }

        [Given("The first number is {int}")]
        public void GivenTheFirstNumberIs(int leftMember)
        {
            _leftMember = leftMember;
        }

        [Given("The second number is {int}")]
        public void GivenTheSecondNumberIs(int rightMember)
        {
            _rightMember = rightMember;
        }

        [When("I make the Add Operation")]
        public void WhenIMakeTheAddOperation()
        {
            _result = _addOperation.Do(_leftMember, _rightMember);
        }


        [Then("The result should be {int}")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.Equal(result, _result);
        }

        [Then("The descriptive result shoud be")]
        public void ThenTheDescriptiveResultShoudBe(DataTable dataTable)
        {
            Assert.Equal(int.Parse(dataTable.Rows[0][0]), _leftMember);
            Assert.Equal(int.Parse(dataTable.Rows[0]["Right Member"]), _rightMember);
            Assert.Equal(dataTable.Rows.First()[2], "Add");
            Assert.Equal(int.Parse(dataTable.Rows.First().Last().Value), _result);
        }

    }
}
