using System;

namespace Events
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Subscribing to receive messages after 1s from Subscriber, after 2s from AnotherSubscriber");
            var c = new Countdown();
            var subscriber = new Subscriber();
            var another = new AnotherSubscriber();
            
            subscriber.Subscribe(c, 2000);
            another.Subscribe(c,  1000);
            c.Invoke();
        }
    }
}