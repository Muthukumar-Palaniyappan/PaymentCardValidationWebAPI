using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Web;
using IPPContracts;
using IPPBusinessLogic;
using IppDataAccess;

namespace IppWebApi.Controllers
{
    public class PaymentServiceController : ApiController,IPaymentService
    {
        //[Dependency]
        public IUserStore _userStore;

        public PaymentServiceController()
        {
            //Dependency Injection & Unit Test Mocking is yet to be implemented. 
            _userStore = new UserIDFileStore();
        }

        [HttpGet]
        [Route("api/PaymentService/WhatsYourId")]
        public string WhatsYourId()
        {
            var userId = _userStore.GetUserID();
            
            if (string.IsNullOrEmpty(userId))
            {
                ///////No Code Coverage ////////////////
                throw new HttpException((int)HttpStatusCode.NotFound, "Your UserID not found");
                ///////No Code Coverage ////////////////
            }

            return userId;
        }

        [HttpPost]
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

        [HttpPost]
        [Route("api/PaymentService/IsValidPaymentAmount")]
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
        [HttpPost]
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
