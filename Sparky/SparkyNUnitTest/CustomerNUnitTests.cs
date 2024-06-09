using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {

        private Customer customer;

        // SetUp method is used to initialize objects or perform any necessary setup tasks before each test method is executed.
        // It's a way to ensure that the test environment is consistent and ready for each individual test.
        [SetUp]
        public void Setup() 
        {
            customer = new Customer();
        }


        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            customer.GreetAndCombineNames("John", "Smith");

            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, John Smith"));
            Assert.AreEqual(customer.GreetMessage, "Hello, John Smith");
            Assert.That(customer.GreetMessage, Does.Contain("John smith").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
            Assert.That(customer.GreetMessage, Does.EndWith("Smith"));            
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

            /*  Code Below ::
             *  [A-Z]{0}[a-z]+: This part describes the pattern for the first name.
                It allows for an optional uppercase letter (0 or 1) followed by one or more lowercase letters.
            */

            // customer.GreetAndCombineNames("john", "Smith");
            // Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{0}[a-z]+ [A-Z]{1}[a-z]+"));

        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {   
            Assert.IsNull(customer.GreetMessage);
        }


        [Test]
        [TestCase("C101", "Rohit Borse", ExpectedResult = "C101 Rohit Borse")]
        [TestCase("C102", "Paresh Chaudhari", ExpectedResult = "C102 Paresh Chaudhari")]
        public string CustomerIdWithFullName_InputCustIDAndFullName_ReturnCustIdWithFullName(string customerId, string fullName)
        {
            string CustId_fullName = customer.CustomerIdWithFullName(customerId, fullName);
            return CustId_fullName;
        }



        // ---------------- START: Working with Exceptions ----------------
        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull() 
        {
            customer.GreetAndCombineNames("James", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }


        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(
                                    ()=> customer.GreetAndCombineNames("", "Bond"));

            Assert.AreEqual("Empty First Name", exceptionDetails.Message);
        }

        // ---------------- END: Working with Exceptions ----------------


    }
}
