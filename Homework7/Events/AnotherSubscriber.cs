using System;
using System.Threading;

namespace Events
{
    public class AnotherSubscriber : ICountdownSubscriber
    {
        private string receivedMessage;
        private int messageDelay;

        public AnotherSubscriber(int delay)
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