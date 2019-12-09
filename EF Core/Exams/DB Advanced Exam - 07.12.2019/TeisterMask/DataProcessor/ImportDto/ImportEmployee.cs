namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    public class ImportEmployee
    {

        [RegularExpression(@"[A-Za-z0-9]+")]
        [StringLength(40, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }


        public int[] Tasks { get; set; }
    }
}
