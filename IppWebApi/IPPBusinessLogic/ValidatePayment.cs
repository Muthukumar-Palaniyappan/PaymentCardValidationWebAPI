using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPPBusinessLogic
{
    public class ValidatePayment
    {
        public static bool ValidatePaymentAmount(long amount,out string errorMessage)
        {
            bool isValidAmount = (amount >= Constants.minAmountValue &&
                                  amount <= Constants.maxAmountValue);
            errorMessage = (!isValidAmount) ? ErrorMessages.InvalidPaymentAmount : string.Empty;
            return isValidAmount;
        }
    }
}
