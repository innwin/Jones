using System.Reactive.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Jones.EventBus.RabbitMQ.Extensions;

public static class ChannelExtensions
{
    public static IObservable<ReadOnlyMemory<byte>> WhenEventingBasicConsumerReceived(this IModel channel, string queueName)
    {
        var consumer = new EventingBasicConsumer(channel);
        return Observable
            .FromEventPattern<BasicDeliverEventArgs>(
                h =>
                {
                    consumer.Received += h;
                    channel.BasicConsume(queueName, true, consumer);
                }, 
                h => consumer.Received -= h)
            .Select(p => p.EventArgs.Body);
    }
}