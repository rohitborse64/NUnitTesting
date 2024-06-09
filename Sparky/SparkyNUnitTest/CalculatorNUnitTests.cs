using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int actualResult = calculator.AddNumbers(100, 200);

            //Assert
            Assert.AreEqual(300, actualResult);
        }

        [Test]
        public void IsOddNumber_InputEvenNumber_ReturnFalse()
        {
            //Arrange
            Calculator calculator = new();

            //Act
            bool isOdd = calculator.isOddNumber(10);    // Even number passing

            //Assert
            Assert.That(isOdd,Is.EqualTo(false));
            // Assert.IsFalse(isOdd);
            
        }



        // Testing multiple values by passing argument parameters
        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int num)
        {
            //Arrange
            Calculator calculator = new();

            //Act
            bool isOdd = calculator.isOddNumber(num);  // Odd number passing            

            //Assert
            //Assert.That(isOdd, Is.EqualTo(true));
            Assert.IsTrue(isOdd);

        }


        // Combine unit test with expected result
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddNumber_InputOddNumber_ReturnTrueIfOdd(int num)
        {
            Calculator calculator = new();
            return calculator.isOddNumber(num);           
        }

        [Test]
        [TestCase(10.5, 10.4, 20.9)]      // Correct result: 10.5 + 10.4 = 20.9
        [TestCase(10.65, 10.50, 21.15)]   // Correct result: 10.65 + 10.50 = 21.15
        [TestCase(5.50, 15.60, 21.10)]    // Correct result: 5.50 + 15.60 = 21.10
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double num1, double num2, double expectedResult)
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            double actualResult = calculator.AddNumbersDouble(num1, num2);

            /*
                The delta parameter (last param added) in the Assert.AreEqual method specifies the maximum 
                allowable difference between the expected and actual values for the assertion to pass.
               
                For example, if the expected result is 20.9, the test will pass if the actual result is 
                any value between 20.89 and 20.91 (inclusive), because the absolute difference between
                20.9 and any value within this range is less than or equal to 0.01.
             */

            //Assert
            Assert.AreEqual(expectedResult, actualResult, 0.01); // Tolerance of 0.01

        }





    }
}
