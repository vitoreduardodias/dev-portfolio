using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyStock.Models.Tables
{
    public class Supplier
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [MinLength(3, ErrorMessage = "The name should contain at least 3 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a address")]
        [MinLength(3, ErrorMessage = "The address should contain at least 3 characters")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a contact")]
        [MinLength(3, ErrorMessage = "The contact should contain at least 3 characters")]
        public string Contact { get; set; } = string.Empty;

        public List<Entry> Entries { get; set; } = new();
    }
}
