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
                        var op = inpArray[1];
                        switch (op) {
                            case "+":
                            result = input1 + input2;
                                break;
                            case "-":
                                result = input1 - input2;
                                break;
                        }


                    }
                    else
                    {
                        return new EvaluationResult { Result = result, ErrorMessage = "The second entry was incorrect." };

                    }

                }
                else
                {
                    return new EvaluationResult { Result = result, ErrorMessage="The first entry was incorrect." };

                }
            }
            return new EvaluationResult { Result = result};

        }
    }
}
