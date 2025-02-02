using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidation.Services;

namespace CreditCardValidation.Tests
{
    [TestClass]
    public class CreditCardValidatorTests
    {
        [TestMethod]
        public void TestValidVisaCard()
        {
            Assert.IsTrue(CreditCardValidator.Validate("4111111111111111"));
        }

        [TestMethod]
        public void TestValidMastercard()
        {
            Assert.IsTrue(CreditCardValidator.Validate("5105105105105100")); 
        }

        [TestMethod]
        public void TestValidAmexCard()
        {
            Assert.IsTrue(CreditCardValidator.Validate("378282246310005"));
        }

        [TestMethod]
        public void TestValidDiscoverCard()
        {
            Assert.IsTrue(CreditCardValidator.Validate("6011111111111117"));
        }

        [TestMethod]
        public void TestInvalidCard()
        {
            Assert.IsFalse(CreditCardValidator.Validate("1234567890123456"));
        }

        [TestMethod]
        public void TestLuhnCheckValid()
        {
            Assert.IsTrue(CreditCardValidator.Validate("4111111111111111"));  // Valid Luhn
        }

        [TestMethod]
        public void TestLuhnCheckInvalid()
        {
            Assert.IsFalse(CreditCardValidator.Validate("4111111111111121"));  // Invalid Luhn
        }

        [TestMethod]
        public void TestUnknownProvider()
        {
            Assert.AreEqual("Unknown", CreditCardValidator.GetCardProvider("1234567890123456"));
        }
    }
}
