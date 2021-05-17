using System;
using System.Threading.Tasks;

namespace Events
{
    public class Countdown
    {
        private event Action CountdownMessage;

        public void Invoke()
        {
            if (CountdownMessage is null)
            {
                throw new NullReferenceException();
            }
            
            var delegates = CountdownMessage.GetInvocationList();
            var tasks = new Task[delegates.Length];
            
            for (var i = 0; i < delegates.Length; i++)
            {
                tasks[i] = Task.Run((Action)delegates[i]);
            }

            Task.WaitAll(tasks);
        }

        private void Subscribe(Action method)
        {
            CountdownMessage += method ?? throw new ArgumentNullException();
        }

        public void AddSubscriber(ICountdownSubscriber subscriber)
        {
            Subscribe(subscriber.GetMessage);
        }
    }
}