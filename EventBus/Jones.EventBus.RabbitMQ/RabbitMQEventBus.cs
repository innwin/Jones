using System.Reactive.Linq;
using System.Text;
using System.Text.Json;
using Jones.EventBus.RabbitMQ.Extensions;
using Jones.RabbitMQ;
using Microsoft.Extensions.Options;

namespace Jones.EventBus.RabbitMQ;

public class RabbitMQEventBus<TEvent> : IEventBus<TEvent>
{
    private readonly RabbitMQClient _rabbitMqClient;
    private readonly JsonSerializerOptions? _jsonSerializerOptions;

    public RabbitMQEventBus(RabbitMQClient rabbitMqClient, IOptions<JsonSerializerOptions>? jsonSerializerOptions)
    {
        _rabbitMqClient = rabbitMqClient;
        _jsonSerializerOptions = jsonSerializerOptions?.Value;
    }

    public void Publish<T>(T eventItem) where T : TEvent
    {
        _rabbitMqClient.Channel.BasicPublish(
            exchange: "",
            routingKey: GetQueueName<T>(),
            basicProperties: null,
            mandatory: false,
            body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(eventItem, _jsonSerializerOptions)));
    }

    public IObservable<T> Of<T>() where T : TEvent => _rabbitMqClient.Channel
        .WhenEventingBasicConsumerReceived(GetQueueName<T>())
        .Select(body => JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(body.ToArray()), _jsonSerializerOptions))!;

    protected string GetQueueName<T>() => GetQueueName(typeof(T));

    protected virtual string GetQueueName(Type type)
    {
        var queueName = type.FullName ?? throw new ArgumentNullException($"{nameof(Type)}.FullName");
#if DEBUG
        return $"{queueName}.Debug";
#else
        return queueName;
#endif
    }
}