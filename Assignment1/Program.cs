using System;
using System.Collections.Generic;

namespace Assignment1
{
    // TODO Add supporting classes here
    public class OperatorClass
    {
       
    }
    public class InfixToPostfix
    {
        
    }

    public class Calc
    {
        
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
