using System;
using System.Collections.Generic;

namespace Assignment1
{
    // TODO Add supporting classes here
    public class OperatorClass
    {
        public static int OperatorOrder(char op)
        {
            if (op == '+' || op == '-')
                return 1;
            if (op == '*' || op == '/')
                return 2;
            return 0;
        }

        public static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
    }
    public class InfixToPostfix
    {
        public static List<string> ConvertToPostfix(string input)

        {

            Stack<char> operators = new Stack<char>();

            List<string> output = new List<string>();

            int i = 0;

            while (i < input.Length)

            {

                char currentChar = input[i];

                if (Char.IsDigit(currentChar) || (currentChar == '-' &&

                    (i == 0 || input[i - 1] == '(' || OperatorClass.IsOperator(input[i - 1]))))

                {

                    string number = "";

                    if (currentChar == '-')

                    {

                        number += currentChar;

                        i++;

                        if (i < input.Length)

                            currentChar = input[i];

                    }

                    while (i < input.Length && (Char.IsDigit(currentChar) || currentChar == '.'))

                    {

                        number += currentChar;

                        i++;

                        if (i < input.Length)

                            currentChar = input[i];

                    }

                    output.Add(number);

                    continue;

                }

                else if (currentChar == '(')

                {

                    operators.Push(currentChar);

                }

                else if (currentChar == ')')

                {

                    while (operators.Peek() != '(')

                    {

                        output.Add(operators.Pop().ToString());

                    }

                    operators.Pop();

                }

                else if (OperatorClass.IsOperator(currentChar))

                {

                    while (operators.Count > 0 && OperatorClass.OperatorOrder(operators.Peek()) >= OperatorClass.OperatorOrder(currentChar))

                    {

                        output.Add(operators.Pop().ToString());

                    }

                    operators.Push(currentChar);

                }

                i++;

            }

            while (operators.Count > 0)

            {

                output.Add(operators.Pop().ToString());

            }

            return output;

        }


    }


    public class Calc
    {
        public static double CalcPostfix(List<string> tokens)

        {

            Stack<double> stack = new Stack<double>();

            foreach (var token in tokens)

            {

                if (double.TryParse(token, out double num))

                {

                    stack.Push(num);

                }

                else if (token == "+" || token == "-" || token == "*" || token == "/")

                {

                    double b = stack.Pop();

                    double a = stack.Pop();

                    double result = 0;

                    switch (token)

                    {

                        case "+":

                            result = a + b;

                            break;

                        case "-":

                            result = a - b;

                            break;

                        case "*":

                            result = a * b;

                            break;

                        case "/":

                            result = a / b;

                            break;

                    }

                    stack.Push(result);

                }

            }

            return stack.Pop();

        }

    }

    //testing changes

    public class Program
    {
        public static string ProcessCommand(string input)
        {
            try
            {
                input = input.Replace(" ", "");

                String result = "0.0";

                return result;
            }
            catch (Exception e)
            {
                return "Error evaluating expression: " + e;
            }
        }
// adjusted by Renato Paz
    static void Main(string[] args)
        {
            Console.WriteLine("Enter a mathematical expression (or 'exit' to quit):");
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                Console.WriteLine(ProcessCommand(input));
            }
            }
        }
    }
}
