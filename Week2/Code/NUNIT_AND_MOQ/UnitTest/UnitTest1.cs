using System.Runtime.CompilerServices;
using NUnit.Framework.Legacy;
using UnitTest.Calc;
using System;

namespace UnitTestProject
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [Test]
        public void Addition_ReturnsCorrectSum()
        {
            double result = calculator.Addition(4, 5);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void Subtraction_ReturnsCorrectDifference()
        {
            double result = calculator.Subtraction(10, 3);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void Multiplication_ReturnsCorrectProduct()
        {
            double result = calculator.Multiplication(6, 2);
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Division_ReturnsCorrectQuotient()
        {
            double result = calculator.Division(10, 2);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Division_ByZero_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => calculator.Division(10, 0));
        }

        [Test]
        public void AllClear_ResetsResultToZero()
        {
            calculator.Addition(5, 5);
            calculator.AllClear();
            Assert.AreEqual(0, calculator.GetResult);
        }

        [TearDown]
        public void Cleanup()
        {
            calculator = null;
        }
    }
}
