using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPPBusinessLogic
{
    public class ValidatePayment
    {
        public static bool ValidatePaymentAmount(long amount)
        {
            bool isValidAmount = (amount >= Constants.minAmountValue &&
                                  amount <= Constants.maxAmountValue);
            return isValidAmount;
        }
    }
}
