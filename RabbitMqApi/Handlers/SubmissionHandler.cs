using RabbitMqApi.Model;
using RabbitMqApi.PubSub;

namespace RabbitMqApi.Handlers
{
    public class SubmissionHandler(ISubmissionPublisher submissionPublisher) : ISubmissionHandler
    {
        public void HandleNewSubmission(NewSubmissionRequest request)
        {
            Submission submission = new Submission()
            {
                Id = Guid.NewGuid(),
                Industry = request.Industry,
                Status = request.Status,
                SubmissionRef = request.SubmissionRef
            };
            submissionPublisher.PublishNewSubmission(submission);
        }
    }
}
