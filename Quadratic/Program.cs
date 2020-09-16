using System;

namespace MiscTesting
{
    class Program
    {
        public static void Main()
        {
            string option = string.Empty;
            do
            {
                //get inputs
                Console.WriteLine("Enter values for a,b and c");
                string input = Console.ReadLine();
                double[] values = new double[3];
                //validate
                if (ValidateInput(input, out values))
                {
                    //do the logic
                    Console.WriteLine("Processing answer");
                    FindRoots(values[0], values[1], values[2]);
                }
                else
                {
                    Console.WriteLine("Your input is not valid");
                }
                Console.WriteLine("\nEnter q to quit or any key to restart");
                option = Console.ReadLine();

            } while (!option.Equals("Q", StringComparison.OrdinalIgnoreCase));

        }

        private static bool ValidateInput(string input,out double[] values)
        {
            values = new double[3];
            char[] variableNames = { 'a', 'b', 'c' };
            string[] stringValues = input.Split(" ");
            for (int i = 0; i < stringValues.Length; i++)
            {
                bool isDouble = double.TryParse(stringValues[i], out values[i]);
                if (!isDouble)
                {
                    Console.WriteLine(string.Format("Input for {0} is not a valid double value", variableNames[i]));
                    return false;
                }
                else
                {
                    //check for a
                    if (i == 0 && values[i] == 0)
                    {
                        Console.WriteLine("a cannot be 0");
                        return false;
                    }
                }
            }

            return true;
        }

        private static void FindRoots(double a, double b, double c)
        {
            bool isImaginary;
            double squareRoot = GetSquareRootPart(a, b, c, out isImaginary);
            //Imganiary
            if (isImaginary)
            {
                Console.Write(string.Format("{0}+{1}i {0}-{1}i",
                    String.Format("{0:0.00}", (-b / (2 * a))),
                    String.Format("{0:0.00}", (squareRoot / (2 * a)))
                    ));
            }
            //normal
            else
            {
                Console.Write(string.Format("{0} {1}",
                    String.Format("{0:0.00}", (-b+squareRoot)/(2*a)),
                    String.Format("{0:0.00}", (-b - squareRoot) / (2 * a))
                    ));
            }
        }

        private static double GetSquareRootPart(double a, double b, double c,out bool isImaginary)
        {
            double value1 = (b * b) - (4 * a * c);
            isImaginary = (value1 < 0);
            return Math.Sqrt(Math.Abs(value1));
        }

    }
}
