using BDDSampleProject.Operations;
using BDDSampleProject.Operations.Interfaces;

namespace BDDSampleProject.Acceptance.Tests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private ICalculator _calculator;
        private readonly ScenarioContext _context;
        private int _result = -1;


        private ICalculator GetCalculator()
        {
            if (_context.ContainsKey("Calculator"))
            {
                return _context.Get<ICalculator>("Calculator");
            }
            return _calculator;
        }
        public CalculatorStepDefinitions(ICalculator calculator, ScenarioContext context)
        {
            _calculator = calculator;
            _context = context;
        }

        [Given("The first number is {int}")]
        public void GivenTheFirstNumberIs(int first)
        {
            GetCalculator().AddLeftMember(first);
        }

        [Given("The second number is {int}")]
        public void GivenTheSecondNumberIs(int second)
        {
            GetCalculator().AddRightMember(second);
        }

        [When("I make the Operation {string}")]
        public void WhenIMakeTheAddOperation(string operation)
        {
            var operationType = Enum.Parse<OperationType>(operation);
            try
            {
                _result = GetCalculator().MakeOperation(operationType);
            }
            catch (Exception e)
            {
                _context.Add("Exception", e);
            }
        }

        [Given("{string} load the calculator")]
        public void GivenLoadTheCalculator(string personna)
        {
            if (string.IsNullOrEmpty(personna))
                return;
            if (personna == "NoOne")
            {
                _calculator = new NotAvailableCalculator();
            }
            else if (personna == "Bob")
            {
                _calculator = new Calculator(new List<IOperation>());
            }
        }


        [Then("The result should be {int}")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.Equal(result, _result);
        }

        public class DummyOperation : IOperation
        {
            private readonly IOperation _realOperation;
            public OperationType OperationType { get; }

            public DummyOperation(OperationType operationType, IOperation realOperation)
            {
                OperationType = operationType;
                _realOperation = realOperation;
            }

            public int Do(int leftmember, int rightmember)
            {
                return _realOperation.Do(leftmember, rightmember);
            }
        }


        [Given("A DivideOperation with Type {string}")]
        public void GivenADivideOperationWithType(string operationType)
        {
            AddOperationInContext(operationType, new DivideOperation());
        }

        [Given("A MultiplyOperation with Type {string}")]
        public void GivenAMultiplyOperationWithType(string operationType)
        {
            AddOperationInContext(operationType, new MultiplyOperation());
        }

        [Given("A AddOperation with Type {string}")]
        public void GivenAAddOperationWithType(string operationType)
        {
            AddOperationInContext(operationType, new AddOperation());
        }

        [Given("A SubstractOperation with Type {string}")]
        public void GivenASubstractOperationWithType(string operationType)
        {
            AddOperationInContext(operationType, new SubstractOperation());
        }
        private void AddOperationInContext(string operationType, IOperation realOperation)
        {
            var operations = new List<IOperation>();
            if (_context.ContainsKey("Operations"))
            {
                operations = _context.Get<List<IOperation>>("Operations");
            }
            operations.Add(new DummyOperation(Enum.Parse<OperationType>(operationType), realOperation));

            if (_context.ContainsKey("Operations"))
            {
                _context.Remove("Operations");
            }
            _context.Add("Operations", operations);
        }

        [Given("A Calculator with operations defined")]
        public void GivenACalculatorWithOperationsDefined()
        {
            var operations = new List<IOperation>();
            if (_context.ContainsKey("Operations"))
            {
                operations = _context.Get<List<IOperation>>("Operations");
            }
            var calculator = new Calculator(operations);
            if (_context.ContainsKey("Calculator"))
            {
                _context.Remove("Calculator");
            }
            _context.Add("Calculator", calculator);
        }

    }
}
