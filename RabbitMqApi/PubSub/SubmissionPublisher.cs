using RabbitMQ.Client;
using RabbitMqApi.PubSub;

namespace RabbitMqApi.Queue
{
    public class SubmissionPublisher 
        : Publisher, ISubmissionPublisher
    {
        static SubmissionPublisher()
        {
            channel.ExchangeDeclare("submission", ExchangeType.Fanout);
        }
    }
}
