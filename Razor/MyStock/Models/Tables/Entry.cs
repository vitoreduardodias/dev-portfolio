using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyStock.Models.Tables
{
    public class Entry
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please select a Product")]
        public List<Product> Products { get; set;} = new();

        [Required(ErrorMessage = "Please provide a Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "The value should be greater than zero.")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please provide a Price in $")]
        [Range(1, int.MaxValue, ErrorMessage = "The value should be greater than zero.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [DisplayName("Price (Unity)")]
        public decimal Price { get; set; }

        [DisplayName("Entry Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }

        public List<Supplier> Suppliers { get; set; } = new();

    }
}
