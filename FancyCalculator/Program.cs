using System;
using System.Collections.Generic;
using FancyCalculator;
namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Input input = new Input();
            decimal input1 = Decimal.Zero;
            decimal input2 = Decimal.Zero;
            string strInput1 = String.Empty;
            List<string> opList=new List<string>{ "+","-","*","/"};
            bool success = false;

            bool done = false;
            while (!done)
            {
                Console.WriteLine("Please enter a math equation with two values and a space between each value, or x to exit.");
                strInput1 = Console.ReadLine();
                if (!strInput1.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                   var inputArray= strInput1.Trim().Split(" ");
                    if (inputArray.Length != 3)
                    {
                    
                     Console.WriteLine("Your entry was invalid.\nPlease enter a math equation with two numeric values.");


                    }
                    if (!opList.Contains(inputArray[1]))
                    {
                        Console.WriteLine("Your entry was invalid.\nPlease enter a math equation with '+','-','*','/'.");

                    }
                    else if(inputArray.Length == 3 || opList.Contains(inputArray[1])) {
                        success = Decimal.TryParse(inputArray[0], out input1);
                        if (success)
                        {
                            success = Decimal.TryParse(inputArray[2], out input2);
                            if (success)
                            {
                                string op = inputArray[1];
                                switch (op)
                                { 
                                case "+": 
                                    Console.WriteLine("The sum is: {0}", input1 + input2);
                                    break;

                                 case "-": 
                                    Console.WriteLine("The result is: {0}", input1 - input2);
                                     break;

                                 case "*": 
                                     Console.WriteLine("The product is: {0}", input1 * input2);
                                     break;

                                 case "/":
                                     Console.WriteLine("The quotient is: {0}", input1 / input2);
                                     break;
                                } 
                            }
                        }
                        if (!success)
                        {
                        Console.WriteLine("Your entry was invalid.\nPlease enter a math equation with two numeric values.");

                        }

                    }

                }
                else
                {
                    done = true;
                }
            }

        }
    }
}
