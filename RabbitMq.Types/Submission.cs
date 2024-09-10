namespace RabbitMqTypes;

    public class Submission
    { 
        public Guid Id { get; set; }

        public Industry Industry { get; set; }

        public Status Status { get; set; }

        public string SubmissionRef { get; set; }

        private List<Quote> Quotes { get; set; } = new();

        public void AddQuote(Quote quote)
        {
            Quotes.Add(quote);
        }

        public Quote GetQuote(Guid id)
        {
            return Quotes.Find(x => x.QuoteId.Equals(id));
        }
    }

