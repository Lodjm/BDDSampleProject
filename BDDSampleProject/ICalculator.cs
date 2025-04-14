namespace BDDSampleProject
{
    public interface ICalculator
    {
        void AddLeftMember(int leftMember);
        void AddRightMember(int rightMember);
        int MakeOperation(OperationType operationType);
    }
}