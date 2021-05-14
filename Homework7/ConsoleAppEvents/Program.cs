using System;

namespace ConsoleAppEvents
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Subscribing to receive messages after 1400ms");
            var c = new Countdown();
            var subscriber = new Subscriber();
            var another = new AnotherSubscriber();
            
            subscriber.Subscribe(c);
            another.Subscribe(c);
            c.Invoke(1400);
        }
    }
}