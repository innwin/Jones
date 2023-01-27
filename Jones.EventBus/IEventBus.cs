using System;

namespace Jones.EventBus;

public interface IEventBus
{
    void Publish<TEvent>(TEvent eventItem) where TEvent : IEvent;
    IObservable<TEvent> Of<TEvent>() where TEvent : IEvent;
}