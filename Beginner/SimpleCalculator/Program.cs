using System;

namespace Calculator_Simple_
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Simple Calculator");

                //Let the user enter the first number 
                Console.Write("Enter first number: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Invalid number, try again");
                    continue;
                }
                /*In case of entering a number without tryparse
                 * double num1 = Convert.ToDouble(Console.ReadLine());
                */

                //Let the user enter the second number 
                Console.Write("Enter second number: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.WriteLine("Invalid number, try again");
                    continue;
                }

                /*In case of entering a number without tryparse
                 * double num2 = Convert.ToDouble(Console.ReadLine());
                */

                //Choosing the operation
                Console.Write("Enter your operateor: (+, -, /, *, %, ^ ): ");
                string operation = Console.ReadLine();

                double result;

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "%":
                        result = num1 % num2;
                        break;
                    case "^":
                        result = Math.Pow(num1, num2);
                        break;
                    case " /":
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            Console.WriteLine("Cannot divide by zero.");
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operator ");
                        return;
                }

                //Printing the results 
                Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
                Console.WriteLine();
                Console.WriteLine("Do you want to calculate again? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                    break;
                Console.Clear();

            }
        }
    }
}
