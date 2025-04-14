using BDDSampleProject.Operations.Interfaces;

namespace BDDSampleProject
{
    public class Calculator : ICalculator
    {
        private readonly IEnumerable<IOperation> _operations;
        private int _leftMember;
        private int _rightMember;

        public Calculator(IEnumerable<IOperation> operations)
        {
            _operations = operations;
        }

        public void AddLeftMember(int leftMember)
        {
            _leftMember = leftMember;
        }

        public void AddRightMember(int rightMember)
        {
            _rightMember = rightMember;
        }

        public int MakeOperation(OperationType operationType)
        {
            var operation = _operations.SingleOrDefault(o => o.OperationType == operationType);
            if (operation == null)
            {
           
                throw new Exception($"Operation : {operationType.ToString()} not found");
            }

            int result = 0;
            try
            {
                result = operation.Do(_leftMember, _rightMember);
            }
            catch
            {
                throw;
            }
            finally
            {
                _leftMember = 0;
                _rightMember = 0;
            }

            return result;
        }
    }
}
