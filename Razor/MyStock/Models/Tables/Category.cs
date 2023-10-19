using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyStock.Models.Tables
{
    public class Category
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Please provide a Title")]
        public string Title { get; set; } = string.Empty;

        [DisplayName("Description")]
        [Required(ErrorMessage = "Please provide a Description")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Product")]
        [Required(ErrorMessage = "Please provide a Product")]
        public List<Product> Products { get; set; } = new();
    }
}
