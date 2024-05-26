using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky.NUnitTest
{
    [TestFixture]
    public class GradingCalculatorUnitTest
    {
        private GradingCalculator _gradingCalculator;
        [SetUp]
        public void SetUp()
        {
            _gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void Score_95_Attendance_90_ShouldReturnA()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 90;
            Assert.That(_gradingCalculator.GetGrade(), Is.EqualTo("A"));
        }

        [Test]
        public void Score_85_Attendance_90_ShouldReturnB()
        {
            _gradingCalculator.Score = 85;
            _gradingCalculator.AttendancePercentage = 90;
            Assert.That(_gradingCalculator.GetGrade(), Is.EqualTo("B"));
        }

        [Test]
        public void Score_65_Attendance_90_ShouldReturnC()
        {
            _gradingCalculator.Score = 65;
            _gradingCalculator.AttendancePercentage = 90;
            Assert.That(_gradingCalculator.GetGrade(), Is.EqualTo("C"));
        }

        [Test]
        public void Score_95_Attendance_65_ShouldReturnB()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 65;
            Assert.That(_gradingCalculator.GetGrade(), Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65,55)]
        [TestCase(50, 90)]
        public void Given_Score_And_Attndaces_ShouldReturnF(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;
            Assert.That(_gradingCalculator.GetGrade(), Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GradeCalc_AllGradeLogicalScenario_GradeOutput(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;
            string grade = _gradingCalculator.GetGrade();
            return grade;
        }
    }
}
