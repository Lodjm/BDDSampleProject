namespace BDDSampleProject.Operations.Interfaces
{
    public interface IOperation
    {
        public OperationType OperationType { get; }
        int Do(int leftmember, int rightmember);
    }
}