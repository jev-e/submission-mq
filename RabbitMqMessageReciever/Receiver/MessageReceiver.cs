using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqTypes;
using System.Text.Json;

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

            _channel.ExchangeDeclare(exchange: "submission", type: ExchangeType.Fanout);

            // declare a server-named queue
            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName,
                              exchange: "submission",
                              routingKey: string.Empty);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var sub = JsonSerializer.Deserialize<Submission>(body);
                Console.WriteLine($" [x] Submission with id {sub.Id} from queue");
            };

            _channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }


    }
}
