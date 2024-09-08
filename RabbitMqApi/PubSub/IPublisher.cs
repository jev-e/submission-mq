using RabbitMQ.Client;

namespace RabbitMqApi.PubSub
{
    public interface IPublisher
    {
        IConnection GetConnection();
    }
}
