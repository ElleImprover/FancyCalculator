using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
   public class CalcConsole
    {
        public void RunCalculator()
        {

            var calculator = new Calculator();
            bool done = false;

            Console.WriteLine("Please enter a numeric expression with two numbers or type x to exit.");
            var input = Console.ReadLine();
            if (input.Contains("x"))
            {
                done = true;
            }
            while (!done)
            {
                var result = calculator.Evaluate(input);
                if (!String.IsNullOrWhiteSpace(result.ErrorMessage))
                {
                    Console.ResetColor();
                    Console.WriteLine($"\u001b[31m{ result.ErrorMessage}\u001b[0m");
                }
                else
                {
                    Console.WriteLine(result.Result);
                }
            }

        }
    }
}
