using BDDSampleProject.Operations.Interfaces;

namespace BDDSampleProject.Operations
{
    public class SubstractOperation : ISubstractOperation
    {
        public OperationType OperationType => OperationType.Substract;
        public int Do(int leftmember, int rightmember)
        {
            return leftmember - rightmember;
        }
    }
}
