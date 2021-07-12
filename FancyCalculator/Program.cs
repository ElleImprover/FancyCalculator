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

            Console.WriteLine("Please enter two numeric values.");
            Console.WriteLine("Please enter the first number.");

            bool success =  Decimal.TryParse(Console.ReadLine(),out strInput1);
            if (success)
            {
                input.Input1 = strInput1;
                Console.WriteLine("Please enter the second number.");

                 success = Decimal.TryParse(Console.ReadLine(), out strInput2);
                if (success)
                {
                    input.Input2 = strInput2;
                    Console.WriteLine("The sum is:{0}",input.Input1+input.Input2);

                }
            }

        }
    }
}
