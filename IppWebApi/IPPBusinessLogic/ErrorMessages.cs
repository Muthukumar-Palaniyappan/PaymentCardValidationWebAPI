using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPPBusinessLogic
{
    //Error Messages are defined in a way to help users for format issues due to careless entries. 
    //Upon correct formats, errors are displayed in generalised format to avoid hinting.
    class ErrorMessages
    {
        public const string CardNumberNotFound = "The supplied card number is null or empty. Please check.";
        public const string InvalidDigits = "The supplied card number does not have 16 digits. Please check.";
        public const string InvalidCardNumber = "The supplied card number is invalid. Please check.";
        public const string InvalidExpiryDateFormat = "The supplied expiry date is not in a valid format. Please check.";
        public const string InvalidExpiryDate = "The supplied expiry date is not valid. Please check.";
        public const string InvalidPaymentAmount = "The Specified amount is invlaid. Please Check.";
    }
   
}
