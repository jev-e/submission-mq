using RabbitMqApi.Model;
using RabbitMqTypes;

namespace RabbitMqApi.PubSub
{
    public interface ISubmissionPublisher
    {
        public void PublishNewSubmission(Submission submission);
    }
}
