using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace StringToInt
{
    public class StringNumber
    {
        private static ILogger logger;
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

            if (!str.Trim().Trim("+-".ToCharArray()).All(char.IsDigit))
            {
                throw new ArgumentException($"String {str} is not an integer value");
            }

            isNegative = (str.Trim()[0] == '-');
            strValue = str.Trim().Trim("+-".ToCharArray()).TrimStart('0');

            if (string.IsNullOrWhiteSpace(strValue))
            {
                strValue = "0";
            }
            
            SetIntValue();
            
            logger.LogInformation("New StringNumber created :");
            logger.LogInformation($"String : {str}, isNegative : {isNegative}, strValue : {strValue}, intValue : {intValue}");
        }

        public static void SetLogger(ILogger newLogger)
        {
            logger = newLogger;
        }

        public int GetInt() => intValue;

        private void SetIntValue()
        {
            intValue = 0;

            for (var i = strValue.Length - 1; i >= 0; i--)
            {
                var digit = Digits.IndexOf(strValue[i]);

                try
                {
                    checked
                    {
                        intValue += digit * (int) Math.Pow(NumeralSystem, strValue.Length - 1 - i);
                    }
                }
                catch (OverflowException e)
                {
                    logger.LogError(e, e.Message);
                    throw new ArgumentException($"Value {strValue} is bigger than integer");
                }
            }

            if (isNegative)
            {
                intValue *= -1;
            }
        }
    }
}