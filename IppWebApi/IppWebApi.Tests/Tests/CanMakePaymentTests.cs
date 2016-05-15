using Microsoft.VisualStudio.TestTools.UnitTesting;
using IppWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IppWebApi.Controllers.Tests
{
    [TestClass()]
    public class CanMakePaymentTests
    {
        PaymentServiceController controller;
        public CanMakePaymentTests()
        {
             controller = new PaymentServiceController();
        }

        [TestMethod()]
        public void CanMakePaymentWithCardValidTest()
        {
            Assert.IsTrue(controller.CanMakePaymentWithCard("4095069064525721", 9, 2017));
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void CanMakePaymentWithCardInValidCardTest()
        {
            Assert.IsTrue(controller.CanMakePaymentWithCard("4999969064525721", 9, 2017));
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void CanMakePaymentWithCardInValidMonthTest()
        {
            Assert.IsTrue(controller.CanMakePaymentWithCard("4095069064525721", 149, 2017));
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void CanMakePaymentWithCardInValidYearTest()
        {
            Assert.IsTrue(controller.CanMakePaymentWithCard("4095069064525721", 9, 20147));
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void CanMakePaymentWithCardInValidExpiryTest()
        {
            Assert.IsTrue(controller.CanMakePaymentWithCard("4095069064525721", 8, 2015));
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void CanMakePaymentWithCardCurrentMonthTest()
        {
            Assert.IsTrue(controller.CanMakePaymentWithCard("4095069064525721", 5, 2016));
        }
    }
}