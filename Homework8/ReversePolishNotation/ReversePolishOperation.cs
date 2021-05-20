using System;
using System.Collections.Generic;

namespace ReversePolishNotation
{
    public static class ReversePolishOperation
    {
        private static Stack<double> stack;

        public static double Calculate(string input)
        {
            stack = new Stack<double>();

            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var array = input.Split();

            foreach (var operandOrSign in array)
            {
                if ("+-/*".Contains(operandOrSign) && operandOrSign.Length == 1)
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Wrong string");
                    }

                    stack.Push(DoOperation(operandOrSign));
                }
                else if (double.TryParse(operandOrSign, out var number))
                {
                    stack.Push(number);
                }
                else
                {
                    throw new ArgumentException("Wrong string");
                }
            }

            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new AggregateException("Wrong String");
            }
        }

        private static double DoOperation(string sign)
        {
            var b = stack.Pop();
            var a = stack.Pop();

            switch (sign)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                default:
                    return 0;
            }
        }
    }
}