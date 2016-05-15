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
    public class IsValidAmountTests
    {
        PaymentServiceController controller;
        public IsValidAmountTests()
        {
            controller = new PaymentServiceController();
        }

        [TestMethod()]
        public void IsValidAmountFunctionalTest()
        {
            Assert.IsTrue(controller.IsValidPaymentAmount(1000));
        }
        [TestMethod()]
        public void IsValidAmountBoundaryTest()
        {
            Assert.IsTrue(controller.IsValidPaymentAmount(99));
            Assert.IsTrue(controller.IsValidPaymentAmount(99999999));
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void IsValidAmountOutOfBoundaryTest1()
        {
            Assert.IsTrue(controller.IsValidPaymentAmount(1));
            
        }
        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void IsValidAmountOutOfBoundaryTest2()
        {
            Assert.IsTrue(controller.IsValidPaymentAmount(100000000));

        }
        
      
    }
}