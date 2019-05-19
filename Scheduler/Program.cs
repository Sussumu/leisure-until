using System;
using System.Collections.Generic;

namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrivalTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 0, 0);

            var events = new List<Event>
            {
                Event.Create("Jantar", 0, 30),
                Event.Create("Metro", 1, 0),
                Event.Create("Banho", 0, 40),
                Event.Create("Lavar banheiro", 0, 50),
            };

            var startTime = arrivalTime;
            foreach (var @event in events)
            {
                startTime -= @event.Duration;
            }

            Console.WriteLine(startTime);
        }
    }

    internal class Event
    {
        public static Event Create(string description, int hours, int minutes)
        {
            return new Event(description, hours, minutes);
        }

        private Event(string description, int hours, int minutes)
        {
            Description = description;
            Duration = new TimeSpan(hours, minutes, 0);
        }

        public string Description { get; }
        public TimeSpan Duration { get; }
    }
}
