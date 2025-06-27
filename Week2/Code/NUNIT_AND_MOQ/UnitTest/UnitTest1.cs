using System.Runtime.CompilerServices;
using NUnit.Framework.Legacy;
using UnitTest.Calc;

[TestFixture]
public class Tests
{

    Calculator calc;
    [SetUp]
    public void Setup()
    {
        calc = new Calculator();
    }

    [Test]
    public void CalculatorTests()
    {
        int a = 5;
        int b = 23;
        int result = calc.Add(a, b);
        ClassicAssert.AreEqual(28, result);
    }

    [TearDown]
    public void TearDown()
    {
        calc=null;
    }
}


