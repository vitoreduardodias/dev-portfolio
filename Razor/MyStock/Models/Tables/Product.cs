using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyStock.Models.Tables
{
    public class Product
    {
        [Key]
        [DisplayName ("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a Title")]
        [DisplayName("Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a Description")]
        [DisplayName("Description")]
        public string Description { get; set; } = string.Empty;

        [Range(1.0, double.MaxValue, ErrorMessage = "The value should be greater than zero.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Please provide a Price")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Range(1.0, double.MaxValue, ErrorMessage = "The value should be greater than zero.")]
        [Required(ErrorMessage = "Please provide a Quantity")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Category")]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }

        [DisplayName("Entry")]
        public List<Entry> Entries { get; set; } = new();

    }
}
