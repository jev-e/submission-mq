using RabbitMqTypes;
using System.ComponentModel.DataAnnotations;

namespace RabbitMqApi.Model
{
    public class NewSubmissionRequest
    {
        [Required]
        public Industry Industry;

        [Required]
        public string SubmissionRef;

        [Required]
        public int Premium;

        public Status Status;
    }
}
