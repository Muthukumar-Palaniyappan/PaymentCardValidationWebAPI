using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPPBusinessLogic
{
    public class LuhnValidation
    {
        
        public static bool Mod10Check(int[] cardDigits)
        {
            bool isCardValid = false;
            if (cardDigits != null && cardDigits.Length == Constants.ValidNumberOfDigits)
            {
                int checkDigitValue = cardDigits[Constants.ValidNumberOfDigits - 1];
                var checkSum = GenerateCheckSum(cardDigits);
                int checkDigitCalcValue = GetCheckDigitCalcValue(checkSum);
                if (checkDigitValue == checkDigitCalcValue)
                {
                    isCardValid = true;
                }
            }
            return isCardValid;
        }

        private static int GetCheckDigitCalcValue(int checkSum)
        {
            return checkSum * Constants.CheckSumMultiplicant % Constants.ModByNumber;
        }

        private static int GenerateCheckSum(int[] cardDigits)
        {
            int checkSum = 0;
            int revIndex = 2;
            for (int index = Constants.ValidNumberOfDigits - 2; index >= 0; index--)
            {
                int value = cardDigits[index];
                if (isEvenNumber(revIndex++))
                {
                    value *= 2;
                    value = (value > Constants.digitMax) ? value - Constants.digitMax : value;
                }
                checkSum += value;
            }
            return checkSum;
        }
        private static bool isEvenNumber(int number)
        {
            return number % 2 == 0;
        }

    }
}
