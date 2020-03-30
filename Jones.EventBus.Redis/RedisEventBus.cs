using System;
using System.Reactive.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using Jones.EventBus.Redis.Extensions;
using StackExchange.Redis;

namespace Jones.EventBus.Redis
{
    public class RedisEventBus : IRedisEventBus
    {
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,    // 忽略null值的属性
            PropertyNameCaseInsensitive = true,    //忽略大小写
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping    // 序列化中文时的编码问题
        };
        
        private readonly ISubscriber _subscriber;
        public RedisEventBus(ISubscriber subscriber)
        {
            _subscriber = subscriber;
        }

        public void Publish<TEvent>(TEvent eventItem) where TEvent : IEvent
        {
            _subscriber.Publish(GetChannel<TEvent>(), JsonSerializer.Serialize(eventItem, JsonOptions));
        }

        public IObservable<TEvent> Of<TEvent>() where TEvent : IEvent =>
            _subscriber.WhenMessageReceived(GetChannel<TEvent>())
                .Select(message => JsonSerializer.Deserialize<TEvent>(message, JsonOptions));
        
        public static string GetChannel<TEvent>()
        {
            return typeof(TEvent).FullName;
        }
    }
}