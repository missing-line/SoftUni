namespace BookShop.DataProcessor.ExportDto
{
    using System.Collections.Generic;
    public class ExportAuthorDto
    {
        public string AuthorName { get; set; }
        public ICollection<ExportABookDto> Books { get; set; }
    }
}
