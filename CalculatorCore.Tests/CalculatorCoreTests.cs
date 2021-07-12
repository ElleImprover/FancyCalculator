using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorCore.Tests;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {
        [TestMethod]
        public void AddTwoNumbers()
        {
            var calc = new Calculator();
            EvaluationResult result = calc.Evaluate("6 + 8");
            Assert.AreEqual(15m, result.Result);
        }

        [TestMethod]
        public void AddTwoNumbersFirstErrorMessage()
        {
            var calc = new Calculator();
            EvaluationResult result = calc.Evaluate("x + 8");
            Assert.AreEqual("The first entry was incorrect.", result.ErrorMessage);
        }
        [TestMethod]
        public void AddTwoNumbersSecondErrorMessage()
        {
            var calc = new Calculator();
            EvaluationResult result = calc.Evaluate("8 + z");
            Assert.AreEqual("The second entry was incorrect.", result.ErrorMessage);
        }

        [TestMethod]
        public void SubtractTwoNumbers()
        {
            var calc = new Calculator();
            EvaluationResult result = calc.Evaluate("10 - 2");
            Assert.AreEqual(8m, result.Result);
        }


    }
}
