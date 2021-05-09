using System;
using Microsoft.Extensions.Logging;

namespace StringToInt
{
    public static class StringToIntExt
    {
        public static int ToInt(this string str)
        {
            if (str is null)
            {
                var e = new ArgumentNullException(nameof(str));
                LoggerWrapper.MyLogger?.LogError(e, e.Message);
                throw e;
            }

            int result;
            
            try
            {
                result = new StringNumber(str).GetInt();
            }
            catch (ArgumentException e)
            {
                LoggerWrapper.MyLogger?.LogError(e, e.Message);
                throw;
            }
            
            return result;
        }
    }
}