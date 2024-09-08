using RabbitMqApi.Model;

namespace RabbitMqApi.PubSub
{
    public interface ISubmissionPublisher
    {
        public void PublishNewSubmission(Submission submission);
    }
}
