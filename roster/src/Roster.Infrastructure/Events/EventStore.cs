using MassTransit;
using Roster.Core.Events;

namespace Roster.Infrastructure.Events {
    public class EventStore : IEventStore
    {
        private readonly IBus _bus;

        public EventStore(IBus bus) {
            _bus = bus;
        }
        
        public void Publish<T>(T @event) where T: class
        {
            _bus.Publish<T>(@event);
        }
    }
}