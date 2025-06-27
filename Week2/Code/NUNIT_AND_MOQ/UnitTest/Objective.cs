/*
 1. What is Unit Testing? How is it different from Functional Testing?
ANS-Unit testing is testing the smallest part of code, like a function or method,
to check if it works correctly. It's usually done by developers.
Functional testing checks if a full feature works properly from the user's perspective.
It's usually done by testers or QA. Unit testing is low-level, functional testing is high-level.


2. What is meant by "Smallest unit to test" and "Mocking dependencies"?
ANS- "Smallest unit to test" means testing one function or method at a time.
"Mocking dependencies" means creating fake versions of external services like databases or APIs
so the test focuses only on the logic inside that function.


 3. What are the types of testing?
 ANS- Unit Testing: Testing individual functions or methods.
 - Functional Testing: Testing if a complete feature behaves as expected. - Automated Testing: Running tests automatically using tools instead of manually.
 - Performance Testing: Testing how fast, stable, and scalable the application is under load.


 4. What are the benefits of Automated Testing?
ANS- Saves time by running tests automatically.
 - Catches bugs early before they reach production.
 - Increases developer confidence that the code works.
 - Makes it easier to test frequently during development.


 5. What is loosely coupled and testable design?
 ANS-Loosely coupled design means parts of the code are not tightly dependent on each other.
 This makes it easier to test, because we can replace one part with a mock or fake version.

 Example of tightly coupled (not testable):
 class ReportGenerator {
    Database db = new Database(); // hardcoded dependency
 }

 Example of loosely coupled (testable):
 class ReportGenerator {
     IDatabase db;
     public ReportGenerator(IDatabase database) {
        db = database; // inject dependency
     }
 }


 6. How to write your first unit test for a calculator’s addition function?

ANS- Main class:
public class Calculator {
  public int Add(int a, int b) => a + b;
}

 Test class using NUnit:
using NUnit.Framework;

[TestFixture]
public class CalculatorTests {

    [Test]
    public void Add_TwoNumbers_ReturnsSum() {
        Calculator calc = new Calculator();
        int result = calc.Add(2, 3);
        Assert.AreEqual(5, result);
    }
}


 7. What is the need for [SetUp], [TearDown] & [Ignore] in tests?

ANS- [SetUp] runs before every test method. Used to create objects.
 [TearDown] runs after every test. Used to clean up resources.
 [Ignore] tells the test runner to skip the test.

 Example:
[TestFixture]
public class MyTests {
    Calculator calc;

    [SetUp]
    public void Init() {
        calc = new Calculator(); // runs before each test
    }

    [TearDown]
    public void Cleanup() {
        calc = null; // runs after each test
    }

    [Test]
    public void Add_Test() {
        Assert.AreEqual(5, calc.Add(2, 3));
    }

    [Test, Ignore("This test is skipped")]
    public void Subtract_Test() {
        // This test will not run
    }
}


 8. What is the benefit of writing parameterized test cases?

ANS- Parameterized tests let us run the same test multiple times with different inputs.
 This avoids writing the same test again and again.

 Example:
[TestFixture]
public class CalculatorParameterizedTests {

    [TestCase(2, 3, 5)]
    [TestCase(0, 0, 0)]
    [TestCase(-1, 1, 0)]
    public void Add_Tests(int a, int b, int expected) {
        Calculator calc = new Calculator();
        Assert.AreEqual(expected, calc.Add(a, b));
    }
}
*/