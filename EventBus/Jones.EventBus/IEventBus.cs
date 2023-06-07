namespace Jones.EventBus;

public interface IEventBus<in TEvent>
{
    void Publish<T>(T eventItem) where T : TEvent;
    IObservable<T> Of<T>() where T : TEvent;
}