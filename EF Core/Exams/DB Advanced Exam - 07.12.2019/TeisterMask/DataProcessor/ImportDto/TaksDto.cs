namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Task")]
    public class TaksDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }


        [Required]
        public string DueDate { get; set; }


        [Required]
      
        public int ExecutionType { get; set; }

        [Required]
      
        public int LabelType { get; set; }
    }
}
