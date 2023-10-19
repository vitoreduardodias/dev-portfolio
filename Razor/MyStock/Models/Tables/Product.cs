﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyStock.Models.Tables
{
    public class Product
    {
        [Key]
        [DisplayName("Id")]
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

        [Range(1, int.MaxValue, ErrorMessage = "The value should be greater than zero.")]
        [Required(ErrorMessage = "Please provide a Quantity")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [DisplayName("Entries")]
        public List<Entry> Entries { get; set; } = new List<Entry>();

        [DisplayName("Outputs")]
        public List<Output> Outputs { get; set; } = new List<Output>();
    }
}
