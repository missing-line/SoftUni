namespace VaporStore.DataProcessor.Import
{
    using System.ComponentModel.DataAnnotations;
    using VaporStore.Data.Enums;

    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]{3}$")]
        public string CVC { get; set; }

        [Required]
        public CardType Type { get; set; }
    }
}
