using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
   public class CalcConsole
    {
        public void RunCalculator()  {

            decimal decResult = 0m;
            var calculator = new Calculator();
            bool done = false;

            while (!done) 
            {
            Console.WriteLine("Please enter a numeric expression or type x to exit.");
            var input = Console.ReadLine();
                if (input.Contains("x")) {
                    done = true;
                }
                else {
                    var result = calculator.Evaluate(input,default ,decResult);
                    decResult = result.Result;
                    if (!String.IsNullOrWhiteSpace(result.ErrorMessage)) {
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
}
