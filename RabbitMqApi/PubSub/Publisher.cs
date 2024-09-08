using RabbitMQ.Client;
using RabbitMqApi.PubSub;

namespace RabbitMqApi.Queue
{
    public class Publisher : IPublisher
    {
        internal static readonly IConnection connection;

        static Publisher()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
        }

        public IConnection GetConnection() 
        {
            return connection;
        }
    }
}
