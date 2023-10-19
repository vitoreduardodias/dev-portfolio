using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyStock.Models.Tables
{
    public class Category
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage ="Please provide a Title")]
        public string Title { get; set; } = string.Empty;

        [DisplayName("Description")]
        [Required(ErrorMessage = "Please provide a Description")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Description")]
        [Required(ErrorMessage = "Please provide a Product")]
        public List<Product> Product { get; set; } = new();

    }
}
