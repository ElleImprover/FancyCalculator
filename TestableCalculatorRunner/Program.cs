using System;
using CalculatorCore;

namespace TestableCalculatorRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            Console.WriteLine("Please enter a numeric expression with two numbers.");
            var result = calculator.Evaluate(Console.ReadLine());
            if (!String.IsNullOrWhiteSpace(result.ErrorMessage))  {
                Console.ResetColor();
                Console.WriteLine($"\u001b[31m{ result.ErrorMessage}\u001b[0m"); 
            }
            else { Console.WriteLine(result.Result); 
            }
         }
    }
}
