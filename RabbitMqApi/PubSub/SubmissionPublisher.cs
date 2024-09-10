using RabbitMQ.Client;
using RabbitMqApi.Model;
using RabbitMqApi.PubSub;
using RabbitMqTypes;
using System.Text.Json;

namespace RabbitMqApi.Queue
{
    public class SubmissionPublisher()
        : ISubmissionPublisher
    {
        internal static string exchange = "submission";

        internal IPublisher publisher;
        internal IModel channel;

        public SubmissionPublisher(IPublisher publisher) : this()
        {
            this.publisher = publisher;
            channel = this.publisher.GetConnection().CreateModel();
            channel.ExchangeDeclare(exchange, ExchangeType.Fanout);
        }

        public void PublishNewSubmission(Submission submission)
        {
            var body = JsonSerializer.SerializeToUtf8Bytes(submission);
            IBasicProperties props = channel.CreateBasicProperties();
            props.ContentType = "application/json";
            props.DeliveryMode = 2;
            channel.BasicPublish(exchange, string.Empty, props, body);
        }



    }
}
