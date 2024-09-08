using RabbitMqApi.Model;

namespace RabbitMqApi.Handlers
{
    public interface ISubmissionHandler
    {
        public void HandleNewSubmission(NewSubmissionRequest request);
    }
}
