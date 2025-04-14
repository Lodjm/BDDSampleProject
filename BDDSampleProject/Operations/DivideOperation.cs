using BDDSampleProject.Operations.Interfaces;

namespace BDDSampleProject.Operations
{
    public class DivideOperation : IDivideOperation
    {
        public OperationType OperationType => OperationType.Divide;
        public int Do(int leftmember, int rightmember)
        {
            return leftmember / rightmember;
        }
    }
}
