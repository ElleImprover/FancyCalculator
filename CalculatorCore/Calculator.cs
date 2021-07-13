using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {
        private const string _VALID_OPERATORS = "/*-+";

        public EvaluationResult Evaluate(string input, decimal decResult=0m)
        {
            Decimal input1 = Decimal.Zero;
            Decimal input2 = Decimal.Zero;
            Decimal result = decResult;

            bool done = false;

            var inpArray = input.Split(" ");
            if (inpArray.Length >= 2 && inpArray.Length < 4)
            {
                if (inpArray.Length == 3)
                {
                    if (_VALID_OPERATORS.Contains(inpArray[1]))
                    {
                        bool success = Decimal.TryParse(inpArray[0], out input1);
                        if (success)
                        {
                            success = Decimal.TryParse(inpArray[2], out input2);
                            if (success)
                            {
                                var op = inpArray[1];
                                switch (op)
                                {
                                    case "+":
                                        result = input1 + input2;
                                        break;
                                    case "-":
                                        result = input1 - input2;
                                        break;
                                    case "*":
                                        result = input1 * input2;
                                        break;
                                    case "/":
                                        result = input1 / input2;
                                        break;
                                    default:
                                        throw new NotImplementedException($"The following operator was used, but incorrect{op}");
                                }

                            }
                            else
                            {
                                return new EvaluationResult { Result = result, ErrorMessage = "The second entry was incorrect." };

                            }

                        }
                        else
                        {
                            return new EvaluationResult { Result = result, ErrorMessage = "The first entry was incorrect." };

                        }
                    }
                    else
                    {
                        return new EvaluationResult { Result = result, ErrorMessage = "The operator was incorrect." };
                    }
                }
                else if (inpArray.Length == 2)
                {

                    if (_VALID_OPERATORS.Contains(inpArray[0]))
                    {
                        bool success = Decimal.TryParse(inpArray[1], out input1);
                        if (success)
                        {

                            var op = inpArray[0];
                            switch (op)
                            {
                                case "+":
                                    result += input1;
                                    break;
                                case "-":
                                    result -= input1;
                                    break;
                                case "*":
                                    result *= input1;
                                    break;
                                case "/":
                                    result /= input1;
                                    break;
                                default:
                                    throw new NotImplementedException($"The following operator was used, but incorrect{op}");
                            }
                        } 
                        else
                        {
                            return new EvaluationResult { Result = result, ErrorMessage = "The second entry was incorrect." };

                        }  
                    }
                    else
                    {
                        return new EvaluationResult { Result = result, ErrorMessage = "The operator was incorrect." };
                    } 
                }
            }
            else
            {
                return new EvaluationResult { Result = result, ErrorMessage = "There are an incorrect number of entries." };

            }
             return new EvaluationResult { Result = result };
        }
    }
}
