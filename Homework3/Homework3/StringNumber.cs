using System;
using System.Linq;
using System.Text;

namespace Homework3
{
    public class StringNumber
    { 
        const string digits = "0123456789";
        
        private string strValue;
        private bool isNegative;

        public StringNumber(string str)
        {
            if (str == null)
            {
                throw new ArgumentException();
            }

            if (str.Count(ch => "+-".Contains(ch)) > 1)
            {
                throw new ArgumentException();
            }

            if (!str.Trim().TrimStart("+-".ToCharArray()).All(char.IsDigit))
            {
                throw new ArgumentException();
            }

            isNegative = (str.Trim()[0] == '-');
            strValue = str.Trim().TrimStart("+-".ToCharArray()).TrimStart('0');
            
            if (string.IsNullOrWhiteSpace(strValue))
            {
                strValue = "0";
            }
        }

        private int CompareValues(StringNumber other)
        {
            if (this.strValue.Length != other.strValue.Length)
            {
                return this.strValue.Length.CompareTo(other.strValue.Length);
            }
            else
            {
                for (var i = 0; i < strValue.Length; i++)
                {
                    if (this.strValue[i] > other.strValue[i])
                    {
                        return 1;
                    }

                    if (this.strValue[i] < other.strValue[i])
                    {
                        return -1;
                    }
                }

                return 0;
            }
        }

        public StringNumber Plus(StringNumber other)
        {
            var a = this.strValue.ReverseString();
            var b = other.strValue.ReverseString();
            var strBuilder = new StringBuilder();
            var overflow = false;

            if (this.CompareValues(other) == -1)
            {
                var tmp = a;
                a = b;
                b = tmp;
            }

            for (var i = 0; i < a.Length; i++)
            {
                var digitToSum = (i < b.Length) ? b[i] : '0';

                strBuilder.Append((this.isNegative == other.isNegative)
                    ? SumOfTwoDigits(a[i], digitToSum, ref overflow)
                    : DiffOfTwoDigits(a[i], digitToSum, ref overflow));
            }

            if ((overflow) && (this.isNegative == other.isNegative))
            {
                strBuilder.Append('1');
            }

            var result = new StringNumber(strBuilder.ToString().ReverseString());
            
            if (this.isNegative == other.isNegative)
            {
                result.isNegative = this.isNegative;
            }
            else
            {
                result.isNegative = (this.CompareValues(other) == -1)? other.isNegative : this.isNegative;
            }

            return result;
        }

        private static char SumOfTwoDigits(char a, char b, ref bool overflow)
        {
            if ((!digits.Contains(a)) || (!digits.Contains(b)))
            {
                throw new ArgumentException();
            }

            var aIndex = digits.IndexOf(a);
            var bIndex = digits.IndexOf(b);

            if (overflow)
            {
                aIndex++;
            }

            var resultIndex = (aIndex + bIndex) % digits.Length;
            overflow = (aIndex + bIndex > digits.Length - 1);

            return digits[resultIndex];
        }

        private static char DiffOfTwoDigits(char a, char b, ref bool overflow)
        {
            if ((!digits.Contains(a)) || (!digits.Contains(b)))
            {
                throw new ArgumentException();
            }

            var aIndex = digits.IndexOf(a);
            var bIndex = digits.IndexOf(b);

            if (overflow)
            {
                aIndex = (aIndex - 1 + digits.Length) % digits.Length;
            }

            if (aIndex == 9 && overflow)
            {
                overflow = true;
            }
            else
            {
                overflow = (aIndex - bIndex < 0);
            }

            var resultIndex = (aIndex - bIndex + digits.Length) % digits.Length;

            return digits[resultIndex];
        }

        public override string ToString()
        {
            if (strValue == "0" || !isNegative)
            {
                return strValue;
            }
            else
            {
                return string.Concat("-", strValue);
            }
        }
    }
}