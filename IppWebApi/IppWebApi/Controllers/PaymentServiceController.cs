using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ipp.Recruitment;
using System.Configuration;
using System.Web;
using IPPBusinessLogic;

namespace IppWebApi.Controllers
{
    public class PaymentServiceController : ApiController,IPaymentService
    {
        
        [HttpGet]
        [Route("api/PaymentService/WhatsYourId")]
        public string WhatsYourId()
        {
            var userId = (string)ConfigurationManager.AppSettings["YourId"];
            if (string.IsNullOrEmpty(userId))
            {
                throw new HttpException((int)HttpStatusCode.NotFound, "Your UserID not found");
            }
            return userId;
        }

        [Route("api/PaymentService/IsCardNumberValid")]
        public bool IsCardNumberValid(string cardNumber)
        {
            string errorMessage;
            bool isCardValid = ValidateCard.ValidateCardNumber(cardNumber, out errorMessage);
            if(!isCardValid)
            {
                throw new HttpException((int)HttpStatusCode.ExpectationFailed, errorMessage);
            }
            return isCardValid;
        }

        public bool IsValidPaymentAmount(long amount)
        {
            string errorMessage;
            bool isValidPaymentAmount = ValidatePayment.ValidatePaymentAmount(amount,out errorMessage);
            if(!isValidPaymentAmount)
            {
                throw new HttpException((int)HttpStatusCode.ExpectationFailed, errorMessage);
            }
            return isValidPaymentAmount;
        }

        [Route("api/PaymentService/CanMakePaymentWithCard")]
        public bool CanMakePaymentWithCard(string cardNumber, int expiryMonth, int expiryYear)
        {
            bool canMakePayment = false;
            if (IsCardNumberValid(cardNumber))
            {
                string errorMessage;
                canMakePayment = ValidateCard.ValidateCardExpiry(expiryMonth, expiryYear, out errorMessage);
                if (!canMakePayment)
                {
                    throw new HttpException((int)HttpStatusCode.ExpectationFailed, errorMessage);
                }
            }
            return canMakePayment;
        }
    }
}
