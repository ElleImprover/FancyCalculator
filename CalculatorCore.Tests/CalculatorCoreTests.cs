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
    }
}
