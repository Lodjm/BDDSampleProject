using BDDSampleProject.Operations.Interfaces;

namespace BDDSampleProject.Operations
{
    public class MultiplyOperation : IMultiplyOperation
    {
        public OperationType OperationType => OperationType.Multiply;
        public int Do(int leftmember, int rightmember)
        {
            return leftmember * rightmember;
        }
    }
}
