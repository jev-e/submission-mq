namespace RabbitMqTypes
{
    public class Quote
    {
        public Guid QuoteId { get; set; }

        public Guid SubmissionId { get; set; }

        public long Premium { get; set; }
    }
}
