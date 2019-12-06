﻿namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarWithPartsDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long Travelled { get; set; }

        [XmlArray("parts")]
        public ExportPartDTO[] Parts { get; set; }
 
 
    }
}
