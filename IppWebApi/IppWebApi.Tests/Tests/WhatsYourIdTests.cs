using Microsoft.VisualStudio.TestTools.UnitTesting;
using IppWebApi.Controllers;
using IppDataAccess;
using IPPContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Rhino.Mocks;
using System.Web;

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
            IUserStore _userStoreMock = MockRepository.GenerateMock<IUserStore>();
            _userStoreMock.Stub(dao => dao.GetUserID()).Return("2a8dec5a-5f70-45a2-9e0b-b14064850de0");
            controller._userStore = _userStoreMock;
            Assert.AreEqual("2a8dec5a-5f70-45a2-9e0b-b14064850de0",
                controller.WhatsYourId());
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void WhatsYourIdEmpty()
        {
            IUserStore _userStoreMock = MockRepository.GenerateMock<IUserStore>();
            _userStoreMock.Stub(dao => dao.GetUserID()).Return(string.Empty);
            controller._userStore = _userStoreMock;
            Assert.AreEqual("2a8dec5a-5f70-45a2-9e0b-b14064850de0",
                controller.WhatsYourId());
        }

        [TestMethod()]
        [ExpectedException(typeof(HttpException))]
        public void WhatsYourIdInvalid()
        {
            IUserStore _userStoreMock = MockRepository.GenerateMock<IUserStore>();
            _userStoreMock.Stub(dao => dao.GetUserID()).Return(string.Empty);
            controller._userStore = _userStoreMock;
            Assert.AreEqual("99999999-5f70-45a2-9e0b-b14064850de0",
                controller.WhatsYourId());
        }
    }
}