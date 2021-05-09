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
                Logger.LogError(e, e.Message);
                throw e;
            }

            int result;
            StringNumber.SetLogger(Logger);
            
            try
            {
                result = new StringNumber(str).GetInt();
            }
            catch (ArgumentException e)
            {
                Logger.LogError(e, e.Message);
                throw;
            }
            
            return result;
        }

        private static ILogger Logger;
        
        public static void SetLogger(ILogger newLogger)
        {
            Logger = newLogger;
        }

        public static ILogger GetLogger() => Logger;
    }
}