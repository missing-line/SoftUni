namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    public class MailsDTO
    {
        [Required]
        public string Description { get; set; }


        [Required]
        public string Sender { get; set; }


        [RegularExpression(@"^[0-9 a-zA-Z]+str.$")]
        public string Address { get; set; }
    }
}
