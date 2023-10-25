using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyStock.Models.Tables
{
    public class Output
    {

        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Product")]
        public int ProductOutId { get; set; }
        public Product? ProductOut { get; set; }

        [Required(ErrorMessage = "Please provide a Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "The value should be greater than zero.")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Out Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime OutDate { get; set; }

        [Required(ErrorMessage = "Please provide a Recipient")]
        [DisplayName("Recipient")]
        public string Recipient { get; set; } = string.Empty;
    }
}
