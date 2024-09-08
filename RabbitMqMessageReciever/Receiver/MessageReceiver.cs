using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMqMessageReciever.Receiver
{
    public class MessageReceiver : IMessageReceiver
    {
        private static readonly IConnection _connection;
        private static readonly IModel _channel;

        static MessageReceiver()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
             _channel = _connection.CreateModel();
        }

        public void SubscribeToChannel()
        {

            _channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

            // declare a server-named queue
            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName,
                              exchange: "logs",
                              routingKey: string.Empty);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] {message}");
            };
            _channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }


    }
}
