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
    public class IsCardNumberValidTests
    {
        PaymentServiceController controller;
        public IsCardNumberValidTests()
        {
            controller = new PaymentServiceController();
        }

        [TestMethod()]
        public void IsCardNumberValidTest()
        {
            //CC Number generated from http://bradconte.com/cc_generator
            Assert.IsTrue(controller.IsCardNumberValid("4095069064525721"));
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void IsCardNumberValidEmptyTest()
        {
            Assert.IsTrue(controller.IsCardNumberValid(string.Empty));
        }
        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void IsCardNumberValidInvalidTest()
        {
            Assert.IsTrue(controller.IsCardNumberValid("4193069074525721"));
        }
        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void IsCardNumberValidInvalidFormatTest()
        {
            Assert.IsTrue(controller.IsCardNumberValid("41930XXYZ4525721"));
        }
    }
}