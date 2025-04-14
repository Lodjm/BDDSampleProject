namespace BDDSampleProject.Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void Constructor_Shouldnt_Throw()
        {
            var calculator = new CalculatorTest();
            Assert.NotNull(calculator);
        }
    }
}