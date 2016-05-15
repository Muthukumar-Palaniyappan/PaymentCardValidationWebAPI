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
        // GET: api/PaymentService
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PaymentService/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PaymentService
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PaymentService/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PaymentService/5
        public void Delete(int id)
        {
        }
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
            throw new NotImplementedException();
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
