using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using StackExchange.Redis;

namespace Jones.EventBus.Redis.Extensions;

public static class RxRedisExtensions
{
    public static IObservable<RedisValue> WhenMessageReceived(this ISubscriber subscriber, RedisChannel channel)
    {
        return Observable.Create<RedisValue>(async (obs, _) =>
        {
            await subscriber.SubscribeAsync(channel, (_, message) =>
            {
                obs.OnNext(message);
            }).ConfigureAwait(false);

            return Disposable.Create(() => subscriber.Unsubscribe(channel));
        });
    }
}