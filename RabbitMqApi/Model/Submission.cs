namespace RabbitMqApi.Model
{
    public class Submission
    { 
        public Guid Id { get; set; }

        public Industry Industry { get; set; }

        public Status Status { get; set; }

        public string SubmissionRef { get; set; }
    }
}
