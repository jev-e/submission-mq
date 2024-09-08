using RabbitMqApi.Queue;

namespace RabbitMqApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public void RegisterPubSub(this IServiceCollection collection)
        {
            var publisher = new Publisher();
            var submissionPublisher = new SubmissionPublisher();
            collection.AddSingleton()
        }
    }
}
