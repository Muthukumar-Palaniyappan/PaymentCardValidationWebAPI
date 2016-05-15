using Microsoft.VisualStudio.TestTools.UnitTesting;
using IppWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IppWebApi.Controllers.Tests
{
    [TestClass()]
    public class WhatsYourIdTests
    {
        PaymentServiceController controller;
        public WhatsYourIdTests()
        {
            controller = new PaymentServiceController();
        }
       

        [TestMethod()]
        public void WhatsYourIdTest()
        {
            Assert.AreEqual("2a8dec5a-5f70-45a2-9e0b-b14064850de0",
                controller.WhatsYourId());
        }


    }
}