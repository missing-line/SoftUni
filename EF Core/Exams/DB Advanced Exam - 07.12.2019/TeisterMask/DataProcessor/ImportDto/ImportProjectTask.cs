using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ImportProjectTask
    {

        [Required]
        [StringLength(40, MinimumLength = 3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }


        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TaksDto[] Tasks { get; set; }
    }
}
