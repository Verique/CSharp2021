using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace StringToInt
{
    public class StringNumber
    {
        private ILogger logger; 
        private const string Digits = "0123456789";
        private const int NumeralSystem = 10;
        private readonly string strValue;
        private readonly bool isNegative;
        private int intValue;

        public StringNumber(string str, ILogger logger = null)
        {
            this.logger = logger;
            
            if (str is null)
            {
                var e = new ArgumentNullException(nameof(str));
                logger?.LogError(e, e.Message);
                throw e;
            }
            
            if (str.Count(ch => "+-".Contains(ch)) > 1)
            {
                var e = new ArgumentException();
                logger?.LogError(e, e.Message);
                throw e;
            }

            if (!str.Trim().TrimStart("+-".ToCharArray()).All(char.IsDigit))
            {
                var e = new ArgumentException($"String {str} is not an integer value");
                logger?.LogError(e, e.Message);
                throw e;
            }

            isNegative = (str.Trim()[0] == '-');
            strValue = str.Trim().TrimStart("+-".ToCharArray()).TrimStart('0');

            if (string.IsNullOrWhiteSpace(strValue))
            {
                strValue = "0";
            }
            
            SetIntValue();
            
            logger?.LogInformation("New StringNumber created :");
            logger?.LogInformation($"String : {str}, isNegative : {isNegative}, strValue : {strValue}, intValue : {intValue}");
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
                    logger?.LogError(e, e.Message);
                    var ex = new ArgumentException($"Value {strValue} is bigger than integer");
                    logger?.LogError(ex, ex.Message);
                    throw ex;
                }
            }
        }
    }
}