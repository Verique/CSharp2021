using System;

namespace Events
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Subscribing to receive messages after 1s from Subscriber, after 2s from AnotherSubscriber, after 3s from Subscriber");
            var c = new Countdown();
            
            c.AddSubscriber(new Subscriber(1000));
            c.AddSubscriber(new AnotherSubscriber(2000));
            c.AddSubscriber(new Subscriber(3000));
            c.Invoke();
        }
    }
}