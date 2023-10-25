using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyStock.Models.Tables
{
    public class Entry
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required(ErrorMessage = "Please provide a Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "The value should be greater than zero.")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Entry Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }

        [DisplayName("Supplier")]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
