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
            decimal result = Decimal.Zero;

            string strInput1 = String.Empty;

            List<string> opList = new List<string> { "+", "-", "*", "/" };
            List<string> historyList = new List<string>();

            bool success = false;

            bool done = false;
            while (!done)
            {
                Console.WriteLine("Please enter a math equation with two values and a space between each value, type history to view previous operations, or x to exit.");
                strInput1 = Console.ReadLine().Trim();
                if (!strInput1.Equals("x", StringComparison.OrdinalIgnoreCase)&& !strInput1.Contains("history", StringComparison.OrdinalIgnoreCase))
                {
                    var inputArray = strInput1.Trim().Split(" ");

                    if (inputArray.Length < 2 || inputArray.Length > 3)
                    { 
                        Console.WriteLine("Your entry was invalid.\nPlease enter a math equation with two numeric values."); 
                    }
                    if (inputArray.Length == 2)
                    {
                        if (!opList.Contains(inputArray[0]))
                        {
                            Console.WriteLine("Your entry was invalid.\nPlease enter a math equation with '+','-','*','/'.");
                        }
                    }

                    if (inputArray.Length == 3 && opList.Contains(inputArray[1]))
                    {
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
                                        result = input1 + input2;
                                        Console.WriteLine("The sum is: {0}", result);
                                        break;

                                    case "-":
                                        result = input1 - input2;

                                        Console.WriteLine("The result is: {0}", result);
                                        break;

                                    case "*":
                                        result = input1 * input2;
                                        Console.WriteLine("The product is: {0}", result);
                                        break;

                                    case "/":
                                        result = input1 / input2;
                                        Console.WriteLine("The quotient is: {0}", result);
                                        break;
                                }
                                //var histStringOG = $"{strInput1} ";
                                //var oGLength = histStringOG.Length;
                                //var length = oGLength - 20;
                                //var inpLength = result.ToString().Length;
                                //length = 20 - oGLength + inpLength;
                                //var formatedResult = String.Format("{0," + length + "}", "= " + result);
                                //var histString = $"{strInput1} {formatedResult}";

                                historyList.Add(FormatForConsole1(result, strInput1));
                            }
                        }
                    }
                    else if (inputArray.Length == 2 && opList.Contains(inputArray[0]))
                    {
                        decimal ogResult;
                        success = Decimal.TryParse(inputArray[1], out input2);
                        if (success)
                        {
                            string op = inputArray[0];
                            ogResult = result;
                            switch (op)  {
                                case "+":
                                    result += input2;
                                    Console.WriteLine("The sum is: {0}", result);
                                    break;

                                case "-":
                                    result -= input2;
                                    Console.WriteLine("The result is: {0}", result);
                                    break;

                                case "*":
                                    result *= input2;
                                    Console.WriteLine("The product is: {0}", result);
                                    break;

                                case "/":
                                    result /= input2;
                                    Console.WriteLine("The quotient is: {0}", result);
                                    break;

                            }

                            //var histStringOG = $"_{ogResult}_ {strInput1} ";//ED - use the string formating here and concatenate them.
                            //var oGLength = histStringOG.Length;
                            //var length = oGLength-20;
                            //var inpLength = result.ToString().Length;
                            //length = 20 - oGLength+inpLength;
                            //var formatedResult = String.Format("{0," + length + "}", "= " + result);
                            //var histString = $"_{ogResult}_ {strInput1} {formatedResult}";
                            historyList.Add(FormatForConsole2(ogResult, strInput1)); 
                        }
                    }

                        if (!success)
                        {
                            Console.WriteLine("Your entry was invalid.\nPlease enter a math equation with two numeric values.");

                        }
                }
                else  if (strInput1.Contains("history", StringComparison.OrdinalIgnoreCase))
                {
                    var getOpArray = strInput1.Split(" ");
                    string oper;

                    if (historyList.Count > 0)
                    {
                        if (getOpArray.Length > 1)
                        {
                            oper = getOpArray[1];
                            historyList = historyList.FindAll(x => x.Contains(" "+oper+" "));
                        }

                        Console.WriteLine();

                        foreach (var x in historyList) {
                            Console.WriteLine(x);

                        }
                    }
                    else
                    {
                        Console.WriteLine("There's no history to report.");

                    }
                }
                else if (strInput1.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    done = true;
                }

            }
        }
       public static string FormatForConsole1(decimal result, string input)
        {
            var histStringOG = $"{input} ";
            var oGLength = histStringOG.Length;
            var length = oGLength - 20;
            var inpLength = result.ToString().Length;
            length = 20 - oGLength + inpLength;
            var formatedResult = String.Format("{0," + length + "}", "= " + result);
            return $"{input} {formatedResult}";
        }

        public static string FormatForConsole2(decimal result, string input)
        {
            var histStringOG = $"_{result}_ {input} ";//ED - use the string formating here and concatenate them.
            var oGLength = histStringOG.Length;
            var length = oGLength - 20;
            var inpLength = result.ToString().Length;
            length = 20 - oGLength + inpLength;
            var formatedResult = String.Format("{0," + length + "}", "= " + result);
            return $"_{result}_ {input} {formatedResult}";
        }
    }
}
