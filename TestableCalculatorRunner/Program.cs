using System;
using CalculatorCore;

namespace TestableCalculatorRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            Console.WriteLine("Please enter a numeric expression to add");
            Console.WriteLine(calculator.Evaluate(Console.ReadLine()).Result);
         }
    }
}
