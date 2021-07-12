using System;
using FancyCalculator;
namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Input input = new Input();
            decimal strInput1 = Decimal.Zero;
            decimal strInput2 = Decimal.Zero;
            string input1 = String.Empty;
            string input2 = String.Empty;
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Please enter two numeric values.");
                Console.WriteLine("Please enter the first number or x to exit.");
                input1 = Console.ReadLine();
                if (!input1.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    bool success = Decimal.TryParse(input1, out strInput1);
                    if (success)
                    {
                        input.Input1 = strInput1;
                        Console.WriteLine("Please enter the second number or x to exit.");
                        input2 = Console.ReadLine();
                        if (!input2.Equals("x", StringComparison.OrdinalIgnoreCase))
                        {
                            success = Decimal.TryParse(input2, out strInput2);
                            if (success)
                            {
                                input.Input2 = strInput2;
                                Console.WriteLine("The sum is:{0}", input.Input1 + input.Input2);

                            }
                        }
                        else
                        {
                            done = true;
                        }
                    }
                    if (!success)
                    {
                        Console.WriteLine("Your entry was invalid.\nPlease re-try.");

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
