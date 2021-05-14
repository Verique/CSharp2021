using System;
using System.Threading;

namespace Events
{
    public class AnotherSubscriber
    {
        private string receivedMessage;
        public AnotherSubscriber()
        {
            receivedMessage = "";
        }
        
        public void Subscribe(Countdown countdown, int milliseconds)
        {
            if (countdown is null)
            {
                throw new ArgumentNullException(nameof(countdown));
            }
            
            countdown.Subscribe(() => GetMessage(milliseconds));
        }

        private void GetMessage(int milliseconds)
        {
            Thread.Sleep(milliseconds);
            var message = $"Message from {this}";
            receivedMessage = message;
            Console.WriteLine(receivedMessage);
        }
        
    }

}