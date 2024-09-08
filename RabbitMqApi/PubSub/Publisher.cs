using RabbitMQ.Client;

namespace RabbitMqApi.Queue
{
    public class Publisher
    {
        protected static readonly IConnection connection;
        protected static readonly IModel channel;

        static Publisher()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            // "guest"/"guest" by default, limited to localhost connections

            // this name will be shared by all connections instantiated by
            // this factory

            connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }
    }
}
