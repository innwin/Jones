using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Jones.EventBus
{
    public class EventBus : IEventBus
    {
        private readonly Subject<IEvent> _bus = new Subject<IEvent>();
        
        public void Publish<TEvent>(TEvent eventItem) where TEvent : IEvent
        {
            _bus.OnNext(eventItem);
        }

        public IObservable<TEvent> Of<TEvent>() where TEvent : IEvent
        {
            return _bus.OfType<TEvent>();
        }
    }
}