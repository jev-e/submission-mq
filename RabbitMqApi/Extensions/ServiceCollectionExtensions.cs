using RabbitMqApi.PubSub;
using RabbitMqApi.Queue;

namespace RabbitMqApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterPubSub(this IServiceCollection collection)
        {
            var publisher = new Publisher();
            collection.AddSingleton<IPublisher>(publisher);
            collection.AddSingleton<ISubmissionPublisher, SubmissionPublisher>();
        }
    }
}
