using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorCore.Tests;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {
        private Calculator calc;

        [TestInitialize()]
        public void TestInitialize()
        {
            calc = new Calculator();
        }

        [TestMethod]
        public void AddTwoNumbers()
        {
            EvaluationResult result = calc.Evaluate("6 + 8");
            Assert.AreEqual(14m, result.Result);
        }

        [TestMethod]
        public void AddTwoNumbersFirstErrorMessage()
        {
            EvaluationResult result = calc.Evaluate("x + 8");
            Assert.AreEqual("The first entry was incorrect.", result.ErrorMessage);
        }
        [TestMethod]
        public void AddTwoNumbersSecondErrorMessage()
        {
            EvaluationResult result = calc.Evaluate("8 + z");
            Assert.AreEqual("The second entry was incorrect.", result.ErrorMessage);
        }

        [TestMethod]
        public void SubtractTwoNumbers()
        {
            EvaluationResult result = calc.Evaluate("10 - 2");
            Assert.AreEqual(8m, result.Result);
        }

        [TestMethod]
        public void MultiplyTwoNumbers()
        {
            EvaluationResult result = calc.Evaluate("10 * 2");
            Assert.AreEqual(20m, result.Result);
        }
        [TestMethod]
        public void DivisionTwoNumbers()
        {
            EvaluationResult result = calc.Evaluate("10 / 2");
            Assert.AreEqual(5m, result.Result);
        }

        [TestMethod]
        public void ValidateOperator()
        {
            EvaluationResult result = calc.Evaluate("8 plus z");
            Assert.AreEqual("The operator was incorrect.", result.ErrorMessage);
        }
        [TestMethod]
        public void IncorrectNumberOperators()
        {
            EvaluationResult result = calc.Evaluate("8 + = z");
            Assert.AreEqual("There are an incorrect number of entries.", result.ErrorMessage);
        }
        [TestMethod]
        public void ValidateSingularInputWorks()
        {
            EvaluationResult result = calc.Evaluate("+ 9");
            Assert.AreEqual(9, result.Result);
        }
        [TestMethod]
        public void ValidateRegularHistoryWorks()
        {
            EvaluationResult result = calc.Evaluate("1 + 9");
            Assert.IsTrue(result.History.Contains("1 + 9 = 10"));
        }

        //[TestMethod]
        //public void ValidateSingularHistoryWorks()
        //{
        //    EvaluationResult result = calc.Evaluate("+ 9");
        //    Assert.IsTrue(result.History.Contains("+ 9 = 10"));
        //}
        [TestMethod]
    
        public void ValidateConsoleExit()
        {
            CalcConsole calc = new();
            //calc.RunCalculator();
            //Assert.AreEqual("The operator is incorrect.", result.ErrorMessage);
        }
    }
}
