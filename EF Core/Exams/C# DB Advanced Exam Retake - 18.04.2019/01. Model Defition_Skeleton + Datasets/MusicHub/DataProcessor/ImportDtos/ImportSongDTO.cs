namespace MusicHub.DataProcessor.ImportDtos
{
    using MusicHub.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportSongDTO
    {

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }


        [Required]
        public string Duration { get; set; }


        [Required]
        public string CreatedOn { get; set; }


        [Required]
        public string Genre { get; set; }

        public int? AlbumId { get; set; }

        [Required]
        public int WriterId { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
