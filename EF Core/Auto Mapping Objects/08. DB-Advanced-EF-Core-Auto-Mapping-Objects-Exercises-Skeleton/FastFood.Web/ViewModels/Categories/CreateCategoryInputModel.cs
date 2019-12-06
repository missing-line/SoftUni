namespace FastFood.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;
    public class CreateCategoryInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string CategoryName { get; set; }
    }
}
