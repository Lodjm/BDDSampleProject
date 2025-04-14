using BDDSampleProject.Operations.Interfaces;

namespace BDDSampleProject.Operations
{
    public class AddOperation : IAddOperation
    {
        public OperationType OperationType => OperationType.Add;

        public int Do(int leftmember, int rightmember)
        {
            return leftmember + rightmember;
        }
    }
}
