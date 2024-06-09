using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {

        private GradingCalculator gradingCalculator { get; set; }

        [SetUp]
        public void SetUp()
        {
            gradingCalculator = new GradingCalculator();
        }


        [Test]
        public void GradeCalc_InputScore95Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;
            string result = gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("A"));
        }


        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GradeCalc_InputScoreAndAttendance_ReturnGrade(int _score, int _attendance)
        {
            gradingCalculator.Score = _score;
            gradingCalculator.AttendancePercentage = _attendance;
            string result = gradingCalculator.GetGrade();

            return result;
        }

    }
}
