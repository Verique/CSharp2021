using System;
using System.Threading;

namespace Events
{
    public class Subscriber : ICountdownSubscriber
    {
        private string receivedMessage;
        private int messageDelay;

        public Subscriber(int delay)
        {
            receivedMessage = "";
            messageDelay = delay;
        }
        
        private void GetMessageAfter(int milliseconds)
        {
            Thread.Sleep(milliseconds);
            var message = $"Message from {this}";
            receivedMessage = message;
            Console.WriteLine(receivedMessage);
        }

        public void GetMessage() => GetMessageAfter(messageDelay);
    }
}