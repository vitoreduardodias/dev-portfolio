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

        //[DisplayName("Products")]
        //[Required(ErrorMessage = "Please select a Product")]
        //public List<Product> Products { get; set; } = new List<Product>(); // Foreign key

        [DisplayName("Product")]
        public int ProductEntryId { get; set; }
        public Product? EntryProduct { get; set; }

        [Required(ErrorMessage = "Please provide a Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "The value should be greater than zero.")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please provide a Price in $")]
        [Range(1, int.MaxValue, ErrorMessage = "The value should be greater than zero.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [DisplayName("Price (Unity)")]
        public double Price { get; set; }

        [DisplayName("Entry Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }

        //[DisplayName("Suppliers")]
        //public List<Supplier> Suppliers { get; set; } = new List<Supplier>(); // Foreign key

        [DisplayName("Supplier")]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
