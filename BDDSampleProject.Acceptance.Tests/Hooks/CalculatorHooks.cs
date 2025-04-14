using BDDSampleProject.Operations;
using BDDSampleProject.Operations.Interfaces;

namespace BDDSampleProject.Acceptance.Tests.Hooks
{
    [Binding]
    public class CalculatorHooks
    {
        private readonly ScenarioContext _context;

        public CalculatorHooks(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario("@Calculator")]
        public void SetupCalculator(ITestRunnerManager testRunnerManager)
        {
            var runner = testRunnerManager.GetTestRunner();
            var context = runner.TestThreadContext;
            var operations = context.TestThreadContainer.ResolveAll<IOperation>();

            var calculator = new Calculator(operations);
            _context.Add("Calculator", calculator);
        }

        [BeforeScenario("@AddCalculator")]
        public void SetupAddCalculator()
        {
            IEnumerable<IOperation> operations = new List<IOperation>() { new AddOperation() };
            var calculator = new Calculator(operations);
            _context.Add("Calculator", calculator);
        }

        [BeforeScenario("@BadCalculator")]
        public void SetupBaddCalculator()
        {
            IEnumerable<IOperation> operations = new List<IOperation>();
            var calculator = new Calculator(operations);
            _context.Add("Calculator", calculator);
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            if (_context.ContainsKey("Calculator"))
            {
                _context.Remove("Calculator");
            }
        }

    }
}
