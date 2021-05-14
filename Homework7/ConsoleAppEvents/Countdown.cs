using System;
using System.Threading;

namespace ConsoleAppEvents
{
    public class Countdown
    {
        private event Action CountdownMessage;

        public void Invoke(int milliseconds)
        {
            Thread.Sleep(milliseconds);
            CountdownMessage?.Invoke();
            var a = CountdownMessage;
        }

        public void Subscribe(Action method)
        {
            CountdownMessage += method ?? throw new ArgumentNullException();
        }
    }
}