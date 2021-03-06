using System;
using Microsoft.Extensions.Logging;

namespace StringToInt
{
    public static class StringToIntExt
    {
        public static int ToInt(this string str, ILogger logger)
        {
            if (str is null)
            {
                var e = new ArgumentNullException(nameof(str));
                logger?.LogError(e, e.Message);
                throw e;
            }

            return new StringNumber(str, logger).GetInt(); 
        }

        public static int ToInt(this string str)
        {
            return str.ToInt(null);
        }
    }
}