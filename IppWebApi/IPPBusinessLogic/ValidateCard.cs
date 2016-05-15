using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPPBusinessLogic
{
    public class ValidateCard
    {
        public static bool ValidateCardNumber(string cardNumber, out string errorMessage)
        {
            bool isCardValid = false;
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(cardNumber))
            {
                errorMessage = ErrorMessages.CardNumberNotFound;
            }
            else
            {
                if (cardNumber.Trim().Length != Constants.ValidNumberOfDigits)
                {
                    errorMessage = ErrorMessages.InvalidDigits;
                }
                var cardDigits = GetCardDigits(cardNumber);
                if (cardDigits != null)
                {
                    if (LuhnValidation.Mod10Check(cardDigits))
                    {
                        isCardValid = true;
                    }
                    else
                    {
                        errorMessage = ErrorMessages.InvalidCardNumber;
                    }
                }
                else
                {
                    errorMessage = ErrorMessages.InvalidCardNumber;
                }
            }
            return isCardValid;
        }
        public static bool ValidateCardExpiry(int expiringMonth, int expiringYear, out string errorMessage)
        {
            bool isExpiryValid = true;
            errorMessage = string.Empty;
            try
            {
                int monthValidationAutoDate = 01;
                DateTime expiryDate = new DateTime(expiringYear, expiringMonth, monthValidationAutoDate);
                int differenceInDays = (expiryDate - DateTime.Now).Days;
                if (differenceInDays <= 0)
                {
                    isExpiryValid = false;
                    errorMessage = ErrorMessages.InvalidExpiryDate;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                isExpiryValid = false;
                errorMessage = ErrorMessages.InvalidExpiryDateFormat;
            }

            return isExpiryValid;
        }
        private static int[] GetCardDigits(string cardNumber)
        {
            int[] cardDigits = new int[Constants.ValidNumberOfDigits];
            var cardArray = cardNumber.ToCharArray();
            if (cardArray.Length == Constants.ValidNumberOfDigits)
            {
                int index = 0;
                foreach (char digit in cardArray)
                {
                    int digitInt;
                    if (int.TryParse(digit.ToString(), out digitInt))
                    {
                        cardDigits[index++] = digitInt;
                    }
                    else
                    {
                        cardDigits = null;
                        break;
                    }
                }
            }

            return cardDigits;

        }
    }
}
