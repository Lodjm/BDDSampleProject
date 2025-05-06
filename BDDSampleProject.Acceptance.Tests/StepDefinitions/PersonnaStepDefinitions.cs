using BDDSampleProject.Operations.Interfaces;

namespace BDDSampleProject.Acceptance.Tests.StepDefinitions
{
    [Binding]
    public class PersonnaStepDefinitions
    {

        private readonly ScenarioContext _context;

        public PersonnaStepDefinitions(ScenarioContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Load the calculator for a personna
        /// </summary>
        /// <param name="personna">Name of a personna</param>
        [Given("{string} load the calculator")]
        public void GivenLoadTheCalculator(string personna)
        {
            if (string.IsNullOrEmpty(personna))
                return;
            ICalculator calculator = null;
            if (personna == "NoOne")
            {
                calculator = new NotAvailableCalculator();
            }
            else if (personna == "Bob")
            {
                calculator = new Calculator(new List<IOperation>());
            }

            if (_context.ContainsKey("Calculator"))
            {
                _context.Remove("Calculator");
            }
            _context.Set<ICalculator>(calculator, "Calculator");

        }
    }
}
