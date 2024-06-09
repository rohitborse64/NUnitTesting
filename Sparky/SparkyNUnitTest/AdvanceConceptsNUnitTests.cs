using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class AdvanceConceptsNUnitTests
    {
        private AdvanceConcepts _advanceConcepts;

        [SetUp]
        public void Setup() 
        {
            _advanceConcepts = new AdvanceConcepts();
        }


        // Collections Helper Methods
        [Test]
        public void OddRanger_InputMaxMin_ReturnsValidOddNumberRange()
        {
            List<int> expectedOddRange = new List<int>() { 5, 7, 9 };   // 5-10

            List<int> result = _advanceConcepts.GetOddRange(5, 10);

            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            Assert.That(result, Does.Contain(7));
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);        // Assert.That(result, Is.Ordered.Descending);
            Assert.That(result, Is.Unique);

            // Alternates methods to check
            Assert.AreEqual(expectedOddRange, result);
            Assert.Contains(7, result); 
        }


        // Range Assert
        [Test]
        public void DiscountCheck_DefaultObject_ReturnsDiscountInRange() 
        {
            int result = _advanceConcepts.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }


        // Multiple Assert
        // For many assert calls, In case any assert condition fails it still continuous for next calls and gives sequence wise explanation
        [Test]
        public void UseOfMultipleAssert_OddRanger_InputMaxMin_ReturnsValidOddNumberRange()
        {
            List<int> expectedOddRange = new List<int>() { 5, 7, 9 };   // 5-10

            List<int> result = _advanceConcepts.GetOddRange(5, 10);

            Assert.Multiple(() =>
            {
                // Pass cases
                Assert.That(result, Does.Contain(7));
                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result, Has.No.Member(6));

                // Fail Cases, To check use of Multiple Assert
                //Assert.That(result, Does.Contain(8));
                //Assert.That(result.Count, Is.EqualTo(5));
                //Assert.That(result, Has.No.Member(7));
            });
        }


        // ---------------- Working with Exceptions ----------------
        [Test]
        public void FullNameChecker_EmptyFirstName_ThrowsException() 
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(()=> _advanceConcepts.GetFullName("", "Bond"));

            Assert.AreEqual("Empty First Name", exceptionDetails.Message);

            // Alternate
            Assert.That(() => _advanceConcepts.GetFullName("", "Bond"), Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));


            // Below code for check just Exceptions without Message
            Assert.Throws<ArgumentException>(() => _advanceConcepts.GetFullName("", "Bond"));
            Assert.That(() => _advanceConcepts.GetFullName("", "Bond"), Throws.ArgumentException);
        }


        // use of Inheritance
        [Test]
        public void CustomerType_CreateCustomerLessThan100Order_ReturnBasicCustomer() 
        {
            _advanceConcepts.OrderTotal = 50;
            Assert.That(_advanceConcepts.GetCustomerDetails(),Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerMoreThan100Order_ReturnPlatinumCustomer()
        {
            _advanceConcepts.OrderTotal = 150;
            Assert.That(_advanceConcepts.GetCustomerDetails(), Is.TypeOf<PlatinumCustomer>());
        }


    }
}
