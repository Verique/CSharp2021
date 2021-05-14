using System;

namespace ConsoleAppEvents
{
    public class Subscriber
    {
        private string receivedMessage;

        public Subscriber()
        {
            receivedMessage = "";
        }
        
        public void Subscribe(Countdown countdown)
        {
            if (countdown is null)
            {
                throw new ArgumentNullException(nameof(countdown));
            }
            
            countdown.Subscribe(GetMessage);
        }

        private void GetMessage()
        {
            var message = $"Message from {this}";
            receivedMessage = message;
            Console.WriteLine(receivedMessage);
        }
        
    }
}