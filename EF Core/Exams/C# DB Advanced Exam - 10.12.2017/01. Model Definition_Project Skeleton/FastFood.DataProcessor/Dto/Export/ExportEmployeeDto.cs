using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataProcessor.Dto.Export
{
    public class ExportEmployeeDto
    {
        public string Name { get; set; }
        public ExportItemDto[] Orders { get; set; }
        public decimal TotalMade { get; set; }
    }
}
