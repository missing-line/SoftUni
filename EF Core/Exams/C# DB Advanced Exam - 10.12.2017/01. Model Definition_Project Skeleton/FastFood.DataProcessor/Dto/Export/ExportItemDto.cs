namespace FastFood.DataProcessor.Dto.Export
{
    public class ExportItemDto
    {
        public string Customer { get; set; }

        public ExportSingleItemDto[] Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
