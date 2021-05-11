using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace StringToInt
{
    public class StringNumber
    {
        private const string Digits = "0123456789";
        private const int NumeralSystem = 10;
        private readonly string strValue;
        private readonly bool isNegative;
        private int intValue;

        public StringNumber(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            
            if (str.Count(ch => "+-".Contains(ch)) > 1)
            {
                throw new ArgumentException();
            }

            if (!str.Trim().TrimStart("+-".ToCharArray()).All(char.IsDigit))
            {
                throw new ArgumentException($"String {str} is not an integer value");
            }

            isNegative = (str.Trim()[0] == '-');
            strValue = str.Trim().TrimStart("+-".ToCharArray()).TrimStart('0');

            if (string.IsNullOrWhiteSpace(strValue))
            {
                strValue = "0";
            }
            
            SetIntValue();
            
            LoggerWrapper.MyLogger?.LogInformation("New StringNumber created :");
            LoggerWrapper.MyLogger?.LogInformation($"String : {str}, isNegative : {isNegative}, strValue : {strValue}, intValue : {intValue}");
        }

        public int GetInt() => intValue;

        private void SetIntValue()
        {
            intValue = 0;

            for (var i = strValue.Length - 1; i >= 0; i--)
            {
                var digit = Digits.IndexOf(strValue[i]);

                if (isNegative)
                {
                    digit = -digit;
                }

                try
                {
                    checked
                    {
                        intValue += digit * (int) Math.Pow(NumeralSystem, strValue.Length - 1 - i);
                    }
                }
                catch (OverflowException e)
                {
                    LoggerWrapper.MyLogger?.LogError(e, e.Message);
                    throw new ArgumentException($"Value {strValue} is bigger than integer");
                }
            }
        }
    }
}