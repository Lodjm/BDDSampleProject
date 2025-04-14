using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDSampleProject
{
    public class NotAvailableCalculator : ICalculator
    {
        private static string _exception = "Calculator is not available";
        public void AddLeftMember(int leftMember)
        {
            return;
        }

        public void AddRightMember(int rightMember)
        {
            return;
        }

        public int MakeOperation(OperationType operationType)
        {
            throw new Exception(_exception);
        }
    }
}
