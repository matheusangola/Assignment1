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
        
    }

    // Add by Renato Paz
    public class Calc
    {
        public static double EvaluatePostfix(string postfix)
        {
            Stack<double> stack = new Stack<double>();
            string[] tokens = postfix.Split(' ');

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number); // If it's a number, push it onto the stack
                }
                else if (token.Length == 1 && OperatorClass.IsOperator(token[0]))
                {
                    // If it's an operator, pop two numbers and apply the operation
                    double b = stack.Pop();
                    double a = stack.Pop();
                    stack.Push(OperatorClass.ApplyOperation(a, b, token[0]));
                }
            }

            return stack.Pop(); // The result will be the last item in the stack
        }
    }



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

        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                Console.WriteLine(ProcessCommand(input));
            }
        }
    }
}
