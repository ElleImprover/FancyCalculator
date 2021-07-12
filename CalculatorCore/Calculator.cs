using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {

        public EvaluationResult Evaluate(string input)
        {
            Decimal input1 = Decimal.Zero;

            Decimal input2 = Decimal.Zero;
            Decimal result = Decimal.Zero;

            var inpArray = input.Split(" ");
            if (inpArray.Length == 3)
            {
                bool success = Decimal.TryParse(inpArray[0], out input1);
                if (success)
                {
                    success = Decimal.TryParse(inpArray[2], out input2);
                    if (success)
                    {
                        result = input1 + input2;

                    }
                    else
                    {
                        return new EvaluationResult { Result = result, ErrorMessage = "" };

                    }

                }
                else
                {
                    return new EvaluationResult { Result = result, ErrorMessage="" };

                }
            }
            return new EvaluationResult { Result = result};

        }
    }
}
