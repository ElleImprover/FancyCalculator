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
        public List<string> HistoryList { get; set; }

        public Calculator()
        {
            HistoryList = new();
        }


        public EvaluationResult Evaluate(string input, List<string> curHistList=default, decimal decResult = 0m)
        {
            Decimal input1 = Decimal.Zero;
            Decimal input2 = Decimal.Zero;
            Decimal result = decResult;
            if (curHistList != default)
            {
                HistoryList = curHistList;
            }

            bool done = false;

            if (!input.Contains("history", StringComparison.CurrentCultureIgnoreCase))
            {
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
                                    HistoryList.Add(FormatTwoInputs(result, input));
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
                                var ogResult = result;
                                var op = inpArray[0];
                                switch (op) {

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
                                        return new EvaluationResult { Result = result, ErrorMessage = $"The following operator was used, but incorrect{op}"};
                                }
                                HistoryList.Add(FormatOneInput(ogResult, input,result));

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
            }
            else
            {
                //Call method that returns a list; possibly do this at a different level


                if (HistoryList.Count > 0)
                {
                    GetHistList(input);//Filters current list
                    if (HistoryList.Count == 0) {
                        return new EvaluationResult { ErrorMessage = "There's no history to report." };

                    }
                    else
                    {
                        return new EvaluationResult { History = HistoryList };
                    }

                }
                else
                {
                    return new EvaluationResult { ErrorMessage = "There's no history to report." };

                }
            }

            return new EvaluationResult { Result = result,History=HistoryList };
            }

        public List<string> GetHistList(string input)
        {
            var getOpArray = input.Split(" ");
            string oper;
            if (getOpArray.Length > 1)
            {
                oper = getOpArray[1];
                HistoryList = HistoryList.FindAll(x => x.Contains(" " + oper + " "));
            }

            return HistoryList;
        }

        public  string FormatTwoInputs(decimal result, string input)
        {
            var histStringOG = $"{input} ";
            var oGLength = histStringOG.Length;
            var length = oGLength - 20;
            var inpLength = result.ToString().Length;
            length = 20 - oGLength + inpLength;
            var formatedResult = String.Format("{0," + length + "}", "= " + result);
            return $"{input} {formatedResult}";
        }

        public  string FormatOneInput(decimal oGresult, string input, decimal result)
        {
            var histStringOG = $"_{oGresult}_ {input} ";//ED - use the string formating here and concatenate them.
            var oGLength = histStringOG.Length;
            var length = oGLength - 20;
            var inpLength = result.ToString().Length;
            length = 20 - oGLength + inpLength;
            var formatedResult = String.Format("{0," + length + "}", "= " + result);
            return $"_{oGresult}_ {input} {formatedResult}";
        }


    }
    } 
